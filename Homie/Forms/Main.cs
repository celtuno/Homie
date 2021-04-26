using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;


using System.Diagnostics;
using System.Runtime.InteropServices;
using Homie.Models;




namespace Homie
{
    public partial class frmMain : Form
    {
        //initialize classes
        LoginUser login = new LoginUser();
        Actuator actuator;
        Sensor sensor;
        DaqCommunication daqCom;
        
        List<string> myRoom = new List<string>();
      


        public frmMain()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            //only works if loginform was started
            ToolStripItem[] testItem = new ToolStripItem[contextMenuTop.Items.Count];
            
           
            for(int i = 0; i<= contextMenuTop.Items.Count;i++) 
            {
                contextMenuTop.Items.CopyTo(testItem,i);

                menuStripTop.Items.AddRange(testItem);
             }
            CheckLogin();


            DaqCommunication daqCom = new DaqCommunication();
            try
            {
                daqCom.ReadDaqDevices();
                cmbDaqList.DataSource = daqCom.AvailableDaq;
               // cmbDaqAddress.DataSource = daqCom.AllChannels;
            }
            catch(DaqException daqError)
            {
                this.Close();
                throw new DaqException();
                
            }
            GetMyRooms();
            cmbRoom.DataSource = myRoom;
            //Disable initializehomie if database or daq problems
            InitializeHomie();
            
            TimerControl timerControl = new TimerControl() ;
            radioTimer.ForeColor =  timerControl.CheckTimer(out bool timerStatus);
            radioTimer.Checked = timerStatus;
            chkTimer.Checked = timerStatus;
            UpTime();           

        }

        private void CheckLogin()
        {
            //Set labeltext to welcommessage with Full name if login is valid
          
                if (login.UserValidated)
                {
                    lblWelcome.Text = "Welcome to Homie, " + login.UserFullName;

                }
        }

