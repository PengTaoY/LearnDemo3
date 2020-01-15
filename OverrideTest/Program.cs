using System;

namespace OverrideTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new WeatherInfo().ToString());

            WeatherInfo weatherInfo = new WeatherInfo
            {
                City = "北京",
                Temp = "朝阳",
                Radar = "Dont know"
            };

            Console.WriteLine(weatherInfo.ToString());


            Console.WriteLine(new WeatherInfo2().ToString());

            Console.ReadLine();

            testa testa = new testa();
            testa.is_locked = true;
            Console.WriteLine(testa.operator_status_text + "     " + testa.apply_car_statusText);

            testa testa1 = new testa
            {
                is_locked = false
            };
            Console.WriteLine(testa1.operator_status_text + "           " + testa1.apply_car_statusText);

            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }

    public class WeatherInfo
    {
        public string City { get; set; } = "";
        public string CityId { get; set; } = "";
        public string Temp { get; set; } = "";
        public string WD { get; set; } = "";
        public string WS { get; set; } = "";
        public string SD { get; set; } = "";
        public string AP { get; set; } = "";
        public string Njd { get; set; } = "";
        public string WSE { get; set; } = "";
        public string Time { get; set; } = "";
        public string SM { get; set; } = "";
        public string IsRadar { get; set; } = "";
        public string Radar { get; set; } = "";

        public override string ToString()
        {
            return string.Format($"City:{City}\r\n"
                + $"CityId:{CityId}\r\n"
                + $"Temp:{Temp}\r\n"
                + $"WD:{WD}\r\n"
                + $"WS:{WS}\r\n"
                + $"SD:{SD}\r\n"
                + $"AP:{AP}\r\n"
                + $"Njd:{Njd}\r\n"
                + $"WSD:{WSE}\r\n"
                + $"Time:{Time}\r\n"
                + $"SM:{SM}\r\n"
                + $"IsRadar:{IsRadar}\r\n"
                + $"Radar:{Radar}\r\n");
        }
    }

    public class WeatherInfo2
    {
        public string City { get; set; } = "";

        public string Temp { get; set; } = "";
    }

    public class testa
    {
        public bool is_locked { get; set; }

        /// <summary>
        /// 车辆申请状态文字描述
        /// </summary>
        public string apply_car_statusText
        {
            get
            {
                if (String.IsNullOrEmpty(operator_status_text))
                {
                    return "已锁定";
                }

                return "待取车";
            }
        }

        /// <summary>
        /// 下一步操作状态文本
        /// </summary>
        public string operator_status_text
        {
            get
            {
                if (apply_car_statusText == "待取车")
                {
                    return "需联系车库管理员确认交接";
                }
                return "";
            }
        }
    }
}
