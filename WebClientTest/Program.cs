using System;
using System.Text.RegularExpressions;


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

            string bbsUrl = "https://bbs.hupu.com";

            HttpItem httpItem = new HttpItem
            {
                URL = bbsUrl + "/all-gambia"
            };
            HttpHelper httpHelper = new HttpHelper();

            var result = httpHelper.GetHtml(httpItem);

            string pattern_between = "(?<=({0}))[.\\s\\S]*?(?=({1}))";

            string pattern = string.Format(pattern_between, "<span class=\"textSpan\">", "</em>");

            foreach (Match match in Regex.Matches(result.Html, pattern))
            {
                string res = match.Value;
                string pattern_url = string.Format(pattern_between, "href=\"", "\"");
                string pattern_title = string.Format(pattern_between, "title=\"", "\">");
                string pattern_count = string.Format(pattern_between, "<em>", "回复");



                string title = GetValueByPattern(match.Value, pattern_title);

                string url_link = GetValueByPattern(match.Value, pattern_url);
                string count = GetValueByPattern(match.Value, pattern_count).Trim();

                Console.WriteLine($"标题：{title},链接地址：{bbsUrl + url_link}，{count}+回复");
            }









            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }


        static string GetValueByPattern(string content, string pattern)
        {
            MatchCollection m = Regex.Matches(content, pattern);

            foreach (Match item in m)
            {
                return item.Value;
            }
            return "";
        }

    }
}
