using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homie.Models;

namespace Homie.Forms
{
    public partial class frmSensors : Form
    {
        //ComboBox comboBox = new ComboBox();
        ListBox listBox = new ListBox();
        List<string> myRoom = new List<string>();
        Sensor sensorClass = new Sensor();
        Room room = new Room();

        FlowLayoutPanel sensors;//= new FlowLayoutPanel();
        int count = 0;
        int roomNr = 0;


        public frmSensors()
        {
            InitializeComponent();
        }

        private void frmSensorStatus_Load(object sender, EventArgs e)
        {

            tmrSensor.Enabled = true;

            GetRooms();
            cmbRoom.DataSource = myRoom.ToArray();
            ShowRooms();
            GetSensors(cmbRoom);
            //GetSensors();
            GetDaqvalues();


            ShowSensors(roomFlow);
            TimerControl timerControl = new TimerControl();
            //timerControl.ControlTimer(false);
        }

        private void btnGetSenorRoom_Click(object sender, EventArgs e)
        {

            myRoom.Clear();

            GetRooms();
            // cmbRoom.DataSource = myRoom.ToArray();
            GetSensors(cmbRoom);
            ShowSensors(roomFlow);
        }


        private void ShowSensors(FlowLayoutPanel panel)
        {


            count = 0;
            roomNr = 0;
            try
            {
                foreach (GroupBox group in panel.Controls)//roomFlow.Controls)
                {

                    sensors = new FlowLayoutPanel();
                    foreach (Control c in group.Controls)
                    {
                        {
                            group.Controls.Remove(c);
                            c.Dispose();
                            break;
                        }
                    }
                    //roomFlow.BackColor = Color.Cornsilk;
                    sensors.Padding = new Padding(5);
                    sensors.MinimumSize = new Size(group.Size.Width - 15, group.Height - 25);
                    sensors.Top = 15;
                    sensors.Left = 10;
                    group.Controls.Add(sensors);

                    roomNr = room.RoomId[count];
                    count++;


                    for (int i = sensorClass.SensorId.Count; i > 0; i--)//each (string sensor in Sensor.sensorName)
                    {
                        //RadioButton radioButton = new RadioButton();
                        //CheckBox radioButton = new CheckBox();
                        TextBox radioButton = new TextBox();
                        //radioButton.Left = 55;
                        //radioButton.Top = 55;
                        radioButton.AutoSize = true;
                        radioButton.MinimumSize = new Size((sensors.Width / 3), 15);
                        radioButton.MaximumSize = new Size((sensors.Width / 2), 15);
                        Label label = new Label();
                        //label.AutoSize = true;
                        label.MinimumSize = new Size(100, 15);
                        label.MaximumSize = new Size(sensors.Width / 2, 15);

                        radioButton.Location = new Point(sensors.Location.X + 50, sensors.Location.Y + 20);
                        int tt1 = sensorClass.RoomId[i - 1];
                        if (roomNr == sensorClass.RoomId[i - 1])
                        {
                            //SensorLog sensorLog = new SensorLog();
                            //sensorLog.GetSensorLog(sensorClass.SensorId[(i-1)]);
                            DaqCommunication daqCommunication = new DaqCommunication();
                            //double daqValue = daqCommunication.AnalogValueArray[i - 1];
                            //int tt = Sensor.sensorName.Count();
                            string sensorstring = sensorClass.SensorName[i - 1];
                            label.Text = sensorstring;
                            radioButton.Name = "sensor" + (i - 1);
                            //int testing = daqCommunication.AnalogValueArray.Length;
                            ////int testing = sensorLog.SensorValue.Count;

                            //if (testing >= 1)
                            //    //radioButton.Text = daqValue.ToString();
                            //    radioButton.Text = daqCommunication.AnalogValueArray[i].ToString().Trim();
                            ////radioButton.Text = sensorLog.SensorValue[0].ToString();

                            daqCommunication.ReadAnalogIn(sensorClass.IoChannel[i - 1], "termo");


                            //daqCommunication.ReadAnalogIn(sensor.IoChannel[j], "termo");
                            double roundAnalog = Math.Round(daqCommunication.analogdataRead, 3);
                            string tmpValue = roundAnalog.ToString();// daqCom.AnalogValueArray[j+7].ToString();
                            radioButton.Text = tmpValue;
                            sensors.Controls.Add(label);
                            sensors.Controls.Add(radioButton);

                        }

                    }
                }
            }
            catch (MyDaqError error)
            {
                MessageBox.Show(error.Message);
            }
        }


