using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using RecompOne.Runtime.Hardware;

namespace RecompOne.SoTN.Android
{
    public enum TouchControlMode
    {
        DPad = 0,
        VirtualJoystick = 1
    }

    public class TouchOverlayView : View
    {
        public Action? OnMenuClicked;
        public Action<bool>? OnVisibilityToggled;
        public float TouchOpacity = 0.7f;
        public bool TouchVisible = true;
        public TouchControlMode ControlMode = TouchControlMode.DPad;

        private readonly Paint _fillPaint = new Paint(PaintFlags.AntiAlias);
        private readonly Paint _strokePaint = new Paint(PaintFlags.AntiAlias);
        private readonly Paint _textPaint = new Paint(PaintFlags.AntiAlias);

        // Active pressed states, for visual feedback only.
        private bool _pUp, _pDown, _pLeft, _pRight;
        private bool _pTriangle, _pSquare, _pCircle, _pCross;
        private bool _pL1, _pL2, _pR1, _pR2;
        private bool _pSelect, _pMenu, _pStart, _pToggle;

        private float _knobOffsetX, _knobOffsetY;

        // Safe-area insets. The bottom row used to be drawn underneath the navigation
        // bar in landscape, which is what clipped the d-pad and the SELECT/START row.
        private int _insetL, _insetT, _insetR, _insetB;

        public TouchOverlayView(Context context) : base(context)
        {
            SetBackgroundColor(Color.Transparent);
        }

        public override WindowInsets? OnApplyWindowInsets(WindowInsets? insets)
        {
            if (insets != null)
            {
                _insetL = insets.SystemWindowInsetLeft;
                _insetT = insets.SystemWindowInsetTop;
                _insetR = insets.SystemWindowInsetRight;
                _insetB = insets.SystemWindowInsetBottom;
                Invalidate();
            }
            return base.OnApplyWindowInsets(insets);
        }

