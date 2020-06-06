using MarsRover.Business;
using MarsRover.Common.Model;
using MarsRover.Common.Model.Request;
using MarsRover.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputControlFL = true;
                var anotherRoverControlFL = true;


                CoordinateControlResponse coordinateControl = new CoordinateControlResponse();
                List<RequestMovingModel> requestMovingList = new List<RequestMovingModel>();

                //Girilen koordinat değer aralıkları kontrol ettiriliyor
                while (inputControlFL)
                {
                    Console.WriteLine("Koordinatları giriniz :"); var coordinate = Console.ReadLine();

                    coordinateControl = inputValueControl.coordinateControl(coordinate.TrimEnd().Split(' ').Select(x => x).ToList());

                    inputControlFL = !coordinateControl.continueFL;

                    if (inputControlFL)
                        Console.WriteLine("Girilen koordinat bilgiler yanlış.  Tekrar Deneyiniz");
                }


                //Girilen yönlendirmeler listeye ekleniyor
                while (anotherRoverControlFL)
                {
                    var reqModel = new RequestMovingModel();

                    inputControlFL = true;
                    while (inputControlFL)
                    {
                        Console.WriteLine("Başlangıç pozisyonu giriniz :"); var startPostion = Console.ReadLine();

                        var inputValue = startPostion.ToUpper().Split(' ').Select(x => x).ToList();

                        var startValueControl = inputValueControl.startValueControl(new StartValueControlRequest
                        {
                            startValue = inputValue,
                            maxXPoint = coordinateControl.maxXPoint,
                            maxYPoint = coordinateControl.maxYPoint
                        });

                        inputControlFL = !startValueControl.continueFL;
                        if (inputControlFL)
                            Console.WriteLine("Girilen başlangıç pozisyon bilgiler veya aralıklar dışında.  Tekrar Deneyiniz");
                        else
                        {
                            reqModel.x = startValueControl.x;
                            reqModel.y = startValueControl.y;
                            reqModel.Direction = startValueControl.Direction;
                        }
                    }

                    Console.WriteLine("Yönlendirmeleri giriniz giriniz :");
                    reqModel.moving = Console.ReadLine().ToUpper();


                    //Girilen değer istek listesine ekleniyor
                    requestMovingList.Add(reqModel);

                    Console.WriteLine("Başka bir yönlendirme istiyor musunuz  ? (Y)");
                    if (Console.ReadLine().ToUpper() != "Y")
                    {
                        anotherRoverControlFL = false;
                    }
                }


                MarsRoverProcess roverProcess = new MarsRoverProcess(new MarsRoverProcessRequest
                {
                    x = coordinateControl.maxXPoint,
                    y = coordinateControl.maxYPoint
                });

                Console.WriteLine("İşlem Çıktıları :");
                foreach (RequestMovingModel moving in requestMovingList)
                {
                    roverProcess.beginMoving(moving);
                    Console.WriteLine($"{roverProcess.x} {roverProcess.y} {roverProcess.Direction.ToString()}");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
 


        private static readonly InputValueControl _inputValueControl;
        public static InputValueControl inputValueControl => (_inputValueControl ?? new InputValueControl());
    }
}
