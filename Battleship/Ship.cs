using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Ship
    {
        public int length { get; private set; }
        public (int x, int y) OriginPoint { get; private set; }
        public enum Direction { horizontal, vertical }
        public Direction direction { get; private set; }
        enum ShipType { Carrier, Cruiser, Battleship, Submarine, Destroyer }
        ShipType type { get; set; }

        public Ship(int x, int y, int length, Direction dir)
        {
            this.OriginPoint = (x, y);
            this.length = length;
            this.direction = dir;
            SetTypeShip();
        }

        void SetTypeShip()
        {
            switch (length)
            {
                case 1:
                    this.type = ShipType.Carrier;
                    break;
                case 2:
                    this.type = ShipType.Cruiser;
                    break;
                case 3:
                    this.type = ShipType.Battleship;
                    break;
                case 4:
                    this.type = ShipType.Submarine;
                    break;
                default:
                    break;
            }
        }
        public string GetShipType()
        {
            return type.ToString();
        }
    }
}
