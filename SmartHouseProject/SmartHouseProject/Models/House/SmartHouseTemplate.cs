using SmartHouseProject.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.House
{
    public abstract class SmartHouseTemplate
    {   

        public string address {  get; protected set; }
        public string name { get; protected set; }
        public int value { get; protected set; }
        public int size { get; protected set; }

        private readonly List<RoomTemplate> rooms = new();


        public SmartHouseTemplate(string address,string name,int value, int size)
        {
            this.address = address;
            this.name = name;
            this.value = value;
            this.size = size;

            Console.WriteLine($"New SmartHouse added!{name}, on address: {address}, worth: {value}$ USD, size: {size}m2.");
        }
        public void AddNewFloor(RoomTemplate room)
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
