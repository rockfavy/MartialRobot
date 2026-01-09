using MartialRobot.Features.BasicRobotMovement.Models;
using MartialRobot.Features.GridBoundaries.Models;

namespace MartialRobot.Features.BasicRobotMovement.Commands
{
    public interface ICommand
    {
        void Execute(Robot robot, MarsGrid? grid = null);
    }
}
