using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace ITextSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            try
            {
                //PdfWriter.GetInstance(document, new FileStream("D:\\my.pdf", FileMode.Create));
                //document.Open();
                //HttpClient hc = new HttpClient();


                //string htmlText = hc.GetStringAsync("https://www.baidu.com").Result;
                //htmlText = htmlText.Replace("//www.baidu.com/img/baidu_jgylogo3.gif", "http://www.baidu.com/img/baidu_jgylogo3.gif").Replace("//www.baidu.com/img/bd_logo.png", "http://www.baidu.com/img/bd_logo.png");
                //Console.WriteLine(htmlText);
                //var htmlarraylist = HtmlWorker.ParseToList(new StringReader(htmlText), null);


                ////List<IElement> htmlarraylist = HtmlWorker.ParseToList(new StringReader(htmlText), null);
                //for (int k = 0; k < htmlarraylist.Count; k++)
                //{
                //    document.Add((IElement)htmlarraylist[k]);
                //}

                //document.Close();
                string[] images = new string[3] { @"D:\ThisisMyHorse\LearnDemo3\ITextSharpDemo\bin\Debug\netcoreapp2.1\png.png", @"D:\ThisisMyHorse\LearnDemo3\ITextSharpDemo\bin\Debug\netcoreapp2.1\微信图片_20191219145410.png", @"D:\ThisisMyHorse\LearnDemo3\ITextSharpDemo\bin\Debug\netcoreapp2.1\微信图片_20191219145350.jpg" };

                foreach (var item in images)
                {
                    Console.WriteLine(ConvertImg2PDF(item, $"png_{Guid.NewGuid().ToString("N")}.pdf"));
                }

                Console.WriteLine(ConvertImgs2PDF(images, $"png_{Guid.NewGuid().ToString("N")}.pdf"));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Hello World!");
        }


        /// <summary>
        /// 将单张图片转换成PDF
        /// </summary>
        /// <param name="imgFilePath">图片路径</param>
        /// <param name="pdfName">pdf名称</param>
        /// <returns>转换后的pdf文件路径</returns>
        static string ConvertImg2PDF(string imgFilePath, string pdfName)
        {
            string pdfFilePath = Directory.GetCurrentDirectory() + "\\" + pdfName;
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
            }
            catch (Exception e)
            {
                pdfFilePath = e.Message;

            }
            return pdfFilePath;
        }

        /// <summary>
        /// 将多张图片转换成PDF
        /// </summary>
        /// <param name="imgsFilePath"></param>
        /// <param name="pdfName"></param>
        /// <returns></returns>
        static string ConvertImgs2PDF(string[] imgsFilePath, string pdfName)
        {
            string pdfFilePath = Directory.GetCurrentDirectory() + "\\" + pdfName;

            Document document = new Document(PageSize.A4, 25, 25, 25, 25);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(pdfName, FileMode.Create, FileAccess.ReadWrite));

                document.Open();
                Image image;
                for (int i = 0; i < imgsFilePath.Length; i++)
                {
                    if (string.IsNullOrEmpty(imgsFilePath[i])) break;

                    image = Image.GetInstance(imgsFilePath[i]);

                    if (image.Height > PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    else if (image.Width > PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    image.Alignment = Element.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);

                    document.NewPage();
                    document.Add(image);

                }

            }
            catch (Exception ex)
            {
                pdfFilePath = ex.Message;
            }
            document.Close();

            return pdfFilePath;
        }

    }
}
