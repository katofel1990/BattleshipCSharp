using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Display
    {
        public void PrintBoard(Board b)
        {
            Square[,] board = b.ocean;
            Console.WriteLine("    A B C D E F G H I J ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i == 9)
                {
                    Console.Write($" {i + 1} ");
                }
                else { Console.Write($"  {i + 1} "); }

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[j, i].GetCharacter()} ");
                }
                Console.WriteLine();
            }
        }

        public void PrintBoardWithPotentialShip(Board b, (int xmin, int xmax, int ymin, int ymax) ship)
        {
            Console.Clear();
            Square[,] board = b.ocean;
            Console.WriteLine("    A B C D E F G H I J ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i == 9)
                {
                    Console.Write($" {i + 1} ");
                }
                else { Console.Write($"  {i + 1} "); }

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if ((j >= ship.xmin && j <= ship.xmax) && (i >= ship.ymin && i <= ship.ymax))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.Write($"{board[j, i].GetCharacter()} "); }

                }
                Console.WriteLine();
            }
        }

    }
}
