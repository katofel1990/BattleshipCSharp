using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Game
    {
        Display _display;
        Input _input;
        BoardFactory _factory;
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Dictionary<Player, Board> Boards { get; } = new Dictionary<Player, Board>();

        public Game(Player player1, Player player2, int boardSize)
        {
            Player1 = player1;
            Player2 = player2;
            Boards.Add(Player1, new Board(boardSize));
            Boards.Add(Player2, new Board(boardSize));
        }

        public void ConfigureUI(Display d, Input i)
        {
            _display = d;
            _input = i;
            _factory = new BoardFactory(_display, _input);
        }

        public void Run()
        {
            PlaceShips();
            Fight();
        }

        private void PlaceShips()
        {
            PlaceShips(Player1);
            PlaceShips(Player2);
        }

        private void PlaceShips(Player player)
        {
            if (player.IsRandomPlacing)
            {
                _factory.RandomPlacement(Boards[player], player.Ships);
            }
            else
            {
                _factory.ManualPlacement(Boards[player], player.Ships);
            }
        }

        private void Fight()
        {
            Player currentPlayer = Player1;
            Player nextPlayer = Player2;

            while (currentPlayer.IsAlive)
            {
                _display.PrintMassage($"{currentPlayer.Name}'s turn");
                //_display.PrintEnemyBoard(Boards[nextPlayer]); // TODO add and use cursor to select where to shoot
            }
        }
    }
}