        private void RefreshInsets()
        {
            // OnApplyWindowInsets is not guaranteed to have fired before the first draw,
            // so read the current insets defensively too.
            if (Build.VERSION.SdkInt < BuildVersionCodes.M) return;
            try
            {
                var wi = RootWindowInsets;
                if (wi == null) return;
                _insetL = wi.SystemWindowInsetLeft;
                _insetT = wi.SystemWindowInsetTop;
                _insetR = wi.SystemWindowInsetRight;
                _insetB = wi.SystemWindowInsetBottom;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Every rect the overlay draws and hit-tests. Computed in one place so the
        /// touch targets can never drift away from what is painted on screen.
        /// </summary>
        private struct Layout
        {
            public float Density, Btn;
            public RectF Up, Down, Left, Right;
            public RectF Triangle, Cross, Square, Circle;
            public RectF L1, L2, R1, R2;
            public RectF Select, Start, Menu, Toggle;
            public float DpadCX, DpadCY, DpadR;
            public float ActCX, ActCY, ActR;
        }

        private Layout ComputeLayout()
        {
            RefreshInsets();

            var l = new Layout();
            float density = Context?.Resources?.DisplayMetrics?.Density ?? 1f;
            l.Density = density;

            int w = Width, h = Height;
            bool isPortrait = h >= w;

            float margin = 10f * density;
            float left = _insetL + margin;
            float top = _insetT + margin;
            float right = w - _insetR - margin;
            float bottom = h - _insetB - margin;
            float availW = Math.Max(1f, right - left);
            float availH = Math.Max(1f, bottom - top);

            // Scale to the screen instead of using fixed dp, so the cluster always fits
            // between the safe-area edges no matter how short the landscape window is.
            float btn = Math.Clamp(MathF.Min(availW, availH) * 0.155f, 34f * density, 62f * density);
            l.Btn = btn;

            float cluster = btn * 3.0f;
            float half = btn / 2f;
            float gap = 8f * density;

            // Movement cluster, bottom-left.
            float dpadLeft = left;
            float dpadTop = bottom - cluster;
            l.DpadCX = dpadLeft + cluster / 2f;
            l.DpadCY = dpadTop + cluster / 2f;
            l.DpadR = cluster / 2f;

            l.Up    = new RectF(l.DpadCX - half, dpadTop, l.DpadCX + half, dpadTop + btn);
            l.Down  = new RectF(l.DpadCX - half, dpadTop + cluster - btn, l.DpadCX + half, dpadTop + cluster);
            l.Left  = new RectF(dpadLeft, l.DpadCY - half, dpadLeft + btn, l.DpadCY + half);
            l.Right = new RectF(dpadLeft + cluster - btn, l.DpadCY - half, dpadLeft + cluster, l.DpadCY + half);

            // Action cluster, bottom-right.
            float actLeft = right - cluster;
            float actTop = bottom - cluster;
            l.ActCX = actLeft + cluster / 2f;
            l.ActCY = actTop + cluster / 2f;
            l.ActR = cluster / 2f;

            l.Triangle = new RectF(l.ActCX - half, actTop, l.ActCX + half, actTop + btn);
            l.Cross    = new RectF(l.ActCX - half, actTop + cluster - btn, l.ActCX + half, actTop + cluster);
            l.Square   = new RectF(actLeft, l.ActCY - half, actLeft + btn, l.ActCY + half);
            l.Circle   = new RectF(actLeft + cluster - btn, l.ActCY - half, actLeft + cluster, l.ActCY + half);

            // Shoulders sit directly above their cluster, keeping the top-right corner
            // free for the menu and the hide toggle.
            float shW = btn * 1.25f;
            float shH = btn * 0.55f;
            float shBottom = actTop - gap;
            float shTop = shBottom - shH;

            l.L1 = new RectF(left, shTop, left + shW, shBottom);
            l.L2 = new RectF(left + shW + gap, shTop, left + shW * 2f + gap, shBottom);
            l.R2 = new RectF(right - shW * 2f - gap, shTop, right - shW - gap, shBottom);
            l.R1 = new RectF(right - shW, shTop, right, shBottom);

            // SELECT / START. Landscape has a wide empty gap between the clusters, so
            // they go bottom-centre; portrait does not, so they get their own row above
            // the shoulders instead of overlapping them.
            float sysW = btn * 1.5f;
            float sysH = btn * 0.55f;
            float sysCX = (left + right) / 2f;
            float sysBottom = isPortrait ? shTop - gap : bottom;
            float sysTop = sysBottom - sysH;

            l.Select = new RectF(sysCX - sysW - gap / 2f, sysTop, sysCX - gap / 2f, sysBottom);
            l.Start  = new RectF(sysCX + gap / 2f, sysTop, sysCX + sysW + gap / 2f, sysBottom);

            // Menu and the hide/show toggle, top-right in both orientations.
            float menuW = btn * 1.5f;
            float menuH = btn * 0.55f;
            float togW = btn * 1.15f;

            l.Menu = new RectF(right - menuW, top, right, top + menuH);
            l.Toggle = new RectF(l.Menu.Left - gap - togW, top, l.Menu.Left - gap, top + menuH);

            return l;
        }

        public override bool OnTouchEvent(MotionEvent? e)
        {
            if (e == null) return false;

            var l = ComputeLayout();
            if (Width <= 0 || Height <= 0) return false;

            int action = (int)e.ActionMasked;
            int actionIndex = e.ActionIndex;
            bool isDownAction = action == (int)MotionEventActions.Down || action == (int)MotionEventActions.PointerDown;

            bool pUp = false, pDown = false, pLeft = false, pRight = false;
            bool pTriangle = false, pSquare = false, pCircle = false, pCross = false;
            bool pL1 = false, pL2 = false, pR1 = false, pR2 = false;
            bool pSelect = false, pMenu = false, pStart = false, pToggle = false;

            bool menuTriggered = false, toggleTriggered = false;
            bool joystickActive = false;
            float knobX = 0f, knobY = 0f;
            bool hitAnything = false;

            for (int i = 0; i < e.PointerCount; i++)
            {
                // The pointer named by an UP/CANCEL action is leaving, so it must not
                // count as held.
                if ((action == (int)MotionEventActions.PointerUp ||
                     action == (int)MotionEventActions.Up ||
                     action == (int)MotionEventActions.Cancel) && i == actionIndex)
                    continue;

                float px = e.GetX(i);
                float py = e.GetY(i);

                if (l.Menu.Contains(px, py))
                {
                    pMenu = true;
                    hitAnything = true;
                    if (isDownAction) menuTriggered = true;
                    continue;
                }

                if (l.Toggle.Contains(px, py))
                {
                    pToggle = true;
                    hitAnything = true;
                    if (isDownAction) toggleTriggered = true;
                    continue;
                }

                // Everything below is a game control, so it is inert while hidden.
                if (!TouchVisible) continue;

                hitAnything = true;

                float dx = px - l.DpadCX;
                float dy = py - l.DpadCY;
                float dist = MathF.Sqrt(dx * dx + dy * dy);

                if (ControlMode == TouchControlMode.VirtualJoystick)
                {
                    if (dist <= l.DpadR * 1.6f)
                    {
                        joystickActive = true;
                        float maxDrag = l.DpadR * 0.75f;
                        float clamped = MathF.Min(dist, maxDrag);
                        float angle = MathF.Atan2(dy, dx);
                        knobX = MathF.Cos(angle) * clamped;
                        knobY = MathF.Sin(angle) * clamped;

                        float normX = dist > 0f ? (dx / dist) * (clamped / maxDrag) : 0f;
                        float normY = dist > 0f ? (dy / dist) * (clamped / maxDrag) : 0f;

                        if (normX < -0.3f) pLeft = true;
                        if (normX > 0.3f) pRight = true;
                        if (normY < -0.3f) pUp = true;
                        if (normY > 0.3f) pDown = true;

                        Controller.LeftX = (byte)Math.Clamp(128 + (int)(normX * 127f), 0, 255);
                        Controller.LeftY = (byte)Math.Clamp(128 + (int)(normY * 127f), 0, 255);
                    }
                }
                else if (dist <= l.DpadR * 1.4f && dist > 4f * l.Density)
                {
                    // Angular sectors, so diagonals press two directions at once.
                    double deg = Math.Atan2(dy, dx) * (180.0 / Math.PI);
                    if (deg >= -67.5 && deg <= 67.5) pRight = true;
                    if (deg >= 22.5 && deg <= 157.5) pDown = true;
                    if (deg >= 112.5 || deg <= -112.5) pLeft = true;
                    if (deg >= -157.5 && deg <= -22.5) pUp = true;
                }

                float ax = px - l.ActCX;
                float ay = py - l.ActCY;
                if (MathF.Sqrt(ax * ax + ay * ay) <= l.ActR * 1.4f)
                {
                    float sub = l.Btn * 0.6f;
                    float o = l.Btn * 0.9f;
                    if (MathF.Sqrt(ax * ax + (ay + o) * (ay + o)) <= sub || (ay < -l.Btn * 0.3f && MathF.Abs(ax) < l.Btn * 0.85f))
                        pTriangle = true;
                    if (MathF.Sqrt(ax * ax + (ay - o) * (ay - o)) <= sub || (ay > l.Btn * 0.3f && MathF.Abs(ax) < l.Btn * 0.85f))
                        pCross = true;
                    if (MathF.Sqrt((ax + o) * (ax + o) + ay * ay) <= sub || (ax < -l.Btn * 0.3f && MathF.Abs(ay) < l.Btn * 0.85f))
                        pSquare = true;
                    if (MathF.Sqrt((ax - o) * (ax - o) + ay * ay) <= sub || (ax > l.Btn * 0.3f && MathF.Abs(ay) < l.Btn * 0.85f))
                        pCircle = true;
                }

                if (l.L1.Contains(px, py)) pL1 = true;
                if (l.L2.Contains(px, py)) pL2 = true;
                if (l.R1.Contains(px, py)) pR1 = true;
                if (l.R2.Contains(px, py)) pR2 = true;
                if (l.Select.Contains(px, py)) pSelect = true;
                if (l.Start.Contains(px, py)) pStart = true;
            }

            if (ControlMode == TouchControlMode.VirtualJoystick)
            {
                if (joystickActive)
                {
                    _knobOffsetX = knobX;
                    _knobOffsetY = knobY;
                }
                else
                {
                    _knobOffsetX = _knobOffsetY = 0f;
                    Controller.LeftX = 128;
                    Controller.LeftY = 128;
                }
            }
            else
            {
                Controller.LeftX = pLeft ? (byte)0 : pRight ? (byte)255 : (byte)128;
                Controller.LeftY = pUp ? (byte)0 : pDown ? (byte)255 : (byte)128;
            }

            _pUp = pUp; _pDown = pDown; _pLeft = pLeft; _pRight = pRight;
            _pTriangle = pTriangle; _pSquare = pSquare; _pCircle = pCircle; _pCross = pCross;
            _pL1 = pL1; _pL2 = pL2; _pR1 = pR1; _pR2 = pR2;
            _pSelect = pSelect; _pMenu = pMenu; _pStart = pStart; _pToggle = pToggle;

            // Active low: 0 = pressed. Published as the host's own channel so it composes
            // with the physical pad instead of overwriting it.
            ushort state = 0xFFFF;
            if (pUp) state &= unchecked((ushort)~Controller.Up);
            if (pDown) state &= unchecked((ushort)~Controller.Down);
            if (pLeft) state &= unchecked((ushort)~Controller.Left);
            if (pRight) state &= unchecked((ushort)~Controller.Right);
            if (pCross) state &= unchecked((ushort)~Controller.Cross);
            if (pCircle) state &= unchecked((ushort)~Controller.Circle);
            if (pSquare) state &= unchecked((ushort)~Controller.Square);
            if (pTriangle) state &= unchecked((ushort)~Controller.Triangle);
            if (pL1) state &= unchecked((ushort)~Controller.L1);
            if (pL2) state &= unchecked((ushort)~Controller.L2);
            if (pR1) state &= unchecked((ushort)~Controller.R1);
            if (pR2) state &= unchecked((ushort)~Controller.R2);
            if (pSelect) state &= unchecked((ushort)~Controller.Select);
            if (pStart) state &= unchecked((ushort)~Controller.Start);

            Controller.SetExternalState(state);

            if (toggleTriggered)
            {
                TouchVisible = !TouchVisible;
                if (!TouchVisible) Controller.SetExternalState(0xFFFF);
                OnVisibilityToggled?.Invoke(TouchVisible);
            }

            Invalidate();

            if (menuTriggered) OnMenuClicked?.Invoke();

            // While hidden, let touches that missed our two buttons fall through.
            return TouchVisible || hitAnything;
        }

        protected override void OnDraw(Canvas? canvas)
        {
            base.OnDraw(canvas);
            if (canvas == null || Width <= 0 || Height <= 0) return;

            var l = ComputeLayout();
            float density = l.Density;

            int alphaNorm = (int)(128 * TouchOpacity);
            int alphaHigh = (int)(220 * TouchOpacity);

            void DrawBtn(RectF rect, string label, Color textColor, bool pressed, float textDp = 14f, float cornerDp = 25f)
            {
                _fillPaint.Color = pressed ? Color.Argb(alphaHigh, 100, 100, 240) : Color.Argb(alphaNorm, 40, 40, 40);
                canvas.DrawRoundRect(rect, cornerDp * density, cornerDp * density, _fillPaint);

                _strokePaint.Color = pressed ? Color.White : Color.Argb(180, 200, 200, 200);
                _strokePaint.SetStyle(Paint.Style.Stroke);
                _strokePaint.StrokeWidth = 1.5f * density;
                canvas.DrawRoundRect(rect, cornerDp * density, cornerDp * density, _strokePaint);

                _textPaint.Color = textColor;
                _textPaint.TextSize = textDp * density;
                _textPaint.TextAlign = Paint.Align.Center;
                var fm = _textPaint.GetFontMetrics();
                canvas.DrawText(label, rect.CenterX(), rect.CenterY() - (fm.Ascent + fm.Descent) / 2f, _textPaint);
            }

            if (TouchVisible)
            {
                if (ControlMode == TouchControlMode.VirtualJoystick)
                {
                    _fillPaint.Color = Color.Argb(alphaNorm, 30, 30, 30);
                    canvas.DrawCircle(l.DpadCX, l.DpadCY, l.DpadR, _fillPaint);

                    _strokePaint.Color = Color.Argb(180, 200, 200, 200);
                    _strokePaint.SetStyle(Paint.Style.Stroke);
                    _strokePaint.StrokeWidth = 2f * density;
                    canvas.DrawCircle(l.DpadCX, l.DpadCY, l.DpadR, _strokePaint);

                    _strokePaint.Color = Color.Argb(100, 150, 150, 150);
                    _strokePaint.StrokeWidth = 1f * density;
                    canvas.DrawCircle(l.DpadCX, l.DpadCY, l.DpadR * 0.4f, _strokePaint);

                    float kx = l.DpadCX + _knobOffsetX;
                    float ky = l.DpadCY + _knobOffsetY;
                    float knobR = l.Btn * 0.6f;
                    bool active = _knobOffsetX != 0f || _knobOffsetY != 0f;

                    _fillPaint.Color = active ? Color.Argb(alphaHigh, 80, 140, 255) : Color.Argb(alphaHigh, 70, 70, 70);
                    canvas.DrawCircle(kx, ky, knobR, _fillPaint);

                    _strokePaint.Color = Color.White;
                    _strokePaint.StrokeWidth = 2f * density;
                    canvas.DrawCircle(kx, ky, knobR, _strokePaint);
                }
                else
                {
                    DrawBtn(l.Up, "▲", Color.White, _pUp);
                    DrawBtn(l.Down, "▼", Color.White, _pDown);
                    DrawBtn(l.Left, "◄", Color.White, _pLeft);
                    DrawBtn(l.Right, "►", Color.White, _pRight);
                }

                DrawBtn(l.Triangle, "Δ", Color.Rgb(60, 220, 100), _pTriangle);
                DrawBtn(l.Square, "□", Color.Rgb(240, 100, 180), _pSquare);
                DrawBtn(l.Circle, "O", Color.Rgb(240, 60, 60), _pCircle);
                DrawBtn(l.Cross, "X", Color.Rgb(80, 140, 240), _pCross);

                DrawBtn(l.L1, "L1", Color.White, _pL1, 13f, 15f);
                DrawBtn(l.L2, "L2", Color.White, _pL2, 13f, 15f);
                DrawBtn(l.R1, "R1", Color.White, _pR1, 13f, 15f);
                DrawBtn(l.R2, "R2", Color.White, _pR2, 13f, 15f);

                DrawBtn(l.Select, "SELECT", Color.White, _pSelect, 12f, 15f);
                DrawBtn(l.Start, "START", Color.White, _pStart, 12f, 15f);
            }

            // Menu and the hide/show toggle stay on screen even when the controls are
            // hidden, otherwise there would be no way to bring them back.
            // Plain text rather than emoji: colour-emoji glyphs fall back to tofu boxes
            // on some devices' default Paint typeface.
            DrawAccented(canvas, l.Menu, "⚙ MENU", Color.Yellow, _pMenu, 12f, density, alphaHigh);
            DrawAccented(canvas, l.Toggle, TouchVisible ? "HIDE" : "SHOW", Color.Cyan, _pToggle, 12f, density, alphaHigh);
        }

        private void DrawAccented(Canvas canvas, RectF rect, string label, Color accent, bool pressed,
                                  float textDp, float density, int alphaHigh)
        {
            _fillPaint.Color = pressed
                ? Color.Argb(alphaHigh, 120, 120, 40)
                : Color.Argb((int)(180 * TouchOpacity), 20, 20, 20);
            canvas.DrawRoundRect(rect, 15f * density, 15f * density, _fillPaint);

            _strokePaint.Color = accent;
            _strokePaint.SetStyle(Paint.Style.Stroke);
            _strokePaint.StrokeWidth = 1.5f * density;
            canvas.DrawRoundRect(rect, 15f * density, 15f * density, _strokePaint);

            _textPaint.Color = accent;
            _textPaint.TextSize = textDp * density;
            _textPaint.TextAlign = Paint.Align.Center;
            var fm = _textPaint.GetFontMetrics();
            canvas.DrawText(label, rect.CenterX(), rect.CenterY() - (fm.Ascent + fm.Descent) / 2f, _textPaint);
        }
    }
}
