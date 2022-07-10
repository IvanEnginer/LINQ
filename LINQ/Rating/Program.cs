using System;
using System.Collections.Generic;
using System.Linq;

namespace Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.ShowTotalInfo();

            Console.WriteLine();

            dataBase.ShowTopPlayersByLevel();

            Console.WriteLine();

            dataBase.ShowTopPlayersByPower();
        }
    }

    class DataBase
    {
        private List<Player> _players = new List<Player>();
        private Random _random = new Random();
        private int _quantityPlayers = 100;
        private int _maximumLevel = 100;
        private int _maximumPower = 1000;
        private int _maximumTopPlayers = 3;

        public DataBase()
        {
            Fill();
        }

        public void ShowTopPlayersByLevel()
        {
            var palersTop = _players.OrderByDescending(player => player.Level).Take(_maximumTopPlayers).ToList();

            ShowInfoTop(palersTop);
        }

        public void ShowTopPlayersByPower()
        {
            var palersTop = _players.OrderByDescending(player => player.Power).Take(_maximumTopPlayers).ToList();

            ShowInfoTop(palersTop);
        }

        public void ShowTotalInfo()
        {
            foreach (Player player in _players)
            {
                player.ShowInfo();
            }
        }

        private void ShowInfoTop(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }
        }

        private void Fill()
        {
            List<string> name = new List<string> { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill", "Buba", "Pupa" };

            for (int i = 0; i < _quantityPlayers; i++)
            {
                _players.Add(new Player(name[_random.Next(0, name.Count)], _random.Next(0, _maximumLevel), _random.Next(0, _maximumPower)));
            }
        }
    }

    class Player
    { 
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}. Level: {Level}. Power: {Power}");
        }
    }
}
