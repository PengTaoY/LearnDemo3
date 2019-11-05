using System;
using Spire.Xls;
using Spire.Xls.Charts;
using System.Drawing;

namespace operxls
{
    class Program
    {
        static void Main(string[] args)
        {
            //加载测试文档
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("test.xlsx");

            //获取第一个工作薄以及其中的第一个图表
            Worksheet sheet = workbook.Worksheets[0];
            Chart chart = sheet.Charts[0];

            //获取图表中的指定系列
            ChartSerie serie1 = chart.Series[1];
            //添加数据标签,并设置数据标签样式
            serie1.DataPoints.DefaultDataPoint.DataLabels.HasValue = true;
            serie1.DataPoints.DefaultDataPoint.DataLabels.FrameFormat.Fill.FillType = ShapeFillType.SolidColor;
            serie1.DataPoints.DefaultDataPoint.DataLabels.FrameFormat.Fill.ForeColor = Color.White;
            serie1.DataPoints.DefaultDataPoint.DataLabels.FrameFormat.Border.Pattern = ChartLinePatternType.Solid;
            serie1.DataPoints.DefaultDataPoint.DataLabels.FrameFormat.Border.Color = Color.Green;


            ////使用文档中其他单元格的数据自定义datalabel
            //ChartSerie serie2 = chart.Series[2];
            //serie2.DataPoints.DefaultDataPoint.DataLabels.ValueFromCell = sheet.Range["B4:E4"];
            ////添加数据标注
            //serie2.DataPoints.DefaultDataPoint.DataLabels.HasWedgeCallout = true;

            //保存文档
            workbook.SaveToFile("AddDataLable.xlsx");
            System.Diagnostics.Process.Start("AddDataLable.xlsx");
        }
    }
}
