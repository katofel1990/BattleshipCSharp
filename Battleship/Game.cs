using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        public Player CurrentPlayer { get; private set; }
        public Player NextPlayer { get; private set; }

        public Game(Player player1, Player player2)
        {
            CurrentPlayer = player1;
            NextPlayer = player2;
        }

        public void ConfigureUI(Display d, Input i)
        {
            _display = d;
            _input = i;
        }

        public void Run()
        {
            while (CurrentPlayer.IsAlive() && NextPlayer.IsAlive())
            {
                Fight();
                SwitchPlayers();
            }

            var winner = NextPlayer;

            _display.PrintMassage($"{winner.Name} has won. Congratulations!");
            WaitForTime(2000);

            // TODO handle win
        }

        private void SwitchPlayers()
        {
            Player temp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = temp;
        }

        private void Fight()
        {
            NextPlayer.OneShot(CurrentPlayer.Name);
            WaitForTime(700);
        }

        private static void WaitForTime(int miliseconds)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }
    }
}
