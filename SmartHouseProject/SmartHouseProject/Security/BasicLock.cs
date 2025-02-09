using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Security
{
    public class BasicLock : LockTemplate
    {
        public BasicLock(string name,string passwordCode = null) : base(name, passwordCode) {}
        public override void SystemStatusReport()
        {
            Console.WriteLine($"{Name} is {(IsLockedState ?  "Locked" : "Unlocked")}");
        }
    }
}
