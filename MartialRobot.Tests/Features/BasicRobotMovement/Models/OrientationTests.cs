using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Models
{
    public class OrientationTests
    {
        [Fact]
        public void RotateLeft_FromNorth_ReturnsWest()
        {
            var result = Orientation.North.RotateLeft();
            Assert.Equal(Orientation.West, result);
        }

        [Fact]
        public void RotateLeft_FromWest_ReturnsSouth()
        {
            var result = Orientation.West.RotateLeft();
            Assert.Equal(Orientation.South, result);
        }

        [Fact]
        public void RotateLeft_FromSouth_ReturnsEast()
        {
            var result = Orientation.South.RotateLeft();
            Assert.Equal(Orientation.East, result);
        }

        [Fact]
        public void RotateLeft_FromEast_ReturnsNorth()
        {
            var result = Orientation.East.RotateLeft();
            Assert.Equal(Orientation.North, result);
        }

        [Fact]
        public void RotateLeft_FullRotation_ReturnsToOriginal()
        {
            var original = Orientation.North;
            var rotated = original.RotateLeft().RotateLeft().RotateLeft().RotateLeft();

            Assert.Equal(original, rotated);
        }

        [Fact]
        public void RotateRight_FromNorth_ReturnsEast()
        {
            var result = Orientation.North.RotateRight();
            Assert.Equal(Orientation.East, result);
        }

        [Fact]
        public void RotateRight_FromEast_ReturnsSouth()
        {
            var result = Orientation.East.RotateRight();
            Assert.Equal(Orientation.South, result);
        }

        [Fact]
        public void RotateRight_FromSouth_ReturnsWest()
        {
            var result = Orientation.South.RotateRight();
            Assert.Equal(Orientation.West, result);
        }

        [Fact]
        public void RotateRight_FromWest_ReturnsNorth()
        {
            var result = Orientation.West.RotateRight();
            Assert.Equal(Orientation.North, result);
        }

        [Fact]
        public void RotateRight_FullRotation_ReturnsToOriginal()
        {
            var original = Orientation.North;
            var rotated = original.RotateRight().RotateRight().RotateRight().RotateRight();

            Assert.Equal(original, rotated);
        }

        [Fact]
        public void RotateLeftThenRight_ReturnsToOriginal()
        {
            var original = Orientation.North;
            var rotated = original.RotateLeft().RotateRight();

            Assert.Equal(original, rotated);
        }

        [Fact]
        public void RotateRightThenLeft_ReturnsToOriginal()
        {
            var original = Orientation.East;
            var rotated = original.RotateRight().RotateLeft();

            Assert.Equal(original, rotated);
        }

        [Fact]
        public void ToChar_North_ReturnsN()
        {
            Assert.Equal('N', Orientation.North.ToChar());
        }

        [Fact]
        public void ToChar_South_ReturnsS()
        {
            Assert.Equal('S', Orientation.South.ToChar());
        }

        [Fact]
        public void ToChar_East_ReturnsE()
        {
            Assert.Equal('E', Orientation.East.ToChar());
        }

        [Fact]
        public void ToChar_West_ReturnsW()
        {
            Assert.Equal('W', Orientation.West.ToChar());
        }

        [Fact]
        public void FromChar_UpperCaseN_ReturnsNorth()
        {
            Assert.Equal(Orientation.North, OrientationExtensions.FromChar('N'));
        }

        [Fact]
        public void FromChar_LowerCaseN_ReturnsNorth()
        {
            Assert.Equal(Orientation.North, OrientationExtensions.FromChar('n'));
        }

        [Fact]
        public void FromChar_UpperCaseS_ReturnsSouth()
        {
            Assert.Equal(Orientation.South, OrientationExtensions.FromChar('S'));
        }

        [Fact]
        public void FromChar_LowerCaseS_ReturnsSouth()
        {
            Assert.Equal(Orientation.South, OrientationExtensions.FromChar('s'));
        }

        [Fact]
        public void FromChar_UpperCaseE_ReturnsEast()
        {
            Assert.Equal(Orientation.East, OrientationExtensions.FromChar('E'));
        }

        [Fact]
        public void FromChar_LowerCaseE_ReturnsEast()
        {
            Assert.Equal(Orientation.East, OrientationExtensions.FromChar('e'));
        }

        [Fact]
        public void FromChar_UpperCaseW_ReturnsWest()
        {
            Assert.Equal(Orientation.West, OrientationExtensions.FromChar('W'));
        }

        [Fact]
        public void FromChar_LowerCaseW_ReturnsWest()
        {
            Assert.Equal(Orientation.West, OrientationExtensions.FromChar('w'));
        }

        [Fact]
        public void FromChar_InvalidCharacter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => OrientationExtensions.FromChar('X'));
            Assert.Throws<ArgumentException>(() => OrientationExtensions.FromChar('1'));
            Assert.Throws<ArgumentException>(() => OrientationExtensions.FromChar('?'));
        }
    }
}
