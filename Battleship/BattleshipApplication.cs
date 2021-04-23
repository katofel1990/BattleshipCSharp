using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class BattleshipApplication
    {
        readonly Display _display;
        readonly Input _input;
        readonly MainMenu _mainMenu;
        readonly BoardFactory _factory;
        ASCII _ascii;
        readonly HighScores _highScores;
        readonly List<(int length, int count)> _shipsTemplate = new List<(int length, int count)>
                {
                    (4, 1), (3, 2), (2, 3), (1, 4)
                };

        public BattleshipApplication(MainMenu menu, Display display, Input input, HighScores highScores)
        {
            _display = display;
            _input = input;
            _mainMenu = menu;
            _factory = new BoardFactory(_display, _input);
            _ascii = new ASCII(_display);
            _highScores = highScores;
        }
        public void Run()
        {
            bool isRunning = true;
            //_ascii.Welcome();

            do
            {
                Player player1 = new Player("Player1", _display, _input);
                Player player2 = new Player("Player2", _display, _input);

                _highScores.Load();

                int option = _mainMenu.Menu(new List<string>() { "Human vs Human", "Human vs AI", "AI vs AI", "High Scores", "Exit" });

                switch (option)
                {
                    case 0:
                        player1.Name = AskForName("Player1");
                        player2.Name = AskForName("Player2");
                        PlaceShips(_shipsTemplate, player1);
                        PlaceShips(_shipsTemplate, player2);

                        break;
                    case 1:
                        player1.Name = AskForName("Player1");
                        player2 = new ComputerPlayer("Computer", _display, _input); // TODO why cannot cast here?
                        PlaceShips(_shipsTemplate, player1);
                        PlaceComputerShips(_shipsTemplate, player2);
                        break;
                    case 2:
                        player1 = new ComputerPlayer("Computer1", _display, _input);
                        player2 = new ComputerPlayer("Computer2", _display, _input); // TODO why cannot cast here?
                        PlaceComputerShips(_shipsTemplate, player1);
                        PlaceComputerShips(_shipsTemplate, player2);
                        break;
                    case 3:
                        _highScores.Print();
                        _display.PrintMessage(_ascii.PressAnyKey());
                        _input.ReadKey();
                        continue;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        break;
                }

                if(!isRunning) break;

                var game = new Game(player1, player2, _highScores);
                game.ConfigureUI(_display, _input);
                game.Run();

            } while (isRunning);

        }

        private void PlaceComputerShips(List<(int length, int count)> shipsTemplate, Player player2)
        {
            GeneratePlayerShips(shipsTemplate, player2);
            _factory.RandomPlacement(player2.Board, player2.Ships);
        }

        private void PlaceShips(List<(int length, int count)> shipsTemplate, Player player)
        {
            bool runningPlacement = true;
            do
            {
                int optionsPlacement = _mainMenu.Menu(new List<string>() { "Auto placement", "Manual Placement", "Back to main menu" }, $"{player.Name} ship placement turn.");
                switch (optionsPlacement)
                {
                    case 0:
                        GeneratePlayerShips(shipsTemplate, player);
                        _factory.RandomPlacement(player.Board, player.Ships);
                        runningPlacement = false;
                        break;
                    case 1:
                        GeneratePlayerShips(shipsTemplate, player);
                        _factory.ManualPlacement(player.Board, player.Ships);
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

        private void GeneratePlayerShips(List<(int length, int count)> shipsTemplate, Player player)
        {
            foreach (var shipTuple in shipsTemplate)
            {
                for (int i = 0; i < shipTuple.count; i++)
                {
                    player.Ships.Add(new Ship(shipTuple.length));
                }
            }
        }

        private string AskForName(string playerID)
        {
            _display.PrintMessage($"Type name for {playerID}. (A-Z, a-z, 0-9, 3 - 10 characters)");
            string userInput = _input.ReadLine();
            return userInput.Length > 2 && userInput.Length < 11 ? userInput : AskForName(playerID);
        }
    }
}