        //TextBox radioButton;
        private void ShowRooms()
        {  
            Room rooms = new Room();
            
            roomFlow.Padding = new Padding(5,5,5,5);

            foreach (string room in rooms.RoomNames)
            { GroupBox groupBox;
                groupBox = new GroupBox();
                groupBox.Text = room;
                
                groupBox.MinimumSize = new Size(250, 180);
                groupBox.Padding = new Padding(13,13,13,13 );
                
                roomFlow.Controls.Add(groupBox);                           
            }
        }
        
        
        private void GetDaqvalues()
        {
            DaqCommunication daqCom = new DaqCommunication();
            string[] channelType = new string[2];
            channelType = Enum.GetNames(typeof(DaqCommunication.ioTypeList)).ToArray();

            for (int i =  0; i< channelType.Length; i++)
            {
                daqCom.ReadAllPortValues(i);
            }
           
            

        }


        private void GetDaqvalues(int channelType)
        {
            DaqCommunication daqCom = new DaqCommunication();
            daqCom.ReadAllPortValues(channelType);

        }


        private void GetRooms()
        {

        //RoomId, HOuseId, RoomName
        myRoom.Clear();

        //Get rooms from sql
        SqlCommunication sqlCom = new SqlCommunication();
            LoginUser loginUser = new LoginUser();
        sqlCom.GetRooms("GetRooms", loginUser.UserHouse);
                        
        //Add a new rooms from sql rooms (list)
        Room rooms = new Room();
        myRoom = new List<string>();
        myRoom.Add("All");
        foreach(string roomi in rooms.RoomNames.ToArray())
        {
            myRoom.Add(roomi);

        }            
        //cmbRoom.DataSource = myRoom.ToArray();           
        }

        

        private void GetSensors( ComboBox combo)
        {
            
            SqlCommunication sqlCommunication = new SqlCommunication();
            string room = "All";
            //RoomId, HOuseId, RoomName
            //Check if value in combobox, read all if not
            if (combo.Text != "")
            {room = (combo.Text);
            //int roomId;
            //if (combo.Text == "All")
            //{
                
            //    for (int i = 0; i <= room.RoomId.Count - 1; i++)
            //    {
            //        roomId = room.RoomId[i];
            //        //Get a list of sensors from sql            
            //        // sqlCommunication.GetSensors("GetSensors",room );
            //        sqlCommunication.GetSensors("GetSensors", roomId);
            //        //sqlCommunication.GetSensorLog("GetSensorLog", 1);

            //    }

            //}
            //else
            //{



                //Get a list of sensors from sql
                //roomId = room.RoomId[combo.SelectedIndex-1];
                 sqlCommunication.GetSensors("GetSensors",room );
                //sqlCommunication.GetSensors("GetSensors", roomId);
                //sqlCommunication.GetSensorLog("GetSensorLog", 1);
            }
                //comboBox = combo;
            

            lstboxSensor.DataSource = sensorClass.SensorName.ToArray();
            //listBox1.Items.Clear();

        }


        private void btnGraph_Click(object sender, EventArgs e)
        {
            //string boxValue;
            //string boxName = ""; 
            ////The selected sensor in the listbox
            //string listName = lstboxSensor.Text.Trim();

            
            
           
            //Loop through all controls in the flow layotpanel / room groupboxes
            //foreach (GroupBox group in roomFlow.Controls)//roomFlow.Controls)
            //{
            //    foreach (FlowLayoutPanel panel in group.Controls)//roomFlow.Controls)
            //    {   
            //        foreach (Control box in panel.Controls)
            //        {
            //            //check control type
            //            if (box.GetType() == typeof(Label))
            //            {
            //                 boxName = box.Text.Trim();                   
                  
            //            }
            //            //check control type
            //            if (box.GetType() == typeof(TextBox))
            //            {
                            
            //                 boxValue = box.Text;
            //                //check if the boxes are the right ones and that it has a value, then show data
            //                if (boxName == listName && boxValue != "")
            //                {                       
                        
            //                    MessageBox.Show("Sensor name: \t" +boxName + " \r\n Text from sensor: \t" + boxValue);
            //                }
            //            }
                 
            //        }
                   
            //    }
               
            //}
            frmGraphing frmGraphing = new frmGraphing();
                frmGraphing.ShowDialog();
        }

        private void tmrSensor_Tick(object sender, EventArgs e)
        {
            myRoom.Clear();
            //Get latest values from daq
            GetDaqvalues();
            //Refresh room and sensorlist
            GetRooms();          
            ShowSensors(roomFlow);
            
           
        }

        private void frmSensors_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrSensor.Enabled = false;
         
        }
    }
}
