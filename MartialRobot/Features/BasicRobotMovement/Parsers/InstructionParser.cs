namespace MartialRobot.Features.BasicRobotMovement.Parsers
{
    public class InstructionParser
    {
        public string Parse(string instructionLine)
        {
            if (string.IsNullOrWhiteSpace(instructionLine))
            {
                throw new ArgumentException("Instruction line cannot be empty");
            }

            foreach (var ch in instructionLine)
            {
                var upperCh = char.ToUpper(ch);
                if (upperCh != 'L' && upperCh != 'R' && upperCh != 'F')
                {
                    throw new ArgumentException($"Invalid instruction character: {ch}");
                }
            }

            return instructionLine;
        }
    }
}
