using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BattleshipApplication
    {
        Display _display;
        Input _input;
        MainMenu _mainMenu;
        Game _game;
        BoardFactory _factory;

        public BattleshipApplication(MainMenu menu, Display display, Input input)
        {
            _display = display;
            _input = input;
            _mainMenu = menu;
            _factory = new BoardFactory(_display, _input);
        }
        public void Run()
        {
            bool isRunning = true;
            do
            {
                Player player1 = new Player("Player1");
                Player player2 = new Player("Player2");
                int option = _mainMenu.Menu(new List<string>() { "Human vs Human", "Human vs AI", "Exit" });
                List<(int length, int count)> shipsTemplate = new List<(int length, int count)>
                {
                    (4, 1), (3, 2), (2, 3), (1, 4)
                };



                switch (option)
                {
                    case 0:
                        player1.Name = AskForName("Player1");
                        player2.Name = AskForName("Player2");
                        PlacementShips(shipsTemplate, player1);
                        PlacementShips(shipsTemplate, player2);
                        break;
                    case 1:
                        player1.Name = AskForName("Player1");
                        player2 = new ComputerPlayer("Computer");
                        PlacementShips(shipsTemplate, player1);
                        _factory.RandomPlacement(player2.Board, GeneratePlayerShips(shipsTemplate));
                        break;
                    case 2:
                        isRunning = false;
                        break;
                    default:
                        break;
                }


                // Start Game

                _game = new Game(player1, player2);
                _game.ConfigureUI(_display, _input);
                _game.Run();

            } while (isRunning);

        }

        private void PlacementShips(List<(int length, int count)> shipsTemplate, Player player)
        {
            bool runningPlacement = true;
            do
            {
                int optionsPlacement = _mainMenu.Menu(new List<string>() { "Auto placement", "Manual Placement", "Back to main menu" }, $"{player.Name} ship placement turn.");
                switch (optionsPlacement)
                {
                    case 0:
                        _factory.RandomPlacement(player.Board, GeneratePlayerShips(shipsTemplate));
                        runningPlacement = false;
                        break;
                    case 1:
                        _factory.ManualPlacement(player.Board, GeneratePlayerShips(shipsTemplate));
                        runningPlacement = false;
                        break;
                    case 2:
                        runningPlacement = false;
                        break;
                    default:
                        break;
                }
            } while (runningPlacement);
        }

        private List<Ship> GeneratePlayerShips(List<(int length, int count)> shipsTemplate)
        {
            List<Ship> result = new List<Ship>();
            foreach (var shipTuple in shipsTemplate)
            {
                for (int i = 0; i < shipTuple.count; i++)
                {
                    result.Add(new Ship(shipTuple.length));
                }
            }
            return result;
        }

        private string AskForName(string playerID)
        {
            _display.PrintMassage($"Type name for {playerID}. (A-Z, a-z, 0-9, 3 - 15 characters)");
            string userInput = _input.ReadLine();
            return userInput.Length > 2 && userInput.Length < 16 ? userInput : AskForName(playerID);
        }
    }
}
