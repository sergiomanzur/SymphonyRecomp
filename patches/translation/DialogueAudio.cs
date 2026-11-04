using System.Globalization;
using System.Text.Json;
using RecompOne.Runtime.Assets;
using RecompOne.Runtime.Assets.Decoders;
using RecompOne.Runtime.Assets.Xa;
using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

public static class DialogueAudio
{
    private static Dictionary<int, string> _clips = [];
    private static readonly Dictionary<uint, (uint Original, uint Replacement)> Durations = [];
    private static XaEntry? _entry;

    internal static Dictionary<int, string> Read(string root)
    {
        using var manifest = JsonDocument.Parse(File.ReadAllText(Path.Combine(root, "manifest.json")));
        
        if (!manifest.RootElement.TryGetProperty("audio", out var audio)) return [];
        
        using var document = JsonDocument.Parse(File.ReadAllText(Resolve(root, audio.GetString()!)));
        var clips = new Dictionary<int, string>();
        
        foreach (var item in document.RootElement.GetProperty("clips").EnumerateObject())
        {
            if (!item.Name.StartsWith("xa:", StringComparison.Ordinal)) continue;
            if (!int.TryParse(item.Name.AsSpan(3), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int id) || id <= 0x300 || id >= 0x533)
                throw new InvalidDataException($"Invalid voice ID: {item.Name}.");
            string path = Resolve(root, item.Value.GetProperty("file").GetString()!);
            if (!File.Exists(path)) throw new FileNotFoundException($"Missing voice clip: {item.Name}.", path);
            if (!PcmDecoderFactory.IsSupported(path)) throw new InvalidDataException($"Unsupported voice file: {path}.");
            clips.Add(id, path);
        }
        return clips;
    }

    private static string Resolve(string root, string relative)
    {
        string directory = Path.GetFullPath(root) + Path.DirectorySeparatorChar;
        string path = Path.GetFullPath(Path.Combine(directory, relative));
        
        if (!path.StartsWith(directory, StringComparison.Ordinal)) 
            throw new InvalidDataException("Audio path is outside the pack.");
        
        return path;
    }

    internal static void Load(Dictionary<int, string> clips, IMemory? memory)
    {
        StopReplacement();
        if (memory != null)
            foreach (var duration in Durations)
                if (memory.ReadU32(duration.Key) == duration.Value.Replacement) memory.WriteU32(duration.Key, duration.Value.Original);
        
        Durations.Clear();
        
        _clips = clips;
    }

    private static void StopReplacement()
    {
        if (_entry == null) return;
        if (XaRouter.ActiveName == _entry.AudioName) XaRouter.Reset();
        
        AssetApi.Remove(_entry);
        
        _entry = null;
    }

    public static bool StartVoice(CpuContext context, IMemory memory)
    {
        if (memory.ReadU8(0x8013AE80) != 0) return true;
        
        int id = memory.ReadU16(0x80139064) + 0x300;
        
        if (id <= 0x300 || id >= 0x533) return true;
        
        StopReplacement();
        
        if (!_clips.TryGetValue(id, out string? path)) return true;
        
        try
        {
            byte[] bytes = File.ReadAllBytes(path);
            using var decoder = PcmDecoderFactory.Open(path, bytes);
            if (decoder.SampleRate <= 0 || decoder.TotalFrames <= 0) throw new InvalidDataException("Empty voice clip.");
            uint ticks = checked((uint)Math.Ceiling(decoder.TotalFrames * 60.0 / decoder.SampleRate));
            uint config = 0x800BD224u + (uint)(id - 0x300) * 16;
            int file = memory.ReadU8(config + 8), channel = memory.ReadU8(config + 9);
            int sector = checked((int)(memory.ReadU32(config) + memory.ReadU32(0x80138F20)) + channel);
            var entry = AssetApi.ReplaceXa(file, channel & 15, sector, path, () => bytes,
                options => { options.Direct = true; options.OnShorter = ShortPolicy.Silence; }, "sotn.translation");
            uint original = memory.ReadU32(config + 4);
            if (Durations.TryGetValue(config + 4, out var previous) && original == previous.Replacement) original = previous.Original;
            Durations[config + 4] = (original, ticks);
            memory.WriteU32(config + 4, ticks);
            _entry = entry;
        }
        
        catch (Exception error) when (error is not OutOfMemoryException)
        {
            Console.Error.WriteLine($"[translation] Voice {id:X4}: {error.Message}. Original audio retained.");
        }
        
        return true;
    }
}
