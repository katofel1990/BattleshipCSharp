using System;
using System.Collections.Generic;

namespace Battleship
{
    public class ComputerPlayer : Player
    {
        Random random = new Random();
        List<Square> ShipUnderFire;

        public ComputerPlayer(string name) : base (name)
        {
            ShipUnderFire = new List<Square>();
        }

        public override void OneShot(string currentPlayerName)
        {
            if (LastShot != null)
            {
                if (LastShot.Status == Square.SquareStatus.hit)
                {
                    ComputerHard();
                }
            }
            (int x, int y) coords = GetRandomCoords();
            if (CoordsAreValid(coords.x, coords.y))
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
            if (!LastShot.CourentShip.IsAlive())
            {
                ShipUnderFire.Clear();
            }
            else
            {
                ShipUnderFire.Add(LastShot);
            }
        }


        private List<Square> GeneratePossibleShoots()
        {
            List<Square> result = new List<Square>();
            int x = ShipUnderFire[0].Position.x;
            int y = ShipUnderFire[0].Position.y;
            if (ShipUnderFire.Count == 1)
            {
                AreCoordsEmpty(result, x, y + 1);
                AreCoordsEmpty(result, x, y - 1);
                AreCoordsEmpty(result, x + 1, y);
                AreCoordsEmpty(result, x - 1, y);
            }
            else
            {
                if(ShipUnderFire[0].Position.x == ShipUnderFire[1].Position.x)
                {
                    result.Add(Board.ocean[x - 1, y]);
                }
            }
            return result;
        }

        private void AreCoordsEmpty(List<Square> result, int x, int y)
        {
            if (Board.ocean[x, y].Status == Square.SquareStatus.empty)
            {
                result.Add(Board.ocean[x, y]);
            }
        }
        /// <summary>
        /// IF ostatni strzał był trafny
        /// tworzymy liste aktualnie "ostrzeliwiany statek", zawierająca potencjalne koordynaty dookoła, sprawdzamy czy żaden z nich nie jest miss
        /// Oddajemy kolejny strzał, jeśli nie jest trafny usuwamy dany koordynat z listy i próbujemy dalej
        /// Jeśli trafimy to idziemy w danej orientacji (góra/dół lub lewo/prawo)
        /// walimy dopóki nie zatopimy statku
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