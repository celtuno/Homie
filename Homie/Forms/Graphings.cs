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
    public partial class frmGraphing : Form
    {
        public frmGraphing()
        {
            InitializeComponent();
        }
        SqlCommunication sqlCom;
        Room room;
        Sensor sensor;



        private void Graphing_Load(object sender, EventArgs e)
        {
            LoginUser loginUser = new LoginUser();
            dateTimeenddate.Value = DateTime.Today.Date;
            room = new Room();
            room.GetRooms("GetRooms",loginUser.UserHouse);
            cmbRoomList.DataSource = room.RoomNames;
            List<int> daylist = new List<int> {1, 2, 3, 4, 5, 6, 7, 9, 14, 31 };
            Color graphColor1, graphColor2;
            graphColor1 = Color.Gray;
            graphColor2 = Color.Green;



            cmdDays.DataSource = daylist;
            cmdDays.SelectedIndex = 3;

           sqlCom = new Models.SqlCommunication();

            sensor = new Sensor();
            sqlCom.GetSensors("GetSensors",room.RoomId[cmbRoomList.SelectedIndex]);

            cmbSensorGraph.DataSource = sensor.SensorName; 
            
            
            //cmbSensor.DataSource = sqlCom.Sensors;
            //sqlCom.GetSensors();
           // int SensorId = cmbSensor.SelectedIndex;
            // int tmpsensorid;




        }

       

        private void cmdDays_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void dateTimestartdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnShowDays_Click(object sender, EventArgs e)
        {
            testChange();
        }
        void testChange()
        {
            
            Color graphColor1, graphColor2;
            graphColor1 = Color.Gray;
            graphColor2 = Color.Green;
            int.TryParse(cmdDays.Text, out int days);
            Sensor sensor = new Sensor();


          
            int SensorId = cmbSensorGraph.SelectedIndex;
            //string tmpNAme = cmbSensorGraph.Text;
           
            for(int i = 0;i<= sensor.SensorId.Count-1; i++)
            {

                string sensName = cmbSensorGraph.Text;
                if(sensor.SensorName[i].Contains(sensName))
                {
                    SensorId = sensor.SensorId[i];
                }
            }

            
            
           
            Models.Graphing mygraph = new Models.Graphing(chrtSensorData, days, SensorId);
            //Models.Graphing mygraph2 = new Models.Graphing(graphColor1, graphColor2, chrtSensorData2, tmpsensorid, startdate, enddate);

            chrtSensorData.Update();
        }
        
        void testChange(DateTime startdate, DateTime enddate)
        {
            
            Color graphColor1, graphColor2;
            graphColor1 = Color.Gray;
            graphColor2 = Color.Green;
           // int.TryParse(cmdDays.Text, out int days);
            /*Models.SqlCommunication sqlCom = new Models.SqlCommunication();
            sqlCom.GetSensors();
            int SensorId = cmbSensor.SelectedIndex;
            */
            Sensor sensor = new Sensor();
            int tmpsensorid;

            tmpsensorid = sensor.SensorId[cmbSensorGraph.SelectedIndex];
            //string test = cmbSensor.Text;
   
            
            // Models.Graphing mygraph = new Models.Graphing(chrtSensorData, days, tmpsensorid);
            Models.Graphing mygraph2 = new Models.Graphing(graphColor1,graphColor2 ,chrtSensorData2, tmpsensorid, startdate, enddate);
            
            chrtSensorData2.Update();
        }

        private void btnSetDate_Click(object sender, EventArgs e)
        {
            testChange(dateTimestartdate.Value, dateTimeenddate.Value);
        }
        

        private void btnGetSensor_Click(object sender, EventArgs e)
        {
            //sensor = new Sensor(true);
            
            sqlCom.GetSensors("GetSensors", room.RoomNames[cmbRoomList.SelectedIndex]);
            //sensor = new Sensor();
            cmbSensorGraph.DataSource = null;
            cmbSensorGraph.DataSource = sensor.SensorName;
            
        }

        private void tabDays_Click(object sender, EventArgs e)
        {

        }

        private void frmGraphing_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

        }
    }
}
