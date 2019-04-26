using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.继承测试
{
    public class InheritanceTest
    {
        public static void Main(string[] args)
        {
            WeaponFork weaponFork = new WeaponFork();
            weaponFork.init();
            Console.Write(weaponFork.name);
            Console.ReadKey();
        }
    }
}
