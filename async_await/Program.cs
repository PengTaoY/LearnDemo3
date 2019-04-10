using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace async_await
{
    class Program
    {
        //https://www.cnblogs.com/liqingwen/p/5831951.html
        private static readonly Stopwatch Watch = new Stopwatch();

        static void Main(string[] args)
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharacters 方法(下载某网站内容，并统计字符的个数)
            Task<int> t1 = CountCharacters(1, url1);
            Task<int> t2 = CountCharacters(2, url2);

            //三次调用ExtraOperation 方法(主要通过拼接字符串达到耗时操作)
            for (int i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} 的字符个数：{t1.Result}");
            Console.WriteLine($"{url2} 的字符个数：{t2.Result}");

            Console.Read();
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}: {Watch.ElapsedMilliseconds} ms");

            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine($"调用完成 id = {id}: {Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="v"></param>
        private static void ExtraOperation(int id)
        {
            //拼接字符串进行耗时操作
            var s = "";

            for (int i = 0; i < 6000; i++)
            {
                s += i;
            }
            Console.WriteLine($"id = {id} 的ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");
        }

    }
}
