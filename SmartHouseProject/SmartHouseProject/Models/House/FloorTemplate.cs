using SmartHouseProject.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.House
{
    public abstract class FloorTemplate
    {
        public int floorNumber { get; protected set; }
        protected List<RoomTemplate> rooms = new List<RoomTemplate>();

        public FloorTemplate(int floorNumber)
        {
            this.floorNumber = floorNumber;
        }

        public void AddRoom(RoomTemplate room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(RoomTemplate room)
        {
            rooms.Remove(room);
        }

        public IEnumerable<RoomTemplate> getRooms()
        {
            return rooms;
        }

        public abstract void printFloorInfo();

    }
}
