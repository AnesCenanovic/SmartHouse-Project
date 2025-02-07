using SmartHouseProject.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.House
{
    internal class SmartHouse
    {
        private List<RoomTemplate> rooms = new List<RoomTemplate>;

        public void AddNewRoom(RoomTemplate room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(RoomTemplate room) {
            rooms.Remove(room);
        }
        public List<RoomTemplate> GetRooms() { return rooms; }

        public void printInfo()
        {
            Console.WriteLine("Welcome to Your SmartHouse. Here's an overview:");
            foreach (RoomTemplate room in rooms) {
                room.printDevices();
            }
        }
    }
}
