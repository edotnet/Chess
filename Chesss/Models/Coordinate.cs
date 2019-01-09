namespace Chesss.Models
{
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(double x, double y)
        {
            X = (int)x;
            Y = (int)y;
        }


        public static bool operator ==(Coordinate c1, Coordinate c2) => c1.X == c2.X && c1.Y == c2.Y;
        public static bool operator !=(Coordinate c1, Coordinate c2) => !(c1 == c2);

        public override string ToString() => X + " " + Y;
    }
}
