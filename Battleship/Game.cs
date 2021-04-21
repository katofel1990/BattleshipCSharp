using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

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
            while (Player1.IsAlive() && Player2.IsAlive())
            {
                Fight();
                SwitchPlayers();
            }

            var winner = GetWinner();

            // TODO handle win
        }

        private void SwitchPlayers()
        {
            Player temp = Player1;
            Player1 = Player2;
            Player2 = temp;
        }

        private void Fight()
        {
            //_display.PrintBoards();
            //Player2.Shoot();
            //_display.PrintBoards;
            //WaitForTime(700);
        }

        private static void WaitForTime(int miliseconds)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }

        private Player GetWinner()
        {
            return Player1.IsAlive() ? Player1 : Player2;
        }
    }
}
