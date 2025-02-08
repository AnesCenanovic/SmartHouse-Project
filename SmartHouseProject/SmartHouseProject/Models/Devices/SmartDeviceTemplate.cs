using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public abstract class SmartDeviceTemplate
    {
        public string Name { get; protected set; } 
        public bool State { get; protected set; } // is on or off

        public SmartDeviceTemplate(string name) {
            Name = name;
            State = false; // off by default
        }

        public void turnStateOn()
        {
            State = true;
        }
        public void turnStateOff() { 
            State = false; 
        }

        public abstract void statusReport(); // za printanje detalja pojedinačnog uređaja
    }
}
