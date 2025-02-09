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

        public string Address {  get; protected set; }
        public string Name { get; protected set; }
        public int Value { get; protected set; }
        public int Size { get; protected set; }

        private readonly List<RoomTemplate> rooms = new();


        public SmartHouseTemplate(string address,string name,int value, int size)
        {
            this.Address = address;
            this.Name = name;
            this.Value = value;
            this.Size = size;

            Console.WriteLine($"New SmartHouse added!{name}, on address: {address}, worth: {value}$ USD, size: {size}m2.");
        }
        public void AddNewRoom(RoomTemplate room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(RoomTemplate room) {
            rooms.Remove(room);
        }
        public List<RoomTemplate> GetRooms() { return rooms; }

        public void PrintInfo()
        {
            Console.WriteLine("Welcome to Your SmartHouse. Here's an overview:");
            foreach (RoomTemplate room in rooms) {
                room.PrintDevices();
            }
        }

        public void LockHouseLocks()
        {
            foreach (RoomTemplate room in rooms)
            {
                room.LockSecurityDevices();
            }
        }

        public void UnlockHouseLocks()
        {
            foreach (RoomTemplate room in rooms)
            {
                room.UnlockSecurityDevices();
            }
        }
    }
}
