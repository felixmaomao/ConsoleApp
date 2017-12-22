using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class string空测试
    {
        public static void Main(String[] args)
        {
            Demo demo = new Demo();
            demo.demoa = "aaa";
            Console.WriteLine(demo.demoa.ToString());                     
            Console.ReadKey();

        }
    }

    class Demo
    {
        public string demoa;      
    }
}
