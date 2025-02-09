using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class SmartTV : DeviceTemplate
    {
        public int Volume { get; protected set; }
        public int ChannelNumber { get; protected set; }
        public int ScreenBrightness {  get; protected set; }

        public SmartTV(string name, double powerConsumption, int volume=50, int channelNumber=1) : base(name, powerConsumption)
        {
            Volume = volume;
            ChannelNumber = channelNumber;
        }

        public void SetVolume(int amount)
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot adjust volume. TV is off.");
            }
            if(Volume < 0)
            {
                Volume = 0;
                return;
            }
            Volume = Math.Min(amount, 100); // cap at 100% volume
            Console.WriteLine($"{Name} volume set to {Volume}.");
        }

        public void SetChannel(int channel)
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot set channel. TV is off.");
            }
            if (channel < 0)
            {
                ChannelNumber = 1;
                return;
            }
            ChannelNumber = Math.Min(channel, 200); // 200 channels at most
            Console.WriteLine($"{Name} channel set to {ChannelNumber}.");
        }

        public void SetScreenBrightness(int percentage)
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot set brightness. TV is off.");
            }
            if (percentage < 0)
            {
                ScreenBrightness = 1;
                return;
            }
            ScreenBrightness = Math.Min(percentage, 100); 
            Console.WriteLine($"{Name} brightness set to {ScreenBrightness}.");
        }

        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, showing: {ChannelNumber}, at volume: {Volume}, brightness: {ScreenBrightness}");
        }
    }
}
