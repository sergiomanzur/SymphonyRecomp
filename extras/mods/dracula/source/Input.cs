using Sotn;

namespace DraculaMod;

/// <summary>Which button opens Dracula's moveset. Configurable, because one of these may clash with a rebind.</summary>
public enum Modifier
{
    Circle = 0,
    L2 = 1,
    R2 = 2,
}

/// <summary>
/// Reads the pad for Dracula's moves.
///
/// Circle is the default modifier for a checked reason: sweeping the pad reads in the DRA
/// overlay, mask 0x0020 is only ever tested against 0x7498/0x749C - the *second* controller.
/// Pad one never tests Circle, so it is genuinely free during Alucard gameplay and binding to
/// it takes nothing away. L1 and R1 both looked tempting and both turned out to be taken
/// (backdash among them), which is why they are not offered.
///
/// Every move is a modifier + direction tap, so nothing waits for a release and the main
/// attack has no charge latency.
/// </summary>
public static class Input
{
    public static Modifier Mod = Modifier.Circle;

    static ushort _prevPressed;

    public static Button ModButton => Mod switch
    {
        Modifier.L2 => Button.L2,
        Modifier.R2 => Button.R2,
        _ => Button.Circle,
    };

    public static void Reset() => _prevPressed = 0;

    /// <summary>Call once per frame, before asking anything else.</summary>
    public static void Sample()
    {
        _prevPressed = Held;
    }

    public static ushort Held => Game.Available ? Game.Pressed : (ushort)0;

    static bool Down(Button b) => (Held & (ushort)b) != 0;
    static bool WasDown(Button b) => (_prevPressed & (ushort)b) != 0;

    /// <summary>
    /// Rising edge computed from held state rather than the game's own tapped word, so the
    /// mod never competes with vanilla for a consumed tap.
    /// </summary>
    static bool Pressed(Button b) => Down(b) && !WasDown(b);

    public static bool ModifierHeld => Down(ModButton);
    public static bool ModifierPressed => Pressed(ModButton);

    public static bool Up => Down(Button.Up);
    public static bool DownDir => Down(Button.Down);
    public static bool Left => Down(Button.Left);
    public static bool Right => Down(Button.Right);
    public static bool AnyHorizontal => Left || Right;

    /// <summary>-1 left, +1 right, 0 neither. Falls back to the way the player is facing.</summary>
    public static int Facing
    {
        get
        {
            if (Left) return -1;
            if (Right) return 1;
            return Player.FacingLeft ? -1 : 1;
        }
    }
}
