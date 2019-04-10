using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            //valuePairs.Add("createuserid", "张三");
            //valuePairs.Add("createdate", "李四");


            //DateTime dateTime1 = new DateTime(2019, 3, 20, 8, 0, 0);
            //DateTime dateTime2 = new DateTime(2019, 3, 20, 9, 0, 10);
            //Console.WriteLine($"开始时间：{dateTime1.ToString()}     结束时间：{dateTime2.ToString()}"  );

            //Console.WriteLine($"审批时长：{(int)(dateTime2.Subtract(dateTime1).Duration().TotalMinutes)} 秒。");  ;


            //double s = 60;


            Dictionary<int, bool> keyValuePairs = new Dictionary<int, bool>();
            keyValuePairs.Add(1, true);
            keyValuePairs.Add(1, false);
            keyValuePairs.Add(2, true);
            keyValuePairs.Add(2, true);

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine(item.Key + item.Value.ToString());
            }

            Console.WriteLine(TimeSpan.FromMinutes(60).ToString());





            //List<Test> lsTest = new List<Test>();
            //Test test1 = new Test { Id = 1, largeRegion = 1 };
            //Test test2 = new Test { Id = 2, largeRegion = 2 };
            //Test test3 = new Test { Id = 3, largeRegion = 3 };
            //lsTest.Add(test1);
            //lsTest.Add(test2);
            //lsTest.Add(test3);

            //Console.WriteLine("初始顺序");
            //foreach (var item in lsTest)
            //{
            //    Console.WriteLine(item.Id + "  "+item.largeRegion);
            //}

            //Console.WriteLine("OrderBy以后的顺序");

            //lsTest = lsTest.OrderBy(u => u.largeRegion).ToList();
            //foreach (var item in lsTest)
            //{
            //    Console.WriteLine(item.Id + "  " + item.largeRegion);
            //}


            //Console.WriteLine("OrderByDescending以后的顺序");
            //lsTest = lsTest.OrderByDescending(u => u.largeRegion).ToList();
            //foreach (var item in lsTest)
            //{
            //    Console.WriteLine(item.Id + "  " + item.largeRegion);
            //}

            Console.ReadKey();
        }
    }


    public class Test
    {
        public int Id { get; set; }
        public int largeRegion { get; set; }

    }
}
