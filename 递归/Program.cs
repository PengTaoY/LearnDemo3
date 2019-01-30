using System;

namespace 递归
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(Factorial(i));
            }

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 斐波那契数列求值  1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
        /// </summary>
        /// <param name="n">第N个值</param>
        /// <returns></returns>
        static int Fibonacci(int n)
        {
            if (n < 3)
            {
                return 1;
            }
            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }
        
        /// <summary>
        /// N的阶乘  1*2*3*4*5*......
        /// </summary>
        /// <param name="n">N</param>
        /// <returns></returns>
        static int Factorial(int n)
        {
            if (n==1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

    }
}
