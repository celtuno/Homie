using Arbeidskrav_1___Gruppe_4.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Arbeidskrav_1___Gruppe_4.Classes;
//using System.Timers;

namespace Arbeidskrav_1___Gruppe_4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Initiate Timer
        static System.Threading.Timer testingTimer;
        static GlobalTimer timerClass = new GlobalTimer();
        static FileHandling FH = new FileHandling();
        
        
        [STAThread]
        
        
        static void Main()
        {

            //Activate timer

            //5000 = 5 seconds
            


            //initiate sql class
            SqlCon sc = new SqlCon();
            FileHandling FH = new FileHandling();
            FH.FileReader();
            alarmLimits al = sc.GetAlarmLimits();
            AlarmTesting at = new AlarmTesting(al.tempLow, al.tempHigh, al.battPercent, al.PIR, FH.tempErrorParameter, FH.delayAfterAlarmTrigger, FH.serialPort);

            
            //read timer intervall from file
            
            testingTimer = new System.Threading.Timer(new System.Threading.TimerCallback(TickTimer), null, 1000,5000);

            int timerTime = Convert.ToInt16(FH.readInterval);
            testingTimer.Change(1000, timerTime);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MenyAfterLogin());
            //Application.Run(new CurrentValues());
            Application.Run(new Login());


            //Read all changeable settings from file

            //FileHandling FH = new FileHandling();
            //FH.FileStreamer();
            

        }
        //Timer fore reading serial in backgriound
        //Also writes to sql
        static void TickTimer(object state)
            {
            //check for errors'
            if (!timerClass.errorCheck)
            {

                //check for recieved data

                timerClass.CheckData();
                //write data to sql
                timerClass.WriteSql();
                //Send temperature and motion to Glabaldata class
                GlobalData dta = new GlobalData(timerClass.getTemp(), timerClass.newMotion, timerClass.newTempC);
            }


        }


    }
}
