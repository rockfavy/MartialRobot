using MartialRobot.Features.BasicRobotMovement.Commands;
using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Command
{
    public class CommandsTests
    {
        #region left command tests

        [Fact]
        public void Execute_RotatesRobotLeft_FromNorth()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(Orientation.West, robot.Orientation);
        }

        [Fact]
        public void Execute_RotatesRobotLeft_FromWest()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.West);
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(Orientation.South, robot.Orientation);
        }

        [Fact]
        public void Execute_RotatesRobotLeft_FromSouth()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.South);
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(Orientation.East, robot.Orientation);
        }

        [Fact]
        public void Execute_RotatesRobotLeft_FromEast()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(Orientation.North, robot.Orientation);
        }

        [Fact]
        public void Execute_DoesNotChangePosition()
        {
            var robot = new Robot(new CoordonatePoint(5, 3), Orientation.North);
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(5, robot.Position.X);
            Assert.Equal(3, robot.Position.Y);
        }

        [Fact]
        public void Execute_RobotIsLost_DoesNothing()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
            robot.IsLost = true;
            var command = new LeftCommand();

            command.Execute(robot);

            Assert.Equal(Orientation.North, robot.Orientation);
        }

        [Fact]
        public void Execute_MultipleTimes_RotatesCorrectly()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
            var command = new LeftCommand();

            command.Execute(robot);
            Assert.Equal(Orientation.West, robot.Orientation);

            command.Execute(robot);
            Assert.Equal(Orientation.South, robot.Orientation);

            command.Execute(robot);
            Assert.Equal(Orientation.East, robot.Orientation);

            command.Execute(robot);
            Assert.Equal(Orientation.North, robot.Orientation);
        }

        #endregion

        #region right command tests

        public class RightCommandTests
        {
            [Fact]
            public void Execute_RotatesRobotRight_FromNorth()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.East, robot.Orientation);
            }

            [Fact]
            public void Execute_RotatesRobotRight_FromEast()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.South, robot.Orientation);
            }

            [Fact]
            public void Execute_RotatesRobotRight_FromSouth()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.South);
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.West, robot.Orientation);
            }

            [Fact]
            public void Execute_RotatesRobotRight_FromWest()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.West);
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.North, robot.Orientation);
            }

            [Fact]
            public void Execute_DoesNotChangePosition()
            {
                var robot = new Robot(new CoordonatePoint(5, 3), Orientation.North);
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(5, robot.Position.X);
                Assert.Equal(3, robot.Position.Y);
            }

            [Fact]
            public void Execute_RobotIsLost_DoesNothing()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                robot.IsLost = true;
                var command = new RightCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.North, robot.Orientation);
            }

            [Fact]
            public void Execute_MultipleTimes_RotatesCorrectly()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                var command = new RightCommand();

                command.Execute(robot);
                Assert.Equal(Orientation.East, robot.Orientation);

                command.Execute(robot);
                Assert.Equal(Orientation.South, robot.Orientation);

                command.Execute(robot);
                Assert.Equal(Orientation.West, robot.Orientation);

                command.Execute(robot);
                Assert.Equal(Orientation.North, robot.Orientation);
            }
        }

        #endregion

        #region forward command tests
        public class ForwardCommandTests
        {
            [Fact]
            public void Execute_MovesRobotForwardNorth()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(1, robot.Position.X);
                Assert.Equal(2, robot.Position.Y);
                Assert.Equal(Orientation.North, robot.Orientation);
            }

            [Fact]
            public void Execute_MovesRobotForwardSouth()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.South);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(1, robot.Position.X);
                Assert.Equal(0, robot.Position.Y);
                Assert.Equal(Orientation.South, robot.Orientation);
            }

            [Fact]
            public void Execute_MovesRobotForwardEast()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(2, robot.Position.X);
                Assert.Equal(1, robot.Position.Y);
                Assert.Equal(Orientation.East, robot.Orientation);
            }

            [Fact]
            public void Execute_MovesRobotForwardWest()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.West);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(0, robot.Position.X);
                Assert.Equal(1, robot.Position.Y);
                Assert.Equal(Orientation.West, robot.Orientation);
            }

            [Fact]
            public void Execute_DoesNotChangeOrientation()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(Orientation.North, robot.Orientation);
            }

            [Fact]
            public void Execute_RobotIsLost_DoesNothing()
            {
                var robot = new Robot(new CoordonatePoint(1, 1), Orientation.North);
                robot.IsLost = true;
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(1, robot.Position.X);
                Assert.Equal(1, robot.Position.Y);
            }

            [Fact]
            public void Execute_MultipleTimes_MovesCorrectly()
            {
                var robot = new Robot(new CoordonatePoint(0, 0), Orientation.North);
                var command = new ForwardCommand();

                command.Execute(robot);
                Assert.Equal(0, robot.Position.X);
                Assert.Equal(1, robot.Position.Y);

                command.Execute(robot);
                Assert.Equal(0, robot.Position.X);
                Assert.Equal(2, robot.Position.Y);
            }

            [Fact]
            public void Execute_CanMoveToNegativeCoordinates()
            {
                var robot = new Robot(new CoordonatePoint(0, 0), Orientation.South);
                var command = new ForwardCommand();

                command.Execute(robot);

                Assert.Equal(0, robot.Position.X);
                Assert.Equal(-1, robot.Position.Y);
            }
        }
        #endregion

    }
}
