using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BoardFactory
    {
        Display _display { get; }
        Input _input { get; }
        public BoardFactory(Display display, Input input)
        {
            this._display = display;
            this._input = input;
        }
        public void RandomPlacement(Board board, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                AddOneShipRandom(board, ship);
            }
            board.DeleteBouys();
        }

        void AddOneShipRandom(Board board, Ship ship)
        {
            do
            {
                NewRandomPosition(ship, board.Size);
            }
            while (!board.possibleShip(ship));

            board.AddShip(ship);
        }
        void NewRandomPosition(Ship ship, int sizeMap)
        {
            Random rnd = new Random();
            ship.InstanceDirection = rnd.Next(2) == 0 ? Ship.Direction.horizontal : Ship.Direction.vertical;
            ship.OriginPoint = (ship.InstanceDirection == Ship.Direction.horizontal ?  (rnd.Next(sizeMap - ship.Length + 1), rnd.Next(sizeMap)) : (rnd.Next(sizeMap), rnd.Next(sizeMap - ship.Length + 1)));          
        }

        public void ManualPlacement(Board board, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                AddOneShipManual(board, ship);
            }
            board.DeleteBouys();
        }
        void AddOneShipManual(Board board, Ship ship)
        {
            int x = 0;
            int y = 0;
            int size = board.Size;
            Ship.Direction dir = Ship.Direction.horizontal;
            ConsoleKey key;
            bool CordsNotSet = true;
            bool wrongPositionMessage = false;
            do
            {
                ship.OriginPoint = (x, y);
                ship.InstanceDirection = dir;
                _display.PrintBoard(board, ship);
                if (wrongPositionMessage)
                {
                    _display.PrintMessage("Invalid Ship Position", ConsoleColor.Red);
                    wrongPositionMessage = false;
                }
                key = _input.ReadKey();
                
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (y == 0 && dir == Ship.Direction.vertical) { y = size - ship.Length; } 
                        else if (y == 0 && dir == Ship.Direction.horizontal) { y = size - 1; } 
                        else { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if ((y == size - ship.Length && dir == Ship.Direction.vertical) || (y == size - 1)) { y = 0; } 
                        else { y++; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x == 0 && dir == Ship.Direction.horizontal) { x = size - ship.Length; } 
                        else if (x == 0 && dir == Ship.Direction.vertical) { x = size - 1; } 
                        else { x--; }
                        break;
                    case ConsoleKey.RightArrow:
                        if ((x == size - ship.Length && dir == Ship.Direction.horizontal) || (x == size - 1)) { x = 0; } 
                        else { x++; }
                        break;
                    case ConsoleKey.Spacebar:
                        if (dir == Ship.Direction.horizontal)
                        {
                            dir = Ship.Direction.vertical;
                            if (y >= size - ship.Length) { y = size - ship.Length; }
                        } 
                        else
                        {
                            dir = Ship.Direction.horizontal;
                            if (x >= size - ship.Length) { x = size - ship.Length; }
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
                            wrongPositionMessage = true;
                        }
                        break;
                    default:
                        break;
                }
            } while (CordsNotSet);
        }

    }
}
