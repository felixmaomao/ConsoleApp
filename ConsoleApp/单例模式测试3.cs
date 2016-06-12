//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    //很多时候，根本就是最基本的代码基础以及代码素养不够扎实。
//    //单例模式的类还是可以实现接口，继承等机制，配合静态变量即可实现唯一实例（不考虑线程安全）
//    //但是如果采用静态类就不可以和接口什么的写在一起了。 并且单例模式本身这个实例是可以作为方法的参数使用的，如果是static类 就不行了。
//    class 单例模式测试3
//    {
//        public static void Main(string[] args)
//        {
//            ILog logger = ConsoleLog.GetInstance();
//            logger.WriteLog("hello");
//            ILog logger2 = ConsoleLog.GetInstance();
//            logger2.WriteLog("world");
//            Console.WriteLine("there are {0} logs", (logger2 as ConsoleLog).logCount);
//            Console.ReadKey();
//        }
//    }

//    public interface ILog
//    {
//        void WriteLog(string message);
//    }
//    public class ConsoleLog : ILog
//    {
//        private static ConsoleLog _instance = new ConsoleLog(); //核心本质上还是依赖于static，不过这边加载的时候就已经初始化好了，属于eager load
//        //private static ConsoleLog _instance = null;  //lazy load
//        private ConsoleLog() { }
//        //这里随便是采用一个静态方法暴露实例，还是采用属性都可以。（因为属性本质上就是方法。）
//        public static ConsoleLog GetInstance()
//        {
//            if (_instance == null)
//                _instance = new ConsoleLog();
//            return _instance;
//        }
//        public int logCount = 0;
//        public void WriteLog(string message)
//        {
//            Console.WriteLine(message);
//            logCount++;
//        }
//    }
//}
