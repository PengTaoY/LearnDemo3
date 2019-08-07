using System;

namespace WebClientTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string s1 = "www.baidu.com/123.html";

            string s2 = s1.Replace(".html", "_all.html#p1");


            string url = "我爱北京天安门";

            var s = System.Web.HttpUtility.UrlEncode(url);

            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
