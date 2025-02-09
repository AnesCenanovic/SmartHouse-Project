using SmartHouseProject.Models.Devices;
using SmartHouseProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class Kitchen : RoomTemplate
    {
        public Kitchen(string name, double size) : base(name, size) {
            InitializeDevices();
        }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Light("Kitchen light",20));
            AddNewDevice(new Fridge("Fridge", 100));
            AddNewDevice(new Oven("Oven", 400));
        }
    }
}
