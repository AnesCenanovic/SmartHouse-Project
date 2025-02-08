using SmartHouseProject.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class Bathroom : RoomTemplate
    {

        public Bathroom(string name,double size) : base(name, size) { }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Boiler("Boiler"));
            AddNewDevice(new WashingMachine("Washing machine"));
            AddNewDevice(new Light("Bahtroom light"));
        }
    }
}
