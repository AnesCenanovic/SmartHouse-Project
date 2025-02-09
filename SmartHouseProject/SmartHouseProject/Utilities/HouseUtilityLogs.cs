using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SmartHouseProject.Models.Rooms;
using SmartHouseProject.Models.Devices;
using System.Security.Cryptography.X509Certificates;

namespace SmartHouseProject.Utilities
{
    public static class HouseUtilityLogs // static class for miscellaneous function and tracking 
    {
        private static readonly List<Log> Logs = new();

        // Writes a log to archive.

        public static void AddLog(string content, DateTime date, RoomTemplate? room = null, DeviceTemplate? device = null)
        {
            Log Log = new(content,room,device,date);
            Logs.Add(Log);
            Console.WriteLine(Log.ToString());
            WriteLogFile(Log);
        }

        // Prints all logs.

        public static void ShowLogs()
        {
            if(Logs.Count == 0) Console.WriteLine("No logs.");
            else
            {
                foreach (var item in Logs)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        // Returns all logs for a specific room.

        public static List<Log> GetLogsForRoom(RoomTemplate room)
        {
            return Logs.Where(Log => Log.TiedToRoom == room).ToList();
        }

        // Returns all logs for a specific device instead.

        public static List<Log> GetLogsForDevice(DeviceTemplate device)
        {
            return Logs.Where(Log => Log.TiedToDevice == device).ToList();
        }

        public static void WriteLogFile(Log log)
        {
            string toWrite = log.ToString();

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // placeholder directory for now

            string filePath = Path.Combine(folderPath, "Logs.txt");

            try
            {
                using StreamWriter outputFile = new StreamWriter(filePath,append: true);
                outputFile.WriteLine(toWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error writing to log file, {e.Message}");
            }
        }
    }
}
