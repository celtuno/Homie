using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;


namespace Homie.Models
{
    class Actuator 
    {
        //string tmpChannel = "";
        string room = "All";

        static List<int> actuatorId = new List<int>();
        static List<int> roomId = new List<int>();
            
        static List<int> ioId = new List<int>();
            public static List<string> daqId = new List<string>();
        static List<string> actuatorName = new List<string>();
        static List<bool> actuatorValue = new List<bool>();
        
        static List<string> actuatorTypeName = new List<string>();
        static List<int> actuatorTypeId = new List<int>();
        static List<string> roomName = new List<string>();
        static List<string> ioChannel = new List<string>();
        
        static List<string> actuatorType = new List<string>();
        static List<int> actuatorTypeIdType = new List<int>();
        
        static List<string> actuatorTypeDescription = new List<string>();
        
        
        public List<string> ActuatorType
        {
            get { return actuatorType; }
        }

        public List<string> ActuatorTypeDescription
        {
            get { return actuatorTypeDescription; }
        }

        public List<int> ActuatorTypeIdType
        {
            get { return actuatorTypeIdType; }
        }
        public List<int> ActuatorId
        {
            get { return actuatorId; }
        }

        public List<string> ActuatorName
        {
            get { return actuatorName; }
        }

        public List<bool> ActuatorValue
        {
            get { return actuatorValue; }
            set  { actuatorValue = value; }
        }
        public List<int> RoomId
        {
            get { return roomId; }
        }
        public List<string> RoomName
        {
            get { return roomName; }
        }
               
        public List<string> IoChannel
        {
            get { return ioChannel; }
        }

        public List<string> ActuatorTypeName
        {
            get { return actuatorTypeName; }
        }
        
        public List<int> ActuatorTypeId
        {
            get { return actuatorTypeId; }
        }
        public List<int> IoId
        {
            get { return ioId; }
        }


        public ListBox myList = new ListBox();
        public ComboBox myCombo = new ComboBox();

        public Actuator()
        {

        }

        public Actuator(bool status)
        {
            if (status)
            {
                actuatorId.Clear();
                actuatorName.Clear();
                actuatorTypeName.Clear();
                roomId.Clear();
                roomName.Clear();
                ioChannel.Clear();

            }
        }
        public Actuator(int tmpActuatorId, int tmpRoomId, int tmpActuatorTypeId, int tmpIoId, string tmpActuatorName)
        {
            actuatorId.Add(tmpActuatorId);
            roomId.Add(tmpRoomId);
            actuatorTypeId.Add(tmpActuatorTypeId);
            ioId.Add(tmpIoId);
            actuatorName.Add(tmpActuatorName);


        }
        public  Actuator(int tmpActuatorId, string tmpActuatorName, bool tmpActuatorValue,string tmpActuatorTypeName, int tmpRoomId, string tmpRoomName, string tmpIochannel) //, string tmpDaqAddress)
        {
            //actuatorValue.Clear();
            actuatorId.Add(tmpActuatorId);
            roomId.Add(tmpRoomId);
            //actuatorTypeName.Add(tmpActuatorTypeName);
            actuatorValue.Add(tmpActuatorValue);

            bool tt = tmpActuatorValue;
                //||ioChannel.Add(tmpIochannel);
            actuatorName.Add(tmpActuatorName);
            roomId.Add(tmpRoomId);
            roomName.Add(tmpRoomName);
            ioChannel.Add(tmpIochannel);

           // daqId.Add(tmpDaqAddress);


        }



        public void GetActuators(int houseId)
        {
            string room = "All";
        
                //RoomId, HOuseId, RoomName           
                SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetActuators("GetActuators", room);

        }
        public void GetActuators(int houseId,string  tmpRoom)
        {
            string room = "All";
            if (tmpRoom != "") { room = tmpRoom; }
        
                //RoomId, HOuseId, RoomName           
                SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetActuators("GetActuators", room);

        }

        public void GetActuatorTypes()
        {
            string viewName = "GetActuatorTypes";
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetActuatorTypes(viewName);

        }

        public void GetActuators(ListBox list, ComboBox combo, int houseId)
        {
            //RoomId, HOuseId, RoomName
            if (combo.Text != "")
                room = (combo.Text);
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetActuators("GetActuators", room);

            myCombo = combo;
            myList = list;


            list.DataSource = Actuator.actuatorName.ToArray();
            //listBox1.Items.Clear();

        }

        private void myButton_Click(object sender, System.EventArgs e)
        {

            
            Button clickedButton = (Button)sender;
            Color btnColor;
            
            // Add event handler code here.
            string idName = clickedButton.Name.Trim();
            int.TryParse(idName, out int idNumber);
            for (int i = 0 ; i<= ActuatorId.Count-1;i++)
            {
                if (actuatorId[i] == idNumber)
                {
                    
                    
                    bool tmpActuatorValue = ActuatorValue[i];



                    int actId = actuatorId[i];




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
                    CheckArray(i, actId);
                     clickedButton.ForeColor = btnColor;
                }
            }
           

        }
        
