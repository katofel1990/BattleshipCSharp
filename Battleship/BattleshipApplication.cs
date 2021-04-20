using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BattleshipApplication
    {
        public Display Display { get; }
        public Input Input { get; }
        public MainMenu MainMenu { get; }
        public Game Game { get; private set; }

        public BattleshipApplication(MainMenu menu, Display display, Input input)
        {
            Display = display;
            Input = input;
            MainMenu = menu;
        }
        public void Run()
        {
            bool isRunning = true;
            do
            {
                int option = MainMenu.Menu(new List<string>() { "Human vs Human", "Human vs AI", "Exit" });


                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        isRunning = false;
                        break;
                }

                // Use MainMenu here. Get players and additional settings (like board size, ship options) if needed and pass them to the Game object.

                var player1 = new Player("Player 1");
                var player2 = new Player("Player 2");
                var boardSize = 10;

                var startingShipsLengths = new List<int>();

                startingShipsLengths.Add(1);
                startingShipsLengths.Add(2);
                startingShipsLengths.Add(3);
                startingShipsLengths.Add(4);

                foreach (int shipLength in startingShipsLengths)
                {
                    player1.Ships.Add(new Ship(shipLength));
                    player2.Ships.Add(new Ship(shipLength));
                }

                Game = new Game(player1, player2, boardSize);

                Game.ConfigureUI(Display, Input);
                Game.Run();

            } while (isRunning);

        }
    }
}
