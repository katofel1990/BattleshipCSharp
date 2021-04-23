using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        ASCII _ascii;
        HighScores _highScores;
        public Player CurrentPlayer { get; private set; }
        public Player NextPlayer { get; private set; }

        public Game(Player player1, Player player2, HighScores highScores)
        {
            CurrentPlayer = player1;
            NextPlayer = player2;
            _highScores = highScores;
        }

        public void ConfigureUI(Display d, Input i)
        {
            _display = d;
            _input = i;
            _ascii = new ASCII(_display);
        }

        public void Run()
        {
            while (CurrentPlayer.IsAlive() && NextPlayer.IsAlive())
            {
                TakeTurn();
                SwitchPlayers();
            }

            var winner = NextPlayer;
            int score = winner.GetScore();

            _highScores.Save(winner.Name, score);

            _display.PrintMessage($"{winner.Name} has won. Score: {score}");
            _display.PrintMessage(_ascii.PressAnyKey());
            _input.ReadKey();

        }

        private void SwitchPlayers()
        {
            Player temp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = temp;
        }

        private void TakeTurn()
        {
            bool lastShot = true;
            while (lastShot)
            {
                CurrentPlayer.OneShot(NextPlayer.Board);
                if (CurrentPlayer.LastShot.Status != Square.SquareStatus.hit)
                {
                    lastShot = false;
                }
            }
            
        }
    }
}
