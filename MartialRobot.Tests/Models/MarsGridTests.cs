using MartialRobot.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialRobot.Tests.Models
{
    public class MarsGridTests
    {
        [Fact]
        public void IsWithinBounds_PointInsideBounds_ReturnsTrue()
        {
            var grid = new MarsGrid(5, 3);
            var point = new Point(3, 2);

            Assert.True(grid.IsWithinBounds(point));
        }

        [Fact]
        public void IsWithinBounds_PointOutsideBounds_ReturnsFalse()
        {
            var grid = new MarsGrid(5, 3);
            var point = new Point(6, 2);

            Assert.False(grid.IsWithinBounds(point));
        }
    }
}
