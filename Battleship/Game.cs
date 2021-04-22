﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        ASCII _ascii;
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
            _ascii = new ASCII(_display);
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
            _display.PrintMassage(_ascii.PressAnyKey());
            _input.ReadKey();

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
            bool lastShot = true;
            while (lastShot)
            {
                NextPlayer.OneShot(CurrentPlayer.Name);
                if (NextPlayer.lastShot.Status == Square.SquareStatus.hit)
                {
                    NextPlayer.OneShot(CurrentPlayer.Name);
                }
                else
                {
                    lastShot = false;
                }
            }
            
        }
    }
}
