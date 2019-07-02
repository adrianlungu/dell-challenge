using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            Calculator calc = new Calculator();
            int sum1 = calc.Sum(new int[]{ 1, 3});
            int sum2 = calc.Sum(new int[]{ 1, 3, 5});
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
        }
    }

    class Calculator
    {
        public int Sum(int[] numbers)
        {
            int sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            return sum;
        }

    }
}
