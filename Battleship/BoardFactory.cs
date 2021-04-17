using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BoardFactory
    {
        Display display { get; }
        Input input { get; }
        public BoardFactory(Display display, Input input)
        {
            this.display = display;
            this.input = input;
        }
        void RandomPlacement()
        { }
        public void ManualPlacement(Board board, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                AddOneShipManual(board, ship);
            }
        }
        public void AddOneShipManual(Board board, Ship ship)
        {
            int x = 0;
            int y = 0;
            int size = board.Size;
            Ship.Direction dir = Ship.Direction.horizontal;
            ConsoleKey key;
            bool CordsNotSet = true;
            bool wrongPositionMassage = false;
            do
            {
                ship.OriginPoint = (x, y);
                ship.direction = dir;
                display.PrintBoard(board, ship);
                if (wrongPositionMassage)
                {
                    display.PrintMassage("Ivalid Ship Position", ConsoleColor.Red);
                    wrongPositionMassage = false;
                }
                key = input.ReadKey();
                
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (y == 0 && dir == Ship.Direction.vertical) { y = size - ship.length; } 
                        else if (y == 0 && dir == Ship.Direction.horizontal) { y = size - 1; } 
                        else { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if ((y == size - ship.length && dir == Ship.Direction.vertical) || (y == size - 1)) { y = 0; } 
                        else { y++; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x == 0 && dir == Ship.Direction.horizontal) { x = size - ship.length; } 
                        else if (x == 0 && dir == Ship.Direction.vertical) { x = size - 1; } 
                        else { x--; }
                        break;
                    case ConsoleKey.RightArrow:
                        if ((x == size - ship.length && dir == Ship.Direction.horizontal) || (x == size - 1)) { x = 0; } 
                        else { x++; }
                        break;
                    case ConsoleKey.Spacebar:
                        if (dir == Ship.Direction.horizontal)
                        {
                            dir = Ship.Direction.vertical;
                            if (y >= size - ship.length) { y = size - ship.length; }
                        }
                        else
                        {
                            dir = Ship.Direction.horizontal;
                            if (x >= size - ship.length) { x = size - ship.length; }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (board.possibleShip(ship))
                        {
                            board.AddShip(ship);
                            CordsNotSet = false;
                        }
                        else
                        {
                            wrongPositionMassage = true;
                        }
                        break;
                    default:
                        break;
                }
            } while (CordsNotSet);
        }

    }
}
