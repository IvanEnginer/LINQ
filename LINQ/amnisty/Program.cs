using System;
using System.Collections.Generic;
using System.Linq;

namespace amnisty
{
    class Program
    {
        static void Main(string[] args)
        {

            DataBaseCriminal dataBaseCriminal = new DataBaseCriminal();

            Console.WriteLine("Befor amnisty:");

            dataBaseCriminal.ShowInfo();
            dataBaseCriminal.Amnesty();

            Console.WriteLine("After amnisty:");

            dataBaseCriminal.ShowInfo();
        }
    }

    class DataBaseCriminal
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public DataBaseCriminal()
        {
            FillBase();
        }

        public void Amnesty()
        {
            _criminals = _criminals.Where(people => people.Crime != "political").ToList();
        }

        public void ShowInfo()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        private void FillBase()
        {
            _criminals.Add(new Criminal("Swonson", "Ron","thief", true));
            _criminals.Add(new Criminal("Simpson", "Ron","political", true));
            _criminals.Add(new Criminal("Andreus", "Jon", "political", true));
            _criminals.Add(new Criminal("Bubich", "Booba","killer", true));
            _criminals.Add(new Criminal("Pupick", "Pupa","thief", true));
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Crime { get; private set; }
        public bool IsPrisoner { get; private set; }

        public Criminal(string surname, string name, string crime, bool isPrisoner)
        {
            Name = name;
            Surname = surname;
            IsPrisoner = isPrisoner;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name} {Surname}. Status lokation: {IsPrisoner}. Crim: {Crime}.");
        }
    }
}
