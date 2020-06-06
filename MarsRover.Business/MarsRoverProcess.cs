using MarsRover.Common.Abstract;
using MarsRover.Common.Enums;
using MarsRover.Common.Model;
using MarsRover.Common.Model.Request;
using System;

namespace MarsRover.Business
{
    public class MarsRoverProcess : IPosition
    {

        public MarsRoverProcess(MarsRoverProcessRequest process)
        {
            maxXPoint = process.x;
            maxYPoint = process.y;
        }

        /// <summary>
        /// Hareket işlemleri yapılıyor
        /// </summary>
        /// <param name="reqMoves"></param>        
        public void beginMoving(RequestMovingModel reqMoves)
        {
            x = reqMoves.x;
            y = reqMoves.y;
            Direction = reqMoves.Direction;

            foreach (var move in reqMoves.moving)
            {
                switch (move)
                {
                    case 'M':
                        this.directionProcess();
                        break;
                    case 'L':
                        this.rotateLeft();
                        break;
                    case 'R':
                        this.rotateRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                //X ve Ye sınırları dışına çıkar ise hata fırlatılacak
                if (this.x < 0 || this.x > maxXPoint || this.y < 0 || this.y > maxYPoint)
                {
                    throw new Exception($"Yapılan yönlendirmeler sınır dışında, işlem sonlandılırıyor. Sınır değerler (x = {maxXPoint} , y = {maxXPoint}) )");
                }
            }
        }


        /// <summary>
        /// 90 derece sol tarafa yön değiştirildiğinde düzenlemeler yapılıyor
        /// </summary>
        private void rotateLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Hareket ettirildiğinde x ve y koordinatların değerleri güncelleniyor
        /// </summary>
        private void directionProcess()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.y += 1;
                    break;
                case Directions.S:
                    this.y -= 1;
                    break;
                case Directions.E:
                    this.x += 1;
                    break;
                case Directions.W:
                    this.x -= 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 90 derece sağ tarafa yön değiştirildiğinde düzenlemeler yapılıyor
        /// </summary>

        private void rotateRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

         
        #region properties tanımları

        public int x { get; set; }
        public int y { get; set; }

        public int maxXPoint { get; set; }
        public int maxYPoint { get; set; }
        public Directions Direction { get; set; }

        #endregion
    }
}
