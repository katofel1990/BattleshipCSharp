using System.Collections.Generic;
using System;

namespace Battleship
{
    public class MainMenu
    {
        Display display { get; }
        Input input { get; }

        public MainMenu(Display display, Input input)
        {
            this.display = display;
            this.input = input;
        }

        public int Menu(List<string> options)
        {
            int x = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                display.PrintMenu(options, x);
                key = input.ReadKey();
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        x = (x == 0 ? options.Count - 1 : x - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        x = (x == options.Count - 1 ? 0 : x + 1);
                        break;
                    case ConsoleKey.Enter:
                        return x;
                    default:
                        break;
                }
            }
            while (key != ConsoleKey.Enter);
            return -1;    
        }

        public int Menu(List<string> options, string title)
        {
            int x = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                display.PrintMassage(title);
                display.PrintMenu(options, x);
                key = input.ReadKey();
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        x = x == 0 ? options.Count - 1 : x--;
                        break;
                    case ConsoleKey.DownArrow:
                        x = x == options.Count - 1 ? x = 0 : x++;
                        break;
                    case ConsoleKey.Enter:
                        return x;
                    default:
                        break;
                }
            }
            while (key != ConsoleKey.Enter);
            return -1;
        }
    }
}