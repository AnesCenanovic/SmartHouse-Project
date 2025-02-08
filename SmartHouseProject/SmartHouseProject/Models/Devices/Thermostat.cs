using SmartHouseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class Thermostat : SmartDeviceTemplate, ITemperatureDevices {

        public int TemperatureSetting { get; private set; } // Celsius

        public Thermostat(string name,int temperature=20) : base(name) {
            this.TemperatureSetting = temperature;
        }
            
        public void SetTemperature(int temperature) {
            if (State) { 
                if (temperature < 10)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set under 10°C.");
                }
                else if (temperature > 30) {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set above 30°C.");
                }
                else
                {
                    TemperatureSetting = temperature;
                    Console.WriteLine($"Temperature set to {temperature}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set temperature when thermostat is off");
            }
        }

        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, temperature: {TemperatureSetting}°C");
        }
    }
}
