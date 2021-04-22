using System;

namespace Battleship
{
    public class ComputerPlayer : Player
    {
        Random random = new Random();
        public ComputerPlayer(string name) : base (name)
        {
        }

        public override void OneShot(string currentPlayerName)
        {
            (int x, int y) coords = GetRandomCoords();
            Shoot(coords);
        }

        private (int x, int y) GetRandomCoords()
        {
            int x = random.Next(Board.Size);
            int y = random.Next(Board.Size);

            return (x, y);
        }
        
    }
}