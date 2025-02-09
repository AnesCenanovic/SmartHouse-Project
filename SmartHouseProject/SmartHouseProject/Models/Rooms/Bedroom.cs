using SmartHouseProject.Models.Devices;
using SmartHouseProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class Bedroom : RoomTemplate
    {
        public Bedroom(string name, double size) : base(name, size) {
        InitializeDevices();
        }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Light("Bedroom light", 10));
            AddNewDevice(new SmartCurtains("Living Room Curtains", 10));
            AddNewLock(new BasicLock("Bedroom lock"));
        }

        public override void NightMode()
        {
            Console.WriteLine($"Activating Night Mode for {Name}");
            foreach (var device in Devices)
            {
                if (device is Light light)
                {
                    light.SetBrightness(25);
                    light.SetHue(4);
                }
                else if (device is SmartCurtains smartCurtains)
                {
                    smartCurtains.CloseCurtains();
                }
            }
        }

        public override void DayMode()
        {
            Console.WriteLine($"Activating Day Mode for {Name}");
            foreach (var device in Devices)
            {
                if (device is Light light)
                {
                    light.SetBrightness(100);
                    light.SetHue(2);
                }
                else if (device is SmartCurtains smartCurtains)
                {
                    smartCurtains.OpenCurtains();
                }
            }
        }
    }
}
