﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OccupyCar> occupyCars = new List<OccupyCar>();
            occupyCars.Add(new OccupyCar { car_id = 121, car_name = "张三", plate_num = "京123" });
            occupyCars.Add(new OccupyCar { car_id = 122, car_name = "李四", plate_num = "京234" });

            List<OccupyCar> occupyCars2 = new List<OccupyCar>();
            occupyCars2.Add(new OccupyCar { car_id = 122, car_name = "李四", plate_num = "京234" });
            occupyCars2.Add(new OccupyCar { car_id = 123, car_name = "王五", plate_num = "京456" });


            IEnumerable<OccupyCar> union = occupyCars.Union(occupyCars2);

            foreach (var item in union)
            {
                Console.WriteLine($"{item.car_id} {item.car_name} {item.plate_num}");
            }













            List<int> ls1 = new List<int>();
            List<int> ls2 = new List<int>();
            List<int> ls3 = new List<int>();

            ls1.Add(1);
            ls1.Add(2);


            ls3.Add(2);
            ls3.Add(3);


            List<int> result = ls1.Union(ls2).Union(ls3).ToList();












            //Guid guid0 = new Guid("bde3e4a8-524b-4b63-a511-1daf6d6f192d");
            //Guid guid1 = new Guid("c0796d59-2ef3-483b-9582-5b547e7916c1");
            //Guid guid2 = new Guid("c0fb930c-326c-4f81-ad47-8af9dbe630a5");

            Guid guid33 = new Guid("C0FB930C-326C-4F81-AD47-8AQ96BE630A5");

            Guid guid3 = new Guid("c0fb930c-326c-4f81-ad47-8aa96be630a5");

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


    public class OccupyCar : IEquatable<OccupyCar>
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int car_id { get; set; }
        /// <summary>
        /// 车辆名称
        /// </summary>
        public string car_name { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string plate_num { get; set; }

        public bool Equals(OccupyCar other)
        {
            if (other is null)
            {
                return false;
            }
            return this.car_id == other.car_id && this.car_name == other.car_name && this.plate_num == other.plate_num;
        }

        public override bool Equals(object obj) => Equals(obj as OccupyCar);
        public override int GetHashCode() => (car_id, car_name, plate_num).GetHashCode();

    }



}
