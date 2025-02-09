using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class SmartCurtains : DeviceTemplate
    {
        public bool IsDown { get; private set; } // indicates if they're set down or pulled up

        public SmartCurtains(string name, double powerConsumption) : base(name, powerConsumption)
        {
            IsDown = true;
        }

        public void OpenCurtains()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot open curtains if they're off.");
            }
            if (IsDown)
            {
                IsDown = false;
                Console.WriteLine($"{Name} have been pulled up.");
                
            }
            Console.WriteLine($"{Name} is already down");
        }
        public void CloseCurtains()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot open curtains if they're off.");
            }
            if (IsDown)
            {
                Console.WriteLine($"{Name} is already down");
                return;
            }
            IsDown = true;
            Console.WriteLine($"{Name} have been pulled down.");
        }

        public void Toggle()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot toggle curtains when they're off.");
            }

            if (IsDown)
            {
                OpenCurtains();
            }
            else
            {
                CloseCurtains();
            }
        }
        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, isDown: {(IsDown ? "Down" : "Up")}");
        }
    }
}
