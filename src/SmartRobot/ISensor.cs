using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRobot
{
    public interface ISensor
    {
        bool IsObstacle(Point Point);
    }
}
