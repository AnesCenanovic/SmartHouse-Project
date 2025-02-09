using SmartHouseProject.Models.Devices;
using SmartHouseProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class LivingRoom : RoomTemplate
    {
        public LivingRoom(string name, double size) : base(name, size) { }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Thermostat("Thermostat",10));
            AddNewDevice(new Light("Living Room light",10));
            AddNewLock(new BasicLock("Master lock"));
        }
    }
}
