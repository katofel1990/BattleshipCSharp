using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public string Name { get; set; }
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public Board Board { get; }
        public Square LastShot { get; private set; }

        public Player(string name)
        {
            Board = new Board(10);
            Name = name;
        }

        public bool IsAlive()
        {

            foreach (var ship in Ships)
            {
                if (ship.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void OneShot(Board board)
        {
            Display display = new Display();  // do wykasowania
            Input input = new Input(); // do wykasowania
            

            int x = 0;
            int y = 0;
            int size = board.Size;
            ConsoleKey key;            
            bool wrongPositionMessage = false;
            bool shoot = true;
            do
            {
                display.PrintBoard(board, x, y);
                display.PrintMessage($"\n{Name} turn.");
                if (wrongPositionMessage)
                {
                    display.PrintMessage("Ivalid Shoot", ConsoleColor.Red);
                    wrongPositionMessage = false;
                }
                key = input.ReadKey();

                switch (key)
                {
                    case ConsoleKey.UpArrow:

                        if (y == 0) { y = size - 1; }
                        else { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if ((y == size - 1)) { y = 0; }
                        else { y++; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x == 0) { x = size - 1; }
                        else { x--; }
                        break;
                    case ConsoleKey.RightArrow:
                        if ((x == size - 1)) { x = 0; }
                        else { x++; }
                        break;
                    case ConsoleKey.Enter:
                        if (CoordsAreValid(board, x, y))
                        {
                            Shoot(board, x, y);

                            //TODO jak działa system sleep
                            //display.PrintBoard(Board);
                            //display.WaitForTime(1000);

                            shoot = false;
                        }
                        else
                        {
                            wrongPositionMessage = true;
                        }
                        break;
                    default:
                        break;
                }
            } while (shoot);
        }

        protected bool CoordsAreValid(Board board, int x, int y)
        {
            return board.ocean[x, y].Status == Square.SquareStatus.empty || board.ocean[x, y].Status == Square.SquareStatus.ship;
        }

        protected void Shoot(Board board, int x, int y)
        {
            board.ocean[x, y].Status = board.ocean[x, y].Status == Square.SquareStatus.ship ? Square.SquareStatus.hit : Square.SquareStatus.missed;
            if (board.ocean[x, y].Status == Square.SquareStatus.hit)
            {
                if (!board.ocean[x, y].CurrentShip.IsAlive())
                {
                    board.MarkAdjacentSquares(board.ocean[x, y].CurrentShip);
                }
            }
            LastShot = board.ocean[x, y];



            Display display = new Display();  // do wykasowania
            display.PrintBoard(board);
            display.WaitForTime(1000);
        }

        public int GetScore()
        {
            int score = 100;
            score += GetSquaresCount() * 10;
            return score;
        }

        private int GetSquaresCount()
        {
            int result = 0;

            foreach (var ship in Ships)
            {
                foreach(var square in ship.squares)
                {
                    if (square.Status == Square.SquareStatus.ship) result++;
                }
            }

            return result;
        }
    }
}
