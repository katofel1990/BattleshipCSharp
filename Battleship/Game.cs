using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Board Player1Board { get; set; }
        public Board Player2Board { get; set; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }       
    }
}
