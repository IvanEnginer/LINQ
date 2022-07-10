using System;
using System.Collections.Generic;
using System.Linq;

namespace MeatBunk
{
    class Program
    {
        static void Main(string[] args)
        {
            Storege storege = new Storege();

            storege.ShowInfo();
            Console.WriteLine();
            storege.ShowExpiratioPreserve();
        }
    }

    class Storege
    {
        private int _minimumDateMade = 2017;
        private int _maximumDateMade = 2022;
        private int _expirationMinimum = 2;
        private int _expirationMaximum = 5;
        private int _quantityPreserves = 20;

        private Random _random = new Random();

        private List<Preserve> _preserves =new List<Preserve>();

        public Storege()
        {
            Fill();
        }

        public void ShowExpiratioPreserve()
        {
            int todayYear = 2022;
            var expiratioPreserve = _preserves.Where(_preserves => (_preserves.YearOfProduction + _preserves.ExpirationDate) < todayYear).ToList();

            Console.WriteLine("Expiration:");
            foreach (var preserve in expiratioPreserve)
            {
                preserve.ShowInfo();
            }
        }

        public void ShowInfo()
        {
            foreach (Preserve preserve in _preserves)
            {
                preserve.ShowInfo();
            }
        }

        private void Fill()
        {
            List<string> name = new List<string> { "Meat super", "Meat", "Meat super +", "Great meet", "Tomatos and meat" };

            for (int i = 0; i < _quantityPreserves; i++)
            {
                _preserves.Add(new Preserve(name[_random.Next(0, name.Count)], _random.Next(_minimumDateMade, _maximumDateMade), _random.Next(_expirationMinimum, _expirationMaximum)));
            }
        }
    }

    class Preserve
    {
        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public Preserve(string name, int yearOfProduction, int expirationDate)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ExpirationDate = expirationDate;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}. Year of production: {YearOfProduction} year. Expiration date: {ExpirationDate} yrars" );
        }
    }
}
