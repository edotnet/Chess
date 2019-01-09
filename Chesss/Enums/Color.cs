namespace Chesss.Enums
{
    public enum Color
    {
        White,
        Black
    }

    public static class ColorExtensions
    {
        public static Color ReverseColor(this Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }
    }
}
