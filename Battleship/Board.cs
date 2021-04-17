using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Board
    {
        public Square[,] ocean { get; private set; }
        public int Size { get; private set; }

        public Board() // TODO pass size (or widht and height) here - bart
        {
            Size = 10;
            ocean = NewOcean(Size);
        }
        void AddWatter(Square[,] o)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    o[j, i] = new Square(j, i);
                }
            }
        }
        Square[,] NewOcean(int size)
        {
            Square[,] res = new Square[size, size];
            AddWatter(res);
            return res;
        }

        public void AddShip(Ship ship)
        {
            for (int i = 0; i < ship.length; i++)
            {
                Square square;
                if (ship.direction == Ship.Direction.horizontal)
                {
                    square = ocean[ship.OriginPoint.x + i, ship.OriginPoint.y];
                    square.Status = Square.SquareStatus.ship;
                    ship.AddSquare(square);
                }
                else
                {
                    square = ocean[ship.OriginPoint.x, ship.OriginPoint.y + i];
                    square.Status = Square.SquareStatus.ship;
                    ship.AddSquare(square);
                }
            }
        }

        public bool possibleShip(Ship ship)
        {
            for (int i = 0; i < ship.length; i++)
            {
                if (ship.direction == Ship.Direction.horizontal)
                {
                    if (ocean[ship.OriginPoint.x+i, ship.OriginPoint.y].Status != Square.SquareStatus.empty)
                    {
                        return false;
                    }
                }
                else
                {
                    if (ocean[ship.OriginPoint.x, ship.OriginPoint.y + i].Status != Square.SquareStatus.empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
