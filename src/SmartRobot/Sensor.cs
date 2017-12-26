using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRobot
{
    public class MapReader : ISensor
    {
        public readonly Map Map;

        public MapReader(Map map)
        {
            this.Map = map;
        }

        public MapReader()
            :this(new Map())
        {
            Map.AddColumn(2,5, 10);
            Map.AddRow(10, 10, 5);
            Map.AddColumn(15, 15, 5);
            Map.AddColumn(20, 15, 5);
        }


        public bool IsObstacle(Point point)
        {
            return Map.Obstacles.Contains(point);
        }
    }

}
