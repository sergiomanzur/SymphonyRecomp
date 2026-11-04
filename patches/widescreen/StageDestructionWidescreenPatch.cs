using RecompOne.Runtime.Events;
using RecompOne.Runtime.Hle;
using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch
{
    const int DestructionCaptureOrder = 0x67;
    const int DestructionTileOrder = 0x6C;
    const int DestructionTileW = 17;
    const int DestructionTileH = 16;
    const int DestructionRows = 15;
    const int DestructionColumns = 15;
    const int DestructionScreen = 0x80;
    const int DestructionFarZ = 0x180;

    sealed class DestructionTile
    {
        public int X, Y;
        public int OffsetX, OffsetY, Z = DestructionScreen;
        public int SpinX, SpinY, AngleX, AngleY;
        public int Delay;
        public bool Done;
    }

    static List<DestructionTile>? _destruction;
    static int _destructionImage = -1;
    static int _destructionLeft, _destructionTop, _destructionWidth, _destructionHeight;
    static bool _destructionMoving;
    static readonly Random _destructionRandom = new();

    static void ExtendStageDestruction(TilemapRenderedEvent e)
    {
        var m = e.Memory;
        if (OriginalAspect || Margin <= 0 || !IsSt0(m))
        {
            StopDestruction();
            return;
        }

        uint entity = DestructionEntity(m);
        int step = entity == 0 ? -1 : m.ReadU16(entity + EntStep);

        if (_destruction == null)
        {
            if (step == 4) BeginDestruction(m);
            return;
        }

        if (step == 7 || (entity == 0 && !_destructionMoving))
        {
            StopDestruction();
            return;
        }

        bool ready = GpuPrims.TryGetCapture(_destructionImage, out var capture);
        if (ready)
        {
            _destructionLeft = -capture.Margin;
            _destructionWidth = capture.Width + capture.Margin * 2;
            _destructionHeight = capture.Height;
            GpuPrims.SetOrderingTable(m.ReadU32(CurrentBufferPtr) + OtOfs, OtSize);
        }

        if (!_destructionMoving)
        {
            if (step == 6) StartDestructionMotion();
            if (ready)
                foreach (var tile in _destruction)
                    DrawDestructionFlat(tile);
            return;
        }

        var active = false;
        foreach (var tile in _destruction)
        {
            if (tile.Done) continue;
            active = true;
            if (!ready) continue;
            if (tile.Delay > 0) DrawDestructionFlat(tile);
            else DrawDestructionProjected(tile);
        }

        foreach (var tile in _destruction)
        {
            if (tile.Done) continue;
            if (tile.Delay > 0)
            {
                tile.Delay--;
                continue;
            }

            tile.AngleX += tile.SpinX;
            tile.AngleY += tile.SpinY;
            tile.Z += 3;
            if (tile.Z > DestructionFarZ) tile.Done = true;
        }

        if (!active) StopDestruction();
    }

    static uint DestructionEntity(IMemory m)
    {
        uint update = StageSym(m, "func_801BD8F0").Addr;
        if (update == 0) return 0;
        for (int i = StageEntityStart; i < TotalEntityCount; i++)
        {
            uint entity = PedAt(i);
            if (m.ReadU32(entity + EntPfnUpdate) == update) return entity;
        }
        return 0;
    }

    static void BeginDestruction(IMemory m)
    {
        GpuPrims.SetOrderingTable(m.ReadU32(CurrentBufferPtr) + OtOfs, OtSize);
        _destructionTop = Zoomed ? StageViewTop : 0;
        _destructionImage = GpuPrims.Capture(DestructionCaptureOrder, DestructionOverlays(m));
        if (_destructionImage < 0) return;

        _destruction = [];
        _destructionMoving = false;
        for (int column = -1; column * DestructionTileW + DestructionTileW > ViewLeft; column--)
            AddDestructionColumn(column);
        for (int column = DestructionColumns; column * DestructionTileW < ViewRight; column++)
            AddDestructionColumn(column);
    }

    static void AddDestructionColumn(int column)
    {
        for (int row = 0; row < DestructionRows; row++)
            _destruction!.Add(new DestructionTile { X = column * DestructionTileW, Y = row * DestructionTileH });
    }

    static void StartDestructionMotion()
    {
        foreach (var tile in _destruction!)
        {
            int x = tile.X + 8 - DestructionScreen;
            int y = tile.Y + 8 - DestructionScreen;
            tile.OffsetX = x;
            tile.OffsetY = y;
            tile.Z = DestructionScreen;

            double angle = Math.Atan2(y, x);
            int distance = (int)Math.Sqrt(x * x + y * y);
            int falloff = 0xC0 - distance;
            int spinX = (int)Math.Round(Math.Sin(angle) * 4096) * 0x24;
            int spinY = (int)Math.Round(Math.Cos(angle) * 4096) * 0x24;
            tile.SpinX = spinX * falloff / 0xC0 >> 12;
            tile.SpinY = spinY * falloff / 0xC0 >> 12;
            tile.Delay = Math.Max(0, distance * 3 / 2 - (_destructionRandom.Next() & 0x1F));
        }

        _destructionMoving = true;
    }

    static void StopDestruction()
    {
        if (_destructionImage >= 0) GpuPrims.ReleaseImage(_destructionImage);
        _destructionImage = -1;
        _destruction = null;
        _destructionMoving = false;
    }

    static PrimVertex DestructionVertex(float x, float y, int sourceX, int sourceY) =>
        new(x, y, (sourceX - _destructionLeft) / (float)_destructionWidth,
            (sourceY - _destructionTop) / (float)_destructionHeight);

    static void DrawDestructionFlat(DestructionTile tile)
    {
        int x0 = tile.X, x1 = tile.X + DestructionTileW, y0 = tile.Y, y1 = tile.Y + DestructionTileH;
        GpuPrims.Quad(DestructionTileOrder,
            DestructionVertex(x0, y0, x0, y0), DestructionVertex(x1, y0, x1, y0),
            DestructionVertex(x0, y1, x0, y1), DestructionVertex(x1, y1, x1, y1),
            _destructionImage);
    }

    static void DrawDestructionProjected(DestructionTile tile)
    {
        double ax = tile.AngleX * Math.PI * 2 / 4096, ay = tile.AngleY * Math.PI * 2 / 4096;
        double cx = Math.Cos(ax), sx = Math.Sin(ax), cy = Math.Cos(ay), sy = Math.Sin(ay);

        (float X, float Y) Project(int px, int py)
        {
            double rx = px * cy + py * sx * sy;
            double ry = py * cx;
            double rz = -px * sy + py * sx * cy;
            double z = rz + tile.Z;
            if (z < 1) z = 1;
            return ((float)(DestructionScreen + (rx + tile.OffsetX) * DestructionScreen / z),
                (float)(DestructionScreen + (ry + tile.OffsetY) * DestructionScreen / z));
        }

        var a = Project(-8, -8);
        var b = Project(8, -8);
        var c = Project(-8, 8);
        var d = Project(8, 8);
        int u0 = tile.X, u1 = tile.X + DestructionTileW, v0 = tile.Y, v1 = tile.Y + DestructionTileH;
        GpuPrims.Quad(DestructionTileOrder,
            DestructionVertex(a.X, a.Y, u0, v0), DestructionVertex(b.X, b.Y, u1, v0),
            DestructionVertex(c.X, c.Y, u0, v1), DestructionVertex(d.X, d.Y, u1, v1),
            _destructionImage);
    }

    static CaptureOverlay[] DestructionOverlays(IMemory m)
    {
        if (!ReadLayer(m, TilemapAddr, out var foreground)) return [];
        return RoomFills.ForegroundImages(m, foreground.ScrollX, foreground.ScrollY)
            .Select(image => new CaptureOverlay(image.Rgba, image.Width, image.Height, image.X, image.Y - _destructionTop))
            .ToArray();
    }
}
