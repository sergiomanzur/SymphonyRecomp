using System.Globalization;
using System.Text;

namespace Recompiled.Translation;

internal static class ScriptYaml
{
    public static List<string[]> Read(string text, string key)
    {
        var rows = new List<string[]>();
        bool inside = false;
        bool found = false;
        int line = 0;
        var lines = text.Replace("\r\n", "\n").Split('\n');
        while (line < lines.Length)
        {
            string current = StripComment(lines[line]);
            int number = ++line;
            if (current.Trim().Length == 0) continue;

            if (!char.IsWhiteSpace(current[0]) && !current.StartsWith('-'))
            {
                int colon = current.IndexOf(':');
                if (colon < 0) throw Error(number, "expected a top-level key.");
                inside = current[..colon].Trim() == key;
                found |= inside;
                if (inside && current[(colon + 1)..].Trim().Length != 0) throw Error(number, $"{key} must be a block list.");
                continue;
            }
            if (!inside) continue;

            string item = current.TrimStart();
            if (!item.StartsWith('-')) throw Error(number, "expected a list item.");
            var flow = new StringBuilder(item[1..].Trim());
            while (!Balanced(flow.ToString()))
            {
                if (line >= lines.Length) throw Error(number, "unterminated row.");
                flow.Append(' ').Append(StripComment(lines[line++]).Trim());
            }
            rows.Add(Row(flow.ToString(), number));
        }
        if (!found) throw new InvalidDataException($"Missing '{key}:' list.");
        return rows;
    }

    public static long Number(string value)
    {
        string text = value.Trim();
        bool negative = text.StartsWith('-');
        if (negative || text.StartsWith('+')) text = text[1..];
        long result = text.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
            ? long.Parse(text[2..], NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture)
            : long.Parse(text, NumberStyles.None, CultureInfo.InvariantCulture);
        return negative ? -result : result;
    }

    public static bool IsNumber(string value)
    {
        try { Number(value); return true; }
        catch (FormatException) { return false; }
        catch (OverflowException) { return false; }
    }

    private static string[] Row(string flow, int line)
    {
        if (!flow.StartsWith('[') || !flow.EndsWith(']')) throw Error(line, "rows must be written as [COMMAND, arguments...].");
        var values = new List<string>();
        int i = 1;
        int end = flow.Length - 1;
        while (true)
        {
            while (i < end && flow[i] == ' ') i++;
            if (i >= end)
            {
                if (values.Count != 0) throw Error(line, "trailing comma.");
                break;
            }
            string value;
            if (flow[i] == '"') value = DoubleQuoted(flow, ref i, line);
            else if (flow[i] == '\'') value = SingleQuoted(flow, ref i, line);
            else
            {
                int start = i;
                while (i < end && flow[i] != ',') i++;
                value = flow[start..i].Trim();
                if (value.Length == 0) throw Error(line, "empty value.");
            }
            values.Add(value);
            while (i < end && flow[i] == ' ') i++;
            if (i >= end) break;
            if (flow[i] != ',') throw Error(line, "expected ',' between values.");
            i++;
        }
        if (values.Count == 0) throw Error(line, "empty row.");
        return values.ToArray();
    }

    private static string DoubleQuoted(string flow, ref int i, int line)
    {
        var output = new StringBuilder();
        for (i++; i < flow.Length; i++)
        {
            char c = flow[i];
            if (c == '"') { i++; return output.ToString(); }
            if (c != '\\') { output.Append(c); continue; }
            if (++i >= flow.Length) break;
            switch (flow[i])
            {
                case '0': output.Append('\0'); break;
                case 'a': output.Append('\a'); break;
                case 'b': output.Append('\b'); break;
                case 't': output.Append('\t'); break;
                case 'n': output.Append('\n'); break;
                case 'v': output.Append('\v'); break;
                case 'f': output.Append('\f'); break;
                case 'r': output.Append('\r'); break;
                case 'e': output.Append('\x1B'); break;
                case ' ': output.Append(' '); break;
                case '"': output.Append('"'); break;
                case '/': output.Append('/'); break;
                case '\\': output.Append('\\'); break;
                case 'N': output.Append('\x85'); break;
                case '_': output.Append('\xA0'); break;
                case 'L': output.Append('\u2028'); break;
                case 'P': output.Append('\u2029'); break;
                case 'x': output.Append(Hex(flow, ref i, 2, line)); break;
                case 'u': output.Append(Hex(flow, ref i, 4, line)); break;
                case 'U': output.Append(Hex(flow, ref i, 8, line)); break;
                default: throw Error(line, $"unknown escape \\{flow[i]}.");
            }
        }
        throw Error(line, "unterminated string.");
    }

    private static string Hex(string flow, ref int i, int digits, int line)
    {
        if (i + digits >= flow.Length) throw Error(line, "truncated escape.");
        int value = int.Parse(flow.AsSpan(i + 1, digits), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
        i += digits;
        return char.ConvertFromUtf32(value);
    }

    private static string SingleQuoted(string flow, ref int i, int line)
    {
        var output = new StringBuilder();
        for (i++; i < flow.Length; i++)
        {
            if (flow[i] != '\'') { output.Append(flow[i]); continue; }
            if (i + 1 < flow.Length && flow[i + 1] == '\'') { output.Append('\''); i++; continue; }
            i++;
            return output.ToString();
        }
        throw Error(line, "unterminated string.");
    }

    private static bool Balanced(string flow)
    {
        int depth = 0;
        char quote = '\0';
        for (int i = 0; i < flow.Length; i++)
        {
            char c = flow[i];
            if (quote == '"')
            {
                if (c == '\\') i++;
                else if (c == '"') quote = '\0';
            }
            else if (quote == '\'')
            {
                if (c == '\'') quote = '\0';
            }
            else if (c is '"' or '\'') quote = c;
            else if (c == '[') depth++;
            else if (c == ']') depth--;
        }
        return depth <= 0 && quote == '\0';
    }

    private static string StripComment(string line)
    {
        char quote = '\0';
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (quote == '"')
            {
                if (c == '\\') i++;
                else if (c == '"') quote = '\0';
            }
            else if (quote == '\'')
            {
                if (c == '\'') quote = '\0';
            }
            else if (c is '"' or '\'') quote = c;
            else if (c == '#' && (i == 0 || char.IsWhiteSpace(line[i - 1]))) return line[..i];
        }
        return line;
    }

    private static InvalidDataException Error(int line, string message) => new($"line {line}: {message}");
}
