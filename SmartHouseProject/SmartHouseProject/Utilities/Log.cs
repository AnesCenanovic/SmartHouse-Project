using System;
using SmartHouseProject.Models.Rooms;
using SmartHouseProject.Models.Devices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Utilities
{
    public class Log
    {
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public RoomTemplate? TiedToRoom { get; set; }  // can but doesn't have to be tied to a room
        public DeviceTemplate? TiedToDevice { get; set; } // can but doesn't have to be tied to a device
        
        public Log(string content,DateTime date, RoomTemplate? room=null, DeviceTemplate? device=null)
        {
            Content= content;
            DateCreated = date;
            TiedToRoom = room;
            TiedToDevice = device;
        }
        public override string ToString()
        {
            string log = $"({DateCreated}) {Content}";

            if(TiedToRoom != null) {
                log += $" Tied To Room: {TiedToRoom.Name}";
            }
            if (TiedToDevice != null)
            {
                log += $" Tied To Device: {TiedToDevice.Name}";
            }
            return log;
        }
    }
}
