using SmartHouseProject.Models.Devices;
using SmartHouseProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class Bathroom : RoomTemplate
    {

        public Bathroom(string name) : base(name) { 
            InitializeDevices();
        }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Boiler("Boiler",100));
            AddNewDevice(new WashingMachine("Washing machine",200));
            AddNewDevice(new Light("Bahtroom light",10));
            AddNewLock(new BasicLock("Bathroom lock"));
        }
    }
}
