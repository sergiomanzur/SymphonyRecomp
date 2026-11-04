using System;
using RecompOne.Runtime.Config;
using RecompOne.Runtime.Host;

namespace RecompOne.SoTN.Android
{
    /// <summary>
    /// How the buttons on a physical pad line up with the PlayStation face buttons.
    /// SDL reports face buttons by index, and which physical button carries which index
    /// depends on how the handheld presents itself, so this is a per-player choice.
    /// </summary>
    public enum PadLayout
    {
        PlayStation = 0,
        Xbox = 1,
        Nintendo = 2
    }

    /// <summary>
    /// Everything the Android menu can change, stored in the shared runtime settings so it
    /// survives a restart. Previously these lived only in fields on the activity and were
    /// lost every launch.
    /// </summary>
    public static class AndroidSettings
    {
        // The upstream 1.1 runtime replaced the old ViewConfig/ConfigManager pair with
        // Options, which persist to settings.json. Keys keep their android.* namespace so
        // they cannot collide with a desktop setting.
        static readonly Option<bool> TouchVisibleOption =
            Options.Bool("android.touch.visible", DefaultTouchVisible);

        static readonly Option<float> TouchOpacityOption =
            Options.Float("android.touch.opacity", DefaultTouchOpacity)
                .Normalized(static v => Math.Clamp(v, 0.1f, 1f));

        static readonly Option<int> OrientationOption =
            Options.Int("android.orientation", 0)
                .Normalized(static v => Math.Clamp(v, 0, 2));

        static readonly Option<int> AspectOption =
            Options.Int("android.aspect", (int)HostWindow.AspectRatioMode.AutoDevice)
                .Normalized(static v => Math.Clamp(v, 0, 3));

        static readonly Option<int> PadLayoutOption =
            Options.Int("android.pad_layout", 0)
                .Normalized(static v => Math.Clamp(v, 0, 2));

        static readonly Option<int> TouchControlModeOption =
            Options.Int("android.touch.control_mode", 0)
                .Normalized(static v => Math.Clamp(v, 0, 1));

        static readonly Option<string> ModsPathOption =
            Options.String("android.mods_path", "");

        public const string KeyModsPath = "android.mods_path";

        public const bool DefaultTouchVisible = true;
        public const float DefaultTouchOpacity = 0.7f;

        public static bool TouchVisible
        {
            get => TouchVisibleOption.Value;
            set { TouchVisibleOption.Value = value; Save(); }
        }

        public static float TouchOpacity
        {
            get => TouchOpacityOption.Value;
            set { TouchOpacityOption.Value = value; Save(); }
        }

        public static int TouchControlMode
        {
            get => TouchControlModeOption.Value;
            set { TouchControlModeOption.Value = value; Save(); }
        }

        public static string ModsPath
        {
            get => ModsPathOption.Value ?? "";
            set { ModsPathOption.Value = value ?? ""; Save(); }
        }

        public static MainActivity.ScreenOrientationMode Orientation
        {
            get => (MainActivity.ScreenOrientationMode)OrientationOption.Value;
            set { OrientationOption.Value = (int)value; Save(); }
        }

        public static HostWindow.AspectRatioMode Aspect
        {
            get => (HostWindow.AspectRatioMode)AspectOption.Value;
            set { AspectOption.Value = (int)value; Save(); }
        }

        public static PadLayout Pad
        {
            get => (PadLayout)PadLayoutOption.Value;
            set { PadLayoutOption.Value = (int)value; Save(); ApplyPadLayout(value); }
        }

        /// <summary>
        /// The device's landscape ratio - 2.22 on a 20:9 phone, 1.78 on a 16:9 handheld.
        /// Measured long edge over short edge so it does not flip when the player rotates:
        /// changing how much of the level is rendered mid-game would be jarring, and in
        /// portrait the frame is boxed anyway.
        /// </summary>
        public static float DeviceAspect { get; set; } = 16f / 9f;

