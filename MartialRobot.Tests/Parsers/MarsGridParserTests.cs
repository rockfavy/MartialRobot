using MartialRobot.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialRobot.Tests.Parsers
{
    public class MarsGridParserTests
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
        public void ParseCoordinates_InvalidInput_ThrowsException()
        {
            var parser = new MarsGridParser();

            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("5"));
            Assert.Throws<ArgumentException>(() => parser.ParseCoordinates("abc 3"));
        }
    }
}