        public void CheckArray(int index, int actId)// Actuator actuator)
        {
            try
            {

                SqlCommunication sqlCom = new SqlCommunication();
                DaqCommunication daqCom = new DaqCommunication();


                int actuatorStatus = 0;

                if (ActuatorValue[index])
                {
                    actuatorStatus = 0;
                    ActuatorValue[index] = false;
                }
                else
                {
                    actuatorStatus = 1;
                    ActuatorValue[index] = true;
                }
                bool tmpStatus = Convert.ToBoolean(actuatorStatus);

                bool tt = ActuatorValue[index];
                daqCom.DigitalValueArray[index] = tt;

                sqlCom.WriteActuatorData(tt, actId);

                string tmpChannel = daqCom.SqlDigitalIoName[index + 4].Trim();
                daqCom.WriteDigitalOut(tt, tmpChannel, actId);
            }
            catch (MyDaqError error)
            {
                MessageBox.Show(error.Message);
            }


        }

        public void ListActuators(FlowLayoutPanel flowActuator,string cmbRoom, int houseId, ComboBox cmbRoomBox )//Actuator actuator)
        {

            //tmpChannel = channel;
            flowActuator.Controls.Clear();
            DaqCommunication daqCom = new DaqCommunication();
            
           // GetActuators(houseId, cmbRoom.Text);
            Room room = new Room();
            Button button;// = new Button();
            Label label;
            foreach (Control c in flowActuator.Controls)
            {
                {
                    flowActuator.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }

            if (cmbRoom == "All")
            {
                for (int j = 0; j <= ActuatorId.Count - 1; j++)
                {


                    label = new Label();
                    //label.AutoSize = true;
                    label.MaximumSize = new Size(90, 35);
                    label.MinimumSize = new Size(45, 20);
                    label.Text = "\t - \t";
                    button = new Button();
                    //button.Text = "N/A";
                    button.Enabled = false;
                    button.MaximumSize = new Size(70, 35);
                    button.MinimumSize = new Size(30, 20);
                    button.Padding = new Padding(1, 1, 1, 1);


                    int tt = RoomId[j];
                    if (actuatorValue[j] == false) button.ForeColor = Color.Green;
                    else button.ForeColor = Color.Red;

                    label.Text = ActuatorName[j];

                    button.Name = actuatorId[j].ToString();
                    bool tmpActuatorValue = actuatorValue[j];
                    if (tmpActuatorValue == false)
                    {
                        button.ForeColor = Color.Green;
                        button.Text = "On";
                    }
                    else
                    {
                        button.ForeColor = Color.Red;
                        button.Text = "Off";

                    }
                    //label.Text = ActuatorName[j];

                    //button.Name = ActuatorId[j].ToString();
                    //button.Text = "On / Off";



                   
                    //button.Click += new EventHandler(myButton_Click);
                    button.Enabled = true;
                    flowActuator.Controls.Add(label);
                    flowActuator.Controls.Add(button);
                    //daqCom.DigitalValueArray[j] = ActuatorValue[j];
                }
            }
            else
            {
                for (int j = 0; j <= actuatorId.Count -1 ; j++)
                {

                    label = new Label();
                    //label.AutoSize = true;
                    label.MaximumSize = new Size(90, 35);
                    label.MinimumSize = new Size(25, 20);
                    label.Text = "\t - \t";
                    button = new Button();
                    button.Text = "N/A";
                    button.Enabled = false;
                    button.MaximumSize = new Size(50, 35);
                    button.MinimumSize = new Size(30, 20);
                    button.Padding = new Padding(1, 1, 1, 1);

                    int tytt = room.RoomId.Count();
                    int ttyt = roomId.Count();
                    if (roomId[j] == room.RoomId[cmbRoomBox.SelectedIndex])
                    {
                        int tt = RoomId[ j];
                        if (actuatorValue[j] == false) button.ForeColor = Color.Green;
                        else button.ForeColor = Color.Red;

                        label.Text = ActuatorName[j];

                        button.Name = actuatorId[j].ToString();
                        bool tmpActuatorValue = actuatorValue[j];
                        if (tmpActuatorValue == false)
                        {
                            button.ForeColor = Color.Green;
                            button.Text = "On";
                        }
                        else
                        {
                            button.ForeColor = Color.Red;
                            button.Text = "Off";

                        }

                        
                        button.Enabled = true;


                        flowActuator.Controls.Add(label);
                        flowActuator.Controls.Add(button);

                        button.Click += new EventHandler(myButton_Click);
                    }

                    try
                    {
                        daqCom.DigitalValueArray[j] = ActuatorValue[j];

                    }
                    catch
                    {
                        MessageBox.Show("Write error", "Error writing to Daq, wrong daq id or channel in db?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    


                }


            }
            //listBox1.DataSource = daqCom.DigitalValueArray;
            //listBox1.Refresh();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
