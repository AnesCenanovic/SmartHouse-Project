﻿using SmartHouseProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class Boiler : DeviceTemplate, ITemperatureDevices
    {
        public int TemperatureSetting { get; private set; } // Celsius

        public bool IsHeating { get; private set; }

        public Boiler(string name, double powerConsumption, int temperature=20, bool isHeating=false) : base(name,powerConsumption) {
            this.TemperatureSetting = temperature;
            this.IsHeating = isHeating;
        }
        public void ToggleHeating()
        {
            if (IsHeating) {IsHeating = false;}
            else {IsHeating = true;}
        }
        public void SetTemperature(int temperature)
        {
            if (State && IsHeating)
            {
                if (temperature < 10)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set under 10°C.");
                }
                else if (temperature > 50)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be set above 50°C.");
                }
                else
                {
                    TemperatureSetting = temperature;
                    Console.WriteLine($"Temperature set to {temperature}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set temperature when boiler is off");
            }
        }

        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, temperature: {TemperatureSetting}°C");
        }

    }
}
