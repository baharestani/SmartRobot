using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRobot
{
    public class Map
    {
        private readonly List<Point> obstacles = new List<Point>();

        public IEnumerable<Point> Obstacles
        {
            get
            {
                return obstacles.AsReadOnly();
            }
        }

        public void AddRow(int x, int y, int length)
        {
            for (int i = 0; i < length; i++)
            {
                obstacles.Add(new Point(x+i, y));
            }
        }

        public void AddColumn(int x, int y, int length)
        {
            for (int i = 0; i < length; i++)
            {
                obstacles.Add(new Point(x, y+i));
            }
        }
    }
}
