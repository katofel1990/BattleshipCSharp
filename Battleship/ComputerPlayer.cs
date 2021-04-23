using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class ComputerPlayer : Player
    {
        Random random = new Random();
        List<Square> _shipUnderFire;

        public ComputerPlayer(string name, Display display, Input input) : base (name, display, input)
        {
            _shipUnderFire = new List<Square>();
        }

        public override void OneShot(Board board)
        {
            if (LastShot != null)
            {
                if (LastShot.Status == Square.SquareStatus.hit || _shipUnderFire.Count > 0)
                {
                    ComputerHard(board);
                }
                else
                {
                    ShootRandom(board);
                }
            }
            else
            {
                ShootRandom(board);
            }
        }

        private void ShootRandom(Board board)
        {
            (int x, int y) coords = GetRandomCoords();
            if (CoordsAreValid(board, coords.x, coords.y))
            {
                Shoot(board, coords.x, coords.y);
            }
            else
            {
                ShootRandom(board);
            }
        }

        private void ComputerHard(Board board)
        {
            List<Square> possibleShots;
            Square squareToShoot;
            if (LastShot.Status == Square.SquareStatus.hit)
            {
                if (!LastShot.CurrentShip.IsAlive())
                {
                    _shipUnderFire.Clear();
                    ShootRandom(board);
                }
                else
                {
                    _shipUnderFire.Add(LastShot);
                    possibleShots = GeneratePossibleShoots();
                    squareToShoot = possibleShots[random.Next(possibleShots.Count)];

                    Shoot(board, squareToShoot.Position.x, squareToShoot.Position.y);
                }
            }
            else
            {
                possibleShots = GeneratePossibleShoots();
                squareToShoot = possibleShots[random.Next(possibleShots.Count)];

                Shoot(board, squareToShoot.Position.x, squareToShoot.Position.y);
            }
        }

        private List<Square> GeneratePossibleShoots()
        {
            List<Square> result = new List<Square>();
            int x = _shipUnderFire[0].Position.x;
            int y = _shipUnderFire[0].Position.y;
            if (_shipUnderFire.Count == 1)
            {
                AddToResultIfValid(result, x, y + 1);
                AddToResultIfValid(result, x, y - 1);
                AddToResultIfValid(result, x + 1, y);
                AddToResultIfValid(result, x - 1, y);
            }
            else
            {
                SortShipSquares();
                if(_shipUnderFire[0].Position.x == _shipUnderFire[1].Position.x)
                {
                    AddToResultIfValid(result, x, _shipUnderFire[0].Position.y - 1);
                    AddToResultIfValid(result, x, _shipUnderFire[_shipUnderFire.Count - 1].Position.y + 1);
                }
                else
                {
                    AddToResultIfValid(result, _shipUnderFire[0].Position.x - 1, y);
                    AddToResultIfValid(result, _shipUnderFire[_shipUnderFire.Count - 1].Position.x + 1, y);
                }

            }
            return result;
        }

        private void SortShipSquares()
        {
            _shipUnderFire = _shipUnderFire.OrderBy(square => square.Position.x).ThenBy(square => square.Position.y).ToList<Square>();
        }

        private void AddToResultIfValid(List<Square> result, int x, int y)
        {
            if (x >= 0 && x < Board.Size && y >= 0 && y < Board.Size)
            {
                var status = Board.ocean[x, y].Status;
                if (status == Square.SquareStatus.empty || status == Square.SquareStatus.ship)
                {
                    result.Add(Board.ocean[x, y]);
                }
            }
        }

        private (int x, int y) GetRandomCoords()
        {
            int x = random.Next(Board.Size);
            int y = random.Next(Board.Size);

            return (x, y);
        }
    }
}