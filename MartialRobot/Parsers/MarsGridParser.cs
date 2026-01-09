using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartialRobot.Parsers
{
    public class MarsGridParser
    {
        public (int maxX, int maxY) ParseCoordinates(string line)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new ArgumentException($"Invalid grid line: {line}");
            }

            if (!int.TryParse(parts[0], out var maxX) || !int.TryParse(parts[1], out var maxY))
            {
                throw new ArgumentException($"Invalid grid coordinates: {line}");
            }

            return (maxX, maxY);
        }
    }
}
