using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homie.Forms;

namespace Homie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            //Application.Run(new frmActuators());
            //Application.Run(new frmSensors());
            //Application.Run(new frmAddSensor());
            Application.Run(new frmLoginScreen());
            //Application.Run(new frmAddDevices());
            //Application.Run(new frmGraphing());

        }
    }
}
