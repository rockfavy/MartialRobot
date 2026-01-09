namespace MartialRobot.Features.BasicRobotMovement.Commands
{
    public class CommandFactory
    {
        public static ICommand Create(char commandChar)
        {
            return char.ToUpper(commandChar) switch
            {
                'L' => new LeftCommand(),
                'R' => new RightCommand(),
                'F' => new ForwardCommand(),
                _ => throw new ArgumentException($"Unknown command: {commandChar}")
            };
        }

        public static IEnumerable<ICommand> CreateFromString(string instructionString)
        {
            foreach (var ch in instructionString)
            {
                yield return Create(ch);
            }
        }
    }
}
