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
    public partial class frmAddDevices : Form
    {
        public frmAddDevices()
        {
            InitializeComponent();
        }
        LoginUser login;
        Room room;
        Sensor sensor = new Sensor();
        Actuator actuator = new Actuator();
        DaqCommunication daqCom;
        SqlCommunication sqlCom;

        bool[] actValues = { false, true };
        
        private void frmAddDevices_Load(object sender, EventArgs e)
        {
           
            UpdateInputs();
        }
        private void UpdateInputs()
        {
             room= new Room();
            daqCom = new DaqCommunication();
            login = new LoginUser();
            actuator.GetActuatorTypes();
           sensor.GetSensorTypes();
            room.GetRooms("GetRooms", login.UserHouse);
            sqlCom = new SqlCommunication();
            
            
            daqCom.ReadDaqDevices();
            sqlCom.GetDaqDigitalIo(login.UserHouse);

            sqlCom.GetDaqAnalogIo(login.UserHouse);
            cmbDaq.DataSource = daqCom.AvailableDaq;
            cmbSensorChannels.DataSource = daqCom.SqlAnalogIoName;
            cmbActChannel.DataSource = daqCom.SqlDigitalIoName;

            cmbSensorType.DataSource = sensor.SensorTypes;// Enum.GetNames(typeof(DaqCommunication.IOTypes)).ToList();
            cmbActType.DataSource = actuator.ActuatorType;
            cmbDefaultValue.DataSource = actValues;
            cmbDefaultValue.SelectedIndex = 0;

            cmbActRoom.DataSource = room.RoomNames;
            cmbRoom.DataSource = room.RoomNames;
                        
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
                string channel = "/Dev2/ao1";
            double.TryParse(numericUpDown1.Value.ToString(), out double number);
            daqOut(number, channel);
     
        }
        private void daqOut(double number, string channel)
        {
            NationalInstruments.DAQmx.Task task = new NationalInstruments.DAQmx.Task("Test");
            task.AOChannels.CreateVoltageChannel("/Dev2/ao1", "testChannel", 0, 5, NationalInstruments.DAQmx.AOVoltageUnits.Volts);
            task.Control(NationalInstruments.DAQmx.TaskAction.Verify);
            NationalInstruments.DAQmx.AnalogSingleChannelWriter analogSingle;

            analogSingle = new NationalInstruments.DAQmx.AnalogSingleChannelWriter(task.Stream);

            analogSingle.WriteSingleSample(true,number );
            task.Dispose();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string channel = "/Dev2/ao1";
            double.TryParse(numericUpDown1.Value.ToString(), out double number);
            daqOut(number, channel);

        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {
            SqlCommunication sqlCommunication = new SqlCommunication();
            int tmpRoomId = room.RoomId[cmbRoom.SelectedIndex];
            int tmpTypeId = sensor.SensorTypeIdType[cmbSensorType.SelectedIndex];
            int tmpIoid = daqCom.SqlAnalogIoID[cmbSensorChannels.SelectedIndex];
            string sensorName = txtSensorName.Text;
            bool result = sqlCommunication.AddSensor(tmpRoomId, tmpTypeId, tmpIoid, sensorName);
            //sensor.Addsensors(tmpRoomId, tmpTypeId, tmpIoid,sensorName );
            AddVerification(result, sensorName);
        }

        private void lblSensorName_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDaq_Click(object sender, EventArgs e)
        {
            string daqName = txtDaqName.Text;
            string daqModel = txtDaqModel.Text;
            string daqAddress = cmbDaq.Text;


            DaqCommunication daqCom = new DaqCommunication();
            LoginUser user = new LoginUser();
            int houseId = 1;
            houseId = user.UserHouse;
           bool result = daqCom.DaqToDb(daqName, daqAddress, daqModel,houseId);
            AddVerification(result, daqName);

        }

        private void btnAddActuator_Click(object sender, EventArgs e)
        {
            daqCom = new DaqCommunication();

            bool actuatorValue;
            Boolean.TryParse(cmbDefaultValue.Text, out actuatorValue);
            int roomId = room.RoomId[cmbActRoom.SelectedIndex];
            int actuator_TypeID = actuator.ActuatorTypeIdType[cmbActType.SelectedIndex]; 
            int ioID = daqCom.SqlDigitalIoID[cmbActChannel.SelectedIndex];
            string actuatorName = txtActuatorName.Text;
            


            SqlCommunication sqlCom = new SqlCommunication();
            
            bool result = sqlCom.AddActuator(actuatorValue, roomId, actuator_TypeID, ioID, actuatorName);
            AddVerification(result, actuatorName);


        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            int houseId = login.UserHouse;
            string roomName = txtRoomName.Text;
            bool result = sqlCom.CreateNewRoom(houseId,roomName );
            UpdateInputs();
            AddVerification(result, roomName);
        }
        private void AddVerification(bool result, string deviceName)
        {
            string textResult;
            if (result) textResult = "Sucsessfull";
            else textResult = "Failed";

            MessageBox.Show("Adding device: " + deviceName + "\r\n" + textResult, "Adding device");
            this.Close();
        }


        private void checkText()
        {

            if (txtDaqName.Text == "")
            {
                addDeviceErrorProv.SetError(txtDaqName, "Enter daq name");
                btnAddDaq.Enabled = false;
            }
            else
            {
                    if (txtDaqName.Text != "" && lblDaqModel.Text != "")
                    {
                        addDeviceErrorProv.Clear();
                        btnAddDaq.Enabled = true;
                    }

            }
            if (txtDaqModel.Text == "") { 
                addDeviceErrorProv.SetError(txtDaqModel, "Enter modelname");
                btnAddDaq.Enabled = false;
             }
            else
            {
                
                if (txtDaqName.Text != "" && lblDaqModel.Text != "")
                {
                    addDeviceErrorProv.Clear();
                    //btnAddDaq.Enabled = true;
                }

            }
            if (txtActuatorName.Text == "")
            {
                addDeviceErrorProv.SetError(txtActuatorName, "Enter actuatorname");
                btnAddActuator.Enabled = false;
            }

            else
            {
                
                addDeviceErrorProv.Clear();
                btnAddActuator.Enabled = true;
                

            }

            if (txtSensorName.Text == "")
            {
                addDeviceErrorProv.SetError(txtSensorName, "Enter sensorname");
                btnAddSensor.Enabled = false;
            }
            else
            {
                addDeviceErrorProv.Clear();
                btnAddSensor.Enabled = true;

            }
            if (txtRoomName.Text == "")
            {
                addDeviceErrorProv.SetError(txtRoomName, "Enter roomoname");
                btnAddRoom.Enabled = false;
            }
            else
            {
                addDeviceErrorProv.Clear();
                btnAddRoom.Enabled = true;

            }
            

        }
        private void txtDaqModel_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }
        private void txtDaqModel_Leave(object sender, EventArgs e)
        {
                checkText();
        }

        private void txtDaqName_TextChanged(object sender, EventArgs e)
        {
            checkText();
}

private void txtDaqName_Enter(object sender, EventArgs e)
        {
            checkText();
}

private void txtActuatorName_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }
    private void txtSensorName_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }

        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }



        private void frmAddDevices_FormClosed(object sender, FormClosingEventArgs e)
        {
        }

        private void frmAddDevices_FormClosed(object sender, FormClosedEventArgs e)
       {
        }

        private void cmbActChannel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabAddAcuator_Enter(object sender, EventArgs e)
        {
          
        }
    }

       

}
    

