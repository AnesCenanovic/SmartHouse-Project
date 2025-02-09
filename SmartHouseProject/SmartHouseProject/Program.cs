// See https://aka.ms/new-console-template for more information
using SmartHouseProject.Models.Devices;
using SmartHouseProject.Models.House;
using SmartHouseProject.Models.Rooms;
using SmartHouseProject.Security;
using SmartHouseProject.Services;
using SmartHouseProject.Utilities;
using System;

class Program
{
    static void Main()
    {
       SmartHouse MyHouse = new("Electric Avenue 42", "My humble abode", 42000, 42); // initializing a new house

        MyHouse.AddNewRoom(new LivingRoom("Living Room"));
        MyHouse.AddNewRoom(new Kitchen("Kitchen"));
        MyHouse.AddNewRoom(new Bedroom("Bedroom"));
        MyHouse.AddNewRoom(new Bathroom("Bathroom")); // adding various rooms, and also initializes devices within them

        //you can make new ones and individually toggle and change their moods or devices

        MyHouse.PrintInfo(); //shows all devices
        MyHouse.TurnOnAllDevices(); // turns on all devices

        foreach (var room in MyHouse.GetRooms())
        {
            room.NightMode(); //changes moods for all rooms
        }

        foreach (var room in MyHouse.GetRooms())
        {
            room.DayMode(); //changes moods for all rooms
        }

        foreach (var room in MyHouse.GetRooms())
        {   
            foreach(DeviceTemplate device in room.Devices)
            {
                device.StatusReport(); // show current status for all devices
            }
        }


        //adding new devices and changing their behaviour
        Oven oven = new("Oven2",400);
        oven.TurnOn();
        oven.ToggleCooking(2);
        oven.SetCookingTime(60);
        oven.StartCycle();
        MyHouse.GetKitchen().AddNewDevice(oven);

        oven.EndCycle();

        WashingMachine waschmaschine = new("Washing Machine", 400);
        waschmaschine.TurnOn();
        waschmaschine.ToggleWash(2);
        MyHouse.GetBathroom().AddNewDevice(waschmaschine);

        waschmaschine.EndCycle();


        //locking and unlocking house locks
        MyHouse.LockHouseLocks();
        MyHouse.UnlockHouseLocks();

        //locking and unlocking room locks
        MyHouse.GetBedroom().GetAllLocks().FirstOrDefault().Lock();
        MyHouse.GetBedroom().GetAllLocks().FirstOrDefault().Unlock();



        //logging actions
        DateTime rightNow = DateTime.Now;
        HouseUtilityLogs.AddLog("Living Room light turned on", rightNow);
        HouseUtilityLogs.AddLog("Oven started cooking", rightNow);
        HouseUtilityLogs.ShowLogs();

        List<DeviceTemplate> allHouseDevices = new List<DeviceTemplate>();
        foreach (var room in MyHouse.GetRooms())
        {
            allHouseDevices.AddRange(room.GetAllDevices());
        }

        Console.WriteLine($"Total Power Usage: {PowerUtility.GetTotalPowerUsage(allHouseDevices)} W");
        Console.WriteLine($"Estimated Electricity Bill: ${PowerUtility.CalculateElectricityBill(allHouseDevices):F2}");

        var sortedDevicesByUsage = PowerUtility.GetDevicesByPowerUsageDescending(allHouseDevices);
        Console.WriteLine("Devices sorted by power usage (descending):");
        foreach (var device in sortedDevicesByUsage)
        {
            Console.WriteLine($"- {device.Name}: {device.GetPowerUsage()} W");
        }
    }
        
}
