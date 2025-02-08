using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Services
{
    public interface ILights
    {
        int Brightness { get; }
        
        void SetBrightness(int brightness);
    }
}
