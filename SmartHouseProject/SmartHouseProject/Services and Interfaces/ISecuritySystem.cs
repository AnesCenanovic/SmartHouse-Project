using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Services
{
    public interface ISecuritySystem
    {

        void Lock();
        void Unlock();
        bool IsLocked();
        void SystemStatusReport();
    }
}
