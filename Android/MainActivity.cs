using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Silk.NET.Windowing.Sdl.Android;
using System;
using System.IO;
using System.Linq;
using RecompOne.Runtime.Config;
using RecompOne.Runtime.Hardware;
using RecompOne.Runtime.Host;
using RecompOne.Runtime.Memory;
using RecompOne.Runtime.Modding;
using Recompiled; // QualityOfLife, MovementCheat - the desktop patch flags
using Sotn;

namespace RecompOne.SoTN.Android
{
    [Activity(Label = "SymphonyRecomp", Icon = "@mipmap/icon", MainLauncher = true, 
              Theme = "@android:style/Theme.NoTitleBar.Fullscreen", 
              ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.SmallestScreenSize | ConfigChanges.ScreenLayout | ConfigChanges.KeyboardHidden,
              ScreenOrientation = ScreenOrientation.Sensor)]
    public class MainActivity : SilkActivity
    {
        public enum ScreenOrientationMode
        {
            AutoRotate = 0,
            LockLandscape = 1,
            LockPortrait = 2
        }

        public static ScreenOrientationMode CurrentOrientationMode = ScreenOrientationMode.AutoRotate;

        // Backed by AndroidSettings so they survive a restart; the setters persist.
        private float _touchOpacity
        {
            get => AndroidSettings.TouchOpacity;
            set => AndroidSettings.TouchOpacity = value;
        }

        private bool _touchVisible
        {
            get => AndroidSettings.TouchVisible;
            set => AndroidSettings.TouchVisible = value;
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            Console.WriteLine("[Android] MainActivity OnCreate started.");
            
            var filesPath = FilesDir?.Path ?? "";
            Directory.SetCurrentDirectory(filesPath);
            Console.WriteLine($"[Android] Set current directory to: {filesPath}");

            // The long edge over the short edge, so "Fit device" renders at this screen's real
            // shape. Taken once and kept: deriving it per-orientation would change how much of
            // the level is drawn every time the player rotates.
            try
            {
                var dm = Resources?.DisplayMetrics;
                if (dm != null && dm.WidthPixels > 0 && dm.HeightPixels > 0)
                {
                    float lo = Math.Min(dm.WidthPixels, dm.HeightPixels);
                    float hi = Math.Max(dm.WidthPixels, dm.HeightPixels);
                    AndroidSettings.DeviceAspect = hi / lo;
                    Console.WriteLine($"[Android] Device aspect: {AndroidSettings.DeviceAspect:0.###}");
                }
            }
            catch { }

            CopyAssets("assets");
            CopyAssets("config");
            CopyAssets("Android");
            CopyAssets("mods"); // bundled mods, unpacked next to any the player adds

            // Entry.Run calls ModLoader.LoadAll() with no argument, so point the loader at the
            // folder chosen in the menu before the game starts.
            try { ModLoader.RootOverride = ModsDir; } catch { }

            // The disc is no longer packaged in the APK, so there may be nothing to boot yet.
            // OnRun gates on it; all that is needed here is the config it gets recorded in.
            try { ConfigManager.Load(); } catch { }
        }

        protected override void OnPostCreate(Bundle? savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            // Restore the saved orientation lock now that the activity exists.
            CurrentOrientationMode = AndroidSettings.Orientation;
            RequestedOrientation = CurrentOrientationMode switch
            {
                ScreenOrientationMode.LockLandscape => ScreenOrientation.SensorLandscape,
                ScreenOrientationMode.LockPortrait => ScreenOrientation.SensorPortrait,
                _ => ScreenOrientation.Sensor
            };

            SetupTouchControls();
            ShowSplashScreen();
        }

