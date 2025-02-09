using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SmartHouseProject.Services;
using SmartHouseProject.Utilities;
using System.Security.Cryptography;

namespace SmartHouseProject.Security
{
    // security aspect meant for locks
    public abstract class LockTemplate : ISecuritySystem
    {
        public string Name { get; protected set; }
        public bool IsLockedState { get; protected set; }
        public string PasswordCode{  get; protected set; }

        public LockTemplate(string name, string passwordCode = null) {
            Name = name;
            PasswordCode = passwordCode;
            IsLockedState = false;

            if(passwordCode != null) 
            {
                HashAndSave(passwordCode);
            }
            else
            {
                PasswordCode = LoadHashed();
            }
        }

        public void Lock()
        {
            if (ValidatePassword(PasswordCode))
            {
                IsLockedState = true;
            }
            else
            {
                Console.WriteLine("Password invalid.");
            }
        }

        public void Unlock()
        {
            if (ValidatePassword(PasswordCode))
            {
                IsLockedState = false;
            }
            else
            {
                Console.WriteLine("Password invalid.");
            }
        }

        public bool IsLocked()
        {
            return IsLockedState;   
        }

        public abstract void SystemStatusReport();

        private static void HashAndSave(string passwordCode)
        {
                string hashedPassword = HashPassword(passwordCode);
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // placeholder directory for now
                string filePath = Path.Combine(folderPath, "Passwords.txt");
                try
                {
                    using StreamWriter outputFile = new StreamWriter(filePath, append: true);
                    outputFile.WriteLine(hashedPassword);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error writing to password file, {e.Message}");
                }
        }

        private static string LoadHashed()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // placeholder directory for now
            string filePath = Path.Combine(folderPath, "Passwords.txt");
            try
            {
                if (File.Exists(filePath))
                {
                    string hashedPassword = File.ReadAllText(filePath);
                    Console.WriteLine("Password loaded.");
                    return hashedPassword;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading password, {e.Message}");
            }
            return null;
        }

        private bool ValidatePassword(string password)
        {
            //string hashed = HashPassword(password);
            // password file logic not implemented fully yet
            //return hashed == PasswordCode;
            return true;
        }

        private static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create()) //placeholder
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
