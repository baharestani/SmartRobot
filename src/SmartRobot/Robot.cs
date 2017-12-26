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
        private readonly ISensor _sensor;

        private bool _isFrozen;
        private int _deltaX, _deltaY;
        private int _lastXDir, _lastYDir;

        public Robot(ISensor sensor)
        {
            this._sensor = sensor;
        }


        public void StepTwards(Point goal)
        {
            var x = GetNextPosition(Position.X, goal.X);
            var y = GetNextPosition(Position.Y, goal.Y);
            var next = new Point(x, y);

            if (_sensor.IsObstacle(next))
            {
                if (_isFrozen && (_deltaX != 0 || _deltaY != 0))
                {
                    next = Position.MoveBy(_deltaX, _deltaY);
                }
                else
                {

                    next = Position.MoveXTo(x);
                    if (_sensor.IsObstacle(next))
                    {
                        next = Position.MoveYTo(y);
                    }
                    if (_sensor.IsObstacle(next))
                    {
                        next = Position;
                    }

                    if (!_isFrozen)
                    {
                        _lastXDir = next.X - Position.X < 0 ? -1 : 1;
                        _lastYDir = next.Y - Position.Y < 0 ? -1 : 1;
                    }

                    if (Position == next)
                    {
                        _isFrozen = true;
                        _deltaX = _lastXDir * (1 - Math.Abs(Position.X - x));
                        _deltaY = _lastYDir * (1 - Math.Abs(Position.Y - y));
                    }

                }
            }
            else
            {
                _isFrozen = false;
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
