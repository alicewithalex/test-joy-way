namespace NoName.Debugging
{
    public struct DColor
    {
        public float r { get; }
        public float g { get; }
        public float b { get; }
        public float a { get; }

        public DColor(float r, float g, float b, float a = 1.0f)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static DColor Red => new DColor(1, 0, 0);
        public static DColor Green => new DColor(0, 1, 0);
        public static DColor Blue => new DColor(1, 0, 0);
        public static DColor White => new DColor(1, 1, 1);
        public static DColor Black => new DColor(0, 0, 0);
        public static DColor Orange => new DColor(1, 0.46f, 0.1f);
        public static DColor Yellow => new DColor(1, 1, 0);
        public static DColor Purple => new DColor(0.6f, 0.4f, 1f);
        public static DColor Magenta => new DColor(1, 0, 1);
        public static DColor Mint => new DColor(0.2f, 1, 0.68f);
        public static DColor Lightblue => new DColor(0.3f, 0.82f, 1f);
    }

    public static class DebugExtensions
    {
        public static string Colorize(this string str, DColor textColor,bool bold = false)
        {
            var color = GetColorFromString(textColor);

            return $"{(bold?"<b>":string.Empty)}<color=#{color}>{str}</color>{(bold?"</b>":string.Empty)}";
        }

        public static string Colorize(this object obj, DColor textColor, bool bold = false)
        {
            var color = GetColorFromString(textColor);

            return $"{(bold ? "<b>" : string.Empty)}<color=#{color}>{obj}</color>{(bold ? "</b>" : string.Empty)}";
        }

        private static string GetColorFromString(DColor color)
        {
            return $"{(color.r * 255f).FloatToHex()}{(color.g * 255f).FloatToHex()}{(color.b * 255f).FloatToHex()}";
        }

        private static string FloatToHex(this float value)
        {
            return ((byte)value).ToString("X2");
        }
    }
}
