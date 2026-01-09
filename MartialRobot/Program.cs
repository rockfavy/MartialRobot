
using System.Collections.Generic;
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
        Console.WriteLine("Martian Robots");
        Console.WriteLine("==============");
        Console.Write("Select input method (1=File, 2=Manual, -1=Exit): ");
        
        var choice = Console.ReadLine()?.Trim();
        
        if (choice == "-1")
        {
            Console.WriteLine("\nYou have chosen to exit the application.");
            Console.WriteLine("No input was processed. To run the application again, execute: dotnet run");
            Console.WriteLine("Thank you for using Martian Robots!");
            Environment.Exit(0);
            return;
        }
        
        if (choice == "1")
        {
            Console.Write("Enter file path (-1 to exit): ");
            var filePath = Console.ReadLine()?.Trim();
            
            if (filePath == "-1")
            {
                Console.WriteLine("\nYou have chosen to exit the application.");
                Console.WriteLine("File input was cancelled. No processing was performed.");
                Console.WriteLine("To run the application again, execute: dotnet run");
                Console.WriteLine("Thank you for using Martian Robots!");
                Environment.Exit(0);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.Error.WriteLine("Error: File path cannot be empty.");
                Environment.Exit(1);
                return;
            }
            
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"Error: File '{filePath}' not found.");
                Environment.Exit(1);
                return;
            }
            
            reader = new StreamReader(filePath);
            Console.WriteLine("Reading from file...\n");
        }
        else if (choice == "2")
        {
            Console.WriteLine("\nEnter input line by line. Type -1 on a new line to finish.\n");
            Console.Write("Grid size (maxX maxY): ");
            
            var gridLine = Console.ReadLine()?.Trim();
            if (gridLine == "-1")
            {
                Console.WriteLine("\nYou have chosen to exit the application.");
                Console.WriteLine("Manual input was cancelled. No processing was performed.");
                Console.WriteLine("To run the application again, execute: dotnet run");
                Console.WriteLine("Thank you for using Martian Robots!");
                Environment.Exit(0);
                return;
            }
            
            var inputLines = new List<string> { gridLine ?? "" };
            
            while (true)
            {
                Console.Write("Robot position (x y orientation) or -1 to finish: ");
                var positionLine = Console.ReadLine()?.Trim();
                
                if (positionLine == "-1")
                {
                    Console.WriteLine("\nInput collection completed. Processing robots...\n");
                    break;
                }
                
                if (string.IsNullOrWhiteSpace(positionLine))
                {
                    continue;
                }
                
                inputLines.Add(positionLine);
                
                Console.Write("Instructions: ");
                var instructionLine = Console.ReadLine()?.Trim();
                
                if (instructionLine == "-1")
                {
                    Console.WriteLine("\nYou have chosen to exit the application.");
                    Console.WriteLine("Warning: Instructions are required for each robot.");
                    Console.WriteLine("The current robot input is incomplete and will not be processed.");
                    Console.WriteLine("To run the application again, execute: dotnet run");
                    Console.WriteLine("Thank you for using Martian Robots!");
                    Environment.Exit(1);
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(instructionLine))
                {
                    Console.Error.WriteLine("Error: Instructions cannot be empty.");
                    Environment.Exit(1);
                    return;
                }
                
                inputLines.Add(instructionLine);
            }
            
            reader = new StringReader(string.Join("\n", inputLines));
        }
        else
        {
            Console.Error.WriteLine($"Error: Invalid choice '{choice}'. Please enter 1, 2, or -1.");
            Environment.Exit(1);
            return;
        }
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
