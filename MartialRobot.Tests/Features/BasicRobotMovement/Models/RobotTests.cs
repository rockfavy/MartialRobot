using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Models
{
    public class RobotTests
    {
        [Fact]
        public void Constructor_SetsPositionAndOrientation()
        {
            var position = new CoordonatePoint(1, 1);
            var robot = new Robot(position, Orientation.East);

            Assert.Equal(position, robot.Position);
            Assert.Equal(Orientation.East, robot.Orientation);
            Assert.False(robot.IsLost);
        }

        [Fact]
        public void Constructor_IsLostDefaultsToFalse()
        {
            var robot = new Robot(new CoordonatePoint(0, 0), Orientation.North);

            Assert.False(robot.IsLost);
        }

        [Fact]
        public void GetStateString_WhenNotLost_ReturnsPositionAndOrientation()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);

            var result = robot.GetStateString();

            Assert.Equal("1 1 E", result);
        }

        [Fact]
        public void GetStateString_WhenLost_IncludesLost()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);
            robot.IsLost = true;

            var result = robot.GetStateString();

            Assert.Equal("1 1 E LOST", result);
        }

        [Fact]
        public void GetStateString_DifferentOrientations_ReturnsCorrectString()
        {
            var robotN = new Robot(new CoordonatePoint(3, 2), Orientation.North);
            var robotS = new Robot(new CoordonatePoint(3, 2), Orientation.South);
            var robotE = new Robot(new CoordonatePoint(3, 2), Orientation.East);
            var robotW = new Robot(new CoordonatePoint(3, 2), Orientation.West);

            Assert.Equal("3 2 N", robotN.GetStateString());
            Assert.Equal("3 2 S", robotS.GetStateString());
            Assert.Equal("3 2 E", robotE.GetStateString());
            Assert.Equal("3 2 W", robotW.GetStateString());
        }

        [Fact]
        public void GetStateString_ZeroCoordinates_ReturnsCorrectString()
        {
            var robot = new Robot(new CoordonatePoint(0, 0), Orientation.North);

            Assert.Equal("0 0 N", robot.GetStateString());
        }

        [Fact]
        public void IsLost_CanBeSetToTrue()
        {
            var robot = new Robot(new CoordonatePoint(1, 1), Orientation.East);
            robot.IsLost = true;

            Assert.True(robot.IsLost);
        }
    }
}
