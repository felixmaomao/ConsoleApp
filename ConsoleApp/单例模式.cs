//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{

//    //这根本不是单例模式 而是静态全局变量。
//    class 单例模式
//    {
//        public static void Main(string[] args)
//        {
//            Singleton instance1 = Singleton.Current;
//            Singleton instance2 = Singleton.Current;
//            IsTheSame(instance1,instance2);
//            Console.ReadKey();
//        }      

//        public static void IsTheSame(object obj1,object obj2)
//        {
//            Console.WriteLine("hashcode of obj1 is {0}",obj1.GetHashCode());
//            Console.WriteLine("hashcode of obj2 is {0}",obj2.GetHashCode());
//        }
//    }

//    public class Singleton
//    {
//        private static Singleton _instance = new Singleton();
//        private Singleton()
//        {

//        }
//        public static Singleton Current
//        {
//            get { return _instance;}
//        }
//    }

//}
