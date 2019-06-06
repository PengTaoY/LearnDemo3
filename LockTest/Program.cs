using System;
using System.Threading;

namespace LockTest
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Thread thread1 = new Thread(new ThreadStart(ThreadStart1));
                thread1.Name = "Thread"+$"【{i}】【1】";
                Thread thread2 = new Thread(new ThreadStart(ThreadStart2));
                thread2.Name = "Thread2" + $"【{i}】【2】";
                Thread thread3 = new Thread(new ThreadStart(ThreadStart3));
                thread3.Name = "Thread3" + $"【{i}】【3】";

                thread1.Start();
                thread2.Start();
                thread3.Start();

                Console.WriteLine("****************************************");
            }

            

            Console.ReadKey();
        }

        static object _object = new object();
        static void Done(int millisecondsTimeout)
        {
            Console.WriteLine(string.Format("{0} -> {1}.Start", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));

            //下边代码段同一时间只能由一个线程在执行
            lock (_object)
            {
                Console.WriteLine(string.Format("{0} -> {1}进入锁定区域.", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine(string.Format("{0} -> {1}退出锁定区域.", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));
            }
        }
        static void ThreadStart1()
        {
            Done(5000);
        }
        static void ThreadStart2()
        {
            Done(3000);
        }
        static void ThreadStart3()
        {
            Done(1000);
        }
    }
}
