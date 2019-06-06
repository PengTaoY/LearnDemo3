using System;
using System.Text;

namespace DateOperator
{
    class Program
    {
        static void Main(string[] args)
        {


            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            DateTime startTime2 = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1),TimeZoneInfo.Local);

            DateTime endTime = new DateTime(2019, 5, 1);

            StringBuilder sb = new StringBuilder();

            sb.Append("我爱北京天安门");


            string sbs = sb.ToString().Substring(1);
            long timeStamp1 = (long)(endTime - startTime).TotalMilliseconds;
            long timeStamp2 = (long)(endTime - startTime2).TotalMilliseconds;
            Console.WriteLine("Hello World!");
        }
    }
}
