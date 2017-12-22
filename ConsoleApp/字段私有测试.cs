using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class 字段私有测试
    {
        //字段的私有与否，都是针对其他类而言，而不是针对自己的。
    }
    class A
    {
        private string _name;
        public string Age
        {
            get;
            private set;                
        }
        public void sayHi()
        {
            Console.WriteLine(this._name);        
        }
    }
}
