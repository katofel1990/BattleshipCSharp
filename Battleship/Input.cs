using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Input
    {
        public ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }
    }
}
