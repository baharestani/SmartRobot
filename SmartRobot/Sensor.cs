using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRobot
{
    public class Sensor : ISensor
    {
        public Point[] obstacles = new[]
        {
            new Point(10 , 10),
            new Point(10 , 11),
            new Point(10 , 12),
            new Point(10 , 13),
            new Point(10 , 14),
            new Point(10 , 15),
            new Point(11 , 15),
            new Point(12 , 15),
            new Point(13 , 15),
            new Point(14 , 15),
            new Point(15 , 15),
            new Point(16 , 15),

            new Point(20 , 20),
            new Point(21 , 20),
            new Point(22 , 20),
            new Point(23 , 20),
            new Point(24 , 20),
            new Point(25 , 20),

        };

        public bool IsObstacle(Point Point)
        {
            return obstacles.Contains(Point);
        }
    }
}
