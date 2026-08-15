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

            CopyAssets("assets");
            CopyAssets("config");
            CopyAssets("disc");
            CopyAssets("Android");
            CopyAssets("mods"); // bundled mods, unpacked next to any the player adds

            // Entry.Run calls ModLoader.LoadAll() with no argument, so point the loader at the
            // folder chosen in the menu before the game starts.
            try { ModLoader.RootOverride = ModsDir; } catch { }

            AutoDetectDisc();
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
                AutoDetectDisc();

                // Program.cs does this on desktop via QualityOfLifeMenu.Register(), which wires
                // QualityOfLife.Load() to RuntimeReadyEvent. Program.cs is excluded from the
                // Android build, so without this the saved toggles were never read back and
                // every launch started with all of them off.
                try { QualityOfLife.Load(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] QoL settings failed to load: {ex.Message}"); }

                // Aspect ratio and pad layout are plain statics in the runtime, so restore the
                // saved choices before the game starts. Orientation is applied in OnPostCreate,
                // once the activity can accept a request.
                try { AndroidSettings.ApplyAtStartup(); }
                catch (Exception ex) { Console.Error.WriteLine($"[Android] settings failed to apply: {ex.Message}"); }

                var cdPath = ConfigManager.Game.CdPath;
                Console.WriteLine($"[Android] Launching Entry.Run with CdPath = '{cdPath}'");

                // Run the game!
                var m = new PSMemory();
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
                        .Item("Mods", $"{ModLoader.Mods.Count} installed", ShowModsMenu)
                        .Section("System")
                        .Item("Display", AspectLabelShort(), ShowDisplayMenu)
                        .Item("Controller layout", AndroidSettings.LayoutName(AndroidSettings.Pad), ShowPadLayoutMenu)
                        .Item("Touch controls", _touchVisible ? "Visible" : "Hidden", ShowTouchControlsMenu)
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
                HostWindow.AspectRatioMode.AutoDevice => "📱 Auto-Fit (Portrait & Landscape)",
                HostWindow.AspectRatioMode.Widescreen_16_9 => "16:9 Widescreen",
                HostWindow.AspectRatioMode.Stretch => "Stretch to Screen",
                _ => "4:3 Original"
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
                .Toggle("High resolution (4x)", !ConfigManager.View.NativeResolution, on =>
                {
                    ConfigManager.View.NativeResolution = !on;
                    ConfigManager.SaveView(null);
                    HostWindow.RequestGpuReset();
                })
                .Toggle("VSync", ConfigManager.View.VSync, on =>
                {
                    ConfigManager.View.VSync = on;
                    HostWindow.SetVSync(on);
                    ConfigManager.SaveView(null);
                })
                .Back("Back", ShowMenuDialog)
                .Show();
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
                HostWindow.CurrentAspectRatio = mode;
                AndroidSettings.Aspect = mode;
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

        private void AutoDetectDisc()
        {
            try
            {
                ConfigManager.Load();
                var searchDirs = new string[]
                {
                    "/sdcard/Android/data/com.blacklabelhq.sotn/files/disc",
                    global::Android.OS.Environment.ExternalStorageDirectory?.AbsolutePath != null
                        ? System.IO.Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Android", "data", PackageName ?? "com.blacklabelhq.sotn", "files", "disc")
                        : "",
                    System.IO.Path.Combine(FilesDir?.Path ?? "", "disc"),
                    "/sdcard/SymphonyRecomp/disc",
                    "/sdcard/disc"
                };

                foreach (var discDir in searchDirs)
                {
                    if (!string.IsNullOrWhiteSpace(discDir) && Directory.Exists(discDir))
                    {
                        var cueFiles = Directory.GetFiles(discDir, "*.cue");
                        if (cueFiles.Length > 0)
                        {
                            var validCue = cueFiles.FirstOrDefault(f => File.Exists(f) && new FileInfo(f).Length > 0);
                            if (validCue != null)
                            {
                                ConfigManager.Game.CdPath = validCue;
                                ConfigManager.SaveGame();
                                Console.WriteLine($"[Android] Auto-configured CdPath to valid cue: {validCue}");
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] AutoDetectDisc error: {ex.Message}");
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
