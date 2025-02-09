using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHouseProject.Models.Devices.WashingMachine;

namespace SmartHouseProject.Models.Devices
{
    public class Light : DeviceTemplate
    {
        public int Brightness { get; private set; }

        public enum Color { Red, Blue, Green, Yellow, White}

        public Color Hue { get; private set; }

        public Light(string name, double powerConsumption,int brightness=50)  : base(name,powerConsumption)
        {
            Brightness = brightness;
            Hue = Color.White;
        } 

        public void SetBrightness(int brightness)
        {
            if (State)
            {
                if (brightness < 1)
                {
                    throw new ArgumentOutOfRangeException("Brightness cannot be set under 1.");
                }
                else if (brightness > 100)
                {
                    throw new ArgumentOutOfRangeException("Brightness cannot be set above 100.");
                }
                else
                {
                    Brightness = brightness;
                    Console.WriteLine($"Brightness set to {brightness}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set brightness when light is off");
            }
        }

        public void SetHue(int hue)
        {
            if (State)
            {
                switch (hue)
                {
                    case 1:
                        Hue = Color.Red;
                        break;
                    case 2:
                        Hue = Color.Blue;
                        break;
                    case 3:
                        Hue = Color.Green;
                        break;
                    case 4:
                        Hue = Color.Yellow;
                        break;
                    case 5:
                        Hue = Color.White;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid hue setting");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set hue type when light is off");
            }
        }

        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, brightness: {Brightness}");
        }
    }
}
