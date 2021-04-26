using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homie.Models
{
    class SensorLog
    {

        //static variables for storing sensor log data
        static List<int> sensorId = new List<int>();
        static List<string> sensorName = new List<string>();
        static List<double> sensorValue = new List<double>();
        static List<string> roomName = new List<string>();


        //public variant of variables for reading and changin static variables
        public List<int> SensorId
        {
            get { return sensorId; }
            set { sensorId = value; }
        }
        public List<string> SensorName
        {
            get { return sensorName; }
            set { sensorName= value; }
        }
        public List<double> SensorValue
        {
            get { return sensorValue; }
            set { sensorValue = value; }
        }
        public List<string> RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }


        public SensorLog()
        {

        }

        public SensorLog(bool status)
        {

            //Clear all values if variblae  is true
            if (status)
            {
                sensorId.Clear();
                sensorName.Clear();
                sensorValue.Clear();
                roomName.Clear();
            }
        }


        //execute sql class element sensorlog for a specific sensor
        public void GetSensorLog(int sensorId)
        {
            //innitialize sql class
            SqlCommunication sqlCom = new SqlCommunication();
            //run sqlclass with sensor id
            sqlCom.GetSensorLog("GetSensorLog", sensorId);


        }

    }
}
