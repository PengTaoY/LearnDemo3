using PuppeteerSharp;
using System;
using System.IO;

namespace Pupper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test();

            Console.ReadKey();
        }


        public async static void Test()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            using (Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
            {
                using (var page = await browser.NewPageAsync())
                {
                    //设置浏览器的页面大小😊

                    //  await page.SetViewportAsync(new ViewPortOptions { Width = 1024, Height = 768 });
                    await page.GoToAsync("http://www.baidu.com");
                    // var html = await page.GetContentAsync();

                    var stream = await page.ScreenshotStreamAsync(new ScreenshotOptions { FullPage = true, Type = ScreenshotType.Png });

                    //将页面保存为jpg图片

                    await page.ScreenshotAsync($@"{System.IO.Directory.GetCurrentDirectory()}\page_{Guid.NewGuid().ToString()}.jpg", new ScreenshotOptions() { FullPage = true, Type = ScreenshotType.Jpeg });
                    //将页面保存为png图片
                    await page.ScreenshotAsync($@"{System.IO.Directory.GetCurrentDirectory()}\page_{Guid.NewGuid().ToString()}.png", new ScreenshotOptions() { FullPage = true, Type = ScreenshotType.Png });


                    //将页面保存为pdf文件
                    await page.PdfAsync($@"{System.IO.Directory.GetCurrentDirectory()}\page_{Guid.NewGuid().ToString()}_page.pdf");

                    Console.WriteLine("为什么不行呢 /哭啼啼");

                }

            }
        }
    }
}
