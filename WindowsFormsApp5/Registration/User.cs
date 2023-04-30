using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp5.Registration
{
    public class User
    {
        private byte[] Password;
        public string Name { get;} 
        public string SurName { get;} 

        public User(String name, String surname)
        {
            Name = name;
            SurName = surname;
        }

        public bool HasPassword()
        {
            return Password != null;
        }

        public void SetPassword(string pass)
        {
            var bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            Password = bytes;
        }

        public bool CheckPasssword(string pass)
        {
            var bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            if (bytes.SequenceEqual(Password)) return true;
            return false;
        }
    }
}