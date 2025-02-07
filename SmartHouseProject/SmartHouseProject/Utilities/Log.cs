using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Utilities
{
    public static class Log
    {
        public static void LogData(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
