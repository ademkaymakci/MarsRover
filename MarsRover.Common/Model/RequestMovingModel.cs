using MarsRover.Common.Enums;

namespace MarsRover.Common.Model
{
    public class RequestMovingModel
    {
        public int x { get; set; }
        public int y { get; set; }
        public string moving { get; set; }
        public Directions Direction { get; set; }
    }
}
