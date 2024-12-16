using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagement.Forms.Auth;
using EmployeeManagement.Models;

namespace EmployeeManagement
{
    static class Program
    {
        public static UserInfo CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
