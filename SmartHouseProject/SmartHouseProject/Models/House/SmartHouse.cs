using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.House
{
    internal class SmartHouse : SmartHouseTemplate
    {
        public SmartHouse(string address, string name, int value, int size) : base(address, name, value, size) {

            Console.WriteLine($"House created: {Name}");
        }
    }
}
