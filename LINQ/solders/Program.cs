using System;
using System.Collections.Generic;
using System.Linq;

namespace solders
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseSolders dataBaseSolders = new DataBaseSolders();

            dataBaseSolders.ShowNameRankSolder();
        }
    }

    class DataBaseSolders
    {
        private List<Solder> _solders = new List<Solder>();
        private Random _random = new Random();

        public DataBaseSolders()
        {
            Fill();
        }

        public void ShowInfoAllSolders()
        {
            foreach (Solder solder in _solders)
            {
                solder.ShowInfo();
            }
        }


        public void ShowNameRankSolder()
        {
            var ListNameRankSolder = from Solder solder in _solders select new { name = solder.Name, rank = solder.Rank };

            foreach (var solder in ListNameRankSolder)
            {
                Console.WriteLine("Name solder: " + solder.name + ". Rank: " + solder.rank);
            }
        }

        public void ShowNameWeaponSolders()
        {
            var ListNameRankSolder = from Solder solder in _solders select new { name = solder.Name, weapon = solder.Weapon};

            foreach (var solder in ListNameRankSolder)
            {
                Console.WriteLine("Name solder: " + solder.name +  ". weapon: " + solder.weapon);
            }
        }


        private void Fill()
        {
            int minimumServiseMonth = 0;
            int maximumServiseMonth = 120;
            int maximumSolders = 10;

            List<string> name = new List<string>() { "Booba", "Jake", "Bob", "Biba", "Sid", "Homer", "Cuper" };
            List<string> surname = new List<string>() { "Black", "Jonson", "White", "Simpson", "Gutieres", "Zim" };
            List<string> weapon = new List<string>() { "rifle", "machine gun", "granet", "RPG", "knife" };
            List<string> rank = new List<string>() { "Solder", "Sergeant", "Lieutenant", "Major", "Сolonel" };

            for (int i = 0; i < maximumSolders; i++)
            {
                _solders.Add(new Solder(name[_random.Next(0, name.Count)] + surname[_random.Next(0, surname.Count)], weapon[_random.Next(0, weapon.Count)], rank[_random.Next(0, rank.Count)], _random.Next(minimumServiseMonth, maximumServiseMonth)));
            }
        }
    }

    class Solder
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int ServicMonth { get; private set; }

        public Solder(string name, string weapon, string rank, int servicMonth)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServicMonth = servicMonth;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name: " + Name + ". Rank: " + Rank + ". Weapon: " + Weapon + ". Servic months: " + ServicMonth);
        }
    }
}