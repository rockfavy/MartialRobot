
using MartialRobot.Features.BasicRobotMovement.Commands;
using MartialRobot.Features.MultipleRobots.Parsers;
using MartialRobot.Features.ScentTracking;

try
{
    TextReader reader;

    if (args.Length > 0)
    {
        if (!File.Exists(args[0]))
        {
            Console.Error.WriteLine($"Error: File '{args[0]}' not found.");
            Environment.Exit(1);
            return;
        }
        reader = new StreamReader(args[0]);
    }
    else
    {
        reader = Console.In;
    }

    var parser = new InputParser();
    var robotInputs = parser.ParseAll(reader);

    foreach (var robotInput in robotInputs)
    {
        var scentTracker = new ScentTracker();
        var commands = CommandFactory.CreateFromString(robotInput.Instructions);

        foreach (var command in commands)
        {
            command.Execute(robotInput.Robot, robotInput.Grid, scentTracker);
        }

        Console.WriteLine(robotInput.Robot.GetStateString());
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}
