using System.ComponentModel;

namespace ExcelExport
{
    public class TestExportClass
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public int Code { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        [Description("车型")]
        public string car_name { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        [Description("级别")]
        public string version_name { get; set; }
        /// <summary>
        /// 外观颜色
        /// </summary>
        [Description("外观颜色")]
        public string out_color { get; set; }
    }
}
