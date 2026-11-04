using ImGuiNET;
using RecompOne.Runtime.Config;
using RecompOne.Runtime.Host.Window;

namespace Recompiled;

public static class WidescreenOptions
{
    public static readonly Option<float> Aspect = Options.Float("widescreen.aspect", 16f / 9f)
        .Normalized(static v => Math.Clamp(v, 1f, 3f));
    public static readonly Option<bool> OriginalAspect = Options.Bool("widescreen.original_aspect", true);
    public static readonly Option<bool> Letterbox = Options.Bool("widescreen.letterbox", false);
    public static readonly Option<bool> Unstretch = Options.Bool("widescreen.unstretch", true);
}

public static class WidescreenSettings
{
    static readonly (string Label, float Value)[] _presets =
    [
        ("4:3", 4f / 3f),
        ("16:10", 16f / 10f),
        ("16:9", 16f / 9f),
        ("21:9", 21f / 9f),
    ];

    public static void Register()
    {
        SettingsPages.Page(SettingsPages.Display)
            .Add("widescreen", Draw, 150, "settings.display.widescreen");
    }

    static void Draw()
    {
        float aspect = WidescreenOptions.Aspect;
        bool original = WidescreenOptions.OriginalAspect;
        int selected = MatchPreset(aspect);
        var originalLabel = Localization.T("widescreen.original");
        var customLabel = Localization.T("settings.interface.custom");
        string label = original ? originalLabel : selected >= 0 ? _presets[selected].Label : customLabel;

        ImGui.TextUnformatted(Localization.T("widescreen.aspect"));
        if (ImGui.BeginCombo("##aspect-preset", label))
        {
            if (ImGui.Selectable(originalLabel, original)) WidescreenOptions.OriginalAspect.Value = true;
            for (int i = 0; i < _presets.Length; i++)
            {
                if (ImGui.Selectable(_presets[i].Label, !original && selected == i))
                    Apply(_presets[i].Value);
            }
            if (ImGui.Selectable(customLabel, !original && selected < 0))
                Apply(aspect);
            ImGui.EndCombo();
        }

        if (original) ImGui.BeginDisabled();
        float custom = aspect;
        if (ImGui.SliderFloat("##aspect-custom", ref custom, 1.0f, 2.5f, "%.3f : 1"))
            Apply(custom);
        if (original) ImGui.EndDisabled();

        //ImGui.TextWrapped("");

        ImGui.Spacing();
        SettingsWidgets.Toggle(WidescreenOptions.Unstretch, "widescreen.unstretch", "widescreen.unstretch_hint");

        if (original) ImGui.BeginDisabled();
        SettingsWidgets.Toggle(WidescreenOptions.Letterbox, "widescreen.letterboxing", "widescreen.letterboxing_hint"); //pillar is on the sides dumass
        if (original) ImGui.EndDisabled();
    }

    static int MatchPreset(float aspect)
    {
        for (int i = 0; i < _presets.Length; i++)
            if (MathF.Abs(_presets[i].Value - aspect) < 0.001f) return i;
        return -1;
    }

    static void Apply(float aspect)
    {
        if (WidescreenOptions.OriginalAspect)
            RecompOne.Runtime.Runtime.ShowNotice(Localization.T("widescreen.warning"));

        WidescreenOptions.Aspect.Value = aspect;
        WidescreenOptions.OriginalAspect.Value = false;
    }
}
