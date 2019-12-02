using System;
using System.Collections.Generic;
using System.Text;

namespace 单例模式
{
    /*
     * 利用静态变量实现单例模式
     利用静态变量去实现单例,  由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
    PS: 但是他的缺点也很明显, 在程序初始化后, 静态对象就被CLR构造了, 哪怕你没用。
         */
    public class SingletonThird
    {
        /// <summary>
        /// 静态变量
        /// </summary>
        private static SingletonThird _singletonThird = new SingletonThird();

        public static SingletonThird CreateInstance()
        {
            return _singletonThird;
        }
    }
}
