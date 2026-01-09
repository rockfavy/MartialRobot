using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.BasicRobotMovement.Parsers;
using MartialRobot.Features.GridBoundaries.Models;
using MartialRobot.Features.GridBoundaries.Parsers;

namespace MartialRobot.Features.MultipleRobots.Parsers
{
    public class InputParser
    {
        private readonly MarsGridParser _gridParser = new();
        private readonly RobotPositisionParser _robotPositionParser = new();
        private readonly InstructionParser _instructionParser = new();

        public List<RobotInput> ParseAll(TextReader reader)
        {
            var results = new List<RobotInput>();

            var gridLine = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(gridLine))
            {
                throw new ArgumentException("Grid size line is missing");
            }

            var (maxX, maxY) = _gridParser.ParseCoordinates(gridLine);
            var grid = new MarsGrid(maxX, maxY);

            string? positionLine;
            while ((positionLine = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(positionLine)) continue;

                var instructionLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(instructionLine))
                {
                    throw new ArgumentException($"Missing instruction Line for robot: {positionLine}");
                }

                var (position, orientation) = _robotPositionParser.Parse(positionLine);
                var robot = new Robot(position, orientation);
                var instructions = _instructionParser.Parse(instructionLine);

                results.Add(new RobotInput
                {
                    Robot = robot,
                    Instructions = instructions,
                    Grid = grid
                });
            }

            return results;
        }
    }

    public class RobotInput
    {
        public Robot Robot { get; set; } = null!;
        public string Instructions { get; set; } = string.Empty;
        public MarsGrid Grid { get; set; } = null!;
    }
}
