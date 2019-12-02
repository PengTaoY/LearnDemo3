using System;
using System.Collections.Generic;
using System.Text;

namespace 单例模式
{
    /*
     利用静态构造函数实现单例模式
        静态构造函数：只能有一个，无参数的，程序无法调用 。
        同样是由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        同静态变量一样, 它会随着程序运行, 就被实例化, 同静态变量一个道理。
         */
    public class SingletonSecond
    {
        private static SingletonSecond _SingletonSecond = null;

        static SingletonSecond()
        {

            _SingletonSecond = new SingletonSecond();
        }

        public static SingletonSecond CreateInstance()
        {
            return _SingletonSecond;
        }
    }
}
