using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            var display = new Display();
            var input = new Input();
            var battleApp = new BattleshipApplication(mainMenu, display, input);

            battleApp.Run();
        }
    }
}
