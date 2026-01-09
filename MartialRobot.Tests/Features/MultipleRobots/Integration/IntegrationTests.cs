using MartialRobot.Features.BasicRobotMovement.Commands;
using MartialRobot.Features.MultipleRobots.Parsers;
using MartialRobot.Features.ScentTracking;

namespace MartialRobot.Tests.Features.MultipleRobots.Integration
{
    public class IntegrationTests
    {
        [Fact]
        public void SampleInput_ProducesExpectedOutput()
        {
            var input = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";

            var reader = new StringReader(input);
            var parser = new InputParser();
            var robotInputs = parser.ParseAll(reader);

            var outputs = new List<string>();
            var scentTracker = new ScentTracker(); 
            
            foreach (var robotInput in robotInputs)
            {
                var commands = CommandFactory.CreateFromString(robotInput.Instructions);

                foreach (var command in commands)
                {
                    command.Execute(robotInput.Robot, robotInput.Grid, scentTracker);
                }

                outputs.Add(robotInput.Robot.GetStateString());
            }

            Assert.Equal("1 1 E", outputs[0]);
            Assert.Equal("3 3 N LOST", outputs[1]);
            Assert.Equal("2 3 S", outputs[2]);
        }

        [Fact]
        public void Integration_MultipleRobotsLoseAtSameSpot_SecondPrevented()
        {
            var input = @"5 3
5 3 N
F
5 3 N
F";
            var reader = new StringReader(input);
            var parser = new InputParser();
            var robotInputs = parser.ParseAll(reader);

            var outputs = new List<string>();
            var scentTracker = new ScentTracker();

            foreach (var robotInput in robotInputs)
            {
                var commands = CommandFactory.CreateFromString(robotInput.Instructions);

                foreach (var command in commands)
                {
                    command.Execute(robotInput.Robot, robotInput.Grid, scentTracker);
                }

                outputs.Add(robotInput.Robot.GetStateString());
            }

            Assert.Equal("5 3 N LOST", outputs[0]);
            Assert.Equal("5 3 N", outputs[1]); 
        }
    }
}
