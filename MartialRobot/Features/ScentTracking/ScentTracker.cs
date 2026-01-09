using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Features.ScentTracking
{
    public class ScentTracker
    {
        private readonly HashSet<CoordonatePoint> _scents = new();

        public void AddScent(CoordonatePoint point)
        {
            _scents.Add(point);
        }

        public bool HasScent(CoordonatePoint point)
        {
            return _scents.Contains(point);
        }
    }
}
