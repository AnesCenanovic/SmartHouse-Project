using SmartHouseProject.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Utilities
{
    public static class PowerUtility
    {
        public static double ElectricityPrice { get; set; } = 0.17; // current average price = 0.17$ per kWh in the USA

        // the following are some basic utility functions for statistics that we can use to calculate bills n stuff
        public static double GetTotalPowerUsage(List<DeviceTemplate> devices)
        {
            double result = 0;
            foreach (DeviceTemplate device in devices)
            {
                result += device.GetPowerUsage();
            }
            return result;
        }

        public static List<DeviceTemplate> GetDevicesByPowerUsageDescending(List<DeviceTemplate> devices)
        {
            return devices.OrderByDescending(device => device.GetPowerUsage()).ToList();
        }

        public static List<DeviceTemplate> GetDevicesByPowerUsageAscending(List<DeviceTemplate> devices)
        {
            return devices.OrderBy(device => device.GetPowerUsage()).ToList();
        }

        public static double CalculateElectricityBill(List<DeviceTemplate> devices)
        {
            double result = 0;
            foreach (DeviceTemplate device in devices)
            {
                result += (device.GetPowerUsage() / 1000) * ElectricityPrice;
            }
            return result;
        }

        public static double CalculateRuntime(List<DeviceTemplate> devices)
        {
            double result = 0;
            foreach (DeviceTemplate device in devices)
            {
                if (device.State && device.GetPowerUsage() > 0)
                {
                    TimeSpan total;
                    if (device.GetTimeSpentActive() != null)
                    {
                        total = DateTime.Now - device.GetTimeSpentActive().Value;
                    }
                    else
                    {
                        total = TimeSpan.Zero;
                    }
                    result += total.TotalHours;
                }
            }
            return result;
        }

    }
}
