using SmartHouseProject.Services_and_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class Oven : DeviceTemplate, IAppliance
    {
        public bool IsRunning { get; protected set; }
        public int TimeLeft { get; protected set; }

        public enum Mode {Even, Above, Under} // even cooking, broiling, roasting, etc...

        public Mode CurrentMode { get; protected set; }

        public Oven(string name, double powerConsumption) : base(name, powerConsumption)
        {
            IsRunning = false;
            TimeLeft = 0;
            CurrentMode = Mode.Even;
        }

        public void ToggleCooking(int number)
        {
            if (State && IsRunning)
            {
                CurrentMode = number switch
                {
                    1 => Mode.Even,
                    2 => Mode.Above,
                    3 => Mode.Under,
                    _ => throw new ArgumentOutOfRangeException("Invalid cook setting"),
                };
            }
            else
            {
                throw new InvalidOperationException("Cannot set cook type when oven is off");
            }
        }

        public void SetCookingTime(int time)
        {
            if(time <= 0)
            {
                throw new ArgumentException("Cooking time must be greater than 0.");
            }

            TimeLeft = time;
            Console.WriteLine($"{Name} started cooking in mode {CurrentMode}. Time left : {TimeLeft}.");
        }
        public void Preheat()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot start preheating when oven is off");
            }
            if (IsRunning)
            {
                throw new InvalidOperationException("Preheating already started.");
            }

            IsRunning = true;
            TimeLeft = 0; // doesn't really measure turning off as it's preheating only 
            Console.WriteLine($"{Name} started {CurrentMode} preheating.");
        }
        public void StartCycle()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot start cooking when oven is off");
            }
            if (!IsRunning)
            {
                throw new InvalidOperationException("Cooking cycle already ended.");
            }

            IsRunning = false;
            Console.WriteLine($"{Name} started {CurrentMode} cook cycle. Time left : {TimeLeft}.");
        }
        public void EndCycle()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot end cooking when oven is off");
            }
            if (!IsRunning)
            {
                throw new InvalidOperationException("Oven cooking already ended.");
            }

            IsRunning = false;
            TimeLeft = 0;
            Console.WriteLine($"{Name} ended {CurrentMode} cook cycle.");
        }
        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, washing: {IsRunning}");
        }
    }
}
