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
        public double PowerConsumption { get; protected set; } // watts
        public double PowerUsage {  get; protected set; } // usage for later bill calculation
        public DateTime? TimeSpentActive { get; protected set; } // total time spent consuming electricity
        public DeviceTemplate(string name,double powerConsumption) {
            Name = name;
            PowerConsumption = powerConsumption;
            State = false; // off by default
            PowerUsage = 0;
        }

        public void TurnOn()
        {
            if (!State)
            {
                State = true;
                TimeSpentActive = DateTime.Now;
            }
            else
            {
                Console.WriteLine("Device already on.");
            }
        }
        public void TurnOff() {
            if (State)
            {
                State = false;
                if (TimeSpentActive.HasValue)
                {
                    TimeSpan timeActive = DateTime.Now - TimeSpentActive.Value;
                    PowerUsage += timeActive.TotalHours * PowerUsage; // logic for calculating power usage (in watts per hour)
                }
            }
            else
            {
                Console.WriteLine("Device already off.");
            }
        }

        public abstract void StatusReport(); // za printanje detalja pojedinačnog uređaja, ovo implementiraju izvedene klase 
    }
}
