using System.Text.Json;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;
using Sotn;
using Runtime = RecompOne.Runtime.Runtime;

namespace Recompiled.Translation;

public static class DialogueScripts
{
    private sealed record Registration(string Yaml, string Directory);
    private static readonly Dictionary<string, Registration> Registrations = new(StringComparer.Ordinal);
    private static uint _nextLabel = 0x80100000;
    private static uint _startingEntity;
    private static uint _startingScript;
    private static string? _startingOverlay;

    internal static void Reset(uint nextLabel)
    {
        _nextLabel = nextLabel;
        foreach (var (id, registration) in Registrations)
            Compile(id, registration.Yaml, registration.Directory);
    }

    public static uint Register(string id, string scriptYaml, string packDirectory)
    {
        GameLanguage.EnsureLoaded();
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        
        if (Registrations.ContainsKey(id) || TranslationBindings.Root.GetProperty("scripts").TryGetProperty(id, out _))
            throw new ArgumentException($"Script already registered: {id}.", nameof(id));

        uint address = Compile(id, scriptYaml, packDirectory);
        Registrations.Add(id, new(scriptYaml, Path.GetFullPath(packDirectory)));

        return address;
    }

    private static uint Compile(string id, string yaml, string directory)
    {
        string overlay = id.Split(':', 2)[0];
        if (overlay.Length == 0 || overlay.Length == id.Length)
            throw new ArgumentException("Script IDs must be written as overlay:name.", nameof(id));

        var rows = ScriptYaml.Read(yaml, "script");
        uint nextLabel = _nextLabel;
        var compiled = ScriptData.Compile(id, overlay.ToLowerInvariant(), "dialogue", rows, 0x80180000, [], null, new TextCodec(directory), ref nextLabel);
        uint address = ScriptMemory.Register(compiled);

        _nextLabel = nextLabel;

        return address;
    }

    public static uint GetAddress(string id, string overlay, IMemory memory)
    {
        GameLanguage.EnsureLoaded();
        ScriptMemory.Activate(overlay, memory);
        return ScriptMemory.GetAddress(id, overlay);
    }

    public static Entity Play(string id, string overlay)
    {
        var c = Runtime.Cpu ?? throw new InvalidOperationException("The game is not running.");
        var m = Runtime.Mem ?? throw new InvalidOperationException("The game is not running.");
        overlay = overlay.ToLowerInvariant();

        if (overlay is not ("st0" or "cen" or "lib" or "mar" or "no3" or "nz0"))
            throw new NotSupportedException($"Overlay {overlay} does not use the standard dialogue entity.");

        var current = Dispatcher.ActiveNames.LastOrDefault(name => Dispatcher.Overlays[name].Base == 0x80180000);

        if (!string.Equals(current, overlay, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"Overlay {overlay} is not active.");

        uint handler = Dispatcher.Overlays[overlay].Functions.Single(p => p.Value.Method.Name == overlay.ToUpperInvariant() + "_EntityCutscene").Key;
        
        if (_startingEntity != 0 || Entities.All().Any(entity => entity.Update == handler))
            throw new InvalidOperationException("A dialogue is already running.");
        if (TranslationBindings.Root.GetProperty("scripts").TryGetProperty(id, out var binding) && binding.GetProperty("kind").GetString() != "dialogue")
            throw new ArgumentException("Only dialogue scripts can be played as an entity.", nameof(id));

        uint script = GetAddress(id, overlay, m);
        var snapshot = c.Snapshot();
        uint previousEntity = m.ReadU32(Game.CurrentEntityAddr);
        ushort tapped = m.ReadU16(Game.PadsAddr + 4);

        try
        {
            var entity = Entities.GetFreeStage();

            if (!entity.IsValid) throw new InvalidOperationException("no free entity slot for the dialogue is avaialble");

            m.ZeroRange(entity.Addr, Entity.Stride);
            m.WriteU16(entity.Addr + 0x26, 1);

            entity.Update = handler;
            entity.FlagBits = EntityFlags.KeepAliveOffCamera | EntityFlags.PosCameraLocked;

            _startingEntity = entity.Addr;
            _startingScript = script;
            _startingOverlay = overlay;

            m.WriteU32(Game.CurrentEntityAddr, entity.Addr);
            m.WriteU16(Game.PadsAddr + 4, 0);

            c.A0 = entity.Addr;
            Dispatcher.Call(c, m, handler);

            if (entity.Step == 0)
            {
                m.ZeroRange(entity.Addr, Entity.Stride);
                throw new InvalidOperationException("couldnt allocate the dialogue prims.");
            }

            return entity;
        }
        finally
        {
            _startingEntity = _startingScript = 0;
            _startingOverlay = null;
            m.WriteU32(Game.CurrentEntityAddr, previousEntity);
            m.WriteU16(Game.PadsAddr + 4, tapped);
            c.Restore(snapshot);
        }
    }

    internal static uint ResolveStart(string overlay, uint original, IMemory memory) => _startingOverlay == overlay && _startingEntity != 0 && memory.ReadU32(Game.CurrentEntityAddr) == _startingEntity ? _startingScript : original;
}
