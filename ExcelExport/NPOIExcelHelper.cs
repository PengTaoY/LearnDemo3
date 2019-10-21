using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;

namespace ExcelExport
{
    public class NPOIExcelHelper : IDisposable
    {

        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        /// <summary>
        /// NPOI操作Excel类
        /// </summary>
        /// <param name="fileName">文件名</param>
        public NPOIExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }


        /// <summary>
        /// 写入DataTable的列名
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sheetName"></param>
        /// <param name="isColumnWritten">是否写入列名称</param>
        /// <param name="headName">表头名称</param>
        /// <param name="now">导出时间(当前时间)</param>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, string headName, DateTime now, string filter = "")
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                #region 写入表头跟创建时间
                //写入表头跟创建时间
                if (!string.IsNullOrEmpty(headName))
                {
                    IRow row = sheet.CreateRow(count++);
                    int colums = data.Columns.Count;
                    row.Height = 30 * 20;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, (colums - 1) > 0 ? (colums - 1) : colums));
                    row.CreateCell(0).SetCellValue(headName);

                    ICellStyle style = workbook.CreateCellStyle();
                    //设置单元格的样式：水平对齐居中
                    style.Alignment = HorizontalAlignment.Center;
                    //新建一个字体样式对象
                    IFont font = workbook.CreateFont();
                    //设置字体加粗样式  2003的加粗
                    //font.Boldweight = short.MaxValue;
                    //设置字体加粗样式  2007的加粗
                    font.Boldweight = (short)FontBoldWeight.Bold;

                    font.FontHeightInPoints = 18;
                    //使用SetFont方法将字体样式添加到单元格样式中 
                    style.SetFont(font);
                    //将新的样式赋给单元格
                    row.Cells[0].CellStyle = style;

                    if (!string.IsNullOrEmpty(filter))
                    {
                        IRow rowFilter = sheet.CreateRow(count++);
                        rowFilter.CreateCell(0).SetCellValue($"{filter}");
                        sheet.AddMergedRegion(new CellRangeAddress(count - 1, count - 1, 0, (colums - 1) > 0 ? (colums - 1) : colums));
                    }



                    IRow rowTime = sheet.CreateRow(count++);
                    rowTime.CreateCell(0).SetCellValue($"导出时间:{now.ToString("yyyy/MM/dd HH:mm:ss")}");
                    sheet.AddMergedRegion(new CellRangeAddress(count - 1, count - 1, 0, (colums - 1) > 0 ? (colums - 1) : colums));
                }
                #endregion


                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(count++);
                    ICellStyle style = workbook.CreateCellStyle();
                    //设置单元格的样式：水平对齐居中
                    style.Alignment = HorizontalAlignment.Center;
                    //新建一个字体样式对象
                    IFont font = workbook.CreateFont();
                    //设置字体加粗样式
                    font.Boldweight = (short)FontBoldWeight.Bold;
                    style.SetFont(font);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                        row.Cells[j].CellStyle = style;
                    }
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        ICellStyle testStyle = workbook.CreateCellStyle();

                        if (double.TryParse(data.Rows[i][j].ToString(), out double nx))
                        {
                            //设置单元格的字体颜色
                            IFont fonttest = workbook.CreateFont();
                            fonttest.Color = HSSFColor.Red.Index;
                            row.CreateCell(j).SetCellValue(nx);
                            testStyle.SetFont(fonttest);
                        }
                        //else if (DateTime.TryParse(data.Rows[i][j].ToString(), out DateTime zz))
                        //{
                        //    row.CreateCell(j).SetCellValue(zz.ToString("yyyy-MM-dd"));
                        //}
                        else
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                            //设置单元格的背景颜色
                            testStyle.FillForegroundColor = HSSFColor.Red.Index;
                            testStyle.FillPattern = FillPattern.SolidForeground;
                        }

                        row.Cells[j].CellStyle = testStyle;
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }


        #region Dispoose释放
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
        #endregion
    }
}
