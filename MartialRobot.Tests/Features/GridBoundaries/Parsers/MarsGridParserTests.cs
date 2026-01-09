using MartialRobot.Features.GridBoundaries.Parsers;

namespace MartialRobot.Tests.Features.GridBoundaries.Parsers
{
    public class MarsMarsGridParserTests
    {
        [Fact]
        public void ParseCoordinates_ValidInput_ReturnsCoordinates()
        {
            var parser = new MarsGridParser();
            var (maxX, maxY) = parser.ParseCoordinates("5 3");

            Assert.Equal(5, maxX);
            Assert.Equal(3, maxY);
        }

        [Fact]
        public void ParseCoordinates_ValidInputWithExtraSpaces_ReturnsCoordinates()
        {
            var parser = new MarsGridParser();
            var (maxX, maxY) = parser.ParseCoordinates("  5   3  ");

            Assert.Equal(5, maxX);
            Assert.Equal(3, maxY);
        }

        [Fact]
        public void ParseCoordinates_InvalidInput_TooFewParts_ThrowsException()
        {
            var parser = new MarsGridParser();

            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("5"));
        }

        [Fact]
        public void ParseCoordinates_InvalidInput_TooManyParts_ThrowsException()
        {
            var parser = new MarsGridParser();

            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("5 3 2"));
        }

        [Fact]
        public void ParseCoordinates_InvalidInput_NonNumeric_ThrowsException()
        {
            var parser = new MarsGridParser();

            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("abc 3"));
            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("5 abc"));
        }

        [Fact]
        public void ParseCoordinates_ValidInput_LargeNumbers_ReturnsCoordinates()
        {
            var parser = new MarsGridParser();
            var (maxX, maxY) = parser.ParseCoordinates("50 50");

            Assert.Equal(50, maxX);
            Assert.Equal(50, maxY);
        }
    }
}
