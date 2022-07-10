using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Criminal
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.MenuSearchCriminal();
        }
    }

    class DataBase
    {
        private List<Criminal> _criminals = new List<Criminal>();
        private List<Criminal> _criminalsForSearch = new List<Criminal>();

        public DataBase()
        {
            FillBase();
        }

        public void MenuSearchCriminal()
        {
            Console.WriteLine("Enter parametr\n1.Name\n2.Surename\n3.National\n4.Grow\n5.Wight");


            int number = GetInputNumber();

            switch (number)
            {
                case 1:
                    SerchOnName();
                    break;
                case 2:
                    SerchOnSurename();
                    break;
                case 3:
                    SerchByNation();
                    break;
                case 4:
                    SerchByGrowth();
                    break;
                case 5:
                    SerchByWeight();
                    break;
            }
        }

        private void SerchOnName()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            var filterName = from criminal in _criminals where criminal.Name == name select criminal;

            foreach (var criminal in filterName)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
        }

        private void SerchOnSurename()
        {
            Console.Write("Enter surename: ");
            string sureName = Console.ReadLine();

            var filterName = from criminal in _criminals where criminal.Surname == sureName select criminal;

            foreach (var criminal in filterName)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
        }

        private void SerchByNation()
        {
            Console.Write("Enter surename: ");
            string nationality = Console.ReadLine();

            var filterName = from criminal in _criminals where criminal.Surname == nationality select criminal;

            foreach (var criminal in filterName)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
        }

        private void SerchByGrowth()
        {
            Console.Write("Enter growth: ");
            int growth = GetInputNumber();

            var filterName = from criminal in _criminals where criminal.Growth == growth select criminal;

            foreach (var criminal in filterName)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
        }

        private void SerchByWeight()
        {
            Console.Write("Enter weight: ");
            int weight = GetInputNumber();

            var filterName = from criminal in _criminals where criminal.Weight == weight select criminal;

            foreach (var criminal in filterName)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
        }

        private int GetInputNumber()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumber);

            if (isNumber)
            {
                return inputNumber;
            }
            else
            {
                return 0;
            }
        }

        private void FillBase()
        {
            _criminals.Add(new Criminal("Swonson", "Ron", "USA", false, 170, 100));
            _criminals.Add(new Criminal("Simpson", "Ron", "USA", false,180, 120));
            _criminals.Add(new Criminal("Andreus", "Jon", "FIN", true, 150, 80));
            _criminals.Add(new Criminal("Bubich", "Booba", "COS", true, 160, 90));
            _criminals.Add(new Criminal("Pupick", "Pupa", "RU", false, 190, 120));
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Nationality { get; private set; }
        public bool IsPrisoner { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }

        public Criminal()
        { }

        public Criminal(string surname, string name, string nationality, bool isPrisoner,int growth, int weight)
        {
            Name = name;
            Surname = surname;          
            Nationality = nationality;
            IsPrisoner = isPrisoner;
            Growth = growth;
            Weight = weight;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name} {Surname}. Nationality: {Nationality} . Status lokation: {IsPrisoner}. Growth: {Growth}. Weight: {Weight}.");
        }
    }
}