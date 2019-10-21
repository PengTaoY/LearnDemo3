using System;
using System.Collections.Generic;

namespace ExcelExport
{
    class Program
    {
        static void Main(string[] args)
        {
            int te = 0;
            int te1 = te++;
            Console.WriteLine(te);

            int tee = 0;
            int tee1 = ++tee;
            Console.WriteLine(tee1);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(i);
            }
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine(i);
            }

            var directory = System.IO.Directory.GetCurrentDirectory();





            List<TestExportClass> exportData = new List<TestExportClass>();

            for (int i = 1; i < 4; i++)
            {
                TestExportClass testExport = new TestExportClass
                {
                    Code = i,
                    car_name = "车型" + i,
                    version_name = "级别" + i,
                    out_color = "外观色" + i
                };

                exportData.Add(testExport);
            }

            var s = NPOIHelper.ExportToExcel(exportData, directory, $"文件名{Guid.NewGuid().ToString()}.xlsx", "sheet名称", "table名称");







            Console.WriteLine("Hello World!");
        }
    }
}
