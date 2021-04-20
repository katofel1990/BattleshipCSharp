﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public string Name { get; }
        public List<Ship> Ships { get; } = new List<Ship>();

        public Player(string name)
        {
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
