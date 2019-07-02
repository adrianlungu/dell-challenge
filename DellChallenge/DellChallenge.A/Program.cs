using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constructor chaining works out which base class constructor is going to be called, after which
            // the base class is initialized (in this case class A) after which the other constructors in the chain. 
            // Thus, class A constructor runs first, then class B constructor which also sets Age to 0 triggering the set
            // defined in class A.
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
