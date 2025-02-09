using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class Fridge : DeviceTemplate
    {
        public bool IsRunning { get; protected set; }

        public enum Mode { Freezing, Normal, Warmer }

        public Mode CurrentMode { get; protected set; }

        public Fridge(string name, double powerConsumption) : base(name, powerConsumption)
        {
            IsRunning = false;
            CurrentMode = Mode.Normal;
        }

        public void ToggleTemperature(int number)
        {
            if (State && IsRunning)
            {
                CurrentMode = number switch
                {
                    1 => Mode.Freezing,
                    2 => Mode.Normal,
                    3 => Mode.Warmer,
                    _ => throw new ArgumentOutOfRangeException("Invalid temperature setting"),
                };
            }
            else
            {
                throw new InvalidOperationException("Cannot set temperature setting when fridge is off");
            }
        }
        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, freezing: {IsRunning}");
        }
    }
}
