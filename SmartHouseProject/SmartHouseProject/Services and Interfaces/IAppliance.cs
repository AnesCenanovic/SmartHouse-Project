using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Services_and_Interfaces
{
    public interface IAppliance
    {
        bool IsRunning { get; }
        int TimeLeft { get; }

        void StatusReport();
        void StartCycle();
        void EndCycle();
    }
}
