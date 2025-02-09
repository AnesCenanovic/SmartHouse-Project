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
        public LivingRoom(string name) : base(name) {
            InitializeDevices();
        }

        protected override void InitializeDevices()
        {
            AddNewDevice(new Thermostat("Thermostat",10));
            AddNewDevice(new Light("Living Room light",10));
            AddNewDevice(new SmartTV("TV", 200));
            AddNewDevice(new SmartCurtains("Living Room Curtains", 10));
            AddNewLock(new BasicLock("Master lock"));
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
                else if (device is SmartTV smartTV)
                {
                    smartTV.SetBrightness(25);
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
                else if (device is SmartTV smartTV)
                {
                    smartTV.SetBrightness(100);
                }
            }
        }
    }
}
