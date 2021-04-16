﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Square
    {
        public (int x, int y) Position { get; private set; }
        public enum SquareStatus { empty, ship, hit, missed }
        SquareStatus status { get; set; }


        public Square(int x, int y)
        {
            Position = (x, y);
            status = SquareStatus.empty;
        }

        public char GetCharacter()
        {
            switch ((int)status)
            {
                case 0:
                    return '~';
                case 1:
                    return '0';
                case 2:
                    return 'x';
                case 3:
                    return '*';
                default:
                    return 'e';

            }
        }
        public void ChangeStatus(SquareStatus s)
        {
            this.status = s;
        }
    }
}