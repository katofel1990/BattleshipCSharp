using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            var battleApp = new BattleshipApplication(mainMenu);

            battleApp.Run();
        }
    }
}
