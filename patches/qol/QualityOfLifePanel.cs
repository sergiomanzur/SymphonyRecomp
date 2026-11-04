using System.Numerics;
using ImGuiNET;
using RecompOne.Runtime.Config;
using RecompOne.Runtime.Host.Window;

namespace Recompiled;

public sealed class QualityOfLifePanel : IPanel
{
    public string Name => "Quality Of Life Options";
    public string TitleKey => "panel.qol";
    public bool IsOpen { get; set; }

    public void Draw()
    {
        ImGui.SetNextWindowSize(new Vector2(320, 420), ImGuiCond.FirstUseEver);
        bool open = IsOpen;
        if (!ImGui.Begin(this.Title(), ref open))
        {
            IsOpen = open;
            ImGui.End();
            return;
        }

        ImGui.SeparatorText(Localization.T("qol.toggles"));

        /* Toggles */
        Toggle(QualityOfLifeOptions.ColorBlind, "qol.color_blind");
        Toggle(QualityOfLifeOptions.RemoveFlashing, "qol.remove_flashing");
        Toggle(QualityOfLifeOptions.BugFixes, "qol.bug_fixes");
        Toggle(QualityOfLifeOptions.ClearFile, "qol.clear_file");
        Toggle(QualityOfLifeOptions.AntiFreeze, "qol.anti_freeze");
        Toggle(QualityOfLifeOptions.InfiniteWingSmash, "qol.infinite_wing_smash");
        Toggle(QualityOfLifeOptions.UseEasySpellInput, "qol.easy_spell_input");
        Toggle(QualityOfLifeOptions.IncreaseInvincibilityFrames, "qol.invincibility_frames");
        Toggle(QualityOfLifeOptions.SkipPrologue, "qol.skip_prologue");

        /* Enhancements */
        ImGui.SeparatorText(Localization.T("qol.enhancements"));
        Toggle(QualityOfLifeOptions.RestoreFairySong, "qol.fairy_song");

        IsOpen = open;
        ImGui.End();
    }

    static void Toggle(Option<bool> option, string key)
    {
        SettingsWidgets.Toggle(option, key, key + ".hint");
    }
}
