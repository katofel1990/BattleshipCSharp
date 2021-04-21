using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var display = new Display();
            var input = new Input();
            var mainMenu = new MainMenu(display, input);
            var battleApp = new BattleshipApplication(mainMenu, display, input);

            battleApp.Run();
        }




        // Main do testowana pojedyńczych funkcji
        //static void Main(string[] args)
        //{
        //    Input input = new Input();
        //    Display display = new Display();
        //    Player player1 = new Player();
        //    Board board = new Board(10);
        //    MainMenu menu = new MainMenu(display, input);

        //    //List<string> options = new List<string>() { "Random Placemant", "Manual Placement", "Exit" };
        //    //int o = menu.Menu(options);

        //    BoardFactory fac = new BoardFactory(display, input);
        //    List<Ship> ships = new List<Ship>();
        //    ships.Add(new Ship(1));
        //    ships.Add(new Ship(2));
        //    ships.Add(new Ship(3));
        //    ships.Add(new Ship(4));
        //    fac.RandomPlacement(board, ships);
        //}

    }
}
