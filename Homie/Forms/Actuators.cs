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
    public partial class frmActuators : Form
    {
        //ComboBox comboBox = new ComboBox();
        //ListBox listBox = new ListBox();
        List<string> myRoom = new List<string>();
        FlowLayoutPanel actuators;
        Actuator actuator;
        Room room;
        LoginUser loginUser = new LoginUser();
        public frmActuators()
        {

            InitializeComponent();
        }

        private void frmActuators_Load(object sender, EventArgs e)
        {
            GetRooms();
            ShowRooms();
            actuator = new Actuator();
            actuator.GetActuators(listBox1, cmbRoom, loginUser.UserHouse);
            //GetActuators(listBox1, cmbRoom,loginUser.UserHouse);
            ShowActuators(roomFlowAct);
            tmrUpdateActuator.Enabled = true;
        }

        //Get all rooms from database /room class
        private void GetRooms()
        {

            //RoomId, HOuseId, RoomName
            myRoom.Clear();
            SqlCommunication sqlCom = new SqlCommunication();

            sqlCom.GetRooms("GetRooms", loginUser.UserHouse);//, roomColumns);


            Room rooms = new Room();
            myRoom = new List<string>();
            myRoom.Add("All");
            foreach (string roomi in rooms.RoomNames.ToArray())
            {
                myRoom.Add(roomi);

            }

            cmbRoom.DataSource = myRoom.ToArray();
            //myRoom.Add("All");
        }

        //Get all actuators from database/actuator class
        private void GetActuators(ListBox list, ComboBox combo, int houseId)
        {
             actuator= new Actuator();
            actuator.ActuatorName.Clear();
            //string room = "All";
            ////RoomId, HOuseId, RoomName
            //if (combo.Text != "")
            //    room = (combo.Text);
            //SqlCommunication sqlCommunication = new SqlCommunication();

            //sqlCommunication.GetActuators("GetActuators", room);
            actuator.GetActuators(list, combo, loginUser.UserHouse);

            //comboBox = combo;
            //listBox = listBox1;
            listBox1.DataSource = actuator.ActuatorName.ToArray();
           
            

        }
        

        //Custom flowpanel layout loop for getting all actuators and showing them on a relevant groupbox
        private void ShowActuators(FlowLayoutPanel panel)
        {
            int count = 0;
            //int roomNr = 0;
            string roomName;
            room = new Room();
            
            
            
             actuator = new Actuator();
            
            
            foreach (GroupBox group in panel.Controls)//roomFlow.Controls)
            {
                roomName =room.RoomNames[count].Trim();

                actuators = new FlowLayoutPanel();
                foreach (Control c in group.Controls)
                {
                    {
                        group.Controls.Remove(c);
                        c.Dispose();
                        break;
                    }
                }
                //roomFlow.BackColor = Color.Cornsilk;
                actuators.Padding = new Padding(5);
                actuators.MinimumSize = new Size(group.Size.Width - 15, group.Height - 25);
                actuators.Top = 15;
                actuators.Left = 10;
                group.Controls.Add(actuators);

  

                for (int i = 0; i <= actuator.ActuatorId.Count - 1; i++)//( int i = actuator.ActuatorId.Count-1; i > 0; i--)
                {

                    Button radioButton = new Button
                    {
                        AutoSize = true,
                        MinimumSize = new Size((actuators.Width / 3), 25),
                        MaximumSize = new Size((actuators.Width / 2), 25),
                        Location = new Point(actuators.Location.X + 50, actuators.Location.Y + 20)

                    };
                    radioButton.Enabled = false;
                  
                    
                    Label label = new Label();
                    //label.AutoSize = true;
                    label.MinimumSize = new Size(100, 25);
                    label.MaximumSize = new Size(actuators.Width / 2, 25);
                    //int tmpid = actuator.RoomId[i];
                    //string tty = actuator.RoomName[i];

                    if ( actuator.RoomName[i].Trim() == roomName)
                    {
                        
                           

                       
                            if (actuator.ActuatorValue[i] == false) radioButton.ForeColor = Color.Green;
                            else radioButton.ForeColor = Color.Red;

                            label.Text = actuator.ActuatorName[i];
                        //string ttyt= actuator.ActuatorName[i];

                            radioButton.Name = actuator.ActuatorId[i].ToString();
                            bool tmpActuatorValue = actuator.ActuatorValue[i];
                            if (tmpActuatorValue == false)
                            {
                               radioButton.ForeColor = Color.Green;
                                radioButton.Text = "On";
                            }
                            else
                            {
                                radioButton.ForeColor = Color.Red;
                                radioButton.Text = "Off";

                            }
                        //Custom click_button eventhandler for the flowlayout actuator butttons
                        radioButton.Click += new EventHandler(myButton_Click);
                        radioButton.Enabled = true;
                       
                        actuators.Controls.Add(label);
                        actuators.Controls.Add(radioButton);

                    }
                   
               

                }
                count++;

                 

                 
            }
           //ShowRooms();
        }
        //Custom click_button eventhandler for the flowlayout actuator butttons
        private void myButton_Click(object sender, System.EventArgs e)
        {

            actuator = new Actuator();
            Button clickedButton = (Button)sender;
            Color btnColor;

            // Add event handler code here.
            string idName = clickedButton.Name.Trim();
            int.TryParse(idName, out int idNumber);
            for (int i = 0; i <= actuator.ActuatorId.Count - 1; i++)
            {
                //Change button color and text wether the  button is enabled or disabled
                if (actuator.ActuatorId[i] == idNumber)
                {


                    bool tmpActuatorValue = actuator.ActuatorValue[i];



                    int actId = actuator.ActuatorId[i];



                    if (tmpActuatorValue == true)
                    {
                        btnColor = Color.Green;
                        clickedButton.Text = "On";
                    }
                    else
                    {
                        btnColor = Color.Red;
                        clickedButton.Text = "Off";

                    }
                    //CheckArray(i, actId);
                    //Check the current value and write value to db and daq 

                    actuator.CheckArray(i, actuator.ActuatorId[i]);
                    clickedButton.ForeColor = btnColor;
                }
            }
           


        }


        //TextBox radioButton;
        //Get all room s from sql/Room class
        private void ShowRooms()
        {
            Room rooms = new Room();

            roomFlowAct.Padding = new Padding(5, 5, 5, 5);

            foreach (string room in rooms.RoomNames)
            {
                GroupBox groupBox;
                groupBox = new GroupBox
                {
                    Text = room,
                    MinimumSize = new Size(250, 180),
                    Padding = new Padding(13, 13, 13, 13)
                };                
                //add groupbox to flowlayout panel
                roomFlowAct.Controls.Add(groupBox);
            }
        }


        //Button - get all rooms and sensors
        private void btnGetActuatorsRoom_Click(object sender, EventArgs e)
        {
            myRoom.Clear();
            listBox1.DataSource = myRoom.ToArray();

            GetActuators(listBox1, cmbRoom, loginUser.UserHouse);
            ShowActuators(roomFlowAct);
        }

        private void grpRoom_Enter(object sender, EventArgs e)
        {

        }

        private void tmrUpdateActuator_Tick(object sender, EventArgs e)
        {
            actuator = new Actuator();
            actuator.GetActuators(listBox1, cmbRoom, loginUser.UserHouse);
            ShowActuators(roomFlowAct);
        }

        private void frmActuators_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrUpdateActuator.Enabled = false;
        }
    }
}
