using SmartHouseProject.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public abstract class RoomTemplate
    {
        public string Name { get; set; }
        private List<SmartDeviceTemplate> devices = new List<SmartDeviceTemplate>(); // all devices tied to the room


        public RoomTemplate(string name)
        {
            Name = name;
        }

        public void AddNewDevice(SmartDeviceTemplate device)
        {
            devices.Add(device);
        }

        public void printDevices()
        {
            Console.WriteLine($"Room: {Name}");
            foreach (var device in devices)
            {
                device.statusReport();
            }
        }
    }

}
