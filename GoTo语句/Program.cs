using System;

namespace GoTo语句
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = TestGoto(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Hello World!");
        }

        private static int TestGoto(int number)
        {
            if (number == 0)
            {
                goto Next;
            }

            number = number * 100;

            Next:
            number = number + 1;

            HaHa:
            number = number + 2;

            return number; 

        }
    }
}
