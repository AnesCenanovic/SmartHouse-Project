using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public class Kitchen : RoomTemplate
    {
        public Kitchen(string name, double size) : base(name, size) { }

        protected override void InitializeDevices()
        {
            //Oven, fridge, etc planned
        }
    }
}
