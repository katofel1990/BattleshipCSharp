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
            _display.PrintBoard(board);
            _display.PrintMessage($"{Name}'s turn.");
            _display.WaitForTime(700);

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
            (int x, int y) coords = GetRandomCoords(board);
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
                    possibleShots = GeneratePossibleShots(board);
                    squareToShoot = possibleShots[random.Next(possibleShots.Count)];

                    Shoot(board, squareToShoot.Position.x, squareToShoot.Position.y);
                }
            }
            else
            {
                possibleShots = GeneratePossibleShots(board);
                squareToShoot = possibleShots[random.Next(possibleShots.Count)];

                Shoot(board, squareToShoot.Position.x, squareToShoot.Position.y);
            }
        }

        private List<Square> GeneratePossibleShots(Board board)
        {
            List<Square> result = new List<Square>();
            int x = _shipUnderFire[0].Position.x;
            int y = _shipUnderFire[0].Position.y;
            if (_shipUnderFire.Count == 1)
            {
                AddToResultIfValid(board, result, x, y + 1);
                AddToResultIfValid(board, result, x, y - 1);
                AddToResultIfValid(board, result, x + 1, y);
                AddToResultIfValid(board, result, x - 1, y);
            }
            else
            {
                SortSquaresByPosition();
                if(_shipUnderFire[0].Position.x == _shipUnderFire[1].Position.x)
                {
                    AddToResultIfValid(board, result, x, _shipUnderFire[0].Position.y - 1);
                    AddToResultIfValid(board, result, x, _shipUnderFire[_shipUnderFire.Count - 1].Position.y + 1);
                }
                else
                {
                    AddToResultIfValid(board, result, _shipUnderFire[0].Position.x - 1, y);
                    AddToResultIfValid(board, result, _shipUnderFire[_shipUnderFire.Count - 1].Position.x + 1, y);
                }

            }
            return result;
        }

        private void SortSquaresByPosition()
        {
            _shipUnderFire = _shipUnderFire.OrderBy(square => square.Position.x).ThenBy(square => square.Position.y).ToList<Square>();
        }

        private void AddToResultIfValid(Board board, List<Square> result, int x, int y)
        {
            if (x >= 0 && x < board.Size && y >= 0 && y < board.Size)
            {
                var status = board.ocean[x, y].Status;
                if (status == Square.SquareStatus.empty || status == Square.SquareStatus.ship)
                {
                    result.Add(board.ocean[x, y]);
                }
            }
        }

        private (int x, int y) GetRandomCoords(Board board)
        {
            int x = random.Next(board.Size);
            int y = random.Next(board.Size);

            return (x, y);
        }
    }
}