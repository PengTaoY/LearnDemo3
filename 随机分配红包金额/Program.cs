using System;

namespace 随机分配红包金额
{
    /// <summary>
    /// 博主地址： https://www.cnblogs.com/hucheng/p/9911169.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 200;
            int totalCount = 10;
            RandomMoney randomMoney = new RandomMoney(totalMoney, totalCount);

            double useMoney = 0;
            for (int i = 0; i < totalCount; i++)
            {
                double currentMoney = randomMoney.GetRandomMoney();

                useMoney += currentMoney;
                Console.WriteLine($"第{i + 1}个红包：{currentMoney}；已领取金额：{useMoney}； 还有{(double)Math.Round((totalMoney - useMoney) * 100) / 100  }元待领取");
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 红包
    /// </summary>
    public class RandomMoney
    {
        public RandomMoney(double totalMoney, int totalCount)
        {
            RemainMoney = totalMoney;
            RemainCount = totalCount;
        }
        /// <summary>
        /// 剩下的金额
        /// </summary>
        public double RemainMoney { get; set; }
        /// <summary>
        /// 剩下的红包数
        /// </summary>
        public int RemainCount { get; set; }

        private Random r = new Random();

        public double GetRandomMoney()
        {
            if (RemainCount < 1)
            {
                throw new Exception("红包已经抢完了");
            }

            if (RemainCount == 1)//最后一次
            {
                RemainCount--;
                return (double)Math.Round(RemainMoney * 100) / 100;
            }

            double min = 0.01;
            double max = RemainMoney / RemainCount * 2;
            double money = r.NextDouble() * max;//随机取本次金额
            money = money <= min ? 0.01 : money;//判断最小值
            money = Math.Floor(money * 100) / 100;
            RemainCount--;//红包个数减少
            RemainMoney = RemainMoney - money;//剩余金额
            return money;
        }
    }
}
