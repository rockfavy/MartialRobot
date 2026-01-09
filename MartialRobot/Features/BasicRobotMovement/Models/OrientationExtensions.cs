namespace MartialRobot.Features.BasicRobotMovement.Models
{
    public static class OrientationExtensions
    {
        public static Orientation RotateLeft(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.North => Orientation.West,
                Orientation.West => Orientation.South,
                Orientation.South => Orientation.East,
                Orientation.East => Orientation.North,
                _ => throw new ArgumentException($"Unknown orientation: {orientation}")
            };
        }

        public static Orientation RotateRight(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.North => Orientation.East,
                Orientation.East => Orientation.South,
                Orientation.South => Orientation.West,
                Orientation.West => Orientation.North,
                _ => throw new ArgumentException($"Unknown orientation: {orientation}")
            };
        }

        public static char ToChar(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.North => 'N',
                Orientation.South => 'S',
                Orientation.East => 'E',
                Orientation.West => 'W',
                _ => throw new ArgumentException($"Unknown orientation: {orientation}")
            };
        }

        public static Orientation FromChar(char c)
        {
            return char.ToUpper(c) switch
            {
                'N' => Orientation.North,
                'S' => Orientation.South,
                'E' => Orientation.East,
                'W' => Orientation.West,
                _ => throw new ArgumentException($"Invalid orientation character: {c}")
            };
        }
    }
}
