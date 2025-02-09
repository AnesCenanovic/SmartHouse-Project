using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseProject.Models.Devices
{
    public class WashingMachine : DeviceTemplate
    {
        public bool IsRunning { get; protected set; }
        public int TimeLeft { get; protected set; }

        public enum Mode { Slow, Fast, Medium, Turbo }

        public Mode CurrentMode { get; protected set; }

        public WashingMachine(string name) : base(name)
        {
            IsRunning = false;
            TimeLeft = 0;
            CurrentMode = Mode.Slow;
        }

        public void ToggleWash(int number)
        {
            if (State && IsRunning)
            {
                switch (number)
                {
                    case 1:
                        CurrentMode = Mode.Slow;
                        break;
                    case 2:
                        CurrentMode = Mode.Medium;
                        break;
                    case 3:
                        CurrentMode = Mode.Fast;
                        break;
                    case 4:
                        CurrentMode = Mode.Turbo;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid wash setting");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot set wash type when washing machine is off");
            }
        }
        public void StartCycle()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot start cycle when washing machine is off");
            }
            if (IsRunning)
            {
                throw new InvalidOperationException("Washing machine cycle already started.");
            }

            IsRunning = true;
            TimeLeft = GetCycleTime(CurrentMode);
            Console.WriteLine($"{Name} started {CurrentMode} wash cycle. Time left: {TimeLeft} minutes.");
        }
        public void EndCycle()
        {
            if (!State)
            {
                throw new InvalidOperationException("Cannot end cycle when washing machine is off");
            }
            if (!IsRunning)
            {
                throw new InvalidOperationException("Washing machine cycle already ended.");
            }

            IsRunning = false;
            TimeLeft = 0;
            Console.WriteLine($"{Name} ended {CurrentMode} wash cycle.");
        }
        private static int GetCycleTime(Mode mode)
        {
            return mode switch
            {
                Mode.Slow => 45,
                Mode.Medium => 30,
                Mode.Fast => 15,
                Mode.Turbo => 5,
                _ => 45
            };
        }
        public override void StatusReport()
        {
            Console.WriteLine($"Report : device: {Name}, state: {(State ? "ON" : "OFF")}, washing: {IsRunning}");
        }
    }
}