        protected override void OnRun()
        {
            Console.WriteLine("[Android] MainActivity OnRun executing game Entry.");
            try
            {
                // The disc is not in the APK any more, so it may not exist yet. Entry.Run calls
                // Runtime.WaitForValidDisc(), which spins on the desktop ImGui picker that Android
                // has no way to drive - so this has to be fully settled before we get there, or
                // the game thread hangs with nothing on screen explaining why.
                if (!EnsureDiscReady())
                {
                    Console.Error.WriteLine("[Android] No usable disc; not starting the game.");
                    return;
                }

                // Program.cs does this on desktop via QualityOfLifeMenu.Register(), which wires
                // QualityOfLife.Load() to RuntimeReadyEvent. Program.cs is excluded from the
                // Android build, so without this the saved toggles were never read back and
                // every launch started with all of them off.
                try { QualityOfLife.Load(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] QoL settings failed to load: {ex.Message}"); }

                // Program.cs does this on desktop. The widescreen hooks are already compiled into
                // generated/ and are being called, but without this listener nothing ever sets
                // Display.WideAspect, so the game renders 4:3 however wide the menu asks for.
                try { WidescreenPatch.Register(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] Widescreen registration failed: {ex.Message}"); }

                // Also from Program.cs, and part of the same widescreen story: widening the
                // Prologue exposes empty space to the left of the throne, and this listener
                // draws the artwork that fills it. Without it that strip is just black.
                try { ThroneLeftFill.Register(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] Throne fill registration failed: {ex.Message}"); }

                // Aspect ratio and pad layout are plain statics in the runtime, so restore the
                // saved choices before the game starts. Orientation is applied in OnPostCreate,
                // once the activity can accept a request.
                try { AndroidSettings.ApplyAtStartup(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] settings failed to apply: {ex.Message}"); }

                var cdPath = ConfigManager.Game.CdPath;
                Console.WriteLine($"[Android] Launching Entry.Run with CdPath = '{cdPath}'");

                // Run the game!
                // 8 MB of work RAM, matching Program.cs on desktop. Retail hardware had 2 MB,
                // and the widescreen hooks run out of it while building the extra tile columns
                // a wider view needs, so rooms come up with chunks of background missing. The
                // RAM is a plain byte[], so this costs the app about 16 MB once the freeze map
                // beside it is counted.
                const uint RamSize = 0x00800000;
                var m = new PSMemory(RamSize);
                Recompiled.Entry.Run(m, cdPath, "SymphonyRecomp");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] Game execution crashed: {ex.ToString()}");
            }
        }

        // --- RETROID POCKET, BLUETOOTH & WIRED CONTROLLER INPUT HANDLING ---

        // Physical controllers are handled by the runtime's InputManager, which polls SDL
        // every frame. We deliberately do NOT mirror them here from Android KeyEvents:
        // the SDL view and this activity each only see the events the other did not
        // consume, so a DOWN could arrive without its matching UP and latch a button on
        // forever. Polling is self-correcting; event mirroring is not.
        public override bool OnKeyDown(Keycode keyCode, KeyEvent? e)
        {
            if (keyCode == Keycode.Back || keyCode == Keycode.Menu)
            {
                ShowMenuDialog();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        // --- TOUCH OVERLAY CREATION (PSX LAYOUT) ---

        protected override void OnPause()
        {
            base.OnPause();
            Console.WriteLine("[Android] MainActivity OnPause - pausing audio and resetting controls.");
            Audio.Pause();
            // Release every on-screen button. The physical pad is polled from SDL, so it
            // reports its own real state again on resume and needs no reset here.
            Controller.SetExternalState(0xFFFF);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Console.WriteLine("[Android] MainActivity OnResume - resuming audio.");
            Audio.Resume();
        }

        private TouchOverlayView? _touchView;

        private void SetupTouchControls()
        {
            RunOnUiThread(() =>
            {
                try
                {
                    var decorView = Window?.DecorView as ViewGroup;
                    if (decorView == null) return;

                    if (_touchView != null && _touchView.Parent is ViewGroup p)
                    {
                        p.RemoveView(_touchView);
                    }

                    _touchView = new TouchOverlayView(this)
                    {
                        TouchOpacity = _touchOpacity,
                        TouchVisible = _touchVisible,
                        ControlMode = (TouchControlMode)ConfigManager.View.TouchControlMode,
                        OnMenuClicked = ShowMenuDialog,
                        // Keep the settings dialog's label in step with the on-screen toggle.
                        OnVisibilityToggled = visible => _touchVisible = visible
                    };

                    var paramsMatch = new ViewGroup.LayoutParams(
                        ViewGroup.LayoutParams.MatchParent,
                        ViewGroup.LayoutParams.MatchParent);

                    decorView.AddView(_touchView, paramsMatch);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[Android] Touch controls creation failed: {ex.Message}");
                }
            });
        }

        private ImageView? _splashImageView;

        private void ShowSplashScreen()
        {
            RunOnUiThread(() =>
            {
                try
                {
                    string baseDir = FilesDir?.Path ?? "/sdcard/Android/data/com.blacklabelhq.sotn/files";
                    bool isLandscape = Resources?.Configuration?.Orientation == global::Android.Content.Res.Orientation.Landscape;
                    string splashFile = isLandscape
                        ? global::System.IO.Path.Combine(baseDir, "Android", "splash screen horizontal.png")
                        : global::System.IO.Path.Combine(baseDir, "Android", "splash screen vertical.png");

                    if (!global::System.IO.File.Exists(splashFile))
                    {
                        splashFile = isLandscape
                            ? global::System.IO.Path.Combine(baseDir, "splash screen horizontal.png")
                            : global::System.IO.Path.Combine(baseDir, "splash screen vertical.png");
                    }

                    if (global::System.IO.File.Exists(splashFile))
                    {
                        var bitmap = global::Android.Graphics.BitmapFactory.DecodeFile(splashFile);
                        if (bitmap != null)
                        {
                            _splashImageView = new ImageView(this);
                            _splashImageView.SetImageBitmap(bitmap);
                            _splashImageView.SetScaleType(ImageView.ScaleType.FitCenter);
                            _splashImageView.SetBackgroundColor(global::Android.Graphics.Color.Black);

                            var paramsMatch = new ViewGroup.LayoutParams(
                                ViewGroup.LayoutParams.MatchParent,
                                ViewGroup.LayoutParams.MatchParent);

                            var decorView = Window?.DecorView as ViewGroup;
                            decorView?.AddView(_splashImageView, paramsMatch);

                            // Auto dismiss after 2.5 seconds with smooth fade
                            _splashImageView.PostDelayed(() => DismissSplashScreen(), 2500);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[Android] Splash screen display error: {ex.Message}");
                }
            });
        }

        private void DismissSplashScreen()
        {
            RunOnUiThread(() =>
            {
                if (_splashImageView == null) return;
                _splashImageView.Animate()
                    ?.Alpha(0f)
                    ?.SetDuration(600)
                    ?.WithEndAction(new global::Java.Lang.Runnable(() =>
                    {
                        if (_splashImageView?.Parent is ViewGroup p)
                            p.RemoveView(_splashImageView);
                        _splashImageView = null;
                    }));
            });
        }

        public override void OnConfigurationChanged(global::Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            SetupTouchControls();
        }

        // --- MENU & CHEATS DIALOG ---

        private void ShowMenuDialog()
        {
            RunOnUiThread(() =>
            {
                try
                {
                    string baseDir = FilesDir?.Path ?? "";
                    int used = 0;
                    for (int i = 1; i <= 5; i++)
                        if (!SaveStateManager.GetSlotInfo(baseDir, i).Contains("(Empty)")) used++;

                    new MenuSheet(this, "Symphony Recomp")
                        .Section("Game")
                        .Item("Quality of life", QolSummary(), ShowQualityOfLifeMenu)
                        .Item("Cheats", "Heal, stats, gold", ShowCheatsMenu)
                        .Item("Stats and level", SafeStat(() => $"Lv {Player.Level}"), ShowStatsMenu)
                        .Item("Inventory", "Items, relics, spells", ShowInventoryMenu)
                        .Item("Movement", MovementSummary(), ShowMovementMenu)
                        .Section("Save")
                        .Item("Save state", used == 0 ? "5 slots" : $"{used} of 5 used", ShowSaveStateMenu)
                        .Item("Load state", used == 0 ? "No saves" : $"{used} available", ShowLoadStateMenu)
                        .Item("Memory cards", "Import or export saves", ShowMemoryCardMenu)
                        .Item("Mods", $"{ModLoader.Mods.Count} installed", ShowModsMenu)
                        .Section("System")
                        .Item("Display", AspectLabelShort(), ShowDisplayMenu)
                        .Item("Controllers", ControllerSummary(), ShowControllersMenu)
                        .Item("Controller layout", AndroidSettings.LayoutName(AndroidSettings.Pad), ShowPadLayoutMenu)
                        .Item("Touch controls", _touchVisible ? "Visible" : "Hidden", ShowTouchControlsMenu)
                        .Item("Game disc", DiscLabel(), ShowDiscMenu)
                        .Danger("Reset all settings", ConfirmResetSettings)
                        .Danger("Reset and reload disc", RestartApp)
                        .Back("Close", () => { })
                        .Show();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[Android] Menu dialog failed: {ex.Message}");
                }
            });
        }

        private string DiscLabel()
        {
            try
            {
                string p = ConfigManager.Game.CdPath ?? "";
                return p.Length > 0 ? System.IO.Path.GetFileNameWithoutExtension(p) : "Not set";
            }
            catch { return "Not set"; }
        }

        private void ShowDiscMenu()
        {
            string path = "";
            try { path = ConfigManager.Game.CdPath ?? ""; } catch { }

            new MenuSheet(this, "Game disc",
                          path.Length > 0 ? System.IO.Path.GetFileName(path) : "No disc loaded")
                .Section("Disc")
                .Item("Replace disc", "Restarts the app", ConfirmReplaceDisc)
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        private void ConfirmReplaceDisc()
        {
            MenuSheet.Confirm(this, "Replace disc",
                "The imported disc will be deleted and the app will restart so you can choose new "
                + "files. Your saves and save states are kept.",
                "Replace", () =>
                {
                    // Only ever delete the copies this app made. Files the player placed on shared
                    // storage themselves are theirs, not ours to remove.
                    foreach (var dir in new[]
                             {
                                 DiscImporter.TargetDir(this),
                                 System.IO.Path.Combine(FilesDir?.Path ?? "", "disc"),
                             })
                    {
                        try { if (Directory.Exists(dir)) Directory.Delete(dir, true); }
                        catch (Exception ex) { Console.Error.WriteLine($"[Android] Could not remove {dir}: {ex.Message}"); }
                    }

                    try
                    {
                        ConfigManager.Game.CdPath = "";
                        ConfigManager.SaveGame();
                    }
                    catch (Exception ex) { Console.Error.WriteLine($"[Android] Could not clear the disc path: {ex.Message}"); }

                    RestartApp();
                });
        }

        private void RestartApp()
        {
            try
            {
                var intent = BaseContext?.PackageManager?.GetLaunchIntentForPackage(BaseContext.PackageName);
                if (intent != null)
                {
                    intent.AddFlags(global::Android.Content.ActivityFlags.ClearTop | global::Android.Content.ActivityFlags.NewTask);
                    StartActivity(intent);
                    Finish();
                    global::Java.Lang.JavaSystem.Exit(0);
                }
                else
                {
                    Recreate();
                }
            }
            catch
            {
                Recreate();
            }
        }

        private void ShowSaveStateMenu()
        {
            try
            {
                string baseDir = FilesDir?.Path ?? "/sdcard/Android/data/com.blacklabelhq.sotn/files";
                var sheet = new MenuSheet(this, "Save state", "Overwrites the chosen slot");
                for (int i = 1; i <= 5; i++)
                {
                    int slot = i;
                    sheet.Item($"Slot {slot}", SlotStamp(baseDir, slot), () =>
                        SaveStateManager.RequestSaveState(baseDir, slot, (success, err, sl) =>
                            RunOnUiThread(() => Toast.MakeText(this,
                                success ? $"Saved to slot {sl}" : $"Save failed: {err}",
                                success ? ToastLength.Short : ToastLength.Long)?.Show())));
                }
                sheet.Back("Back", ShowMenuDialog).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Save State error: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void ShowLoadStateMenu()
        {
            try
            {
                string baseDir = FilesDir?.Path ?? "/sdcard/Android/data/com.blacklabelhq.sotn/files";
                var sheet = new MenuSheet(this, "Load state");
                for (int i = 1; i <= 5; i++)
                {
                    int slot = i;
                    sheet.Item($"Slot {slot}", SlotStamp(baseDir, slot), () =>
                        SaveStateManager.RequestLoadState(baseDir, slot, (success, err, sl) =>
                            RunOnUiThread(() => Toast.MakeText(this,
                                success ? $"Loaded slot {sl}" : $"Load failed: {err}",
                                success ? ToastLength.Short : ToastLength.Long)?.Show())));
                }
                sheet.Back("Back", ShowMenuDialog).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Load State error: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void ShowModsMenu()
        {
            try
            {
                string modsDir = ModsDir;
                if (!Directory.Exists(modsDir)) Directory.CreateDirectory(modsDir);

                var mods = ModLoader.Mods;
                if (mods.Count == 0)
                {
                    try { ModLoader.LoadAll(modsDir); mods = ModLoader.Mods; } catch { }
                }

                if (mods.Count == 0)
                {
                    new MenuSheet(this, "Mods", $"Looking in {FriendlyModsDir(modsDir)}")
                        .Section("Nothing installed")
                        .Item("Mods folder", FriendlyModsDir(modsDir), ShowModsFolderMenu)
                        .Item("Scan mods folder", "Refresh", () =>
                        {
                            try { ModLoader.LoadAll(modsDir); } catch { }
                            ShowModsMenu();
                        })
                        .Back("Back", ShowMenuDialog)
                        .Show();
                    return;
                }

                var sheet = new MenuSheet(this, "Mods", $"{mods.Count} installed");
                foreach (var mod in mods)
                {
                    var m = mod;
                    string name = string.IsNullOrWhiteSpace(m.Info.Name) ? m.Info.Id : m.Info.Name;
                    sheet.Toggle($"{name}  v{m.Info.Version}", m.Enabled, on =>
                    {
                        ModLoader.SetEnabled(m.Info.Id, on);
                        Toast.MakeText(this, $"{name} {(on ? "enabled" : "disabled")}", ToastLength.Short)?.Show();
                    });
                }
                sheet.Section("Library")
                     .Item("Mods folder", FriendlyModsDir(modsDir), ShowModsFolderMenu)
                     .Item("Scan mods folder", "Refresh", () =>
                     {
                         try { ModLoader.LoadAll(modsDir); } catch { }
                         Toast.MakeText(this, "Mods folder rescanned", ToastLength.Short)?.Show();
                         ShowModsMenu();
                     })
                     .Back("Back", ShowMenuDialog)
                     .Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Mods Manager error: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void ShowCheatsMenu()
        {
            void Apply(string done, Action act)
            {
                try { act(); Toast.MakeText(this, done, ToastLength.Short)?.Show(); }
                catch (Exception ex) { Toast.MakeText(this, $"Not available right now: {ex.Message}", ToastLength.Long)?.Show(); }
                ShowCheatsMenu(); // reopen so several can be applied in a row
            }

            new MenuSheet(this, "Cheats", "Applies to the current game")
                .Section("Restore")
                .Item("Full heal", "HP, MP, hearts", () => Apply("Healed", Player.FullHeal))
                .Section("Grant")
                .Item("Max out stats", "9999 HP / MP", () => Apply("Stats maxed", () =>
                {
                    Player.HpMax = Player.Hp = 9999;
                    Player.MpMax = Player.Mp = 9999;
                    Player.HeartsMax = Player.Hearts = 999;
                    Player.Strength = 999;
                    Player.Constitution = 999;
                    Player.Intelligence = 999;
                    Player.Luck = 999;
                }))
                .Item("Level 99", $"Now {SafeLevel()}", () => Apply("Level 99", () => Player.Level = 99))
                .Item("999,999 gold", $"Now {SafeGold()}", () => Apply("Gold added", () => Player.Gold = 999999))
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        private void ShowDisplayMenu()
        {
            string aspectStr = HostWindow.CurrentAspectRatio switch
            {
                HostWindow.AspectRatioMode.AutoDevice => $"Fit device ({AndroidSettings.DeviceAspect:0.##}:1)",
                HostWindow.AspectRatioMode.Widescreen_16_9 => "16:9 widescreen",
                HostWindow.AspectRatioMode.Stretch => "Stretch to fill",
                _ => "4:3 original"
            };

            string orientStr = CurrentOrientationMode switch
            {
                ScreenOrientationMode.LockLandscape => "↔️ Lock Landscape",
                ScreenOrientationMode.LockPortrait => "↕️ Lock Portrait",
                _ => "🔄 Auto-Rotate (Sensor)"
            };

            new MenuSheet(this, "Display")
                .Section("Screen")
                .Item("Orientation", orientStr, ShowOrientationSubmenu)
                .Item("Aspect ratio", aspectStr, ShowAspectRatioSubmenu)
                .Section("Rendering")
                .Item("Render scale", RenderScaleLabel(ConfigManager.View.RenderScale), ShowRenderScaleSubmenu)
                .Toggle("VSync", ConfigManager.View.VSync, on =>
                {
                    ConfigManager.View.VSync = on;
                    HostWindow.SetVSync(on);
                    ConfigManager.SaveView(null);
                })
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        static string RenderScaleLabel(int scale) => scale <= 1 ? "Native (1x)" : $"{scale}x";

        /// <summary>
        /// Picks the internal resolution the game is drawn at, the same setting the desktop
        /// build exposes as a slider. It used to be a single "high resolution" toggle here,
        /// which could only say 1x or 4x; on a phone 2x is often the better trade between a
        /// clean picture and battery. The desktop asks for a restart after a change - Android
        /// does not need to, because RequestGpuReset rebuilds the backend on the next frame.
        /// </summary>
        private void ShowRenderScaleSubmenu()
        {
            void Pick(int scale)
            {
                ConfigManager.View.RenderScale = scale;
                ConfigManager.SaveView(null);
                HostWindow.RequestGpuReset();
                Toast.MakeText(this, $"Rendering at {RenderScaleLabel(scale)}", ToastLength.Short)?.Show();
                ShowDisplayMenu();
            }

            int cur = ConfigManager.View.RenderScale;
            var sheet = new MenuSheet(this, "Render scale", "Higher looks sharper and costs more battery");
            foreach (int scale in new[] { 1, 2, 3, 4 })
            {
                int s = scale;
                sheet.Item(RenderScaleLabel(s), cur == s ? "Selected" : null, () => Pick(s));
            }
            sheet.Back("Back", ShowDisplayMenu).Show();
        }

        private void ShowOrientationSubmenu()
        {
            void Pick(ScreenOrientationMode mode, ScreenOrientation req, string label)
            {
                CurrentOrientationMode = mode;
                AndroidSettings.Orientation = mode;
                RequestedOrientation = req;
                SetupTouchControls();
                Toast.MakeText(this, label, ToastLength.Short)?.Show();
                ShowDisplayMenu();
            }

            var cur = CurrentOrientationMode;
            new MenuSheet(this, "Orientation")
                .Item("Follow device", cur == ScreenOrientationMode.AutoRotate ? "Selected" : null,
                    () => Pick(ScreenOrientationMode.AutoRotate, ScreenOrientation.Sensor, "Following device rotation"))
                .Item("Lock landscape", cur == ScreenOrientationMode.LockLandscape ? "Selected" : null,
                    () => Pick(ScreenOrientationMode.LockLandscape, ScreenOrientation.SensorLandscape, "Locked to landscape"))
                .Item("Lock portrait", cur == ScreenOrientationMode.LockPortrait ? "Selected" : null,
                    () => Pick(ScreenOrientationMode.LockPortrait, ScreenOrientation.SensorPortrait, "Locked to portrait"))
                .Back("Back", ShowDisplayMenu)
                .Show();
        }

        private void ShowAspectRatioSubmenu()
        {
            void Pick(HostWindow.AspectRatioMode mode, string label)
            {
                AndroidSettings.Aspect = mode;
                // Re-renders the game at this ratio rather than scaling the old frame into it.
                AndroidSettings.ApplyAspect(mode);
                Toast.MakeText(this, label, ToastLength.Short)?.Show();
                ShowDisplayMenu();
            }

            var cur = HostWindow.CurrentAspectRatio;
            string? Mark(HostWindow.AspectRatioMode m) => cur == m ? "Selected" : null;

            new MenuSheet(this, "Aspect ratio")
                .Item("Fit device", Mark(HostWindow.AspectRatioMode.AutoDevice),
                    () => Pick(HostWindow.AspectRatioMode.AutoDevice, "Fitting the device"))
                .Item("4:3 original", Mark(HostWindow.AspectRatioMode.Original_4_3),
                    () => Pick(HostWindow.AspectRatioMode.Original_4_3, "4:3 original"))
                .Item("16:9 widescreen", Mark(HostWindow.AspectRatioMode.Widescreen_16_9),
                    () => Pick(HostWindow.AspectRatioMode.Widescreen_16_9, "16:9 widescreen"))
                .Item("Stretch to fill", Mark(HostWindow.AspectRatioMode.Stretch),
                    () => Pick(HostWindow.AspectRatioMode.Stretch, "Stretched to fill"))
                .Back("Back", ShowDisplayMenu)
                .Show();
        }

        private void ShowTouchControlsMenu()
        {
            int mode = ConfigManager.View.TouchControlMode;

            void SetOpacity(float v, string label)
            {
                _touchOpacity = v;
                if (_touchView != null) { _touchView.TouchOpacity = v; _touchView.Invalidate(); }
                Toast.MakeText(this, label, ToastLength.Short)?.Show();
                ShowTouchControlsMenu();
            }

            new MenuSheet(this, "Touch controls")
                .Section("Movement")
                .Item("Style", mode == 0 ? "D-pad" : "Analog stick", () =>
                {
                    int next = mode == 0 ? 1 : 0;
                    ConfigManager.View.TouchControlMode = next;
                    try { ConfigManager.SaveView(); } catch { }
                    if (_touchView != null)
                    {
                        _touchView.ControlMode = (TouchControlMode)next;
                        _touchView.Invalidate();
                    }
                    Toast.MakeText(this, next == 0 ? "D-pad" : "Analog stick", ToastLength.Short)?.Show();
                    ShowTouchControlsMenu();
                })
                .Section("Overlay")
                .Toggle("Show buttons", _touchVisible, on =>
                {
                    _touchVisible = on;
                    if (_touchView != null) { _touchView.TouchVisible = on; _touchView.Invalidate(); }
                })
                .Item("Opacity", $"{(int)(_touchOpacity * 100)}%", () =>
                    new MenuSheet(this, "Opacity")
                        .Item("Solid", _touchOpacity >= 0.99f ? "Selected" : null, () => SetOpacity(1.0f, "Opacity 100%"))
                        .Item("Medium", _touchOpacity is > 0.5f and < 0.99f ? "Selected" : null, () => SetOpacity(0.7f, "Opacity 70%"))
                        .Item("Faint", _touchOpacity <= 0.5f ? "Selected" : null, () => SetOpacity(0.4f, "Opacity 40%"))
                        .Back("Back", ShowTouchControlsMenu)
                        .Show())
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        // --- Controller layout -----------------------------------------------------------

        private static string ControllerSummary()
        {
            try
            {
                var pads = HostWindow.ConnectedPadCount;
                if (pads > 0) return pads == 1 ? "1 connected" : $"{pads} connected";
                return HostWindow.DescribeJoysticks().Count > 0 ? "Detected, unusable" : "None detected";
            }
            catch { return "Unavailable"; }
        }

        /// <summary>
        /// What the game can actually see of the attached pads.
        ///
        /// A controller that does nothing has more than one cause - the system never
        /// enumerated it, or SDL enumerated it but has no button mapping for it and so
        /// refuses to drive it - and from the player's side both look identical. This screen
        /// separates them, which matters because there is no usable log to read off a phone.
        /// </summary>
        private void ShowControllersMenu()
        {
            var sheet = new MenuSheet(this, "Controllers", "What the game can see right now");

            List<(int Index, string Name, bool IsGameController)> found;
            try { found = HostWindow.DescribeJoysticks().ToList(); }
            catch (Exception ex)
            {
                sheet.Section("Input system")
                     .Item("Unavailable", ex.Message, () => { })
                     .Back("Back", ShowMenuDialog)
                     .Show();
                return;
            }

            if (found.Count == 0)
            {
                sheet.Section("Attached")
                     .Item("Nothing detected", "Android is not reporting a pad", () =>
                        Toast.MakeText(this,
                            "Wired pads: reseat the USB-C plug and allow any permission prompt. Some pads have a mode switch - the Android or X-input position is the one to use.",
                            ToastLength.Long)?.Show());
            }
            else
            {
                sheet.Section("Attached");
                foreach (var (index, name, isPad) in found)
                {
                    string state = isPad ? "Usable" : "No button mapping";
                    string message = isPad
                        ? $"{name} is mapped and can drive the game."
                        : $"Android reports {name}, but SDL has no button mapping for it, so the game will not read it. Try the pad's other mode if it has a mode switch.";
                    sheet.Item(name, state, () => Toast.MakeText(this, message, ToastLength.Long)?.Show());
                }
            }

            sheet.Section("In use")
               .Item("Player 1", HostWindow.IsPadConnected(0) ? "Pad connected" : "Touch controls", () => { })
               .Item("Player 2", HostWindow.IsPadConnected(1) ? "Pad connected" : "None", () => { })
               .Section("If a pad is not listed")
               .Item("Scan again", "Re-checks without restarting", () =>
               {
                   try { HostWindow.RescanControllers(); } catch { }
                   Toast.MakeText(this, "Scanned again", ToastLength.Short)?.Show();
                   ShowControllersMenu();
               })
               .Back("Back", ShowMenuDialog)
               .Show();
        }

        private void ShowPadLayoutMenu()
        {
            var cur = AndroidSettings.Pad;

            void Pick(PadLayout layout)
            {
                AndroidSettings.Pad = layout;
                Toast.MakeText(this, $"{AndroidSettings.LayoutName(layout)} layout", ToastLength.Short)?.Show();
                ShowPadLayoutMenu();
            }

            new MenuSheet(this, "Controller layout", "Which physical button acts as which PlayStation button")
                .Item("PlayStation", cur == PadLayout.PlayStation ? "In use" : "Bottom is Cross",
                    () => Pick(PadLayout.PlayStation))
                .Item("Xbox", cur == PadLayout.Xbox ? "In use" : "A is Cross",
                    () => Pick(PadLayout.Xbox))
                .Item("Nintendo", cur == PadLayout.Nintendo ? "In use" : "B is Cross",
                    () => Pick(PadLayout.Nintendo))
                .Section("If the buttons feel wrong")
                .Item("Try another layout", "Pads report their buttons differently", () =>
                    Toast.MakeText(this,
                        "Pick the layout whose bottom-row button jumps. Nintendo-arranged pads swap A/B and X/Y.",
                        ToastLength.Long)?.Show())
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        // --- Reset -----------------------------------------------------------------------

        private void ConfirmResetSettings()
        {
            MenuSheet.Confirm(this, "Reset all settings",
                "Display, controls, controller layout, quality of life and the mods folder go back to their defaults. Save states, memory cards and your disc are untouched.",
                "Reset everything", () =>
                {
                    try
                    {
                        AndroidSettings.ResetAll();

                        CurrentOrientationMode = ScreenOrientationMode.AutoRotate;
                        RequestedOrientation = ScreenOrientation.Sensor;
                        if (_touchView != null)
                        {
                            _touchView.TouchVisible = AndroidSettings.DefaultTouchVisible;
                            _touchView.TouchOpacity = AndroidSettings.DefaultTouchOpacity;
                            _touchView.ControlMode = TouchControlMode.DPad;
                            _touchView.Invalidate();
                        }
                        SetupTouchControls();
                        Toast.MakeText(this, "Settings reset", ToastLength.Short)?.Show();
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, $"Could not reset: {ex.Message}", ToastLength.Long)?.Show();
                    }
                });
        }

        // --- Mods folder -----------------------------------------------------------------

        private const string ModsPathKey = "AndroidModsPath";

        /// <summary>
        /// Where mods are loaded from. Defaults to the copy unpacked from the APK, but can be
        /// pointed anywhere the app can read so mods can be added without rebuilding.
        /// </summary>
        private string ModsDir
        {
            get
            {
                try
                {
                    string chosen = ConfigManager.View.GetString(ModsPathKey);
                    if (!string.IsNullOrWhiteSpace(chosen) && Directory.Exists(chosen)) return chosen;
                }
                catch { }
                return System.IO.Path.Combine(FilesDir?.Path ?? "", "mods");
            }
        }

        private string FriendlyModsDir(string dir)
        {
            if (dir.StartsWith(FilesDir?.Path ?? " ", StringComparison.OrdinalIgnoreCase)) return "App storage";
            string ext = GetExternalFilesDir(null)?.AbsolutePath ?? " ";
            if (dir.StartsWith(ext, StringComparison.OrdinalIgnoreCase)) return "Shared app folder";
            return System.IO.Path.GetFileName(dir.TrimEnd('/')) is { Length: > 0 } n ? n : dir;
        }

        private void ShowModsFolderMenu()
        {
            var candidates = new List<(string Label, string Hint, string Path)>();
            string internalMods = System.IO.Path.Combine(FilesDir?.Path ?? "", "mods");
            candidates.Add(("App storage", "Bundled mods, unpacked from the app", internalMods));

            string? ext = GetExternalFilesDir(null)?.AbsolutePath;
            if (!string.IsNullOrEmpty(ext))
                candidates.Add(("Shared app folder", "Reachable over USB, no permission needed",
                    System.IO.Path.Combine(ext, "mods")));

            candidates.Add(("SymphonyRecomp on storage", "/sdcard/SymphonyRecomp/mods",
                "/sdcard/SymphonyRecomp/mods"));

            string current = ModsDir;
            var sheet = new MenuSheet(this, "Mods folder", "Takes effect after a restart");
            foreach (var entry in candidates)
            {
                var c = entry;
                bool selected = string.Equals(c.Path.TrimEnd('/'), current.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);
                bool exists = Directory.Exists(c.Path);
                sheet.Item(c.Label, selected ? "In use" : exists ? "Available" : "Will be created", () =>
                {
                    try
                    {
                        Directory.CreateDirectory(c.Path);
                        ConfigManager.View.SetString(ModsPathKey, c.Path);
                        ConfigManager.SaveView(null);
                        Toast.MakeText(this, $"Mods folder set to {c.Label}. Restart to load from it.", ToastLength.Long)?.Show();
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, $"Could not use that folder: {ex.Message}", ToastLength.Long)?.Show();
                    }
                    ShowModsFolderMenu();
                });
            }

            sheet.Section("Current path")
                 .Item(current, null, () =>
                     Toast.MakeText(this, current, ToastLength.Long)?.Show())
                 .Back("Back", ShowModsMenu)
                 .Show();
        }

        // --- Quality of life -------------------------------------------------------------

        private static string QolSummary()
        {
            int on = 0;
            if (QualityOfLife.ColorBlind) on++;
            if (QualityOfLife.RemoveFlashing) on++;
            if (QualityOfLife.BugFixes) on++;
            if (QualityOfLife.ClearFile) on++;
            if (QualityOfLife.AntiFreeze) on++;
            if (QualityOfLife.InfiniteWingSmash) on++;
            if (QualityOfLife.UseEasySpellInput) on++;
            if (QualityOfLife.IncreaseInvincibilityFrames) on++;
            if (QualityOfLife.RestoreFairySong) on++;
            return on == 0 ? "All off" : $"{on} on";
        }

        private void ShowQualityOfLifeMenu()
        {
            void Save() { try { QualityOfLife.Save(); } catch { } }

            new MenuSheet(this, "Quality of life", "Saved between sessions")
                .Section("Accessibility")
                .Toggle("Colour blind fixes", QualityOfLife.ColorBlind, v => { QualityOfLife.ColorBlind = v; Save(); })
                .Toggle("Remove screen flashes", QualityOfLife.RemoveFlashing, v => { QualityOfLife.RemoveFlashing = v; Save(); })
                .Toggle("No screen freeze", QualityOfLife.AntiFreeze, v => { QualityOfLife.AntiFreeze = v; Save(); })
                .Section("Play")
                .Toggle("Bug fixes", QualityOfLife.BugFixes, v => { QualityOfLife.BugFixes = v; Save(); })
                .Toggle("Easy spell inputs", QualityOfLife.UseEasySpellInput, v => { QualityOfLife.UseEasySpellInput = v; Save(); })
                .Toggle("Infinite wing smash", QualityOfLife.InfiniteWingSmash, v => { QualityOfLife.InfiniteWingSmash = v; Save(); })
                .Toggle("More invincibility frames", QualityOfLife.IncreaseInvincibilityFrames, v => { QualityOfLife.IncreaseInvincibilityFrames = v; Save(); })
                .Toggle("Clear file", QualityOfLife.ClearFile, v => { QualityOfLife.ClearFile = v; Save(); })
                .Section("Enhancements")
                .Toggle("Restore Sprite's Nocturne song", QualityOfLife.RestoreFairySong, v => { QualityOfLife.RestoreFairySong = v; Save(); })
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        // --- Stats and level -------------------------------------------------------------

        private static string SafeStat(Func<string> get)
        {
            try { return get(); } catch { return "-"; }
        }

        private void ShowStatsMenu()
        {
            void Edit(string title, int cur, int min, int max, Action<int> set) =>
                MenuSheet.PromptNumber(this, title, cur, min, max, v =>
                {
                    try { set(v); } catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long)?.Show(); }
                    ShowStatsMenu();
                });

            try
            {
                new MenuSheet(this, "Stats", SafeStat(() => $"{Player.Character}  ·  Level {Player.Level}"))
                    .Section("Vitals")
                    .Item("HP", SafeStat(() => $"{Player.Hp} / {Player.HpMax}"),
                        () => Edit("HP", Player.Hp, 0, 9999, v => Player.Hp = v))
                    .Item("HP max", SafeStat(() => Player.HpMax.ToString()),
                        () => Edit("HP max", Player.HpMax, 1, 9999, v => Player.HpMax = v))
                    .Item("MP", SafeStat(() => $"{Player.Mp} / {Player.MpMax}"),
                        () => Edit("MP", Player.Mp, 0, 9999, v => Player.Mp = v))
                    .Item("MP max", SafeStat(() => Player.MpMax.ToString()),
                        () => Edit("MP max", Player.MpMax, 1, 9999, v => Player.MpMax = v))
                    .Item("Hearts", SafeStat(() => $"{Player.Hearts} / {Player.HeartsMax}"),
                        () => Edit("Hearts", Player.Hearts, 0, 999, v => Player.Hearts = v))
                    .Item("Hearts max", SafeStat(() => Player.HeartsMax.ToString()),
                        () => Edit("Hearts max", Player.HeartsMax, 1, 999, v => Player.HeartsMax = v))
                    .Item("Full heal", "HP, MP, hearts", () =>
                    {
                        try { Player.FullHeal(); Toast.MakeText(this, "Healed", ToastLength.Short)?.Show(); } catch { }
                        ShowStatsMenu();
                    })
                    .Section("Attributes")
                    .Item("Strength", SafeStat(() => Player.Strength.ToString()),
                        () => Edit("Strength", Player.Strength, 1, 999, v => Player.Strength = v))
                    .Item("Constitution", SafeStat(() => Player.Constitution.ToString()),
                        () => Edit("Constitution", Player.Constitution, 1, 999, v => Player.Constitution = v))
                    .Item("Intelligence", SafeStat(() => Player.Intelligence.ToString()),
                        () => Edit("Intelligence", Player.Intelligence, 1, 999, v => Player.Intelligence = v))
                    .Item("Luck", SafeStat(() => Player.Luck.ToString()),
                        () => Edit("Luck", Player.Luck, 1, 999, v => Player.Luck = v))
                    .Section("Progress")
                    .Item("Level", SafeStat(() => Player.Level.ToString()),
                        () => Edit("Level", Player.Level, 1, 99, v => Player.Level = v))
                    .Item("Experience", SafeStat(() => Player.Exp.ToString("N0")),
                        () => Edit("Experience", Player.Exp, 0, 9999999, v => Player.Exp = v))
                    .Item("Gold", SafeStat(() => Player.Gold.ToString("N0")),
                        () => Edit("Gold", Player.Gold, 0, 999999, v => Player.Gold = v))
                    .Back("Back", ShowMenuDialog)
                    .Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Stats need a game in progress: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        // --- Movement --------------------------------------------------------------------

        private static string MovementSummary()
        {
            var on = new List<string>();
            if (MovementCheat.InfiniteJump) on.Add("fly");
            if (MovementCheat.NoClip) on.Add("no clip");
            if (MovementCheat.Invincible) on.Add("invincible");
            return on.Count == 0 ? "Off" : string.Join(", ", on);
        }

        private void ShowMovementMenu()
        {
            new MenuSheet(this, "Movement")
                .Section("Toggles")
                .Toggle("Infinite jump", MovementCheat.InfiniteJump, v => MovementCheat.InfiniteJump = v)
                .Toggle("No clip", MovementCheat.NoClip, v => MovementCheat.NoClip = v)
                .Toggle("Invincible", MovementCheat.Invincible, v => MovementCheat.Invincible = v)
                .Section("Speed")
                .Toggle("Override speed", MovementCheat.SpeedOverride, v => MovementCheat.SpeedOverride = v)
                .Item("Speed multiplier", $"{MovementCheat.SpeedMul:0.0}x", () =>
                    MenuSheet.PromptNumber(this, "Speed multiplier (x10)", (int)(MovementCheat.SpeedMul * 10), 1, 100, v =>
                    {
                        MovementCheat.SpeedMul = v / 10f;
                        ShowMovementMenu();
                    }))
                .Section("Jump")
                .Toggle("Override jump", MovementCheat.JumpOverride, v => MovementCheat.JumpOverride = v)
                .Item("Jump strength", $"{MovementCheat.JumpStrength:0.0}", () =>
                    MenuSheet.PromptNumber(this, "Jump strength", (int)MovementCheat.JumpStrength, 1, 40, v =>
                    {
                        MovementCheat.JumpStrength = v;
                        ShowMovementMenu();
                    }))
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        // --- Inventory -------------------------------------------------------------------

        private void ShowInventoryMenu()
        {
            new MenuSheet(this, "Inventory")
                .Item("Hand items", "Weapons, shields, usables", () => ShowItemList("Hand items", true))
                .Item("Body items", "Armour, cloaks, accessories", () => ShowItemList("Body items", false))
                .Item("Relics", "Grant or clear", ShowRelicsMenu)
                .Item("Spells", "Grant or clear", ShowSpellsMenu)
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        private void ShowItemList(string title, bool hand)
        {
            var sheet = new MenuSheet(this, title, "Tap an entry to set how many you carry");
            var catalogue = hand
                ? Enum.GetValues<HandItem>().Select(v => (Display: Spaced(v.ToString()), Id: (int)v))
                : Enum.GetValues<BodyItem>().Select(v => (Display: Spaced(v.ToString()), Id: (int)v));
            catalogue = catalogue.Where(e => e.Id != 0).GroupBy(e => e.Id).Select(g => g.First()).ToList();

            sheet.Item("Clear all", null, () =>
            {
                try
                {
                    foreach (var it in catalogue) SetItemCount(hand, it.Id, 0);
                }
                catch { }
                ShowItemList(title, hand);
            });

            try
            {
                // Carried items first, so what you own is reachable without scrolling the
                // whole catalogue.
                foreach (var entry in catalogue
                             .Select(e => (e.Display, e.Id, Count: hand ? Inventory.GetHandCount(e.Id) : Inventory.GetBodyCount(e.Id)))
                             .OrderByDescending(e => e.Count > 0)
                             .ThenBy(e => e.Display))
                {
                    var it = entry;
                    sheet.Item(it.Display, it.Count > 0 ? it.Count.ToString() : null, () =>
                        MenuSheet.PromptNumber(this, it.Display, it.Count, 0, 255, v =>
                        {
                            try { SetItemCount(hand, it.Id, v); } catch { }
                            ShowItemList(title, hand);
                        }));
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Inventory needs a game in progress: {ex.Message}", ToastLength.Long)?.Show();
            }

            sheet.Back("Back", ShowInventoryMenu).Show();
        }

        /// <summary>
        /// Sets how many of an item you carry. SoTN keeps the menu's item list in a separate
        /// order array from the counts, so writing the count alone leaves the item invisible
        /// in game - Grant*Item inserts it into that list as well.
        /// </summary>
        private static void SetItemCount(bool hand, int id, int value)
        {
            int current = hand ? Inventory.GetHandCount(id) : Inventory.GetBodyCount(id);
            if (value > 0 && current == 0)
            {
                if (hand) Inventory.GrantHandItem(id, value); else Inventory.GrantBodyItem(id, value);
                return;
            }
            if (hand) Inventory.SetHandCount(id, value); else Inventory.SetBodyCount(id, value);
        }

        private void ShowRelicsMenu()
        {
            var sheet = new MenuSheet(this, "Relics");
            sheet.Item("Grant all", null, () =>
            {
                try { foreach (Relic r in Enum.GetValues<Relic>()) Inventory.GiveRelic(r, true); } catch { }
                ShowRelicsMenu();
            });
            sheet.Item("Clear all", null, () =>
            {
                try { foreach (Relic r in Enum.GetValues<Relic>()) Inventory.GiveRelic(r, false); } catch { }
                ShowRelicsMenu();
            });
            sheet.Section("Owned");
            try
            {
                foreach (Relic relic in Enum.GetValues<Relic>())
                {
                    var r = relic;
                    sheet.Toggle(Spaced(r.ToString()), Inventory.HasRelic(r), v =>
                    {
                        try { Inventory.GiveRelic(r, v); } catch { }
                    });
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Relics need a game in progress: {ex.Message}", ToastLength.Long)?.Show();
            }
            sheet.Back("Back", ShowInventoryMenu).Show();
        }

        private void ShowSpellsMenu()
        {
            var sheet = new MenuSheet(this, "Spells");
            try
            {
                foreach (Spell spell in Enum.GetValues<Spell>())
                {
                    var s = spell;
                    sheet.Toggle(Spaced(s.ToString()), Inventory.HasSpell(s), v =>
                    {
                        try { Inventory.SetSpellLearned(s, v); } catch { }
                    });
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Spells need a game in progress: {ex.Message}", ToastLength.Long)?.Show();
            }
            sheet.Back("Back", ShowInventoryMenu).Show();
        }

        /// <summary>Turns PascalCase enum names into readable labels.</summary>
        private static string Spaced(string s)
        {
            var sb = new System.Text.StringBuilder(s.Length + 8);
            for (int i = 0; i < s.Length; i++)
            {
                if (i > 0 && char.IsUpper(s[i]) && !char.IsUpper(s[i - 1])) sb.Append(' ');
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        private string SlotStamp(string baseDir, int slot)
        {
            string info = SaveStateManager.GetSlotInfo(baseDir, slot);
            int colon = info.IndexOf(':');
            string tail = colon >= 0 ? info[(colon + 1)..].Trim() : info;
            return tail == "(Empty)" ? "Empty" : tail;
        }

        private static string SafeLevel()
        {
            try { return Player.Level.ToString(); } catch { return "-"; }
        }

        private static string SafeGold()
        {
            try { return Player.Gold.ToString("N0"); } catch { return "-"; }
        }

        private static string AspectLabelShort() => HostWindow.CurrentAspectRatio switch
        {
            HostWindow.AspectRatioMode.AutoDevice => "Fit device",
            HostWindow.AspectRatioMode.Widescreen_16_9 => "16:9",
            HostWindow.AspectRatioMode.Stretch => "Stretch",
            _ => "4:3"
        };

        // --- Disc setup ------------------------------------------------------------------
        //
        // The APK ships without game data. On a fresh install the player is asked for their own
        // dump, which is copied into app storage once and found automatically from then on.

        private const int PickDiscRequest = 0x50C7;

        // Raised when the disc question is settled - imported, or given up on. The game thread
        // parks on this because there is nothing it can usefully do until then.
        private readonly System.Threading.ManualResetEventSlim _discGate = new(false);
        private Dialog? _discSetupDialog;
        private volatile bool _discImportRunning;

        /// <summary>
        /// Blocks the calling (game) thread until a usable disc exists. Returns false if the
        /// player chose to quit instead of providing one.
        /// </summary>
        private bool EnsureDiscReady()
        {
            if (ResolveDisc()) return true;

            Console.WriteLine("[Android] No disc found; asking the player for one.");
            RunOnUiThread(() => ShowDiscSetup());
            _discGate.Wait();
            return ResolveDisc();
        }

        /// <summary>
        /// Points CdPath at a usable disc if one can be found, and reports whether it managed to.
        /// Kept cheap - it only confirms the cue and its tracks are present, since parsing the
        /// ISO on every launch would add a visible pause before the splash.
        /// </summary>
        private bool ResolveDisc()
        {
            try
            {
                ConfigManager.Load();

                if (DiscImporter.LooksComplete(ConfigManager.Game.CdPath ?? "")) return true;

                if (DiscImporter.FindExisting(this) is { } found)
                {
                    ConfigManager.Game.CdPath = found;
                    ConfigManager.SaveGame();
                    Console.WriteLine($"[Android] Using disc: {found}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] Disc lookup failed: {ex.Message}");
            }
            return false;
        }

        /// <summary>
        /// First-run screen. Deliberately not cancellable: dismissing it would leave the game
        /// thread parked on _discGate with nothing on screen to explain the black display.
        /// </summary>
        private void ShowDiscSetup(string? error = null)
        {
            DismissSplashScreen();

            float d = Resources?.DisplayMetrics?.Density ?? 1f;
            int P(float v) => (int)(v * d + 0.5f);

            var dialog = new Dialog(this);
            _discSetupDialog = dialog;
            dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
            dialog.SetCancelable(false);

            var panel = new LinearLayout(this) { Orientation = global::Android.Widget.Orientation.Vertical };
            var bg = new global::Android.Graphics.Drawables.GradientDrawable();
            bg.SetColor(MenuSheet.Ink);
            bg.SetCornerRadius(P(18));
            bg.SetStroke(Math.Max(1, P(1)), Color.Argb(90, MenuSheet.Gold.R, MenuSheet.Gold.G, MenuSheet.Gold.B));
            panel.Background = bg;
            panel.SetPadding(P(22), P(20), P(22), P(12));

            var head = new TextView(this) { Text = "GAME FILES NEEDED", TextSize = 17f, LetterSpacing = 0.12f };
            head.SetTextColor(MenuSheet.Gold);
            head.SetTypeface(Typeface.Create("serif", TypefaceStyle.Bold), TypefaceStyle.Bold);
            panel.AddView(head);

            var body = new TextView(this)
            {
                Text = error ?? "This app contains no game data. To play, provide your own copy of "
                     + "Castlevania: Symphony of the Night (USA), dumped from disc.\n\n"
                     + "Select the .cue file and both .bin tracks together. They are copied into "
                     + "the app once, so this is only asked for on the first run.",
                TextSize = 13.5f,
            };
            body.SetTextColor(error != null ? MenuSheet.Blood : MenuSheet.Parchment);
            body.SetPadding(0, P(10), 0, P(4));
            panel.AddView(body);

            // Progress, hidden until a copy is actually running.
            var status = new TextView(this) { TextSize = 12.5f, Visibility = ViewStates.Gone };
            status.SetTextColor(MenuSheet.Mist);
            status.SetPadding(0, P(8), 0, P(4));
            panel.AddView(status);

            var bar = new ProgressBar(this, null, global::Android.Resource.Attribute.ProgressBarStyleHorizontal)
            {
                Max = 100,
                Visibility = ViewStates.Gone,
            };
            panel.AddView(bar);

            LinearLayout Action(string label, Color colour, Action onTap)
            {
                var row = new LinearLayout(this) { Orientation = global::Android.Widget.Orientation.Horizontal };
                row.SetGravity(GravityFlags.Center);
                row.SetPadding(P(16), P(14), P(16), P(14));
                row.SetMinimumHeight(P(52));
                row.Clickable = true;
                var tv = new TextView(this) { Text = label, TextSize = 14f, LetterSpacing = 0.1f };
                tv.SetTextColor(colour);
                tv.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
                row.AddView(tv);
                row.Click += (s, e) => onTap();
                return row;
            }

            var choose = Action("Choose disc files", MenuSheet.Gold, () =>
            {
                if (_discImportRunning) return;
                StartDiscPicker();
            });
            panel.AddView(choose);

            var quit = Action("Exit", MenuSheet.Mist, () =>
            {
                if (_discImportRunning) return;
                dialog.Dismiss();
                _discSetupDialog = null;
                _discGate.Set(); // let the game thread unwind instead of parking forever
                Finish();
            });
            panel.AddView(quit);

            // Handed to the import so it can drive this dialog without rebuilding it.
            _discProgress = (text, percent) => RunOnUiThread(() =>
            {
                status.Visibility = ViewStates.Visible;
                bar.Visibility = ViewStates.Visible;
                choose.Visibility = ViewStates.Gone;
                quit.Visibility = ViewStates.Gone;
                body.Text = "Copying your disc into the app. This takes a minute or two and only happens once.";
                body.SetTextColor(MenuSheet.Parchment);
                status.Text = text;
                bar.Progress = percent;
            });

            var host = new FrameLayout(this);
            host.SetBackgroundColor(Color.Argb(210, 0, 0, 0));
            host.Clickable = true;
            panel.Clickable = true;
            panel.LayoutParameters = new FrameLayout.LayoutParams(
                Math.Min(P(380), (int)((Resources?.DisplayMetrics?.WidthPixels ?? 1000) * 0.86f)),
                ViewGroup.LayoutParams.WrapContent)
            { Gravity = GravityFlags.Center };
            host.AddView(panel);

            dialog.SetContentView(host);
            var w = dialog.Window;
            if (w != null)
            {
                w.SetBackgroundDrawable(new global::Android.Graphics.Drawables.ColorDrawable(Color.Transparent));
                w.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                w.SetDimAmount(0f);
            }

            try
            {
                dialog.Show();
            }
            catch (Exception ex)
            {
                // Without this the game thread would sit on _discGate forever behind a black
                // screen. Better to fail loudly and let the player reopen the app.
                Console.Error.WriteLine($"[Android] Could not show the disc setup screen: {ex.Message}");
                _discSetupDialog = null;
                _discGate.Set();
                Finish();
            }
        }

        private Action<string, int>? _discProgress;

        private void StartDiscPicker()
        {
            try
            {
                var intent = new Intent(Intent.ActionOpenDocument);
                intent.AddCategory(Intent.CategoryOpenable);
                intent.SetType("*/*");
                intent.PutExtra(Intent.ExtraAllowMultiple, true);
                StartActivityForResult(intent, PickDiscRequest);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] Could not open the file picker: {ex.Message}");
                RestartDiscSetup($"This device could not open a file picker ({ex.Message}). "
                               + "Copy your .cue and .bin files into:\n\n" + DiscImporter.TargetDir(this)
                               + "\n\nthen reopen the app.");
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == ExportCardRequest || requestCode == ExportCardRequest + 1)
            {
                if (resultCode == Result.Ok && data?.Data is { } outUri)
                    ExportCardTo(requestCode - ExportCardRequest, outUri);
                return;
            }

            if (requestCode == ImportCardRequest || requestCode == ImportCardRequest + 1)
            {
                if (resultCode == Result.Ok && data?.Data is { } inUri)
                    ImportCardFrom(requestCode - ImportCardRequest, inUri);
                return;
            }

            if (requestCode != PickDiscRequest) return;

            if (resultCode != Result.Ok || data == null)
            {
                Console.WriteLine("[Android] Disc selection cancelled.");
                return; // the setup dialog is still up, so there is nothing to recover
            }

            var picked = CollectPicked(data);
            if (picked.Count == 0)
            {
                RestartDiscSetup("No files came back from the picker. Try selecting them again.");
                return;
            }

            RunImport(picked);
        }

        /// <summary>Reads the names and sizes of everything the picker returned.</summary>
        private List<DiscImporter.Picked> CollectPicked(Intent data)
        {
            var uris = new List<global::Android.Net.Uri>();

            if (data.ClipData is { } clip)
            {
                for (int i = 0; i < clip.ItemCount; i++)
                    if (clip.GetItemAt(i)?.Uri is { } u) uris.Add(u);
            }
            else if (data.Data is { } single)
            {
                uris.Add(single);
            }

            var result = new List<DiscImporter.Picked>();
            foreach (var uri in uris)
            {
                string name = "";
                long size = 0;
                try
                {
                    using var c = ContentResolver?.Query(uri, null, null, null, null);
                    if (c != null && c.MoveToFirst())
                    {
                        // DocumentsContract column names; used literally so this does not depend
                        // on binding constants.
                        int ni = c.GetColumnIndex("_display_name");
                        int si = c.GetColumnIndex("_size");
                        if (ni >= 0 && !c.IsNull(ni)) name = c.GetString(ni) ?? "";
                        if (si >= 0 && !c.IsNull(si)) size = c.GetLong(si);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[Android] Could not read file details: {ex.Message}");
                }

                if (string.IsNullOrWhiteSpace(name)) name = uri.LastPathSegment ?? "file";

                var captured = uri;
                result.Add(new DiscImporter.Picked
                {
                    Name = name,
                    Size = size,
                    Open = () => ContentResolver?.OpenInputStream(captured),
                });
            }
            return result;
        }

        private void RunImport(List<DiscImporter.Picked> picked)
        {
            _discImportRunning = true;
            var report = _discProgress ?? ((_, _) => { });

            System.Threading.Tasks.Task.Run(() =>
            {
                DiscImporter.ImportResult result;
                try
                {
                    result = DiscImporter.Import(this, picked, report);
                }
                catch (Exception ex)
                {
                    result = new DiscImporter.ImportResult { Success = false, Error = ex.Message };
                }

                _discImportRunning = false;

                RunOnUiThread(() =>
                {
                    if (result.Success && result.CuePath != null)
                    {
                        try
                        {
                            ConfigManager.Game.CdPath = result.CuePath;
                            ConfigManager.SaveGame();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"[Android] Could not save the disc path: {ex.Message}");
                        }

                        Console.WriteLine($"[Android] Disc imported: {result.CuePath}");
                        _discSetupDialog?.Dismiss();
                        _discSetupDialog = null;
                        _discGate.Set(); // release the game thread
                    }
                    else
                    {
                        RestartDiscSetup(result.Error ?? "The disc could not be imported.");
                    }
                });
            });
        }

        /// <summary>Rebuilds the setup screen carrying an error, so the player can try again.</summary>
        private void RestartDiscSetup(string error)
        {
            RunOnUiThread(() =>
            {
                try { _discSetupDialog?.Dismiss(); } catch { }
                _discSetupDialog = null;
                ShowDiscSetup(error);
            });
        }

        // --- Memory cards ----------------------------------------------------------------
        //
        // The card lives in app-private storage where nothing else can reach it, so without
        // this a save could never leave the phone or come back from the desktop build.

        private const int ExportCardRequest = 0x5EC0; // +card index
        private const int ImportCardRequest = 0x5EC2; // +card index

        /// <summary>Raw PSX card image, the size every emulator agrees on.</summary>
        private const int CardSize = 0x20000;

        /// <summary>
        /// Headers other tools wrap the same 128 KB payload in. Accepting them means a save
        /// exported from a DexDrive or VGS still imports without being converted first.
        /// </summary>
        private static readonly (long Total, int Skip, string Name)[] CardWrappers =
        {
            (CardSize, 0, "raw"),
            (CardSize + 3904, 3904, "DexDrive"),
            (CardSize + 64, 64, "VGS"),
        };

        private string CardPath(int index)
        {
            string p = "";
            try { p = index == 0 ? ConfigManager.Game.CardAPath : ConfigManager.Game.CardBPath; }
            catch { }
            if (string.IsNullOrWhiteSpace(p)) p = index == 0 ? "carda.sav" : "cardb.sav";
            return System.IO.Path.IsPathRooted(p) ? p : System.IO.Path.Combine(FilesDir?.Path ?? "", p);
        }

        private string CardSummary(int index)
        {
            try
            {
                var fi = new FileInfo(CardPath(index));
                return fi.Exists && fi.Length > 0 ? $"{fi.Length / 1024} KB" : "Empty";
            }
            catch { return "Empty"; }
        }

        private void ShowMemoryCardMenu()
        {
            new MenuSheet(this, "Memory cards", "Move saves on and off the device")
                .Section("Card 1")
                .Item("Export card 1", CardSummary(0), () => StartCardExport(0))
                .Item("Import card 1", null, () => ConfirmCardImport(0))
                .Section("Card 2")
                .Item("Export card 2", CardSummary(1), () => StartCardExport(1))
                .Item("Import card 2", null, () => ConfirmCardImport(1))
                .Back("Back", ShowMenuDialog)
                .Show();
        }

        private void StartCardExport(int index)
        {
            try
            {
                // The live card only reaches disk when the game writes, so push it out first
                // or the export could be a save or two behind what the player just did.
                try { (index == 0 ? global::RecompOne.Runtime.Runtime.CardA
                                  : global::RecompOne.Runtime.Runtime.CardB)?.Flush(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] Card flush failed: {ex.Message}"); }

                if (!File.Exists(CardPath(index)))
                {
                    Toast.MakeText(this, "That card has no save data yet", ToastLength.Short)?.Show();
                    return;
                }

                var intent = new Intent(Intent.ActionCreateDocument);
                intent.AddCategory(Intent.CategoryOpenable);
                intent.SetType("application/octet-stream");
                intent.PutExtra(Intent.ExtraTitle, index == 0 ? "carda.sav" : "cardb.sav");
                StartActivityForResult(intent, ExportCardRequest + index);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Could not open the file picker: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void ConfirmCardImport(int index)
        {
            MenuSheet.Confirm(this, $"Import card {index + 1}",
                "The card on this device will be replaced by the file you choose, and the app will "
                + "restart to load it. Export it first if you want to keep it.",
                "Choose file", () =>
                {
                    try
                    {
                        var intent = new Intent(Intent.ActionOpenDocument);
                        intent.AddCategory(Intent.CategoryOpenable);
                        intent.SetType("*/*");
                        StartActivityForResult(intent, ImportCardRequest + index);
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, $"Could not open the file picker: {ex.Message}", ToastLength.Long)?.Show();
                    }
                });
        }

        private void ExportCardTo(int index, global::Android.Net.Uri uri)
        {
            try
            {
                using var src = File.OpenRead(CardPath(index));
                using var dst = ContentResolver?.OpenOutputStream(uri);
                if (dst == null)
                {
                    Toast.MakeText(this, "That location could not be written to", ToastLength.Long)?.Show();
                    return;
                }
                src.CopyTo(dst);
                dst.Flush();
                Toast.MakeText(this, $"Card {index + 1} exported", ToastLength.Short)?.Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Export failed: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void ImportCardFrom(int index, global::Android.Net.Uri uri)
        {
            try
            {
                byte[] raw;
                using (var src = ContentResolver?.OpenInputStream(uri))
                {
                    if (src == null)
                    {
                        Toast.MakeText(this, "That file could not be opened", ToastLength.Long)?.Show();
                        return;
                    }
                    using var ms = new MemoryStream();
                    src.CopyTo(ms);
                    raw = ms.ToArray();
                }

                var match = Array.Find(CardWrappers, w => w.Total == raw.Length);
                if (match.Total == 0)
                {
                    Toast.MakeText(this,
                        $"That is not a PlayStation memory card ({raw.Length} bytes). Expected a 128 KB .mcr, .mcd or .sav.",
                        ToastLength.Long)?.Show();
                    return;
                }

                var card = new byte[CardSize];
                Array.Copy(raw, match.Skip, card, 0, CardSize);

                // "MC" marks a formatted card. Refusing anything else keeps a mis-picked file
                // from wiping a real save.
                if (card[0] != 0x4D || card[1] != 0x43)
                {
                    Toast.MakeText(this, "That card image is not formatted and was not imported",
                                   ToastLength.Long)?.Show();
                    return;
                }

                string path = CardPath(index);
                string? dir = System.IO.Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

                // Keep the outgoing card next to the new one; an import is otherwise the one
                // action here with no way back.
                try { if (File.Exists(path)) File.Copy(path, path + ".replaced", true); } catch { }

                File.WriteAllBytes(path, card);
                Console.WriteLine($"[Android] Imported {match.Name} card image into {path}");

                // MemoryCard reads the file once when it is constructed and rewrites it on every
                // save, so the running game would overwrite this the next time it wrote. Only a
                // restart picks it up.
                Toast.MakeText(this, "Card imported - restarting", ToastLength.Short)?.Show();
                RestartApp();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Import failed: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void CopyAssets(string path)
        {
            try
            {
                var filesPath = FilesDir?.Path ?? "";
                var normalizedPath = path.Replace('\\', '/');
                var list = Assets?.List(normalizedPath);

                if (list != null && list.Length > 0)
                {
                    var localDir = System.IO.Path.Combine(filesPath, normalizedPath);
                    Directory.CreateDirectory(localDir);

                    foreach (var item in list)
                    {
                        var childPath = string.IsNullOrEmpty(normalizedPath) ? item : $"{normalizedPath}/{item}";
                        CopyAssets(childPath);
                    }
                }
                else
                {
                    var localFile = System.IO.Path.Combine(filesPath, normalizedPath);
                    if (normalizedPath.StartsWith("disc") && File.Exists(localFile) && new FileInfo(localFile).Length > 0)
                        return;

                    try
                    {
                        using var stream = Assets?.Open(normalizedPath);
                        if (stream != null)
                        {
                            var parentDir = System.IO.Path.GetDirectoryName(localFile);
                            if (!string.IsNullOrEmpty(parentDir))
                                Directory.CreateDirectory(parentDir);

                            using var dest = File.Create(localFile);
                            stream.CopyTo(dest);
                        }
                    }
                    catch (Java.IO.FileNotFoundException) { }
                    catch (FileNotFoundException) { }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] Asset copy error for '{path}': {ex.Message}");
            }
        }
    }
}
