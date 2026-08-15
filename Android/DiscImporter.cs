using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Android.Content;
using Android.OS;
using RecompOne.Runtime.Cdrom;

namespace RecompOne.SoTN.Android
{
    /// <summary>
    /// Owns the player's disc image: where it lives, whether it is usable, and how files
    /// chosen from the system picker get copied in.
    ///
    /// The APK ships with no game data, so on a fresh install there is nothing to boot until
    /// the player supplies their own dump. Everything here is deliberately UI-free so the
    /// activity can drive it from a background thread and report progress however it likes.
    /// </summary>
    public static class DiscImporter
    {
        /// <summary>The boot executable on a North American pressing.</summary>
        private const string UsExecutable = "SLUS_000.67";

        /// <summary>Other pressings we can name, so the player gets a useful error rather than "unreadable".</summary>
        private static readonly (string File, string Message)[] KnownRegions =
        {
            ("SLPM_860.23", "That is a Japanese copy. This build needs the North American (USA) release."),
            ("SLES_005.24", "That is a European copy. This build needs the North American (USA) release."),
        };

        /// <summary>Rough headroom demanded on top of the disc itself before copying.</summary>
        private const long FreeSpaceMargin = 64L * 1024 * 1024;

        // FILE "name.bin" BINARY  -> captures the prefix, the quoted-or-bare name, and the tail.
        private static readonly Regex FileLine =
            new(@"^(\s*FILE\s+)(""[^""]*""|\S+)(\s+\S+\s*)$",
                RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

        // --- Locations -------------------------------------------------------------------

        /// <summary>
        /// Where an imported disc is kept: the app's own folder on shared storage. It needs no
        /// runtime permission, is visible over USB so a player can drop files in by hand, and
        /// is removed when the app is uninstalled.
        /// </summary>
        public static string TargetDir(Context context)
        {
            string? external = null;
            try { external = context.GetExternalFilesDir(null)?.AbsolutePath; } catch { }
            if (string.IsNullOrWhiteSpace(external))
                external = context.FilesDir?.Path ?? "";
            return Path.Combine(external, "disc");
        }

        /// <summary>
        /// Everywhere a disc might already be, newest convention first. Players who sideloaded
        /// files by hand before this screen existed are still found.
        /// </summary>
        public static IEnumerable<string> SearchDirs(Context context)
        {
            yield return TargetDir(context);

            string files = context.FilesDir?.Path ?? "";
            if (files.Length > 0) yield return Path.Combine(files, "disc");

            string? ext = null;
            try { ext = global::Android.OS.Environment.ExternalStorageDirectory?.AbsolutePath; } catch { }
            if (!string.IsNullOrWhiteSpace(ext))
            {
                yield return Path.Combine(ext, "SymphonyRecomp", "disc");
                yield return Path.Combine(ext, "disc");
            }
        }

        // --- Cue handling ----------------------------------------------------------------

        /// <summary>The track filenames a cue names, in order, with any directory part stripped.</summary>
        public static List<string> ReferencedTracks(string cueText)
        {
            var names = new List<string>();
            foreach (Match m in FileLine.Matches(cueText))
            {
                string raw = m.Groups[2].Value.Trim();
                if (raw.Length >= 2 && raw[0] == '"' && raw[^1] == '"') raw = raw[1..^1];
                raw = raw.Replace('\\', '/');
                int slash = raw.LastIndexOf('/');
                if (slash >= 0) raw = raw[(slash + 1)..];
                if (raw.Length > 0) names.Add(raw);
            }
            return names;
        }

        /// <summary>
        /// Rewrites every FILE line to name the file as it was actually written to disk.
        /// A cue that points at absolute paths, at a subfolder, or at a differently-cased
        /// filename would otherwise fail to open once copied.
        /// </summary>
        public static string RewriteCue(string cueText, IReadOnlyList<string> actualNames)
        {
            int i = 0;
            return FileLine.Replace(cueText, m =>
            {
                if (i >= actualNames.Count) return m.Value;
                string name = actualNames[i++];
                return $"{m.Groups[1].Value}\"{name}\"{m.Groups[3].Value}";
            });
        }

        /// <summary>
        /// Cheap check used on every launch: the cue exists and each track it names sits
        /// beside it with real bytes in it. Deliberately avoids parsing the ISO, which would
        /// add a noticeable pause to startup.
        /// </summary>
        public static bool LooksComplete(string cuePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cuePath) || !File.Exists(cuePath)) return false;
                string dir = Path.GetDirectoryName(cuePath) ?? "";
                var tracks = ReferencedTracks(File.ReadAllText(cuePath));
                if (tracks.Count == 0) return false;

