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
    /// Everything the Android menu can change, stored in the shared view config so it
    /// survives a restart. Previously these lived only in fields on the activity and were
    /// lost every launch.
    /// </summary>
    public static class AndroidSettings
    {
        const string KeyTouchVisible = "AndroidTouchVisible";
        const string KeyTouchOpacity = "AndroidTouchOpacity";
        const string KeyOrientation = "AndroidOrientation";
        const string KeyAspect = "AndroidAspect";
        const string KeyPadLayout = "AndroidPadLayout";
        public const string KeyModsPath = "AndroidModsPath";

        public const bool DefaultTouchVisible = true;
        public const float DefaultTouchOpacity = 0.7f;

        static ViewConfig V => ConfigManager.View;

        public static bool TouchVisible
        {
            get => V.GetBool(KeyTouchVisible, DefaultTouchVisible);
            set { V.SetBool(KeyTouchVisible, value); Save(); }
        }

        public static float TouchOpacity
        {
            get
            {
                string s = V.GetString(KeyTouchOpacity);
                return float.TryParse(s, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out float f) && f > 0f
                    ? Math.Clamp(f, 0.1f, 1f)
                    : DefaultTouchOpacity;
            }
            set
            {
                V.SetString(KeyTouchOpacity, value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                Save();
            }
        }

        public static MainActivity.ScreenOrientationMode Orientation
        {
            get => (MainActivity.ScreenOrientationMode)Clamp(V.GetInt(KeyOrientation, 0), 0, 2);
            set { V.SetInt(KeyOrientation, (int)value); Save(); }
        }

        public static HostWindow.AspectRatioMode Aspect
        {
            get => (HostWindow.AspectRatioMode)Clamp(V.GetInt(KeyAspect, (int)HostWindow.AspectRatioMode.AutoDevice), 0, 3);
            set { V.SetInt(KeyAspect, (int)value); Save(); }
        }

        public static PadLayout Pad
        {
            get => (PadLayout)Clamp(V.GetInt(KeyPadLayout, 0), 0, 2);
            set { V.SetInt(KeyPadLayout, (int)value); Save(); ApplyPadLayout(value); }
        }

        static int Clamp(int v, int lo, int hi) => v < lo ? lo : v > hi ? hi : v;

        static void Save()
        {
            try { ConfigManager.SaveView(null); } catch { }
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
                var pad = ConfigManager.Game.Pad;
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
                ConfigManager.SaveGame();
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
                HostWindow.CurrentAspectRatio = Aspect;
                ApplyPadLayout(Pad);
            }
            catch
            {
            }
        }

        /// <summary>Puts every Android menu setting back to its default.</summary>
        public static void ResetAll()
        {
            V.SetBool(KeyTouchVisible, DefaultTouchVisible);
            V.SetString(KeyTouchOpacity, DefaultTouchOpacity.ToString(System.Globalization.CultureInfo.InvariantCulture));
            V.SetInt(KeyOrientation, 0);
            V.SetInt(KeyAspect, (int)HostWindow.AspectRatioMode.AutoDevice);
            V.SetInt(KeyPadLayout, 0);
            V.SetString(KeyModsPath, "");
            V.TouchControlMode = 0;
            V.NativeResolution = false;
            V.VSync = false;

            // The quality of life toggles live in the same file, so a reset should clear
            // those too rather than leaving half the settings behind.
            Recompiled.QualityOfLife.ColorBlind = false;
            Recompiled.QualityOfLife.RemoveFlashing = false;
            Recompiled.QualityOfLife.BugFixes = false;
            Recompiled.QualityOfLife.ClearFile = false;
            Recompiled.QualityOfLife.AntiFreeze = false;
            Recompiled.QualityOfLife.InfiniteWingSmash = false;
            Recompiled.QualityOfLife.UseEasySpellInput = false;
            Recompiled.QualityOfLife.IncreaseInvincibilityFrames = false;
            Recompiled.QualityOfLife.RestoreFairySong = false;
            try { Recompiled.QualityOfLife.Save(); } catch { }

            ApplyPadLayout(PadLayout.PlayStation);
            HostWindow.CurrentAspectRatio = HostWindow.AspectRatioMode.AutoDevice;
            Save();
        }
    }
}
