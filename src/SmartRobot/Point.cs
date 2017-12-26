namespace SmartRobot
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point MoveBy(int deltaX, int deltaY)
        {
            return new Point(X + deltaX, Y + deltaY);
        }

        public Point MoveXTo(int newX)
        {
            return new Point(newX, Y);
        }

        public Point MoveYTo(int newY)
        {
            return new Point(X, newY);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return p1.Y != p2.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}