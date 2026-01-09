using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Models
{
    public class CoordonatePointTests
    {
        [Fact]
        public void Constructor_SetsXAndY()
        {
            var CoordonatePoint = new CoordonatePoint(5, 3);

            Assert.Equal(5, CoordonatePoint.X);
            Assert.Equal(3, CoordonatePoint.Y);
        }

        [Fact]
        public void Constructor_ZeroCoordinates_CreatesCoordonatePoint()
        {
            var CoordonatePoint = new CoordonatePoint(0, 0);

            Assert.Equal(0, CoordonatePoint.X);
            Assert.Equal(0, CoordonatePoint.Y);
        }

        [Fact]
        public void Constructor_NegativeCoordinates_CreatesCoordonatePoint()
        {
            var CoordonatePoint = new CoordonatePoint(-1, -5);

            Assert.Equal(-1, CoordonatePoint.X);
            Assert.Equal(-5, CoordonatePoint.Y);
        }

        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(1, 2);

            Assert.Equal(CoordonatePoint1, CoordonatePoint2);
            Assert.True(CoordonatePoint1.Equals(CoordonatePoint2));
        }

        [Fact]
        public void Equals_DifferentX_ReturnsFalse()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(2, 2);

            Assert.NotEqual(CoordonatePoint1, CoordonatePoint2);
            Assert.False(CoordonatePoint1.Equals(CoordonatePoint2));
        }

        [Fact]
        public void Equals_DifferentY_ReturnsFalse()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(1, 3);

            Assert.NotEqual(CoordonatePoint1, CoordonatePoint2);
            Assert.False(CoordonatePoint1.Equals(CoordonatePoint2));
        }

        [Fact]
        public void Equals_DifferentCoordinates_ReturnsFalse()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(3, 4);

            Assert.NotEqual(CoordonatePoint1, CoordonatePoint2);
            Assert.False(CoordonatePoint1.Equals(CoordonatePoint2));
        }

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            var CoordonatePoint = new CoordonatePoint(1, 2);

            Assert.False(CoordonatePoint.Equals(null));
        }

        [Fact]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var CoordonatePoint = new CoordonatePoint(1, 2);

            Assert.False(CoordonatePoint.Equals("not a CoordonatePoint"));
        }

        [Fact]
        public void GetHashCode_SameCoordinates_ReturnsSameHashCode()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(1, 2);

            Assert.Equal(CoordonatePoint1.GetHashCode(), CoordonatePoint2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentCoordinates_ReturnsDifferentHashCode()
        {
            var CoordonatePoint1 = new CoordonatePoint(1, 2);
            var CoordonatePoint2 = new CoordonatePoint(2, 1);

            Assert.NotEqual(CoordonatePoint1.GetHashCode(), CoordonatePoint2.GetHashCode());
        }

        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            var CoordonatePoint = new CoordonatePoint(5, 3);

            Assert.Equal("(5, 3)", CoordonatePoint.ToString());
        }

        [Fact]
        public void ToString_NegativeCoordinates_ReturnsFormattedString()
        {
            var CoordonatePoint = new CoordonatePoint(-1, -2);

            Assert.Equal("(-1, -2)", CoordonatePoint.ToString());
        }
    }
}
