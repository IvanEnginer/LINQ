using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoSqade
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();

            army.ExecuteMove();
        }
    }

    class Army
    {
        private List<Solder> _squadOne = new List<Solder>();
        private List<Solder> _squadTwo = new List<Solder>();

        private Random _random = new Random();

        public Army()
        {
            Fill(_squadOne);
            Fill(_squadTwo);
        }

        public void ExecuteMove()
        {
            ShowInfo(_squadOne);
            Console.WriteLine();
            ShowInfo(_squadTwo);
            Console.WriteLine();
            MoveSelectedSoldiers();
            ShowInfo(_squadOne);
            Console.WriteLine();
            ShowInfo(_squadTwo);
        }

        private void ShowInfo(List<Solder> solders)
        {
            foreach (Solder solder in solders)
            {
                solder.ShowInfo();
            }
        }
        private void MoveSelectedSoldiers()
        {
            var soldiers = _squadOne.Where(soldier => soldier.Surname.StartsWith("B"));
            _squadTwo = _squadTwo.Union(soldiers).ToList();
            _squadOne = _squadOne.Except(soldiers).ToList();
        }

        private void Fill(List<Solder> sqade)
        {
            int minimumServiseMonth = 0;
            int maximumServiseMonth = 120;
            int maximumSolders = 5;

            List<string> name = new List<string>() { "Booba", "Jake", "Bob", "Biba", "Sid", "Homer", "Cuper" };
            List<string> surname = new List<string>() { "Black", "Jonson", "White", "Simpson", "Gutieres", "Zim", "Bibster", "Biger" };
            List<string> weapon = new List<string>() { "rifle", "machine gun", "granet", "RPG", "knife" };
            List<string> rank = new List<string>() { "Solder", "Sergeant", "Lieutenant", "Major", "Сolonel" };

            for (int i = 0; i < maximumSolders; i++)
            {
                sqade.Add(new Solder(name[_random.Next(0, name.Count)], surname[_random.Next(0, surname.Count)], weapon[_random.Next(0, weapon.Count)], rank[_random.Next(0, rank.Count)], _random.Next(minimumServiseMonth, maximumServiseMonth)));
            }
        }
    }

    class Solder
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int ServicMonth { get; private set; }

        public Solder(string name, string surname, string weapon, string rank, int servicMonth)
        {
            Name = name;
            Surname = surname;
            Weapon = weapon;
            Rank = rank;
            ServicMonth = servicMonth;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Name + " " + Surname + ". Rank: " + Rank + ". Weapon: " + Weapon + ". Servic months: " + ServicMonth);
        }
    }
}
