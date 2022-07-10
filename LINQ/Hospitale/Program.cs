using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospitale
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int command;

            Hospitale hospitale = new Hospitale();

            while (isWork)
            {
                Console.Write("1. Show list \n2. Sort by name\n3. Sort by age\n4. Show by disease\n5. Esc\nCommand: ");

                command = GetInputNumber();

                switch (command)
                {
                    case 1:
                        hospitale.ShowInfoPations();
                        break;
                    case 2:
                        hospitale.SortSurname();
                        break;
                    case 3:
                        hospitale.SortAge();
                        break;
                    case 4:
                        hospitale.OutDiseasePation();
                        break;
                    case 5:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static int GetInputNumber()
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
    }

    class Hospitale
    {
        private List<Patien> _patiens = new List<Patien>();
        private Random _random = new Random();
        private int _quantityPatiens = 20;
        private int _minimumAge = 18;
        private int _maximumAge = 100;

        public Hospitale()
        {
            Fill();
        }

        public void SortSurname()
        {
            var sortingNamePations = _patiens.OrderBy(patien => patien.Surname).ToList();

            ShowInfo(sortingNamePations);
        }

        public void SortAge()
        {
            var sortingAgePations = _patiens.OrderBy(patien => patien.Age).ToList();

            ShowInfo(sortingAgePations);
        }

        public void OutDiseasePation()
        {
            string disease;

            Console.Write("Enter disease  (Headach, Fracture lag, Heard attack, Fracture hend,  Rash): ");
            disease = Console.ReadLine();

            var OutDisease = _patiens.Where(patien => patien.Disease == disease).ToList();

            ShowInfo(OutDisease);
        }

        public void ShowInfoPations()
        {
            foreach (Patien patiens in _patiens)
            {
                patiens.ShowInfo();
            }
        }

        private void ShowInfo(IEnumerable<Patien> patiens)
        {
            foreach (var patien in patiens)
            {
                patien.ShowInfo();
            }
        }

        private void Fill()
        {           
            List<string> name = new List<string> { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill", "Buba", "Pupa" };
            List<string> surname = new List<string> {"Jonson", "Simpson", "Georgevich", "Swonson", "Knop", "Black", "Tounenbaum", "Bosch", "Popov", "Lisitchin", "Boobich", "Alonso" };
            List<string> disease = new List<string> { "Headach", "Fracture lag", "Heard attack", "Fracture hend",  "Rash"};

            for (int i = 0; i < _quantityPatiens; i++)
            {
                _patiens.Add(new Patien(name[_random.Next(0, name.Count)], surname[_random.Next(0,surname.Count)], _random.Next(_minimumAge, _maximumAge), disease[_random.Next(0, disease.Count)]));
            }
        }
    }

    class Patien
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patien(string name, string surname, int age, string disease)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Surname} {Name} . Age: {Age}. Disease: {Disease}");
        }
    }
}
