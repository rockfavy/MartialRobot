using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.GridBoundaries.Models;
using MartialRobot.Features.ScentTracking;

namespace MartialRobot.Features.BasicRobotMovement.Commands
{
    public class LeftCommand : ICommand
    {
        public void Execute(Robot robot, MarsGrid? grid = null, ScentTracker? scentTracker = null)
        {
            if (robot.IsLost) return;

            robot.Orientation = robot.Orientation.RotateLeft();
        }
    }

    public class RightCommand : ICommand
    {
        public void Execute(Robot robot, MarsGrid? grid = null, ScentTracker? scentTracker = null)
        {
            if (robot.IsLost) return;

            robot.Orientation = robot.Orientation.RotateRight();
        }
    }

    public class ForwardCommand : ICommand
    {
        public void Execute(Robot robot, MarsGrid? grid = null, ScentTracker? scentTracker = null)
        {
            if (robot.IsLost) 
                return;

            var nextPosition = CalculateNextPosition(robot);

            if (grid != null && !grid.IsWithinBounds(nextPosition))
            {
                if (scentTracker != null && scentTracker.HasScent(robot.Position))                
                    return;              
            }
            else
            {
                robot.Position = nextPosition;
            }
        }

        private CoordonatePoint CalculateNextPosition(Robot robot)
        {
            return robot.Orientation switch
            {
                Orientation.North => new CoordonatePoint(robot.Position.X, robot.Position.Y + 1),
                Orientation.South => new CoordonatePoint(robot.Position.X, robot.Position.Y - 1),
                Orientation.East => new CoordonatePoint(robot.Position.X + 1, robot.Position.Y),
                Orientation.West => new CoordonatePoint(robot.Position.X - 1, robot.Position.Y),
                _ => throw new InvalidOperationException($"Unknown orientation: {robot.Orientation}")
            };
        }
    }
}