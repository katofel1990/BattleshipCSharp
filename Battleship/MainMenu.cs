using System;


namespace Battleship
{
    public class MainMenu
    {
        public string AskForGameMode()
        {
            Console.Clear();
            ASCII.MainMenuText();
            Console.WriteLine("Please Select game mode:\n");
            Console.WriteLine("1. Player vs Player");
            Console.WriteLine("2. Player vs Computer");
            Console.WriteLine("3. Exit");

            return Console.ReadLine();
        }

    }
}