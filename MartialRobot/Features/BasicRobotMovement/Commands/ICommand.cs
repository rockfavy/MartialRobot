using MartialRobot.Features.BasicRobotMovement.Models;

namespace MartialRobot.Features.BasicRobotMovement.Commands
{
    public interface ICommand
    {
        void Execute(Robot robot);
    }
}
