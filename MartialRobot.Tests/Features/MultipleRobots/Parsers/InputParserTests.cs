using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.MultipleRobots.Parsers;

namespace MartialRobot.Tests.Features.MultipleRobots.Parsers
{
    public class InputParserTests
    {
        [Fact]
        public void ParseAll_ValidInput_ReturnsRobotInputs()
        {
            var input = @"5 3
1 1 E
RFRFRFRF";
            var reader = new StringReader(input);
            var parser = new InputParser();

            var results = parser.ParseAll(reader);

            Assert.Single(results);
            Assert.Equal(1, results[0].Robot.Position.X);
            Assert.Equal(1, results[0].Robot.Position.Y);
            Assert.Equal(Orientation.East, results[0].Robot.Orientation);
            Assert.Equal("RFRFRFRF", results[0].Instructions);
            Assert.Equal(5, results[0].Grid.MaxX);
            Assert.Equal(3, results[0].Grid.MaxY);
        }

        [Fact]
        public void ParseAll_MultipleRobots_ReturnsAllRobotInputs()
        {
            var input = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL";
            var reader = new StringReader(input);
            var parser = new InputParser();

            var results = parser.ParseAll(reader);

            Assert.Equal(2, results.Count);
            Assert.Equal(Orientation.East, results[0].Robot.Orientation);
            Assert.Equal(Orientation.North, results[1].Robot.Orientation);
        }

        [Fact]
        public void ParseAll_MissingGridLine_ThrowsException()
        {
            var input = @"1 1 E
RFRFRFRF";
            var reader = new StringReader(input);
            var parser = new InputParser();

            Assert.Throws<ArgumentException>(() => parser.ParseAll(reader));
        }

        [Fact]
        public void ParseAll_MissingInstructionLine_ThrowsException()
        {
            var input = @"5 3
1 1 E";
            var reader = new StringReader(input);
            var parser = new InputParser();

            Assert.Throws<ArgumentException>(() => parser.ParseAll(reader));
        }

        [Fact]
        public void ParseAll_EmptyLines_IgnoresThem()
        {
            var input = @"5 3

1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL";
            var reader = new StringReader(input);
            var parser = new InputParser();

            var results = parser.ParseAll(reader);

            Assert.Equal(2, results.Count);
        }
    }
}
