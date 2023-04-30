using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Registration;

namespace WindowsFormsApp5
{
    static class Program
    {
        public static List<User> Users { get; set; } = new List<User>();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var prof = new Professor("Dom", "Jan");
                prof.SetPassword("123");
                prof.AddSubject("IT");
                prof.AddSubject("DI");
            Users.Add(prof);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
