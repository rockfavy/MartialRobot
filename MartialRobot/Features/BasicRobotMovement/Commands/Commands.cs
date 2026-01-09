using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Features.BasicRobotMovement.Commands
{
    public class LeftCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            if (robot.IsLost) return;

            robot.Orientation = robot.Orientation.RotateLeft();
        }
    }

    public class RightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            if (robot.IsLost) return;

            robot.Orientation = robot.Orientation.RotateRight();
        }
    }

    public class ForwardCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            if (robot.IsLost) return;

            var nextPosition = CalculateNextPosition(robot);
            robot.Position = nextPosition;
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