                foreach (var t in tracks)
                {
                    string p = Path.Combine(dir, t);
                    if (!File.Exists(p) || new FileInfo(p).Length == 0) return false;
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// The thorough check, run once at import: actually mount the image and confirm it is
        /// the North American Symphony of the Night. Returns null when the disc is good, or a
        /// player-facing explanation when it is not.
        /// </summary>
        public static string? Validate(string cuePath)
        {
            if (!File.Exists(cuePath)) return "The .cue file could not be found.";

            CueFs? fs = null;
            try
            {
                fs = CueFs.Open(cuePath);
            }
            catch
            {
                fs?.Dispose();
                return "That .cue could not be read as a disc image. Check that its .bin tracks were selected too.";
            }

            try
            {
                if (fs.FindFile(UsExecutable) != null) return null;
                foreach (var (file, message) in KnownRegions)
                    if (fs.FindFile(file) != null) return message;
                return "That disc is readable but does not look like Castlevania: Symphony of the Night (USA).";
            }
            catch
            {
                return "That disc image could not be read.";
            }
            finally { fs.Dispose(); }
        }

        /// <summary>The first usable disc across every known location, or null if there is none.</summary>
        public static string? FindExisting(Context context)
        {
            foreach (var dir in SearchDirs(context))
            {
                if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir)) continue;
                string[] cues;
                try { cues = Directory.GetFiles(dir, "*.cue"); } catch { continue; }

                foreach (var cue in cues)
                    if (LooksComplete(cue)) return cue;
            }
            return null;
        }

        // --- Import ----------------------------------------------------------------------

        /// <summary>One file the player selected, named and sized but not yet read.</summary>
        public sealed class Picked
        {
            public required string Name { get; init; }
            public required long Size { get; init; }
            public required Func<Stream?> Open { get; init; }
        }

        public sealed class ImportResult
        {
            public bool Success { get; init; }
            public string? CuePath { get; init; }
            public string? Error { get; init; }
        }

