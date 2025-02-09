using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Services
{
    public interface ISmartDeviceTemplate // Common for all devices
    {
        string Name { get; }
        bool State { get; }

        void TurnOn();
        void TurnOff();
        void StatusReport();
    }
}
