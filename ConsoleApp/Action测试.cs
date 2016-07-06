//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    public delegate void showvalue();
//    class Action测试
//    {
//        //自然的理解成 指针就ok。也可以看到委托和是否static冰没有什么关系
//        public static void Main(string[] args)
//        {
//            showvalue show = showToConsole;
//            Action showaction = showToConsole;
//            showaction += new Temp().instanceShow;
//            //show();
//            showaction();
//            Console.ReadKey();
//        }
//        public static void showToConsole()
//        {
//            Console.WriteLine("haha");
//        }

//    }

//    public class Temp
//    {
//        public void instanceShow()
//        {
//            Console.WriteLine("hahahahaah");
//        }
//    }
//}
