using System;

namespace 单例模式
{
    public class Singleton
    {
        private static Singleton _singleton = null;
        private static object _singleton_Lock = new object(); //锁同步
        public static Singleton CreateInstance()
        {
            if (_singleton == null)
            {
                lock (_singleton_Lock)
                {
                    Console.WriteLine("路过");
                    if (_singleton == null)
                    {
                        Console.WriteLine("被创建！");
                        _singleton = new Singleton();
                    }
                }
            }

            return _singleton;
        }
    }
}
