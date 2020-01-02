using HtmlAgilityPack;
using System;
using System.Linq;

namespace HAPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // From Web
            var url = "https://bbs.hupu.com/all-gambia";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var s = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'list')]");

           var sss = s.First().InnerText;


            var s2 = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'list')]").FindFirst("");

            Console.WriteLine("Hello World!");
        }
    }
}
