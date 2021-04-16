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
            // Use MainMenu here. Get players and additional settings (like board size, ship options) if needed and pass them to the Game object.

            var player1 = new Player();
            var player2 = new Player();

            Game = new Game(player1, player2);

            Game.Run();

            //Board board = new Board();
            //Display dis = new Display();
            //Ship ship = new Ship(1, 1, 3, Ship.Direction.horizontal);
            //BoardFactory fac = new BoardFactory();
            //fac.AddOneShipManual(board, 3);
        }
    }
}
