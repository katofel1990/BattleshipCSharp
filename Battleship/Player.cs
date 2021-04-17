using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public string Name { get; }
        public List<Ship> Ships { get; } = new List<Ship>();
        public bool IsAlive => Ships.Count > 0;
        public virtual bool IsRandomPlacing { get; set; } = false;

        public Player(string name)
        {
            Name = name;
        }
    }
}
