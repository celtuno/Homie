using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Homie.Models
{
    class Sensor
    {
        //Static variables for storing sensor information in this class
        static List<int> sensorId = new List<int>();
        static List<int> roomId = new List<int>();
        public static List<int> sensorTypeId = new List<int>();
        static List<int> ioId = new List<int>();
        static List<string> daqId = new List<string>(); 
        static List<string> sensorName =  new List<string>();
        public static List<string> sensorTypeName = new List<string>();
        public static List<string> sensorUnit = new List<string>();
        public static List<string> roomName = new List<string>();
        static List<string> ioChannel = new List<string>();
        static List<int> sensorTypeIdType = new List<int>();
        static List<string> sensorTypes = new List<string>();
        static List<string> sensorTypeDescription = new List<string>();


        // methods for changing and reading variables in this class
        public List<int> IoId
        {
            get { return ioId; }
        }

        public List<int> SensorTypeIdType
        {
            get { return sensorTypeIdType; }
        }
        public List<string> DaqId
        {
            get { return daqId; }
        }

        public  List<string> IoChannel
        {
            get { return ioChannel; }
        }

        public List<int> RoomId
        {
            get { return roomId; }
        }
        public List<int> SensorId 
        {
            get { return sensorId; }
            //set { }
        }

        public List<string> SensorName
        {
            get { return sensorName; }            
        }

        public List<string> SensorTypes
        {
            get { return sensorTypes; }
            set { sensorTypes = value; }
        }
        public List<string> SensorTypeDescription
        {
            get { return sensorTypeDescription; }
            set { sensorTypeDescription= value; }
        }

        public ListBox myList = new ListBox();
        public ComboBox myCombo = new ComboBox();
        LoginUser loginUser = new LoginUser();

        public Sensor()
        {

        }
        public Sensor(bool status)
        {
            //CLear all values if variable status is true
            if (status)
            {
                sensorId.Clear();
                sensorName.Clear();
                sensorTypeName.Clear();
                sensorUnit.Clear();
                roomId.Clear();
                roomName.Clear();
                ioChannel.Clear();

            }
        }
        public Sensor(int tmpSensorId, int tmpRoomId, int tmpSensorTypeId, int tmpIoId, string tmpSensorName)
        {
            sensorId.Add(tmpSensorId);
            roomId.Add(tmpRoomId);
            sensorTypeId.Add(tmpSensorTypeId);
            ioId.Add( tmpIoId);
            sensorName.Add(tmpSensorName);


        }
        public Sensor(int tmpSensorId, string tmpSensorName, string tmpSensorTypeName, string tmpSensorUnit, int tmpRoomId, string tmpRoomName, string tmpIochannel)//, string tmpDaqAddress)
        {
            sensorId.Add(tmpSensorId);
            sensorName.Add(tmpSensorName);
            sensorTypeName.Add(tmpSensorName);
            sensorUnit.Add(tmpSensorUnit);
            roomId.Add(tmpRoomId);
            roomName.Add(tmpRoomName);
            ioChannel.Add(tmpIochannel);



        }
        //Create new sensor when class is initialized with these variables
        public Sensor(int tmpSensorId, string tmpSensorName, string tmpSensorTypeName, string  tmpSensorUnit, int tmpRoomId, string tmpRoomName, string tmpIochannel,string tmpDaqAddress)
        {
            sensorId.Add(tmpSensorId);
            sensorName.Add(tmpSensorName);
            sensorTypeName.Add(tmpSensorName);
            sensorUnit.Add(tmpSensorUnit);
            roomId.Add(tmpRoomId);
            roomName.Add(tmpRoomName);
            ioChannel.Add(tmpIochannel);
            daqId.Add(tmpDaqAddress);


        }

       
        //Get sensors from database based on the houseid(user's house)
        public void GetSensors(int houseId)
        {

            string room = "All";
            //RoomId, HOuseId, RoomName
            //Check if value in combobox, read all if not

            //Get a list of sensors from sql
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetSensors("GetSensors", room);
           

        }
        
        //Get sensors from database

        public void GetSensors(ListBox list, ComboBox combo, int houseId)
        {
            string room = "All";
            //RoomId, HOuseId, RoomName
            if (combo.Text != "")
                room = (combo.Text);
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetSensors("GetSensors", room);
          
            myList = list;            
        }
       
        //Get sensor types from database
        public void GetSensorTypes()
        {
            string viewName = "GetSensorTypes";
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.GetSensorTypes(viewName);

        }

        //Add sensor to databas
        public void Addsensors(int roomId, int sensorTypeId, int ioID, string sensorName)
        {
            //sql: @RoomId int, @SensorTypeId int,@IOID int, @SensorName char(15)
            
            SqlCommunication sqlCommunication = new SqlCommunication();
            sqlCommunication.AddSensor( roomId,  sensorTypeId,  ioID,  sensorName);

        }


        //Loop thruogh all sensors and add controls to groupbox/flowlayoutPanel
        public void ListSensors(FlowLayoutPanel flowSensor, string cmbRoomString, int houseId, ComboBox cmbRoom)
        {
            try 
            {
                
                flowSensor.Controls.Clear();
                DaqCommunication daqCom = new DaqCommunication();

                flowSensor.Controls.Clear();
                Room room = new Room();
                Sensor sensor = new Sensor();
                //Get all sensors at given house id
                sensor.GetSensors(houseId);
               //initialize Label and textbox
                Label label;
                TextBox sensorValue;

                //DEBUG clear/dispose all flow elements
                foreach (Control c in flowSensor.Controls)
                {
                    {
                        flowSensor.Controls.Remove(c);
                        c.Dispose();
                        break;
                    }
                }

                //Get all sensors
                if (cmbRoomString == "All")
                {
                    for (int j = 0; j <= sensor.SensorId.Count - 1; j++)

                    {
                        //int tmpid = sensor.RoomId[j];
                        //if (room.HouseId[tmpid] == loginUser.UserHouse)
                        //{

                            label = new Label();
                            label.Text = "\t\t";
                            //label.AutoSize = true;
                            label.MinimumSize = new Size(10, 25);
                            label.MaximumSize = new Size(flowSensor.Width / 2, 25);


                            sensorValue = new TextBox();
                            sensorValue.ReadOnly = true;
                            sensorValue.Text = "N/A";
                            sensorValue.Enabled = false;
                            //if (sensor.RoomId[j] == room.RoomId[cmbRoom.SelectedIndex])
                            //{

                                sensorValue.MinimumSize = new Size(10, 15);
                                sensorValue.MaximumSize = new Size((flowSensor.Width / 3), 25);
                                sensorValue.Padding = new Padding(2, 2, 2, 2);

                                label.Text = sensor.SensorName[j].Trim();
                                sensorValue.Name = sensor.SensorName[j];

                                daqCom = new DaqCommunication();
                                daqCom.ReadAnalogIn((sensor.IoChannel[j]), "termo");
                                double roundAnalog = Math.Round(daqCom.analogdataRead, 3);
                                string tmpValue = roundAnalog.ToString();
                                sensorValue.Text = tmpValue;

                                sensorValue.Enabled = true;
                                flowSensor.Controls.Add(label);
                                flowSensor.Controls.Add(sensorValue);
                            //}

                        //}
                    }
                   
                }
                //Get sensors in a specified room
                else
                {
                    //Loop though all sensors, and initilaize label and text field -properties
                    for (int j = 0; j <= sensor.SensorId.Count-1; j++)
                    {

                        label = new Label();
                        label.Text = "\t\t";
                        //label.AutoSize = true;
                        label.MinimumSize = new Size(10, 25);
                        label.MaximumSize = new Size(flowSensor.Width / 2, 25);


                        sensorValue = new TextBox();
                        sensorValue.ReadOnly = true;
                        sensorValue.Text = "N/A";
                        sensorValue.Enabled = false;
                        //CHeck if the looped sensor's roomid  matches the chosen roomid from combobox
                        if (sensor.RoomId[j] == room.RoomId[cmbRoom.SelectedIndex])
                        {

                            sensorValue.MinimumSize = new Size(10, 15);
                            sensorValue.MaximumSize = new Size((flowSensor.Width / 3), 25);
                            sensorValue.Padding = new Padding(2, 2, 2, 2);

                            //Get sensorname and sensor cvalue, an write to label and textboxName
                            label.Text = sensor.SensorName[j].Trim();
                            sensorValue.Name = sensor.SensorName[j];

                            daqCom = new DaqCommunication();
                            //Read sensor from daq, and convert to degrees celcius
                            daqCom.ReadAnalogIn((sensor.IoChannel[j]), "termo");
                            //Round of analog sensor value to 3 decimals.
                            double roundAnalog = Math.Round(daqCom.analogdataRead, 3);                            
                            string tmpValue = roundAnalog.ToString();
                            //Set sensorvalue textbox.Text to rounded value
                            sensorValue.Text = tmpValue;

                            sensorValue.Enabled = true;
                            //Add elements to groupbox/flowlayoutpanel
                            flowSensor.Controls.Add(label);
                            flowSensor.Controls.Add(sensorValue);
                        }

                    } 
                }
            
            }
            //Check daq errors
            catch (MyDaqError error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //Re-Read all sensor values in daq data window
        public void getStatus(TreeView treeView1, ComboBox currentNode)
        {
            DaqCommunication daqCommunication = new DaqCommunication();
            List<string> sensorValues = new List<string>();

            List<string> channelTypes = new List<string>();
            //Clear sensor listbox (left side)
            treeView1.Nodes.Clear();
            
            sensorValues = daqCommunication.ReadAllPortValues(currentNode.SelectedIndex);            //daqCommunication.ReadAllPortValues(currentNode.SelectedIndex);


            channelTypes = Enum.GetNames(typeof(Models.DaqCommunication.ioTypeList)).ToList();
            for (int i = 0; i < currentNode.Items.Count; i++)
            {

                sensorValues = daqCommunication.ReadAllPortValues(i);
                addTree(sensorValues.ToArray(), channelTypes[i], daqCommunication, treeView1);// sensorNames.ToArray());
            }
            treeView1.SelectedNode = treeView1.Nodes[currentNode.SelectedIndex];
            treeView1.SelectedNode.Expand();
        }
        private void addTree(string[] values, string sensorType, DaqCommunication daq , TreeView treeView1)// string[] sensorNames)
        {
            List<string> sensorNames = new List<string>();
            //treeView1.ImageList = sensorImages;

            List<TreeNode> valueList = new List<TreeNode>();
            TreeNode treeNode;
            int count = 0;
            string device = daq.AvailableDaq[0] + "/";

            foreach (string value in values)
            {
                string tmpnodeTxt;
                if (sensorType == "Analog")
                {
                    sensorNames = daq.AnalogInchannels;
                    tmpnodeTxt = (sensorNames[count].TrimStart(device.ToCharArray()) + " : " + value);//"Sensor " + count + " : " + value);

                }

                else
                {
                    int.TryParse(value, out int bvalue);
                    sensorNames = daq.DigitalInLines;
                    tmpnodeTxt = (sensorNames[count].TrimStart(device.ToCharArray()) + " : " + Convert.ToBoolean(bvalue));
                    //tmpnodeTxt = ("Sensor " + count + " : " );
                }

                TreeNode node = new TreeNode(tmpnodeTxt);

                node.ImageIndex = 1;
                node.SelectedImageIndex = 0;
                valueList.Add(node);


                count++;
            }

            treeNode = new TreeNode(sensorType, valueList.ToArray());
            treeNode.Checked = false;
            treeNode.StateImageIndex = 0;
            treeNode.ImageIndex = 1;
            treeNode.SelectedImageIndex = 0;

            treeView1.Nodes.Add(treeNode);

            treeView1.Update();



        }
    }
}
