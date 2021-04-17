using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var mainMenu = new MainMenu();
        //    var display = new Display();
        //    var input = new Input();
        //    var battleApp = new BattleshipApplication(mainMenu, display, input);

        //    battleApp.Run();
        //}


        static void Main(string[] args)
        {
            Input input = new Input();
            Display display = new Display();
            Board board = new Board();
            BoardFactory fac = new BoardFactory(display, input);
            List<Ship> ships = new List<Ship>();
            ships.Add(new Ship(1));
            ships.Add(new Ship(2));
            ships.Add(new Ship(3));
            ships.Add(new Ship(4));
            fac.ManualPlacement(board, ships);
        }

    }
}
