using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var display = new Display();
            var input = new Input();
            var mainMenu = new MainMenu(display, input);
            var highScores = new HighScores(display);
            var battleApp = new BattleshipApplication(mainMenu, display, input, highScores);

            battleApp.Run();
        }
    }
}
