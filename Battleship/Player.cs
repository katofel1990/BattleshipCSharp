using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public string Name { get; set; }
        public List<Ship> Ships { get; } = new List<Ship>();
        public Board Board { get; }

        public Player(string name)
        {
            Board = new Board(10);
            Name = name;
        }

        public bool IsAlive()
        {
            foreach (var ship in Ships)
            {
                if (ship.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }


    }
}
