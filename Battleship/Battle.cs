using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Battle
    {
        public void Run()
        {
            Board board = new Board();
            Display dis = new Display();
            Ship ship = new Ship(1, 1, 3, Ship.Direction.horizontal);
            BoardFactory fac = new BoardFactory();
            fac.AddOneShipManual(board, 3);
        }
    }
}
