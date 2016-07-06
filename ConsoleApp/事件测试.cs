//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    class 事件测试
//    {
//        public static void Main(string[] args)
//        {

//        }
//    }

//    class A
//    {
//        public delegate void Greet();
//        public event Greet sayhi;

//        public A()
//        {
//            sayhi += Hello;
//        }

//        public void Hello()
//        {
//            Console.WriteLine("A hello");
//        }

//    }

//    class B
//    {
//        public A a = new A();

//        public void dosomething()
//        {
//          //经测试一个类里是不能直接调用另一个类里的事件的。   
//        }

//    }
//}
