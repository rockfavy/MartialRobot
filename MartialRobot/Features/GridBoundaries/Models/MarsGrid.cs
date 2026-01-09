using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Features.GridBoundaries.Models
{
    public class MarsGrid
    {
        public int MaxX { get; }
        public int MaxY { get; }

        public MarsGrid(int maxX, int maxY)
        {
            if (maxX < 0 || maxY < 0)
            {
                throw new ArgumentException("Grid dimensions must be non-negative");
            }
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsWithinBounds(CoordonatePoint point)
        {
            return point.X >= 0 && point.X <= MaxX &&
                   point.Y >= 0 && point.Y <= MaxY;
        }
    }
}
