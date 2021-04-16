using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BoardFactory
    {
        Display dis = new Display();
        Input input = new Input();
        void RandomPlacement()
        { }
        void ManualPlacement()
        {

        }
        public void AddOneShipManual(Board board, int lenght)
        {
            int x = 0;
            int y = 0;
            int size = board.Size;
            Ship.Direction dir = Ship.Direction.horizontal;
            ConsoleKey key;
            do
            {
                dis.PrintBoardWithPotentialShip(board, GenerateTuple(x, y, lenght, dir));
                key = input.ReadKey();
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (y == 0 && dir == Ship.Direction.vertical) { y = size - lenght; } else if (y == 0 && dir == Ship.Direction.horizontal) { y = size - 1; } else { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if ((y == size - lenght && dir == Ship.Direction.vertical) || (y == size - 1)) { y = 0; } else { y++; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x == 0 && dir == Ship.Direction.horizontal) { x = size - lenght; } else if (x == 0 && dir == Ship.Direction.vertical) { x = size - 1; } else { x--; }
                        break;
                    case ConsoleKey.RightArrow:
                        if ((x == size - lenght && dir == Ship.Direction.horizontal) || (x == size - 1)) { x = 0; } else { x++; }
                        break;
                    case ConsoleKey.Spacebar:
                        if (dir == Ship.Direction.horizontal)
                        {
                            dir = Ship.Direction.vertical;
                            if (y >= size - lenght) { y = size - lenght; }
                        }
                        else
                        {
                            dir = Ship.Direction.horizontal;
                            if (x >= size - lenght) { x = size - lenght; }
                        }
                        break;
                    default:
                        break;
                }
            } while (key != ConsoleKey.Enter);
        }

        private (int, int, int, int) GenerateTuple(int x, int y, int length, Ship.Direction dir)
        {
            int ymax = y;
            int xmax = x;
            int len = length - 1;

            if (dir == Ship.Direction.horizontal)
            {
                xmax += len;
            }
            else
            {
                ymax += len;
            }

            return (x, xmax, y, ymax);
        }
    }
