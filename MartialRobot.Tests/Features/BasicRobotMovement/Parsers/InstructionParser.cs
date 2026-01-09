using MartialRobot.Features.BasicRobotMovement.Parsers;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Parsers
{
    public class InstructionParserTests
    {
        [Fact]
        public void Parse_ValidInstructions_ReturnsString()
        {
            var parser = new InstructionParser();
            var result = parser.Parse("RFRFRFRF");

            Assert.Equal("RFRFRFRF", result);
        }

        [Fact]
        public void Parse_ValidInstructions_AllCommands_ReturnsString()
        {
            var parser = new InstructionParser();
            var result = parser.Parse("LRF");

            Assert.Equal("LRF", result);
        }

        [Fact]
        public void Parse_InvalidCharacter_X_ThrowsException()
        {
            var parser = new InstructionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse("RFX"));
        }

        [Fact]
        public void Parse_EmptyString_ThrowsException()
        {
            var parser = new InstructionParser();

            Assert.Throws<ArgumentException>(() => parser.Parse(""));
        }
    }
}
