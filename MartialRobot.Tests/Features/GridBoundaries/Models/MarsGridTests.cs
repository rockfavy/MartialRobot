using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.GridBoundaries.Models;

namespace MartialRobot.Tests.Features.MarsGridBoundaries.Models
{
    public class MarsMarsGridTests
    {
        [Fact]
        public void Constructor_ValidDimensions_CreatesMarsGrid()
        {
            var MarsGrid = new MarsGrid(5, 3);

            Assert.Equal(5, MarsGrid.MaxX);
            Assert.Equal(3, MarsGrid.MaxY);
        }

        [Fact]
        public void Constructor_ZeroDimensions_CreatesMarsGrid()
        {
            var MarsGrid = new MarsGrid(0, 0);

            Assert.Equal(0, MarsGrid.MaxX);
            Assert.Equal(0, MarsGrid.MaxY);
        }

        [Fact]
        public void Constructor_NegativeMaxX_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new MarsGrid(-1, 3));
        }

        [Fact]
        public void Constructor_NegativeMaxY_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new MarsGrid(5, -1));
        }

        [Fact]
        public void Constructor_BothNegative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new MarsGrid(-1, -1));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointInsideBounds_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(3, 2);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnLowerLeftBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(0, 0);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnUpperRightBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(5, 3);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnLeftBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(0, 2);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnRightBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(5, 2);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnTopBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(3, 3);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOnBottomBoundary_ReturnsTrue()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(3, 0);

            Assert.True(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOutsideBounds_Right_ReturnsFalse()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(6, 2);

            Assert.False(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOutsideBounds_Top_ReturnsFalse()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(3, 4);

            Assert.False(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOutsideBounds_Left_ReturnsFalse()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(-1, 2);

            Assert.False(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOutsideBounds_Bottom_ReturnsFalse()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(3, -1);

            Assert.False(MarsGrid.IsWithinBounds(CoordonatePoint));
        }

        [Fact]
        public void IsWithinBounds_CoordonatePointOutsideBounds_Corner_ReturnsFalse()
        {
            var MarsGrid = new MarsGrid(5, 3);
            var CoordonatePoint = new CoordonatePoint(6, 4);

            Assert.False(MarsGrid.IsWithinBounds(CoordonatePoint));
        }
    }
}
