//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ConsoleApp
//{
//    public class 泛型action测试
//    {        
//        public static void Main()
//        {
//            Action<string> show = showToConsole;
//            Action<string, string> anothershow = showToConsole;
//            show("jahahaaha");
//            anothershow("xxxxxxx","yyyyyyy");
//            Console.ReadKey();
//        }

//        public static void showToConsole(string message)
//        {
//            Console.WriteLine(message);
//        }
//        public static void showToConsole(string msg1,string msg2)
//        {
//            Console.WriteLine(msg1+msg2);
//        }
//    }
//}
