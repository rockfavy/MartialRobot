using MartialRobot.Features.BasicRobotMovement.Commands;

namespace MartialRobot.Tests.Features.BasicRobotMovement.Command
{
    public class CommandFactoryTests
    {
        [Fact]
        public void Create_UpperCaseL_ReturnsLeftCommand()
        {
            var command = CommandFactory.Create('L');

            Assert.IsType<LeftCommand>(command);
        }

        [Fact]
        public void Create_LowerCaseL_ReturnsLeftCommand()
        {
            var command = CommandFactory.Create('l');

            Assert.IsType<LeftCommand>(command);
        }

        [Fact]
        public void Create_UpperCaseR_ReturnsRightCommand()
        {
            var command = CommandFactory.Create('R');

            Assert.IsType<RightCommand>(command);
        }

        [Fact]
        public void Create_UpperCaseF_ReturnsForwardCommand()
        {
            var command = CommandFactory.Create('F');

            Assert.IsType<ForwardCommand>(command);
        }

        [Fact]
        public void Create_InvalidCharacter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => CommandFactory.Create('X'));
        }

        [Fact]
        public void CreateFromString_ValidString_ReturnsCommands()
        {
            var commands = CommandFactory.CreateFromString("LRF").ToList();

            Assert.Equal(3, commands.Count);
            Assert.IsType<LeftCommand>(commands[0]);
            Assert.IsType<RightCommand>(commands[1]);
            Assert.IsType<ForwardCommand>(commands[2]);
        }
    }
}
