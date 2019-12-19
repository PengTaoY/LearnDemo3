using iTextSharp.text;
using iTextSharp.text.pdf;
using PuppeteerSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Html2Pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string pngFile = Html2PNG("").Result;

            string pdf = ConvertImg2PDF(pngFile, $"tempfile\\{Guid.NewGuid().ToString("N")}.pdf");

            Console.WriteLine(pdf);

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 将网页转换成PNG图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<string> Html2PNG(string url)
        {
            string pngResult = string.Empty;
            string path = $@"{Directory.GetCurrentDirectory()}\tempfile";
            string pngName = path + $"\\page_{ Guid.NewGuid().ToString()}.png";

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            try
            {
                await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
                using (Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
                {
                    using (var page = await browser.NewPageAsync())
                    {
                        if (String.IsNullOrEmpty(url))
                        {
                            url = "http://www.baidu.com";
                        }

                        //设置浏览器的页面大
                        //  await page.SetViewportAsync(new ViewPortOptions { Width = 1024, Height = 768 });
                        await page.GoToAsync(url);
                        //将页面保存为png图片
                        await page.ScreenshotAsync(pngName, new ScreenshotOptions() { FullPage = true, Type = ScreenshotType.Png });
                    }

                }
                pngResult = pngName;
            }
            catch (Exception e)
            {
                Console.WriteLine($"生成PNG图片出错了,错误原因：{e.Message}");
            }

            return pngResult;
        }

        /// <summary>
        /// 将单张图片转换成PDF
        /// </summary>
        /// <param name="imgFilePath">图片路径</param>
        /// <param name="pdfName">pdf名称</param>
        /// <returns>转换后的pdf文件路径</returns>
        static string ConvertImg2PDF(string imgFilePath, string pdfName)
        {
            if (string.IsNullOrEmpty(imgFilePath))
            {
                Console.WriteLine($"图片生成PDF出错了,错误原因：图片路径为空");
                return "";
            }
            else
            {
                string pdfResult = string.Empty;
                string path = $@"{Directory.GetCurrentDirectory()}\tempfile";
                string pdfFilePath = $@"{Directory.GetCurrentDirectory()}\" + pdfName;

                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }

                try
                {
                    var document = new Document(PageSize.A4, 25, 25, 25, 25);
                    using (var stream = new FileStream(pdfName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfWriter.GetInstance(document, stream);
                        document.Open();
                        using (var imageStream = new FileStream(imgFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            if (image.Height > PageSize.A4.Height - 25)
                            {
                                image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                            }
                            else if (image.Width > PageSize.A4.Width - 25)
                            {
                                image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                            }
                            image.Alignment = Element.ALIGN_MIDDLE;
                            document.Add(image);
                        }

                        document.Close();
                    }
                    pdfResult = pdfFilePath;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"图片生成PDF出错了,错误原因：{e.Message}");
                }

                return pdfResult;
            }
        }
    }
}
