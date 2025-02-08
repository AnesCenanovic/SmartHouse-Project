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
        public double Size { get; private set; }
        public List<SmartDeviceTemplate> Devices { get; private set; } = new(); // all devices tied to the room


        public RoomTemplate(string name,double size)
        {
            Name = name;
            Size = size;
        }

        public void AddNewDevice(SmartDeviceTemplate device)
        {
            Devices.Add(device);
        }

        public void RemoveDevice(SmartDeviceTemplate device)
        {
            if (Devices.Contains(device))
            {
                Devices.Remove(device);
                Console.WriteLine($"Removed {device.Name} from: {Name}.");
            }
            else
            {
                Console.WriteLine($"{device.Name} does not exist in: {Name}.");
            }
        }

        public void PrintDevices()
        {
            Console.WriteLine($"Room: {Name}");
            foreach (var device in Devices)
            {
                device.StatusReport();
            }
        }

        protected abstract void InitializeDevices();
    }

}