        public static long AvailableBytes(string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
                var st = new StatFs(dir);
                return st.AvailableBytes;
            }
            catch { return long.MaxValue; } // never block the import on a failed probe
        }

        public static string Humanise(long bytes) =>
            bytes >= 1L << 30 ? $"{bytes / (double)(1L << 30):0.#} GB"
                              : $"{bytes / (double)(1L << 20):0} MB";

        /// <summary>
        /// Copies a chosen cue and its tracks into app storage, rewrites the cue to match what
        /// was written, and verifies the result before accepting it.
        /// </summary>
        /// <param name="progress">Called with a status line and 0-100 completion.</param>
        public static ImportResult Import(Context context, IReadOnlyList<Picked> picked,
                                          Action<string, int> progress, CancellationToken cancel = default)
        {
            var cue = picked.FirstOrDefault(p => p.Name.EndsWith(".cue", StringComparison.OrdinalIgnoreCase));
            if (cue == null)
                return Fail("No .cue file was selected. Pick the .cue together with its .bin tracks.");

            // Read the cue first: it names the tracks, so it decides what else has to come along.
            string cueText;
            try
            {
                using var s = cue.Open();
                if (s == null) return Fail("The .cue file could not be opened.");
                using var r = new StreamReader(s);
                cueText = r.ReadToEnd();
            }
            catch (Exception e) { return Fail($"The .cue file could not be read: {e.Message}"); }

            var wanted = ReferencedTracks(cueText);
            if (wanted.Count == 0)
                return Fail("That .cue does not list any tracks, so it cannot be used.");

            // Match each track the cue names against what was actually selected.
            var matched = new List<Picked>();
            var missing = new List<string>();
            foreach (var name in wanted)
            {
                var hit = picked.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
                if (hit == null) missing.Add(name);
                else matched.Add(hit);
            }

            if (missing.Count > 0)
                return Fail($"These tracks are named by the .cue but were not selected:\n\n{string.Join("\n", missing)}\n\nSelect the .cue and every .bin together.");

            string target = TargetDir(context);
            long needed = matched.Sum(m => Math.Max(0, m.Size)) + FreeSpaceMargin;
            long free = AvailableBytes(target);
            if (free < needed)
                return Fail($"Not enough free space. This disc needs about {Humanise(needed)} and only {Humanise(free)} is available.");

            // Copy into a staging folder so a failed or cancelled import cannot leave a
            // half-written disc behind that would look complete on the next launch.
            string staging = target + ".importing";
            try
            {
                if (Directory.Exists(staging)) Directory.Delete(staging, true);
                Directory.CreateDirectory(staging);
            }
            catch (Exception e) { return Fail($"Could not prepare storage: {e.Message}"); }

            try
            {
                long total = Math.Max(1, matched.Sum(m => Math.Max(0, m.Size)));
                long done = 0;
                var written = new List<string>();

                foreach (var track in matched)
                {
                    cancel.ThrowIfCancellationRequested();

                    string safe = SafeName(track.Name);
                    string dest = Path.Combine(staging, safe);
                    progress($"Copying {safe}", (int)(done * 100 / total));

                    using (var src = track.Open())
                    {
                        if (src == null) return Fail($"{track.Name} could not be opened.");
                        using var dst = File.Create(dest);

                        var buffer = new byte[1 << 20];
                        int read;
                        long sinceReport = 0;
                        while ((read = src.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cancel.ThrowIfCancellationRequested();
                            dst.Write(buffer, 0, read);
                            done += read;
                            sinceReport += read;
                            if (sinceReport >= 8L << 20) // report every 8 MB, not every block
                            {
                                sinceReport = 0;
                                progress($"Copying {safe}", (int)Math.Min(99, done * 100 / total));
                            }
                        }
                    }

                    written.Add(safe);
                }

                // Point the cue at the names actually written, then verify the whole thing.
                progress("Checking the disc", 99);
                string cueName = SafeName(cue.Name);
                string cuePath = Path.Combine(staging, cueName);
                File.WriteAllText(cuePath, RewriteCue(cueText, written), new UTF8Encoding(false));

                if (Validate(cuePath) is { } problem)
                {
                    TryDelete(staging);
                    return Fail(problem);
                }

                // Swap staging into place only once it is known good.
                if (Directory.Exists(target)) Directory.Delete(target, true);
                Directory.Move(staging, target);

                return new ImportResult { Success = true, CuePath = Path.Combine(target, cueName) };
            }
            catch (System.OperationCanceledException)
            {
                TryDelete(staging);
                return Fail("Import cancelled.");
            }
            catch (Exception e)
            {
                TryDelete(staging);
                return Fail($"The disc could not be copied: {e.Message}");
            }
        }

        private static ImportResult Fail(string message) => new() { Success = false, Error = message };

        private static void TryDelete(string dir)
        {
            try { if (Directory.Exists(dir)) Directory.Delete(dir, true); } catch { }
        }

        /// <summary>Strips anything that would escape the target folder or upset the filesystem.</summary>
        private static string SafeName(string name)
        {
            name = name.Replace('\\', '/');
            int slash = name.LastIndexOf('/');
            if (slash >= 0) name = name[(slash + 1)..];
            foreach (char c in Path.GetInvalidFileNameChars()) name = name.Replace(c, '_');
            return name.Length == 0 ? "disc.bin" : name;
        }
    }
}
