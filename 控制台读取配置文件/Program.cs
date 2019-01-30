using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace 控制台读取配置文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //需要引用三个Nuget包
            //注意将appsetting.json的编码格式设置为utf-8.然后属性里面设置始终复制


            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuuation = builder.Build();

            string sqlServer = configuuation["ConnectionStrings:SqlServer"];
            Console.WriteLine($"配置文件中sqlServer的值：{ sqlServer}");

            Console.ReadKey();
        }
    }
}
