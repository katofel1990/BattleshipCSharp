using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Display dis = new Display();
            Ship ship = new Ship(1, 1, 3, Ship.Direction.horizontal);
            BoardFactory fac = new BoardFactory();
            fac.AddOneShipManual(board, 3);
        }
    }
}
