using SmartHouseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public abstract class DeviceTemplate : ISmartDeviceTemplate
    {
        public string Name { get; protected set; } 
        public bool State { get; protected set; } // is on or off

        public DeviceTemplate(string name) {
            Name = name;
            State = false; // off by default
        }

        public void TurnOn()
        {
            State = true;
        }
        public void TurnOff() { 
            State = false; 
        }

        public abstract void StatusReport(); // za printanje detalja pojedinačnog uređaja
    }
}
