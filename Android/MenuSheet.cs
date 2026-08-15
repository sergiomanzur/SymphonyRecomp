using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RecompOne.SoTN.Android
{
    /// <summary>
    /// The in-game menu chrome, built to look like it belongs to Symphony of the Night
    /// rather than like a stock Android dialog: near-black navy panels, aged gold rules,
    /// a serif title and an ornamental divider lifted from the game's own menus.
    ///
    /// Slides in from the right in landscape, where it stays under the thumb on a handheld
    /// and leaves most of the game visible, and rises as a bottom sheet in portrait.
    /// </summary>
    public sealed class MenuSheet
    {
        // Palette, taken from SoTN's menu chrome rather than from Material.
        public static readonly Color Ink = Color.ParseColor("#0B0E1A"); // panel base
        public static readonly Color Slate = Color.ParseColor("#141A2E"); // pressed row
        public static readonly Color Gold = Color.ParseColor("#C9A227"); // primary accent
        public static readonly Color GoldDim = Color.ParseColor("#7C6520"); // rules, chevrons
        public static readonly Color Parchment = Color.ParseColor("#E8DCC0"); // body text
        public static readonly Color Mist = Color.ParseColor("#8A93B0"); // secondary text
        public static readonly Color Blood = Color.ParseColor("#B4303F"); // destructive

        private readonly Activity _activity;
        private readonly string _title;
        private readonly string? _subtitle;
        private readonly List<Action<LinearLayout>> _rows = new();
        private Action? _onBack;
        private string _backLabel = "Close";

        // The live dialog, so a row can close this sheet before opening the next one.
        // Without this the sheets stack and Back/Close only peel off one layer at a time.
        private Dialog? _dialog;

        public MenuSheet(Activity activity, string title, string? subtitle = null)
        {
            _activity = activity;
            _title = title;
            _subtitle = subtitle;
        }

        private float Dp(float v) => v * (_activity.Resources?.DisplayMetrics?.Density ?? 1f);
        private int DpI(float v) => (int)(Dp(v) + 0.5f);

        /// <summary>A quiet caption that groups the rows beneath it.</summary>
        public MenuSheet Section(string label)
        {
            _rows.Add(parent =>
            {
                var tv = new TextView(_activity)
                {
                    Text = label.ToUpperInvariant(),
                    LetterSpacing = 0.18f,
                    TextSize = 11f,
                };
                tv.SetTextColor(Mist);
                tv.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
                tv.SetPadding(DpI(20), DpI(18), DpI(20), DpI(6));
                parent.AddView(tv);
            });
            return this;
        }

        /// <summary>A tappable row. <paramref name="value"/> shows the current setting on the right.</summary>
        public MenuSheet Item(string label, string? value, Action onClick, bool danger = false)
        {
            _rows.Add(parent => parent.AddView(BuildRow(label, value, onClick, danger, null)));
            return this;
        }

        public MenuSheet Item(string label, Action onClick) => Item(label, null, onClick);

        /// <summary>A destructive row - reset, delete - marked in blood red.</summary>
        public MenuSheet Danger(string label, Action onClick) => Item(label, null, onClick, danger: true);

        /// <summary>An on/off row. The sheet stays open so several can be flipped in one visit.</summary>
        public MenuSheet Toggle(string label, bool isOn, Action<bool> onChanged)
        {
            _rows.Add(parent =>
            {
                bool state = isOn;
                LinearLayout? row = null;
                row = BuildRow(label, null, () =>
                {
                    state = !state;
                    onChanged(state);
                    if (row?.GetTag(RowStateTag) is TextView pill) StylePill(pill, state);
                }, false, state);
                parent.AddView(row);
            });
            return this;
        }

        /// <summary>Footer action. Defaults to closing; pass an action to return to a parent menu.</summary>
        public MenuSheet Back(string label, Action onBack)
        {
            _backLabel = label;
            _onBack = onBack;
            return this;
        }

        private const int RowStateTag = 0x7f0f0001;

        private LinearLayout BuildRow(string label, string? value, Action onClick, bool danger, bool? toggleState)
        {
            var row = new LinearLayout(_activity) { Orientation = Orientation.Horizontal };
            row.SetGravity(GravityFlags.CenterVertical);
            row.SetPadding(DpI(20), DpI(14), DpI(18), DpI(14));
            row.SetMinimumHeight(DpI(52)); // comfortable touch target on a handheld
            row.Background = RowBackground();
            row.Clickable = true;
            row.Focusable = true;

            var text = new TextView(_activity) { Text = label, TextSize = 15.5f };
            text.SetTextColor(danger ? Blood : Parchment);
            text.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
            text.LayoutParameters = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent, 1f);
            row.AddView(text);

            if (toggleState.HasValue)
            {
                var pill = new TextView(_activity) { TextSize = 11f, LetterSpacing = 0.12f };
                pill.SetPadding(DpI(10), DpI(4), DpI(10), DpI(4));
                StylePill(pill, toggleState.Value);
                row.AddView(pill);
                row.SetTag(RowStateTag, pill);
            }
            else
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var val = new TextView(_activity) { Text = value, TextSize = 13.5f };
                    val.SetTextColor(Mist);
                    val.SetPadding(0, 0, DpI(10), 0);
                    row.AddView(val);
                }

                var chevron = new TextView(_activity) { Text = "›", TextSize = 18f };
                chevron.SetTextColor(danger ? Blood : GoldDim);
                row.AddView(chevron);
            }

            // Navigating rows close this sheet first. Toggles do not - they mutate in place so
            // several can be flipped in one visit.
            row.Click += (s, e) =>
            {
                if (!toggleState.HasValue) _dialog?.Dismiss();
                onClick();
            };
            return row;
        }

        private void StylePill(TextView pill, bool on)
        {
            pill.Text = on ? "ON" : "OFF";
            pill.SetTextColor(on ? Ink : Mist);
            var bg = new GradientDrawable();
            bg.SetShape(ShapeType.Rectangle);
            bg.SetCornerRadius(Dp(11));
            bg.SetColor(on ? Gold : Color.Transparent);
            bg.SetStroke(DpI(1), on ? Gold : GoldDim);
            pill.Background = bg;
        }

        /// <summary>Pressed rows get a slate fill and a gold bar down the leading edge, echoing the game's cursor.</summary>
        private Drawable RowBackground()
        {
            var pressedFill = new GradientDrawable();
            pressedFill.SetColor(Slate);
            var goldBar = new GradientDrawable();
            goldBar.SetColor(Gold);

            var pressed = new LayerDrawable(new Drawable[] { goldBar, pressedFill });
            pressed.SetLayerInset(1, DpI(3), 0, 0, 0);

            var normal = new ColorDrawable(Color.Transparent);

            var states = new StateListDrawable();
            states.AddState(new[] { global::Android.Resource.Attribute.StatePressed }, pressed);
            states.AddState(new int[] { }, normal);
            return states;
        }

        private View Ornament()
        {
            var v = new OrnamentView(_activity);
            v.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, DpI(14));
            return v;
        }

        private View HairLine()
        {
            var v = new View(_activity);
            v.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, Math.Max(1, DpI(1)));
            v.SetBackgroundColor(Color.Argb(60, GoldDim.R, GoldDim.G, GoldDim.B));
            return v;
        }

        public void Show()
        {
            bool portrait = (_activity.Resources?.Configuration?.Orientation
                             ?? global::Android.Content.Res.Orientation.Landscape)
                            == global::Android.Content.Res.Orientation.Portrait;

            var dialog = new Dialog(_activity);
            _dialog = dialog; // rows are built below and capture this to close the sheet
            dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

            // Full-screen transparent window so the scrim and the panel placement are ours.
            var scrim = new FrameLayout(_activity);
            scrim.SetBackgroundColor(Color.Argb(150, 0, 0, 0));
            scrim.Clickable = true;
            scrim.Click += (s, e) => dialog.Dismiss();

            var panel = new LinearLayout(_activity) { Orientation = Orientation.Vertical };
            panel.Clickable = true; // swallow taps so they do not reach the scrim
            panel.Background = PanelBackground(portrait);

            // Header
            var title = new TextView(_activity)
            {
                Text = _title.ToUpperInvariant(),
                TextSize = 19f,
                LetterSpacing = 0.16f,
            };
            title.SetTextColor(Gold);
            title.SetTypeface(Typeface.Create("serif", TypefaceStyle.Bold), TypefaceStyle.Bold);
            title.SetPadding(DpI(20), DpI(18), DpI(20), 0);
            panel.AddView(title);

            if (!string.IsNullOrEmpty(_subtitle))
            {
                var sub = new TextView(_activity) { Text = _subtitle, TextSize = 12.5f };
                sub.SetTextColor(Mist);
                sub.SetPadding(DpI(20), DpI(3), DpI(20), 0);
                panel.AddView(sub);
            }

            panel.AddView(Ornament());

            // Body
            var body = new LinearLayout(_activity) { Orientation = Orientation.Vertical };
            foreach (var add in _rows) add(body);

            var scroller = new ScrollView(_activity);
            scroller.AddView(body);
            scroller.LayoutParameters = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, 0, 1f);
            scroller.VerticalScrollBarEnabled = false;
            panel.AddView(scroller);

            // Footer. Built as a row container like every other tappable line rather than a
            // bare TextView - a TextView with Clickable set does not reliably receive the
            // click here, which left "Close" doing nothing.
            panel.AddView(HairLine());
            var footer = new LinearLayout(_activity) { Orientation = Orientation.Horizontal };
            footer.SetGravity(GravityFlags.Center);
            footer.SetPadding(DpI(20), DpI(15), DpI(20), DpI(15));
            footer.SetMinimumHeight(DpI(52));
            footer.Background = RowBackground();
            footer.Clickable = true;
            footer.Focusable = true;

            var backText = new TextView(_activity)
            {
                Text = _backLabel,
                TextSize = 14f,
                LetterSpacing = 0.1f,
            };
            backText.SetTextColor(Gold);
            backText.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
            footer.AddView(backText);
            footer.Click += (s, e) => { dialog.Dismiss(); _onBack?.Invoke(); };
            panel.AddView(footer);

            // Placement: right-hand panel in landscape, bottom sheet in portrait.
            var dm = _activity.Resources!.DisplayMetrics!;
            var lp = portrait
                ? new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                               ViewGroup.LayoutParams.WrapContent)
                { Gravity = GravityFlags.Bottom }
                : new FrameLayout.LayoutParams(Math.Min(DpI(400), (int)(dm.WidthPixels * 0.46f)),
                                               ViewGroup.LayoutParams.MatchParent)
                { Gravity = GravityFlags.End };
            panel.LayoutParameters = lp;
            scrim.AddView(panel);

            ApplyInsets(panel, portrait);

            dialog.SetContentView(scrim);
            dialog.SetCanceledOnTouchOutside(true);
            var w = dialog.Window;
            if (w != null)
            {
                w.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                w.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                w.SetDimAmount(0f); // our own scrim
                // Open without taking focus, so the activity's immersive flags survive and the
                // status bar does not slide back in over the game while the sheet is up.
                w.SetFlags(WindowManagerFlags.NotFocusable, WindowManagerFlags.NotFocusable);
            }

            // Slide in, so it reads as a panel arriving rather than a dialog popping.
            panel.Alpha = 0f;
            dialog.ShowEvent += (s, e) =>
            {
                if (portrait) panel.TranslationY = Dp(28);
                else panel.TranslationX = Dp(40);
                panel.Animate()?.Alpha(1f)?.TranslationX(0f)?.TranslationY(0f)?.SetDuration(160)?.Start();
            };

            dialog.Show();

            // Match the game's system-UI state, then take focus back so rows stay tappable.
            var decor = dialog.Window?.DecorView;
            var hostDecor = _activity.Window?.DecorView;
            if (decor != null && hostDecor != null)
                decor.SystemUiVisibility = hostDecor.SystemUiVisibility;
            dialog.Window?.ClearFlags(WindowManagerFlags.NotFocusable);
        }

        /// <summary>
        /// Asks before doing something that cannot be undone. The confirming action is drawn
        /// in blood red so it reads differently from the way out.
        /// </summary>
        public static void Confirm(Activity activity, string title, string message,
                                   string confirmLabel, Action onConfirm)
        {
            float d = activity.Resources?.DisplayMetrics?.Density ?? 1f;
            int P(float v) => (int)(v * d + 0.5f);

            var dialog = new Dialog(activity);
            dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

            var panel = new LinearLayout(activity) { Orientation = Orientation.Vertical };
            var bg = new GradientDrawable();
            bg.SetColor(Ink);
            bg.SetCornerRadius(P(18));
            bg.SetStroke(Math.Max(1, P(1)), Color.Argb(90, Gold.R, Gold.G, Gold.B));
            panel.Background = bg;
            panel.SetPadding(P(22), P(20), P(22), P(10));

            var head = new TextView(activity) { Text = title, TextSize = 17f, LetterSpacing = 0.12f };
            head.SetTextColor(Gold);
            head.SetTypeface(Typeface.Create("serif", TypefaceStyle.Bold), TypefaceStyle.Bold);
            panel.AddView(head);

            var body = new TextView(activity) { Text = message, TextSize = 13.5f };
            body.SetTextColor(Parchment);
            body.SetPadding(0, P(10), 0, P(6));
            panel.AddView(body);

            LinearLayout Action(string label, Color colour, Action onTap)
            {
                var row = new LinearLayout(activity) { Orientation = Orientation.Horizontal };
                row.SetGravity(GravityFlags.Center);
                row.SetPadding(P(16), P(14), P(16), P(14));
                row.SetMinimumHeight(P(52));
                row.Clickable = true;
                var tv = new TextView(activity) { Text = label, TextSize = 14f, LetterSpacing = 0.1f };
                tv.SetTextColor(colour);
                tv.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
                row.AddView(tv);
                row.Click += (s, e) => { dialog.Dismiss(); onTap(); };
                return row;
            }

            panel.AddView(Action(confirmLabel, Blood, onConfirm));
            panel.AddView(Action("Cancel", Mist, () => { }));

            var host = new FrameLayout(activity);
            host.SetBackgroundColor(Color.Argb(150, 0, 0, 0));
            host.Clickable = true;
            host.Click += (s, e) => dialog.Dismiss();
            panel.Clickable = true;
            panel.LayoutParameters = new FrameLayout.LayoutParams(
                Math.Min(P(340), (int)((activity.Resources?.DisplayMetrics?.WidthPixels ?? 1000) * 0.82f)),
                ViewGroup.LayoutParams.WrapContent)
            { Gravity = GravityFlags.Center };
            host.AddView(panel);

            dialog.SetContentView(host);
            dialog.SetCanceledOnTouchOutside(true);
            var w = dialog.Window;
            if (w != null)
            {
                w.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                w.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                w.SetDimAmount(0f);
            }
            dialog.Show();
        }

        /// <summary>
        /// Numeric entry for the stat editors, themed to match the sheet instead of using the
        /// stock input dialog.
        /// </summary>
        public static void PromptNumber(Activity activity, string title, int current, int min, int max, Action<int> onValue)
        {
            float d = activity.Resources?.DisplayMetrics?.Density ?? 1f;
            int P(float v) => (int)(v * d + 0.5f);

            var dialog = new Dialog(activity);
            dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

            var panel = new LinearLayout(activity) { Orientation = Orientation.Vertical };
            var bg = new GradientDrawable();
            bg.SetColor(Ink);
            bg.SetCornerRadius(P(18));
            bg.SetStroke(Math.Max(1, P(1)), Color.Argb(90, Gold.R, Gold.G, Gold.B));
            panel.Background = bg;
            panel.SetPadding(P(22), P(20), P(22), P(14));

            var head = new TextView(activity) { Text = title, TextSize = 16f, LetterSpacing = 0.12f };
            head.SetTextColor(Gold);
            head.SetTypeface(Typeface.Create("serif", TypefaceStyle.Bold), TypefaceStyle.Bold);
            panel.AddView(head);

            var hint = new TextView(activity) { Text = $"{min} to {max}", TextSize = 12f };
            hint.SetTextColor(Mist);
            hint.SetPadding(0, P(2), 0, P(10));
            panel.AddView(hint);

            var input = new EditText(activity)
            {
                Text = current.ToString(),
                InputType = global::Android.Text.InputTypes.ClassNumber,
                TextSize = 18f,
            };
            input.SetTextColor(Parchment);
            input.SetBackgroundColor(Slate);
            input.SetPadding(P(12), P(10), P(12), P(10));
            input.SetSelection(input.Text?.Length ?? 0);
            panel.AddView(input);

            var apply = new LinearLayout(activity) { Orientation = Orientation.Horizontal };
            apply.SetGravity(GravityFlags.Center);
            apply.SetPadding(0, P(14), 0, 0);
            apply.Clickable = true;
            var applyText = new TextView(activity) { Text = "Apply", TextSize = 14f, LetterSpacing = 0.1f };
            applyText.SetTextColor(Gold);
            apply.AddView(applyText);
            apply.Click += (s, e) =>
            {
                if (int.TryParse(input.Text, out int v)) onValue(Math.Clamp(v, min, max));
                dialog.Dismiss();
            };
            panel.AddView(apply);

            var host = new FrameLayout(activity);
            host.SetBackgroundColor(Color.Argb(150, 0, 0, 0));
            host.Clickable = true;
            host.Click += (s, e) => dialog.Dismiss();
            panel.LayoutParameters = new FrameLayout.LayoutParams(
                Math.Min(P(320), (int)((activity.Resources?.DisplayMetrics?.WidthPixels ?? 1000) * 0.8f)),
                ViewGroup.LayoutParams.WrapContent)
            { Gravity = GravityFlags.Center };
            panel.Clickable = true;
            host.AddView(panel);

            dialog.SetContentView(host);
            dialog.SetCanceledOnTouchOutside(true);
            var w = dialog.Window;
            if (w != null)
            {
                w.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                w.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                w.SetDimAmount(0f);
            }
            dialog.Show();
        }

        private void ApplyInsets(View panel, bool portrait)
        {
            int l = 0, t = 0, r = 0, b = 0;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                try
                {
                    var wi = _activity.Window?.DecorView?.RootWindowInsets;
                    if (wi != null)
                    {
                        l = wi.SystemWindowInsetLeft; t = wi.SystemWindowInsetTop;
                        r = wi.SystemWindowInsetRight; b = wi.SystemWindowInsetBottom;
                    }
                }
                catch
                {
                }
            }
            // Keep content clear of the navigation bar and any cutout.
            panel.SetPadding(portrait ? 0 : 0, 0, 0, 0);
            if (panel is LinearLayout ll)
                ll.SetPadding(l, t, r, b);
        }

        private Drawable PanelBackground(bool portrait)
        {
            var g = new GradientDrawable();
            g.SetColor(Ink);
            float rr = Dp(18);
            // Round only the edges that face the game.
            g.SetCornerRadii(portrait
                ? new[] { rr, rr, rr, rr, 0f, 0f, 0f, 0f }
                : new[] { rr, rr, 0f, 0f, 0f, 0f, rr, rr });
            g.SetStroke(Math.Max(1, DpI(1)), Color.Argb(90, Gold.R, Gold.G, Gold.B));
            return g;
        }

        /// <summary>
        /// The signature: a gold hairline broken by a centred lozenge, the divider SoTN uses
        /// under its own menu headings. Everything else in the sheet stays quiet so this reads.
        /// </summary>
        private sealed class OrnamentView : View
        {
            private readonly Paint _paint = new Paint(PaintFlags.AntiAlias);
            private readonly float _d;

            public OrnamentView(Context context) : base(context)
            {
                _d = context.Resources?.DisplayMetrics?.Density ?? 1f;
            }

            protected override void OnDraw(Canvas? canvas)
            {
                base.OnDraw(canvas);
                if (canvas == null) return;

                float cy = Height / 2f;
                float pad = 20f * _d;
                float gap = 9f * _d;
                float cx = Width / 2f;

                _paint.SetStyle(Paint.Style.Fill);
                _paint.Color = Color.Argb(120, GoldDim.R, GoldDim.G, GoldDim.B);
                float h = Math.Max(1f, 1f * _d);
                canvas.DrawRect(pad, cy - h / 2f, cx - gap, cy + h / 2f, _paint);
                canvas.DrawRect(cx + gap, cy - h / 2f, Width - pad, cy + h / 2f, _paint);

                // Lozenge
                float s = 4.2f * _d;
                using var path = new global::Android.Graphics.Path();
                path.MoveTo(cx, cy - s);
                path.LineTo(cx + s, cy);
                path.LineTo(cx, cy + s);
                path.LineTo(cx - s, cy);
                path.Close();
                _paint.Color = Gold;
                canvas.DrawPath(path, _paint);
            }
        }
    }
}
