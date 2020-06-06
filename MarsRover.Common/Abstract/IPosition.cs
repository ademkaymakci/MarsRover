using MarsRover.Common.Model;
using System.Collections.Generic;

namespace MarsRover.Common.Abstract
{
    public interface IPosition
    {
        void beginMoving(RequestMovingModel moves);  
    }
}
