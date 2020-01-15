using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace 正则爬取图片
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://bbs.hupu.com/31705041.html";
            string path = Path.Combine(@"D:\\吃不饱");
            HttpGetAction(url, path, 1);
            Console.ReadKey();
        }


        static void HttpGetAction(string url, string path, int name)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("抓取地址:" + url);
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            var response = webRequest.GetResponse();
            using StreamReader reader = new StreamReader((response as HttpWebResponse).GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            reader.Close();

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("请求地址错误");
                Console.ReadKey();
                return;
            }

            //提取img标签src地址
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            //提取匹配的字符串
            MatchCollection matches = regImg.Matches(result);
            //爬取数量
            int i = 0;
            WebClient web = new WebClient();
            foreach (Match match in matches)
            {
                string imgsrc = match.Groups["imgUrl"].Value;
                if (imgsrc.Contains("http") && !imgsrc.Contains(".svg"))
                {
                    i++;
                    HttpGetImg(web, imgsrc, path, name);
                    name++;//图片名
                }
            }
            sw.Stop();
            Console.WriteLine("爬取完成！总共爬取了" + i + "张图片！");
            Console.WriteLine("爬取图片耗时：" + sw.ElapsedMilliseconds / 1000 + "秒");
        }

        private static void HttpGetImg(WebClient web, string imgsrc, string path, int name)
        {
            Console.WriteLine("爬取图片：" + imgsrc);
            if (!Directory.Exists(path))
            {
                Console.WriteLine("路径错误！");
                Console.ReadKey();
                return;
            }
            web.DownloadFile(imgsrc, path + "\\" + name + ".jpg");
            Console.WriteLine("爬取图片成功：" + name + ".jpg");
        }
    }
}
