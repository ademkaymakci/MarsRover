using MarsRover.Common.Enums;

namespace MarsRover.Common.Model.Response
{
    public  class StartValueControlRespose
    {
        public bool continueFL { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Directions Direction { get; set; }
    }
}