        /// <summary>
        /// Renders the game at the ratio the chosen mode asks for.
        ///
        /// This is what makes "16:9" actually mean 16:9. The aspect setting used to change
        /// only the rectangle the finished frame was drawn into, so a 4:3 picture was pulled
        /// sideways to fill it. A wider picture has to be rendered wider in the first place,
        /// which is WidescreenPatch's job - the same path the desktop display settings drive.
        /// </summary>
        public static void ApplyAspect(HostWindow.AspectRatioMode mode)
        {
            try
            {
                HostWindow.CurrentAspectRatio = mode;

                float target = mode switch
                {
                    HostWindow.AspectRatioMode.Widescreen_16_9 => 16f / 9f,
                    HostWindow.AspectRatioMode.AutoDevice => DeviceAspect,
                    // 4:3 and Stretch both keep the original framing. Stretch then fills the
                    // screen with it on purpose, which is the one place distortion is wanted.
                    _ => 0f,
                };

                bool original = target <= 0f;
                // Upstream's own bounds. Past these the widescreen hooks start showing seams
                // at the edges of rooms.
                if (!original) target = Math.Clamp(target, 1f, 3f);

                // Keep the PlayStation's non-square pixels, so the picture keeps the shape the
                // game was drawn for. The alternative - the patch's default - presents the
                // 256x240 stage with square pixels, which is narrower than 4:3 and would have
                // quietly changed how "4:3 original" looks. Widening then only adds level to
                // the sides instead of reshaping the sprites.
                Recompiled.WidescreenOptions.Unstretch.Value = false;

                Recompiled.WidescreenOptions.OriginalAspect.Value = original;

                if (!original)
                {
                    // Written before Refresh: the patch reads these on its first initialisation.
                    Recompiled.WidescreenOptions.Aspect.Value = target;
                }

                Recompiled.WidescreenPatch.Refresh();
                Save();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[Android] Could not apply the aspect ratio: {ex.Message}");
            }
        }

        static void Save()
        {
            try { Settings.Save(); } catch { }
        }

        /// <summary>
        /// Rewrites the face-button bindings for the chosen layout.
        ///
        /// SDL's game controller indices are 0 A, 1 B, 2 X, 3 Y. On a pad arranged like an
        /// Xbox or PlayStation controller those sit bottom, right, left, top - which is the
        /// same arrangement the PlayStation uses, so those two layouts share a mapping.
        /// Nintendo-arranged pads report A on the right and X on the top, so A/B and X/Y are
        /// swapped relative to the others.
        /// </summary>
        public static void ApplyPadLayout(PadLayout layout)
        {
            try
            {
                var port = Settings.System.Input[0];
                foreach (var pad in new[] { port.Digital, port.Analog })
                {
                    switch (layout)
                    {
                        case PadLayout.Nintendo:
                            pad.Cross = [1];
                            pad.Circle = [0];
                            pad.Square = [3];
                            pad.Triangle = [2];
                            break;
                        default: // PlayStation and Xbox share the same physical arrangement
                            pad.Cross = [0];
                            pad.Circle = [1];
                            pad.Square = [2];
                            pad.Triangle = [3];
                            break;
                    }
                }
                Settings.Save();
            }
            catch
            {
            }
        }

        public static string LayoutName(PadLayout layout) => layout switch
        {
            PadLayout.Xbox => "Xbox",
            PadLayout.Nintendo => "Nintendo",
            _ => "PlayStation"
        };

        /// <summary>Applies the stored values to the live runtime at startup.</summary>
        public static void ApplyAtStartup()
        {
            try
            {
                ApplyAspect(Aspect);
                ApplyPadLayout(Pad);
            }
            catch
            {
            }
        }

        /// <summary>Puts every Android menu setting back to its default.</summary>
        public static void ResetAll()
        {
            TouchVisibleOption.Reset();
            TouchOpacityOption.Reset();
            OrientationOption.Reset();
            AspectOption.Reset();
            PadLayoutOption.Reset();
            TouchControlModeOption.Reset();
            ModsPathOption.Reset();

            DisplayOptions.RenderScale.Value = 4;
            DisplayOptions.VSync.Value = false;

            // The quality of life toggles live in the same file, so a reset should clear
            // those too rather than leaving half the settings behind.
            foreach (var option in Recompiled.QualityOfLifeOptions.All) option.Reset();

            ApplyPadLayout(PadLayout.PlayStation);
            ApplyAspect(HostWindow.AspectRatioMode.AutoDevice);
            Save();
        }
    }
}
