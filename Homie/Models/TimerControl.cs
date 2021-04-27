using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;

namespace Homie.Models
{
    class TimerControl
    {
        List<string> channel = new List<string>();
        List<int> sensorId = new List<int>();
        Sensor sensor = new Sensor();
        
        static public System.Timers.Timer daqTimer;

        static string timerStatusText;
        public string TimerStatusText
        {
            get { return timerStatusText; }
            
        }
        static bool timerstatus;
        public bool Timerstatus
        {
            get { return timerstatus; }
            //set { /*timerstatus = value;*/ }

        }
        LoginUser loginUser = new LoginUser();
        public TimerControl()
        {

        }
        
        //Method for controlling the timer (turn on /off) with initial value
        public void ControlTimer(bool status)
        {

            if (status) //if input to method equals true
            {

                if (!timerstatus)//if timer is not on already
                {
                    //"Create new" timer
                    daqTimer = new System.Timers.Timer();
                    daqTimer.Elapsed += new System.Timers.ElapsedEventHandler(daqTimer_Elapsed);
                    daqTimer.Enabled = status;
                    daqTimer.Interval = 15000;
                }
                //set the timer class timerstatus to true
                timerstatus = true;
            }

            else if (!status)  //if input to method equals false
            {
                // myTimer.Change(Timeout.Infinite, Timeout.Infinite);
                try
                {
                    if (timerstatus)//if timer is running already
                    {
                        //"Remove" timer
                        daqTimer.Dispose();
                        timerstatus = false;
                    }
                }
                catch (Exception timerError) 
                {
                    MessageBox.Show(timerError.Message, "Timererror");
                }
            }
        }

        //Get array  of channels from sensorlist.
        private void GetChannelData()
        {
            //sensor = new Sensor(true);
            SqlCommunication sqlCom = new SqlCommunication();
            
            //Get all sesnors from sql database
            sqlCom.GetSensors("GetSensors", "All");
             //clear sensor data from timerclassdata
            channel.Clear();
            sensorId.Clear();
            //Loop through all IO-channels in sensor class
            for (int i =(sensor.IoChannel.Count-1); i >=0 ; i--)
            {
                //channel.Add(sensor.DaqId[i].Trim() + "/" + sensor.IoChannel[i].Trim());
                
                //add senor id's from sensor class to timerclass sesnorid
                sensorId.Add (sensor.SensorId[i]);


            }
            //write sesnordata to sql
            WriteSqlChannelData();
            
        }

        private void WriteSqlChannelData()
        {   sensor = new Sensor();
            SqlCommunication sqlCom = new SqlCommunication();
            DaqCommunication daqCom = new DaqCommunication();
            
            //Loop through all analog IO-channels in sensor class
            for (int i = 0 ;i<= sensor.SensorId.Count-1; i++)
               
                {
                
                //Read the selected(loop) channel IO  from DAQ device
                daqCom.ReadAnalogIn( sensor.IoChannel[i],"termo");
                //Latest datavalue
                string tmpStringValue = daqCom.analogdataRead.ToString().TrimEnd('*');
                //convert data to double
                double tmpValue  = daqCom.analogdataRead;
                //double  tmpvalue = (daqCom.AnalogValueArray[i];
                 sqlCom.WriteSensorData(tmpValue,sensor.SensorId[i]);//daqCom.AnalogValueArray[i], sensorId[i]);
                            
            }                      

        }


        private void daqTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Stop timer to do tasks
            daqTimer.Stop();
            
            //DEBUG
            //MessageBox.Show("Timer 2");
            
            //Read sensordata, and write to sql
            GetChannelData();
            //if timerstatsus still is true, start timer again
            if (timerstatus) daqTimer.Start();
            // throw new NotImplementedException();
        }


        //Set timercolor and text according to timerstaus
        public  Color CheckTimer(out bool status)
        {
            //Check timer status
            bool timerCheck;
            TimerControl timerControl = new TimerControl();
            timerCheck = timerControl.Timerstatus;

          
            Color myColor;
            status = timerCheck;
            if (timerCheck) 
            {
                myColor = Color.DarkGreen;
                timerStatusText = "Datalogger: On";
            }
            else if (!timerCheck) 
            {
                myColor = Color.DarkRed;
                timerStatusText = "Datalogger: Off";
            }
            else { myColor = Color.Gray; }
            return myColor;
   
        }
    }
}
