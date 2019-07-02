using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            new Groot().GetSpecies();
            Console.ReadKey();
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
        void GetSpecies();
    }

    public class Species : ISpecies
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species
    {
        public void Swim()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I am human!");
        }
    }

    public class Bird : Species
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I am bird!");
        }
    }

    public class Fish : Species
    {
        public void Swim()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I am fish!");
        }
    }

    public class Groot : Species
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"I am groot!");
        }
    }
}