        private void InitializeHomie()
        {
            //setup daq and sqlclasses 
            daqCom = new DaqCommunication();
            SqlCommunication sqlCom = new SqlCommunication();
            //setup sensor and actuator classes
            actuator = new Actuator();
            sensor = new Sensor();

            //Read devices, from daq and sql 
            daqCom.ReadDaqDevices();
            sqlCom.GetDaqDigitalIo(login.UserHouse);
            sqlCom.GetDaqAnalogIo(login.UserHouse);
            actuator.GetActuatorTypes();
            actuator.GetActuators(login.UserHouse, "All");
            sensor.GetSensorTypes();
            //ListActuators();

            //ListSensors();

            //DEBUG
            string hardCodedDevice = cmbDaqList.Text;

            
             //actuator = new Actuator();
            actuator.ListActuators(flowActuator, "All", login.UserHouse, cmbRoom);
            //sensor = new Sensor();
            sensor.ListSensors(flowSensor,"All", login.UserHouse,cmbRoom);
           
            
            //Try to set values from sql into  actuator on daq  
            try
            {
                for (int i = actuator.ActuatorId.Count - 1; i >= 0; i--)
                {
                    string channel = daqCom.SqlDigitalIoName[i + 4];
                    //DEBUG
                    // int tt = actuator.IoId.Count();
                    daqCom.WriteDigitalOut(actuator.ActuatorValue[i], channel.Trim(), actuator.ActuatorId[i]);
                    
                }
            }
            //No daq found in sql, install check
            catch (ArgumentOutOfRangeException errorRange)
            {
               DialogResult myresult   =  MessageBox.Show("Starup error, installing?", "Boot upp error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myresult == DialogResult.No) this.Close();
                tmrCheckStuff.Enabled = false;
            }
            //Daq device read error
            catch(MyDaqError error)
            {
                MessageBox.Show(error.Message);
                DialogResult myresult   =  MessageBox.Show("Starup error, installing?", "Boot upp error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myresult == DialogResult.No) this.Close();
                tmrCheckStuff.Enabled = false;
            }

        }

        

        private void btnTimer_Click(object sender, EventArgs e)
        {
            //Start / stop timer
            TimerControl timerControl = new TimerControl();
            timerControl.ControlTimer(chkTimer.Checked);
        }

        private void tmrCheckStuff_Tick(object sender, EventArgs e)
        {
            
            //Background timer 
            TimerControl timerControl = new TimerControl();
            radioTimer.ForeColor = timerControl.CheckTimer(out bool timerStatus);
            radioTimer.Checked = timerStatus;

            //update topmenu item 
            if (timerStatus) toolStripMenuStatus.Text = "Datalogger is  ON";
            else toolStripMenuStatus.Text = "Datalogger  is  OFF";
            //Update uptime  
            UpTime();
            toolTimer.Text = "Datalogger active: " + timerStatus;
            sensor = new Sensor();
            sensor.GetSensors(login.UserHouse);
            sensor.ListSensors(flowSensor, "All", login.UserHouse, cmbRoom);

            actuator = new Actuator();
            actuator.GetActuators(login.UserHouse, "All");//cmbRoom.Text);
            actuator.ListActuators(flowActuator,"All", login.UserHouse,cmbRoom);
            //Some code here for reading sql/update actuators
            try
            {
                for (int i = 0; i <= actuator.ActuatorId.Count - 1; i++)
                {
                    daqCom = new DaqCommunication();
                    daqCom.WriteDigitalOut(actuator.ActuatorValue[i], actuator.IoChannel[i], actuator.ActuatorId[i]);
                    string tt = actuator.IoChannel[i];
                    //actuator.CheckArray(i, actuator.ActuatorId[i]);
                }
            }
            //Get daq write errors
            catch(MyDaqError error)
            {
               
                tmrCheckStuff.Enabled = false;
                MessageBox.Show("Daq write error!", error.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tmrCheckStuff.Enabled = true;
            }

        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.frmLoginScreen frmLogin = new Forms.frmLoginScreen();
            this.Hide();
            frmLogin.Show();
        }

        private void btnSensorForm_Click(object sender, EventArgs e)
        {
            Forms.frmSensors frmSensors = new Forms.frmSensors();
            frmSensors.ShowDialog();
        }
          
        //Get all sensor and actuator data from sql relevant to selected rooms (and house)
        private void btnRoomData_Click(object sender, EventArgs e)
        {                       
            Room room = new Room();
            //room.GetRoom();
            //Clear all sensor controls in flow
            foreach (Control c in flowSensor.Controls)
            {
                {
                    grpRoom.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
           //Get values and create new controls (buttons labels etc.
            sensor.ListSensors(flowSensor,"All" , login.UserHouse,cmbRoom);
            //Clear all actuator controls in flow
            foreach (Control c in flowActuator.Controls)
            {
                {
                    flowActuator.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
            //Get values and create new controls (buttons labels etc.
            actuator.ListActuators(flowActuator, "All", login.UserHouse, cmbRoom);
            //Set groupbox text to room name
            grpRoom.Text = cmbRoom.Text;
            
        }
               
       
       
        //Load the sensor form window
        private void btnAddSensors_Click(object sender, EventArgs e)
        {
            Forms.frmDaqData frmAddSensor = new Forms.frmDaqData();
            frmAddSensor.ShowDialog();
        }

        //Load the actuator  form window
        private void btnShowActuators_Click(object sender, EventArgs e)
        {
            Forms.frmActuators  frmActuators = new Forms.frmActuators();
            frmActuators.ShowDialog();

        }
        

                

        //Gets the current run time of the application enviroment
        private void UpTime()
        {
           
            double upTime = ((Environment.TickCount));// / 1000)/60;
            //double ticks = double.Parse(startdatetime);
            TimeSpan time = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();  //TimeSpan.FromMilliseconds(upTime);
           
            //string format style
            string[] fmts = { "c", "g", "G", @"hh\:mm\:ss", "%m' min.'" };
            //show uptime iwith string formatting
            txtUptime.Text = time.ToString(@"%d' days 'hh\:mm\:ss");
            toolUptime.Text = txtUptime.Text;
            
        }

        //Get all rooms from sql
        private void GetMyRooms()
        {

            //RoomId, HOuseId, RoomName
            myRoom.Clear();

            //Get rooms from sql
            SqlCommunication sqlCom = new SqlCommunication();
            sqlCom.GetRooms("GetRooms", login.UserHouse);

            //Add a new rooms from sql rooms (list)
            Room rooms = new Room();
            myRoom = new List<string>();
            //myRoom.Add("All");
            foreach (string roomi in rooms.RoomNames.ToArray())
            {
                myRoom.Add(roomi);

            }
                   
        }
        
        //Show the add devices from window
        private void btnAddDevicesForm_Click(object sender, EventArgs e)
        {
            Forms.frmAddDevices frmAddDevices = new Forms.frmAddDevices();
            frmAddDevices.ShowDialog();

        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void myStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolLinklabel_Click(object sender, EventArgs e)
        {
            OpenUrl("https://homieusn.azurewebsites.net/");

        }
        //open custom url based on os
        private void OpenUrl(string url)
        {

          
            try
            {
                Process.Start(url);
            }
            catch
            {
               
            }
        }



        private void contextMenuTop_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1337);
        }

        private void toolStripDatalogger_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuStartLogger_Click(object sender, EventArgs e)
        {
            if (!chkTimer.Checked)
            {
                TimerControl timerControl = new TimerControl();
                timerControl.ControlTimer(true);
            }

        }

        private void toolStripMenuStopLogger_Click(object sender, EventArgs e)
        {
            TimerControl timerControl = new TimerControl();
            timerControl.ControlTimer(false);
        }

        private void toolStripMenuManuals_Click(object sender, EventArgs e)
        {
            OpenUrl("http://homie.ml/");
        }

        private void toolStripMenuAbout_Click(object sender, EventArgs e)
        {
            Forms.frmAboutHomie aboutHomie = new Forms.frmAboutHomie();
            aboutHomie.ShowDialog();
        }

        private void menuStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}
