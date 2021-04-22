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
            ComputerHard();
            (int x, int y) coords = GetRandomCoords();
            if (AreCoordsValid(coords.x, coords.y))
            {
                Shoot(coords.x, coords.y);
            }
            else
            {
                OneShot(currentPlayerName);
            }
        }

        private void ComputerHard()
        {

        }
        /// <summary>
        /// IF ostatni strzał był trafny
        /// tworzymy liste aktualnie "ostrzeliwiany statek", zawierająca potencjalne koordynaty dookoła, sprawdzamy czy żaden z nich nie jest miss
        /// Oddajemy kolejny strzał, jeśli nie jest trafny usuwamy dany koordynat z listy i próbujemy dalej
        /// Jeśli 
        /// </summary>
        /// <returns></returns>


        private (int x, int y) GetRandomCoords()
        {
            int x = random.Next(Board.Size);
            int y = random.Next(Board.Size);

            return (x, y);
        }

        
        
    }
}