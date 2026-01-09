namespace MartialRobot.Features.BasicRobotMovement.Models
{
    public class Robot
    {
        public CoordonatePoint Position { get; set; }
        public Orientation Orientation { get; set; }
        public bool IsLost { get; set; }

        public Robot(CoordonatePoint position, Orientation orientation)
        {
            Position = position;
            Orientation = orientation;
            IsLost = false;
        }

        public string GetStateString()
        {
            var state = $"{Position.X} {Position.Y} {Orientation.ToChar()}";
            if (IsLost)
            {
                state += " LOST";
            }
            return state;
        }
    }
}
