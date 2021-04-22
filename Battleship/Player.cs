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

        public void OneShot(string currentPlayerName)
        {
            Display display = new Display();  // do wykasowania
            Input input = new Input(); // do wykasowania
            

            int x = 0;
            int y = 0;
            int size = Board.Size;
            ConsoleKey key;            
            bool wrongPositionMessage = false;
            bool shoot = true;
            do
            {
                display.PrintBoard(Board, x, y);
                display.PrintMessage($"\n{currentPlayerName} turn.");
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
                        if (Board.ocean[x, y].Status == Square.SquareStatus.empty || Board.ocean[x, y].Status == Square.SquareStatus.ship)
                        {
                            Board.ocean[x, y].Status = Board.ocean[x, y].Status == Square.SquareStatus.ship ? Square.SquareStatus.hit : Square.SquareStatus.missed;
                            if (Board.ocean[x,y].Status == Square.SquareStatus.hit)
                            {
                                if (!Board.ocean[x, y].CourentShip.IsAlive())
                                {
                                    Board.MarkAdjacentSquares(Board.ocean[x, y].CourentShip);
                                }                               
                            }
                            LastShot = Board.ocean[x, y];

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
