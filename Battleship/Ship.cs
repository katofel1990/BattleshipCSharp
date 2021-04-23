using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Ship
    {
        public int Length { get; private set; }
        public (int x, int y) OriginPoint { get; set; }
        public enum Direction { horizontal, vertical }
        public Direction InstanceDirection { get; set; }
        enum ShipType { Carrier, Cruiser, Battleship, Submarine, Destroyer }
        ShipType Type { get; set; }
        public List<Square> Squares { get; private set; } = new List<Square>();

        public Ship(int x, int y, int length, Direction dir)
        {
            this.OriginPoint = (x, y);
            this.Length = length;
            this.InstanceDirection = dir;
            SetTypeShip();
        }

        public Ship(int length)
        {
            this.Length = length;
            SetTypeShip();
        }

        void SetTypeShip()
        {
            switch (Length)
            {
                case 1:
                    this.Type = ShipType.Carrier;
                    break;
                case 2:
                    this.Type = ShipType.Cruiser;
                    break;
                case 3:
                    this.Type = ShipType.Battleship;
                    break;
                case 4:
                    this.Type = ShipType.Submarine;
                    break;
                default:
                    break;
            }
        }
        public string GetShipType()
        {
            return Type.ToString();
        }

        internal void AddSquare(Square square)
        {
            Squares.Add(square);
        }
        public bool IsAlive()
        {
            foreach (var square in Squares)
            {
                if (square.Status == Square.SquareStatus.ship)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
