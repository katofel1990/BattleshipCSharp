using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        public Player Player1 { get; }
        public Player Player2 { get; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void ConfigureUI(Display d, Input i)
        {
            _display = d;
            _input = i;
        }

        public void Run()
        {
            Fight();
        }

        private void Fight()
        {
            Player currentPlayer = Player1;
            Player nextPlayer = Player2;

            while (currentPlayer.IsAlive())
            {
                nextPlayer.OneShot();
            }
        }
    }
}
