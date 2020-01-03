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
}
