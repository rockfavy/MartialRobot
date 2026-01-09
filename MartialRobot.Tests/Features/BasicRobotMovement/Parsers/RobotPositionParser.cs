using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.BasicRobotMovement.Parsers;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Parsers
{
    public class RobotPositisionParserTests
    {
        [Fact]
        public void Parse_ValidInput_ReturnsPositionAndOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("1 1 E");

            Assert.Equal(1, position.X);
            Assert.Equal(1, position.Y);
            Assert.Equal(Orientation.East, orientation);
        }

        [Fact]
        public void Parse_ValidInputWithNorth_ReturnsPositionAndOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("3 2 N");

            Assert.Equal(3, position.X);
            Assert.Equal(2, position.Y);
            Assert.Equal(Orientation.North, orientation);
        }

        [Fact]
        public void Parse_ValidInputWithSouth_ReturnsPositionAndOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("0 3 S");

            Assert.Equal(0, position.X);
            Assert.Equal(3, position.Y);
            Assert.Equal(Orientation.South, orientation);
        }

        [Fact]
        public void Parse_ValidInputWithWest_ReturnsPositionAndOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("0 3 W");

            Assert.Equal(0, position.X);
            Assert.Equal(3, position.Y);
            Assert.Equal(Orientation.West, orientation);
        }

        [Fact]
        public void Parse_ValidInputWithExtraSpaces_ReturnsPositionAndOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("  1   1   E  ");

            Assert.Equal(1, position.X);
            Assert.Equal(1, position.Y);
            Assert.Equal(Orientation.East, orientation);
        }

        [Fact]
        public void Parse_InvalidInput_TooFewParts_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("1 1"));
            Assert.Throws<ArgumentException>(() => parser.Parse("1"));
        }

        [Fact]
        public void Parse_InvalidInput_TooManyParts_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("1 1 E N"));
        }

        [Fact]
        public void Parse_InvalidInput_NonNumericX_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("abc 1 E"));
        }

        [Fact]
        public void Parse_InvalidInput_NonNumericY_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("1 abc E"));
        }

        [Fact]
        public void Parse_InvalidInput_InvalidOrientation_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("1 1 X"));
        }

        [Fact]
        public void Parse_InvalidInput_OrientationTooLong_ThrowsException()
        {
            var parser = new RobotPositisionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("1 1 EN"));
        }

        [Fact]
        public void Parse_ValidInput_LowerCaseOrientation_ReturnsOrientation()
        {
            var parser = new RobotPositisionParser();
            var (position, orientation) = parser.Parse("1 1 e");

            Assert.Equal(Orientation.East, orientation);
        }
    }
}
