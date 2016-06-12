//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    class static测试
//    {
//        public static void Main(string[] args)
//        {
//            Demo demo1 = new Demo();
//            Demo demo2 = new Demo();
//            demo1.hah();
//            Console.WriteLine(Demo.instanceCount);
//            Console.ReadKey();
//        }
//    }

//    public class Demo
//    {
//        public static int instanceCount = 0;
//        static Demo()
//        {
//            instanceCount = 5;
//        }
//        public Demo()
//        {
//            instanceCount++;
//        }
//        public void hah()
//        {
//            instanceCount = 0;
//        }
//    }


//}
