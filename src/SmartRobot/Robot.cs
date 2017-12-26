using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRobot
{
    public class Robot
    {
        public Point Position;
        private readonly ISensor sensor;

        private bool isFrozen;
        int deltaX, deltaY;
        int lastXDir, lastYDir;

        public Robot(ISensor sensor)
        {
            this.sensor = sensor;
        }


        public void StepTwards(Point goal)
        {
            var x = GetNextPosition(Position.X, goal.X);
            var y = GetNextPosition(Position.Y, goal.Y);
            var next = new Point(x, y);

            if (sensor.IsObstacle(next))
            {
                if (isFrozen && (deltaX != 0 || deltaY != 0))
                {
                    next = Position.MoveBy(deltaX, deltaY);
                }
                else
                {

                    next = Position.MoveXTo(x);
                    if (sensor.IsObstacle(next))
                    {
                        next = Position.MoveYTo(y);
                    }
                    if (sensor.IsObstacle(next))
                    {
                        next = Position;
                    }

                    if (!isFrozen)
                    {
                        lastXDir = next.X - Position.X < 0 ? -1 : 1;
                        lastYDir = next.Y - Position.Y < 0 ? -1 : 1;
                    }

                    if (Position == next)
                    {
                        isFrozen = true;
                        deltaX = lastXDir * (1 - Math.Abs(Position.X - x));
                        deltaY = lastYDir * (1 - Math.Abs(Position.Y - y));
                    }

                }
            }
            else
            {
                isFrozen = false;
            }


            if (next != default(Point))
            {
                Position = next;
            }
        }


        private int GetNextPosition(int position, int goal)
        {
            return position + Math.Sign(goal - position);
        }
    }
}
