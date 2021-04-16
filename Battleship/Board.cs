using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Board
    {
        public Square[,] ocean { get; private set; }
        public int Size { get; private set; }

        public Board()
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

        void AddShip(Ship ship)
        {

        }

    }
}
