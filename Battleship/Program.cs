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
            MainMenu menu = new MainMenu(display, input);
            List<string> options = new List<string>() { "Random Placemant", "Manual Placement", "Exit" };
            int o = menu.Menu(options);
            BoardFactory fac = new BoardFactory(display, input);
            List<Ship> ships = new List<Ship>();
            List<int> shipsCount = new List<int>() { 1, 2, 3, 4 };
            List<int> shipsSize = new List<int>() { 4, 3, 2, 1 };

            for (int i = 0; i < shipsCount.Count; i++)
            {
                for (int j = 0; j < shipsCount[i]; j++)
                {
                    ships.Add(new Ship(shipsSize[i]));
                }
            }


            if (o == 0)
            {               
                fac.RandomPlacement(board, ships);
            }
            else if (o == 1)
            {
                fac.ManualPlacement(board, ships);
            }
            
            display.PrintBoard(board);
        }

    }
}
