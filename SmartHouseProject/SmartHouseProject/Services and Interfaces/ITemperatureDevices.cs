using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Services
{
    public interface ITemperatureDevices
    {
        int TemperatureSetting {  get; }
        void SetTemperature(int temperature);
    }
}
