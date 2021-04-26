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
    public partial class frmDaqData : Form
    {
        DaqCommunication daq;
        public frmDaqData()
        {
            InitializeComponent();
        }
        public enum ActValues
        {
            False,True
        }

        readonly Sensor sensor = new Sensor();

        private void frmAddSensor_Load(object sender, EventArgs e)
        {
            daq = new DaqCommunication();
            daq.ReadDaqDevices();
            cmbDaqList.DataSource = daq.AvailableDaq;
            cmbDaqAddress.DataSource = daq.AnalogInchannels;

            
     

            cmbInchannels.DataSource = Enum.GetNames(typeof(DaqCommunication.ioTypeList)).ToList();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
             daq = new DaqCommunication();
            if (e.Node.Parent != null && e.Node.Parent.Text == "Digital")
            {
                switch (daq.DigitalValueArray[e.Node.Index])
                {
                    case false:
                        daq.DigitalValueArray[e.Node.Index] = true;
                        break;
                    case true:
                        daq.DigitalValueArray[e.Node.Index] = false;
                        break;
                }
            }           
            sensor.getStatus(treeView1, cmbInchannels);
        }

        private void btnReadStatus_Click(object sender, EventArgs e)
        {
            sensor.getStatus(treeView1, cmbInchannels);
            getStatus();
        }

        private void btnReadDaqList_Click(object sender, EventArgs e)
        {
            try
            {
                daq = new DaqCommunication();
                daq.ReadAnalogIn(cmbDaqAddress.Text, comboBox1.Text);
                txtDaqResult.Text = daq.analogdataRead.ToString();
            }
            catch (MyDaqError daqError)
            {
                MessageBox.Show(daqError.Message);
            }
        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {
            //@ActuatorValue int, @RoomId int,@Actuator_TypeID int ,@IOID int, @ActuatorName char(15)
        }

        private void btnSingleDigital_Click(object sender, EventArgs e)
        {
           
            try
            {
                daq = new DaqCommunication();
                daq.WriteDigitalOut(chkDigital.Checked, cmbDaqAddress.Text, cmbDaqAddress.SelectedIndex);
                cmbInchannels.SelectedIndex = 1;
                getStatus();

            }
            catch (MyDaqError daqerror)
            {
                MessageBox.Show(daqerror.Message);//.Remove(140)); 
            }

           
        }

        private void btnDigitalArray_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] boolArray = { chkDigital.Checked, chkDigital.Checked , chkDigital.Checked , chkDigital.Checked
            ,chkDigital.Checked,chkDigital.Checked,chkDigital.Checked,chkDigital.Checked};
                daq = new DaqCommunication();
                //daqCom.WriteAnalogDaq(checkBox1.Checked);
                daq.WriteDigitalOut(boolArray, cmbDaqAddress.Text);
                cmbInchannels.SelectedIndex = 1;
                getStatus();
            }
            catch (MyDaqError daqerror)
            {
                MessageBox.Show(daqerror.Message);// Remove(148));
            }
            //CheckArray();
        }
        private void getStatus()
        {
            DaqCommunication daqCommunication = new DaqCommunication();
            List<string> sensorValues; //= new List<string>();

            //List<string> channelTypes; //= new List<string>();

            // listBox1.DataSource = null;
            sensorValues = daqCommunication.ReadAllPortValues(cmbInchannels.SelectedIndex);            //daqCommunication.ReadAllPortValues(cmbInchannels.SelectedIndex);                      

            listBox1.DataSource = sensorValues;
            //channelTypes = Enum.GetNames(typeof(Models.DaqCommunication.ioTypeList)).ToList();

        }
    }
}
