using SmartHouseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class Fridge : DeviceTemplate, ITemperatureDevices
    {
        public bool IsRunning { get; protected set; }

        public int TemperatureSetting { get; private set; } // Celsius

        public Fridge(string name, double powerConsumption) : base(name, powerConsumption)
        {
            IsRunning = true;
            TemperatureSetting = 3; // default
        }
        public void SetTemperature(int temperature)
        {
            if (State)
            {
                if (temperature < -10)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set under -10°C.");
                }
                else if (temperature > 10)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set above 10°C.");
                }
                else
                {
                    TemperatureSetting = temperature;
                    Console.WriteLine($"Temperature set to {temperature}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set temperature when fridge is off");
            }
        }
        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, freezing: {IsRunning}");
        }
    }
}
