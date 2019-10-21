namespace ExcelExport
{
    public class ExportToExcelResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string local_path { get; set; }
        /// <summary>
        /// 网络路径
        /// </summary>
        public string path { get; set; }
    }
}
