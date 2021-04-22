using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Battleship
{
    public class HighScores
    {
        Dictionary<string, int> _scores;
        Display _display;
        readonly string _path = AppDomain.CurrentDomain.BaseDirectory + "player_scores.txt";

        public HighScores(Display display)
        {
            _display = display;
        }

        public void Load()
        {
            string savedString = ReadFromDisk();
            _scores = String.IsNullOrEmpty(savedString) ? new Dictionary<string, int>() : JsonConvert.DeserializeObject<Dictionary<string, int>>(savedString);
        }

        public void Save(string name, int score)
        {
            _scores[name] = _scores.ContainsKey(name) ? _scores[name] + score : score;
            WriteToDisk();
        }

        public void Print()
        {
            _display.Clear();
            foreach (var score in _scores)
            {
                _display.PrintMessage($"{score.Key}: {score.Value}");
            }
        }

        void WriteToDisk()
        {
            string output = JsonConvert.SerializeObject(_scores);
            File.WriteAllText(_path, output);
        }

        string ReadFromDisk()
        {
            return File.Exists(_path) ? File.ReadAllText(_path) : "";
        }
    }
}
