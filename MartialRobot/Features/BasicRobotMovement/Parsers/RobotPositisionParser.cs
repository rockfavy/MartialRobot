using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Features.BasicRobotMovement.Parsers
{
    public class RobotPositisionParser
    {
        public (CoordonatePoint position, Orientation orientation) Parse(string positionLine)
        {
            var parts = positionLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new ArgumentException($"Invalid robot position line: {positionLine}");
            }

            if (!int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y))
            {
                throw new ArgumentException($"Invalid robot coordinates: {positionLine}");
            }

            if (parts[2].Length != 1)
            {
                throw new ArgumentException($"Invalid orientation: {positionLine}");
            }

            var orientation = OrientationExtensions.FromChar(parts[2][0]);
            return (new CoordonatePoint(x, y), orientation);
        }
    }
}
