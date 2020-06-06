using System.Collections.Generic;

namespace MarsRover.Common.Model.Request
{
    public class StartValueControlRequest
    {
        public List<string> startValue { get; set; }
        public int maxXPoint { get; set; }
        public int maxYPoint { get; set; }
    }
}
