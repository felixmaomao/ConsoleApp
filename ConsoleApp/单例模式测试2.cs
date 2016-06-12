//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    //单例模式的实现其实也是利用了静态全局变量哈。。。
//    //甚至 有人提出实际上static就是单例模式在语言层面的一种实现。这种看法确实让人眼前一亮。不过其他的区别在哪里呢？
//    class 单例模式测试2
//    {
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("hashcode of obj1 is {0}",Singleton.GetInstance().GetHashCode());
//            Console.WriteLine("hashcode of obj2 is {0}",Singleton.GetInstance().GetHashCode());
//            Console.ReadKey();
//        }
//    }
//    public class Singleton
//    {
//        private Singleton() { }
//        private static Singleton _instance = new Singleton();
//        public static Singleton GetInstance()
//        {
//            if (_instance == null)
//                _instance = new Singleton();
//            return _instance;
//        }
//    }
//}
