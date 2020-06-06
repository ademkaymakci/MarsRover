using MarsRover.Common.Enums;
using MarsRover.Common.Model.Request;
using MarsRover.Common.Model.Response;
using System.Collections.Generic;

namespace MarsRover.Business
{
    public class InputValueControl
    {
        public InputValueControl()
        {
            rotate.Add("E");
            rotate.Add("W");
            rotate.Add("S");
            rotate.Add("N");
        }
        public CoordinateControlResponse coordinateControl(List<string> coordinate)
        {
            CoordinateControlResponse coordinateControlResponse = new CoordinateControlResponse();
            coordinateControlResponse.continueFL = false;
            if (coordinate.Count == 2)
            {
                coordinateControlResponse.continueFL = true;
                coordinateControlResponse.maxXPoint = int.Parse(coordinate[0]);
                coordinateControlResponse.maxYPoint = int.Parse(coordinate[1]);
            }
            return coordinateControlResponse;
        }


        public StartValueControlRespose startValueControl(StartValueControlRequest request)
        {
            var startValueControl = new StartValueControlRespose();

            var startValue = request.startValue;

            if (startValue.Count == 3 && int.Parse(startValue[0]) <= request.maxXPoint && int.Parse(startValue[1]) <= request.maxYPoint && rotate.Contains(startValue[2]))
            {
                startValueControl.continueFL = true;
                startValueControl.x = int.Parse(startValue[0]);
                startValueControl.y = int.Parse(startValue[1]);

                switch (startValue[2])
                {
                    case "E": startValueControl.Direction = Directions.E; break;
                    case "W": startValueControl.Direction = Directions.W; break;
                    case "S": startValueControl.Direction = Directions.S; break;
                    case "N": startValueControl.Direction = Directions.N; break;
                    default: break;
                }
            }

            return startValueControl;
        }

        List<string> rotate = new List<string>();
    }
}
