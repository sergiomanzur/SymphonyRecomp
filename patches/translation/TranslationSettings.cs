using ImGuiNET;
using RecompOne.Runtime.Host.Window;

namespace Recompiled.Translation;

internal static class TranslationSettings
{
    private static IReadOnlyList<LanguagePackInfo>? _packs;
    private static string? _scanError;

    public static void Register()
    {
        SettingsPages.Page(SettingsPages.Language)
            .Add("game", Draw, 100, "settings.language.game");
    }

    private static void Draw()
    {
        if (_packs == null) Rescan();

        string selected = GameLanguage.Pack;
        string original = Localization.T("translation.original");
        string label = selected == GameLanguage.OriginalPack
            ? original
            : _packs!.FirstOrDefault(p => p.Id == selected)?.Name ?? selected;

        ImGui.SetNextItemWidth(-1f);
        if (ImGui.BeginCombo("##game-language", label))
        {
            if (ImGui.Selectable(original, selected == GameLanguage.OriginalPack)) GameLanguage.Select(GameLanguage.OriginalPack);

            foreach (var pack in _packs!)
                if (ImGui.Selectable($"{pack.Name}##pack-{pack.Id}", selected == pack.Id))
                    GameLanguage.Select(pack.Id);

            ImGui.EndCombo();
        }

        SettingsWidgets.Note("translation.hint");

        if (GameLanguage.Pending)
            ImGui.TextWrapped(Localization.T("translation.applying"));
        if (ImGui.Button(Localization.T("translation.rescan"))) Rescan();
        if (_scanError != null) ImGui.TextWrapped(_scanError);
        if (TextPatches.LoadError != null) ImGui.TextWrapped(TextPatches.LoadError);
        if (GameLanguage.Error != null)
        {
            ImGui.TextWrapped(Localization.T("translation.load_error"));
            ImGui.TextWrapped(GameLanguage.Error);
        }
    }

    private static void Rescan()
    {
        _packs = LanguagePacks.Scan(out _scanError);
    }
}
