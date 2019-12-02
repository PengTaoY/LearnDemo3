using System;

namespace 单例模式
{
    public class Singleton
    {
        private static Singleton _singleton = null;
        public static Singleton CreateInstance()
        {
            if (_singleton == null)
            {
                Console.WriteLine("被创建！");
                _singleton = new Singleton();
            }
            return _singleton;
        }
    }
}
