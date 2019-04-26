using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.继承测试
{
    public class WeaponFork:ShootWeapon
    {
        public string myname;
        public string mydamage;
        
        public void init()
        {
            this.myname = "weapon_fork";
            this.mydamage = "huge damage";
            this.damage = mydamage;
            this.name = myname;
        }
    }
}
