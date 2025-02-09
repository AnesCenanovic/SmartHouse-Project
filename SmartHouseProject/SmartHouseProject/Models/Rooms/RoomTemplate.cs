using SmartHouseProject.Models.Devices;
using SmartHouseProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Rooms
{
    public abstract class RoomTemplate
    {
        public string Name { get; set; }
        public double Size { get; private set; }
        public List<DeviceTemplate> Devices { get; private set; } = new(); // all devices tied to the room
        public List<LockTemplate> Locks { get; private set; } = new(); // all locks tied to the room


        public RoomTemplate(string name,double size)
        {
            Name = name;
            Size = size;
        }

        public void AddNewDevice(DeviceTemplate device)
        {
            Devices.Add(device);
        }

        public void AddNewLock(LockTemplate lock_)
        {
            Locks.Add(lock_);
        }

        public void RemoveDevice(DeviceTemplate device)
        {
            if (Devices.Contains(device))
            {
                Devices.Remove(device);
                Console.WriteLine($"Removed {device.Name} from: {Name}.");
            }
            else
            {
                Console.WriteLine($"{device.Name} does not exist in: {Name}.");
            }
        }

        public void RemoveLock(LockTemplate lock_)
        {
            if (Locks.Contains(lock_))
            {
                Locks.Remove(lock_);
                Console.WriteLine($"Removed {lock_.Name} from: {Name}.");
            }
            else
            {
                Console.WriteLine($"{lock_.Name} does not exist in: {Name}.");
            }
        }

        public void PrintDevices()
        {
            Console.WriteLine($"Room: {Name}");
            foreach (var device in Devices)
            {
                device.StatusReport();
            }
        }

        public void PrintSecurityStatus()
        {
            Console.WriteLine($"Room: {Name}");
            foreach (var lock_ in Locks)
            {
                lock_.SystemStatusReport();
            }
        }

        public void LockSecurityDevices()
        {
            foreach (var lock_ in Locks)
            {
                lock_.Lock();
            }
        }

        public void UnlockSecurityDevices()
        {
            foreach (var lock_ in Locks)
            {
                lock_.Unlock();
            }
        }

        protected abstract void InitializeDevices();
    }

}
