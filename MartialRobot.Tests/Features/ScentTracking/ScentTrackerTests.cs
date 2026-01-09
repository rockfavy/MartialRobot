using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.ScentTracking;

namespace MartialRobot.Tests.Features.ScentTracking
{
    public class ScentTrackerTests
    {
        [Fact]
        public void HasScent_AfterAddingScent_ReturnsTrue()
        {
            var tracker = new ScentTracker();
            var point = new CoordonatePoint(5, 3);

            tracker.AddScent(point);

            Assert.True(tracker.HasScent(point));
        }

        [Fact]
        public void HasScent_WithoutAddingScent_ReturnsFalse()
        {
            var tracker = new ScentTracker();
            var point = new CoordonatePoint(5, 3);

            Assert.False(tracker.HasScent(point));
        }

        [Fact]
        public void HasScent_DifferentPoint_ReturnsFalse()
        {
            var tracker = new ScentTracker();
            var point1 = new CoordonatePoint(5, 3);
            var point2 = new CoordonatePoint(5, 4);

            tracker.AddScent(point1);

            Assert.False(tracker.HasScent(point2));
        }

        [Fact]
        public void HasScent_SameCoordinates_DifferentInstance_ReturnsTrue()
        {
            var tracker = new ScentTracker();
            var point1 = new CoordonatePoint(5, 3);
            var point2 = new CoordonatePoint(5, 3);

            tracker.AddScent(point1);

            Assert.True(tracker.HasScent(point2));
        }

        [Fact]
        public void AddScent_MultiplePoints_TracksAll()
        {
            var tracker = new ScentTracker();
            var point1 = new CoordonatePoint(5, 3);
            var point2 = new CoordonatePoint(3, 2);
            var point3 = new CoordonatePoint(0, 0);

            tracker.AddScent(point1);
            tracker.AddScent(point2);
            tracker.AddScent(point3);

            Assert.True(tracker.HasScent(point1));
            Assert.True(tracker.HasScent(point2));
            Assert.True(tracker.HasScent(point3));
        }
    }
}
