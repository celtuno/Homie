using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Homie.Models
{
    class SqlCommunication
    {
        // Connectionstring to the database.
        string sqlConfig = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
        public List<string> UserData = new List<string>();
        Actuator newActuator;
        
        public SqlCommunication()
        {
            
            
        }


        public void ReadDaqName(string daqName,string daqAddress,int houseId,string daqModel)
        {
            Random random = new Random();
            DaqCommunication com = new DaqCommunication();
            //LoginUser user = new LoginUser();
            string DAQ, sqlQuery, DAQ1;
            //int houseId = user.UserHouse;
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    DAQ = com.AvailableDaq[0];
                    DAQ1 = "DAQ" + random.Next(0, 101);

                    sqlQuery = string.Concat(@"INSERT INTO DAQ(DaqAddress, DaqName,HouseId,DaqModel) 
                VALUES('" + daqAddress + " ', '", daqName, "', " + houseId + ",'" + daqModel + "' )");
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        //Retrieve the latest added daq from database
        public int GetLatestDaq()
        {
            string sqlQuery = "";
            int tmpDaqId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConfig))
                { 

                    //Query string for getteing the top1(1) (recently added) daq
                sqlQuery = string.Concat(@"SELECT TOP 1 DaqID FROM DAQ ORDER BY DaqID DESC");


                SqlCommand command;

                command = new SqlCommand(sqlQuery, con);
                command.CommandType = CommandType.Text;// Selecting command type.
                con.Open();//Opening the connection

                command.ExecuteNonQuery();    // Executing
                SqlDataReader dataReader = command.ExecuteReader();// Executing reader for the data
                while (dataReader.Read())//While loop
                {
                    int.TryParse(dataReader[0].ToString(), out tmpDaqId);

                }
                con.Close();
                }
            }

            //Exception/error handling
            catch (Exception error)
            {
                //Show error as a popup messagebux
                MessageBox.Show(error.Message);
                

            }
            return tmpDaqId;
            
        }

        public void GetDaqDigitalIo(int houseId)
        {
            DaqCommunication daqCom = new DaqCommunication();
            string sqlQuery = "";
            daqCom.SqlDigitalIoID.Clear();
            daqCom.SqlDigitalIoName.Clear();
            
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {

                    //Sql query string for selecting all daq io ports / channels
                    sqlQuery = string.Concat(@"SELECT * FROM GetDaqIo where HouseID = " + houseId + " AND IoType = 'Digital' AND IoInputOutput = 'Input' ORDER BY IoID");


                    SqlCommand command;

                    command = new SqlCommand(sqlQuery, con);
                    command.CommandType = CommandType.Text;// Selecting command type.
                    con.Open();//Opening the connection

                    command.ExecuteNonQuery();    // Executing
                    SqlDataReader dataReader = command.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read())//While loop
                    {
                        string tmpChannel = dataReader[1].ToString().Trim();
                        //Add det data from sql reader to daqCommunication class   
                        if (tmpChannel.Contains("line"))
                        { int.TryParse(dataReader[0].ToString(), out int tmpIoId);
                            daqCom.SqlDigitalIoID.Add(tmpIoId);
                            daqCom.SqlDigitalIoName.Add(dataReader[1].ToString().Trim());
                        }
                        else
                        {

                        }

                    }
                    con.Close();
                }
            }
            //Error handling
            catch (Exception error)
            {
                MessageBox.Show(error.Message);


            }
            

        }


        public void GetDaqAnalogIo(int houseId)
        {
            DaqCommunication daqCom = new DaqCommunication();
            string sqlQuery = "";
            daqCom.SqlAnalogIoID.Clear();
            daqCom.SqlAnalogIoName.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    //Sql query string for selecting analog ports / channels

                    sqlQuery = string.Concat(@"SELECT * FROM GetDaqIo where HouseID = " + houseId + " AND IoType = 'Analog' AND IoInputOutput = 'Input' ORDER BY IoID");


                    SqlCommand command;

                    command = new SqlCommand(sqlQuery, con);
                    command.CommandType = CommandType.Text;// Selecting command type.
                    con.Open();//Opening the connection

                    command.ExecuteNonQuery();    // Executing
                    SqlDataReader dataReader = command.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read())//While loop
                    {
                        //Add det analog channel data from sql reader to daqCommunication class   
                        int.TryParse(dataReader[0].ToString(), out int tmpIoId);
                        daqCom.SqlAnalogIoID.Add(tmpIoId);
                        daqCom.SqlAnalogIoName.Add(dataReader[1].ToString().Trim());

                    }
                    con.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);


            }


        }

        //Add daq channels - daqid freom daq device
        public void CreateDaqChannel(int daqId, string ioName, string ioAddress, string ioType, string ioInOut)
        {
            /*
             * From stored procedure: 
             * @DaqId int, @IoName char(30),@IoAddress char(8),@IoType char (30),@IoInputOutput char(15)
             */


            // Creates a new daq io channel in the DB


            
            try
            {
                //set up sql connection
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    //Select the stored proceddure to be used
                    SqlCommand cmd = new SqlCommand("CreateNewDAQIO", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add stored procedure parameters - with values from sender
                    //( @DaqId,@IoName,@IoAddress,@IoType,@IoInputOutput)
                    cmd.Parameters.Add(new SqlParameter("@DaqId", daqId));
                    cmd.Parameters.Add(new SqlParameter("@IoName", ioName));
                    cmd.Parameters.Add(new SqlParameter("@IoAddress", ioAddress));
                    cmd.Parameters.Add(new SqlParameter("@IoType", ioType));
                    cmd.Parameters.Add(new SqlParameter("@IoInputOutput", ioInOut));
                    //open sql an try command (stored procedure)
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //close sql
                    con.Close();
                }

            }//Error handling
            //get sql errors
            catch (SqlException ex)
            {
                

               
            }
        }





       
        //Write senordata to Sensor_log
        public void WriteSensorData(double sensorValue, int sensorId)
        {
            double roundSensorValue = Math.Round(sensorValue,2);
            

            // array for information of the selected user.
            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand = new SqlCommand("AddSensorValues", conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    sqlCommand.CommandType = CommandType.StoredProcedure;// Selecting command type.
                    conSql.Open();//Opening the connection
                    sqlCommand.Parameters.Add(new SqlParameter("@SensorValue", roundSensorValue));// Using the parameter from the stored procedure and giving it a number.
                    sqlCommand.Parameters.Add(new SqlParameter("@SensorId", sensorId));
                    sqlCommand.ExecuteNonQuery();// Executing

                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        public void WriteActuatorData(bool actuatorValue, int actuatorId)
        {

            
            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand = new SqlCommand("UpdateActuator", conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    sqlCommand.CommandType = CommandType.StoredProcedure;// Selecting command type.
                    conSql.Open();//Opening the connection

                    // Using the parameter from the stored procedure.

                    //@ActuatorID int, @ActuatorValue
                    sqlCommand.Parameters.Add(new SqlParameter("@ActuatorID", actuatorId));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActuatorValue", actuatorValue));

                    sqlCommand.ExecuteNonQuery();// Executing

                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //Get values from view 
        public void GetuserData(string userName)
        {

            // array for information of the selected user.
            try
            {
                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand = new SqlCommand("select * from GetCustomerData where Email ='" + userName + "'", conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection
                                  
                    //sqlCommand.Parameters.Add(new SqlParameter("@UserName", userName));
                    // Using the parameter from the stored procedure and giving it a number.
                                  
                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    string[] tmpUserData = new string[dataReader.FieldCount];
                    while (dataReader.Read() == true)//While loop
                    {
                        //DEBUG
                        //string tt = dataReader[2].ToString();
                        
                        int columns = dataReader.FieldCount;
                        for (int i = 0; i < columns - 1; i++)
                        {
                            //tmpUserData[i] = dataReader[i].ToString();// Reads the data from the database into the array UserData
                            //DEBUG
                            string ttt = tmpUserData[2];
                            //Add all sql data rows to user class
                            UserData.Add(dataReader[i].ToString());
                            

                        }


                    }

                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }

        }

       
        // Get all rooms from a house/user
        public void GetRooms(string viewName,int HouseId)//List<string> GetRooms(string viewName)
        {
            Room newRoom;
            newRoom = new Room(true);
            LoginUser loginUser = new LoginUser();
            try
            {
                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand = new SqlCommand("Select * from " + viewName+ " where HouseID = '" + loginUser.UserHouse + "' ORDER BY RoomID" , conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read() == true)//While loop
                    {

                        int.TryParse(dataReader[0].ToString(), out int roomId);
                        int.TryParse(dataReader[1].ToString(), out int houseId);
                        string roomName = dataReader[2].ToString();

                        newRoom = new Room(roomId, houseId, roomName.Trim());

                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            


        }

        
        public bool CreateNewRoom(int houseId,string roomName)
        {
            //@HouseId int,@RoomName char(30)

            try
            {
                //set up sql connection
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    //Select the stored proceddure to be used
                    SqlCommand cmd = new SqlCommand("CreateNewRoom", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add stored procedure parameters - with values from sender
                    //( @DaqId,@IoName,@IoAddress,@IoType,@IoInputOutput)
                    cmd.Parameters.Add(new SqlParameter("@HouseId", houseId));
                    cmd.Parameters.Add(new SqlParameter("@RoomName", roomName));

                    //open sql an try command (stored procedure)
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //close sql
                    con.Close();
                    return true;
                }

            }//Error handling
            //get sql errors
            catch (SqlException ex)
            {

                return false;

            }
        }
        //Get all sensors in a room by roomname

        public void GetSensors(string viewName, int roomId)//List<string> GetRooms(string viewName)
        {

            Sensor newSensor = new Sensor(true);
            
            List<string> inData = new List<string>();
            newSensor.SensorName.Clear();
            newSensor.SensorId.Clear();

            try
            {
                
                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand;
                   
                    sqlCommand = new SqlCommand("Select * from " + viewName + " WHERE RoomID = " + roomId , conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                   
                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    int tt = dataReader.FieldCount;
                    while (dataReader.Read() == true)//While loop
                    {
                        //Get and convert  data from sql reader

                        int.TryParse(dataReader[0].ToString(), out int tmpSensorId);
                        string dt = dataReader[1].ToString();
                        int.TryParse(dataReader[4].ToString(), out int tmpRoomId);

                        //Store data from sql reader to Sensor class
                        //string tmpSensorName,string tmpSensorTypeName, string tmpSensorUnit, string tmpRoomName, string tmpIoChannel
                        newSensor = new Sensor(tmpSensorId, dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), tmpRoomId, dataReader[5].ToString(), dataReader[6].ToString());//,dataReader[7].ToString()); //roomId, houseId, sensorName.Trim());
                        


                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //throw;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



        }



        //Get all sensors in a room by roomname
        public void GetSensors(string viewName, string roomName)//List<string> GetRooms(string viewName)
        {
            Sensor newSensor = new Sensor(true);
            LoginUser loginUser = new LoginUser();
            newSensor.SensorId.Clear();
            newSensor.SensorName.Clear();
            List<string> inData = new List<string>();

            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database


                    SqlCommand sqlCommand;
                    //CHoose sqlcommand wether to get all sensors or from a specified room
                    //sqlCommand with parameters for name of the stored precedure and connection.
                    if (roomName == "All")
                    {
                        sqlCommand = new SqlCommand("Select * from " + viewName + " where HouseID = " + loginUser.UserHouse, conSql);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("Select * from " + viewName + " WHERE RoomName = '" + roomName + "'", conSql);
                    }
                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    int tt = dataReader.FieldCount;
                    while (dataReader.Read() == true)//While loop
                    {
                        //Get and convert sensors from sql database

                        int.TryParse(dataReader[0].ToString(), out int tmpSensorId);
                        string dt = dataReader[1].ToString();
                        int.TryParse(dataReader[4].ToString(), out int tmpRoomId);

                        //string tmpSensorName,string tmpSensorTypeName, string tmpSensorUnit, string tmpRoomName, string tmpIoChannel
                        //Add sensors from from sql reader to sensor class   
                        newSensor = new Sensor(tmpSensorId, dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), tmpRoomId, dataReader[5].ToString(), dataReader[6].ToString());//,dataReader[7].ToString()); //roomId, houseId, sensorName.Trim());



                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //throw;
               MessageBox.Show(ex.Message);
            }



        }

        //Get all sensorlog elements for a specified sensorIdd
        public void GetSensorLog(string viewName, int sensorId)
        {
            List<string> inData = new List<string>();

            SensorLog sensorLog = new SensorLog(true);
            
            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand;

                    sqlCommand = new SqlCommand("Select Top(1) * from " + viewName + " WHERE SensorID = '"
                        + sensorId + "'" + " order by SensorLogID desc", conSql);//sqlCommand with parameters for name of the stored precedure and connection.


                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read() == true)//While loop
                    {

                       // Get and convert sensor data from sql, add them to the sensorlog class
                        int.TryParse(dataReader[0].ToString(), out int tmpSensorId);
                        string sensorName = dataReader[1].ToString();
                        double.TryParse(dataReader[2].ToString(), out double sensorValue);
                        string roomName = dataReader[3].ToString();
                        
                        double roundSensorValue = Math.Round(sensorValue, 2);
                        sensorLog.SensorId.Add(sensorId);
                        sensorLog.SensorName.Add(sensorName);
                        sensorLog.SensorValue.Add(roundSensorValue);
                        sensorLog.RoomName.Add(roomName);



                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //Get all sensors in a room
        public void GetSensorTypes(string viewName)//List<string> GetRooms(string viewName)
        {
             
            //initialize sensor class, and clear old values
            Sensor newSensorType = new Sensor(true);
            newSensorType.SensorTypeDescription.Clear();
            newSensorType.SensorTypes.Clear();
            newSensorType.SensorTypeIdType.Clear();

            List<string> inData = new List<string>();

            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand;

                    //
                    sqlCommand = new SqlCommand("Select * from " + viewName, conSql);//sqlCommand with parameters for name of the stored precedure and connection.

                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    int tt = dataReader.FieldCount;
                    while (dataReader.Read() == true)//While loop
                    {


                        // Get and convert sensor data from sql, add them to the sensor class
                        //From sql:   string tmpSensorName,string tmpSensorTypeName, string tmpSensorUnit, string tmpRoomName, string tmpIoChannel
                        int.TryParse(dataReader[0].ToString(), out int typeid);
                        newSensorType.SensorTypeIdType.Add(typeid);
                        newSensorType.SensorTypes.Add(dataReader[1].ToString());
                        newSensorType.SensorTypeDescription.Add(dataReader[3].ToString());




                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //throw;
               MessageBox.Show(ex.Message);
            }



        }


        //Get all actuators in a room
        public void GetActuators(string viewName, string roomName)//List<string> GetRooms(string viewName)
        {
            newActuator = new Actuator(true);
            newActuator.ActuatorValue.Clear();
            newActuator.ActuatorTypeName.Clear();
            //newActuator.ActuatorId.Clear();
            LoginUser loginUser = new LoginUser();
            
            List<string> inData = new List<string>();
            

            try
            {
                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand;
                   //Select wether to get all sensors or get only for one room
                    if (roomName == "All")
                    {
                        //All sensors from specific house
                        sqlCommand = new SqlCommand("Select * from " + viewName + " where HouseID = " + loginUser.UserHouse + " ORDER BY RoomID asc", conSql);//+ "GetActuators", conSql);
                    }
                    else
                    {
                        //Sensors from one specific room 
                        sqlCommand = new SqlCommand("Select * from " + viewName + " WHERE RoomName = '" + roomName + "' AND HouseID = " + loginUser.UserHouse, conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    }
                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read())//While loop
                    {

                        // Get and convert sensor data from sql, add them to the actuator class
                        int.TryParse(dataReader[0].ToString(), out int tmpActuatorId);
                        bool.TryParse(dataReader[2].ToString(), out bool tmpActuatorValue);
                        string tt = dataReader[2].ToString();
                        int tmpRoomId = Convert.ToInt32(dataReader[4].ToString());
                            //int.TryParse(dataReader[4].ToString(), out int tmpRoomId);

                        //string tmpSensorName,string tmpSensorTypeName, string tmpSensorUnit, string tmpRoomName, string tmpIoChannel
                        newActuator = new Actuator(tmpActuatorId, dataReader[1].ToString(), tmpActuatorValue, dataReader[3].ToString(), tmpRoomId, dataReader[5].ToString(), dataReader[6].ToString());//, dataReader[6].ToString()); //roomId, houseId, sensorName.Trim());



                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



        }
        //List/get all actoatortypes ( Light/fans etc..) 
        public void GetActuatorTypes(string viewName)
        {
            newActuator = new Actuator();
            //Actuator newActuatorType = new Actuator();
            newActuator.ActuatorTypeDescription.Clear();
            newActuator.ActuatorType.Clear();
            newActuator.ActuatorTypeId.Clear();
            
            List<string> inData = new List<string>();

            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand;

                    sqlCommand = new SqlCommand("Select * from " + viewName, conSql);//sqlCommand with parameters for name of the stored precedure and connection.

                    sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                    conSql.Open();//Opening the connection

                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    int tt = dataReader.FieldCount;
                    while (dataReader.Read() == true)//While loop
                    {
                        //Store values to actuator class, and convert values.
                        int typeId = Convert.ToInt32(dataReader[0].ToString());
                        newActuator.ActuatorTypeIdType.Add(typeId);
                        //string tmpSensorName,string tmpSensorTypeName, string tmpSensorUnit, string tmpRoomName, string tmpIoChannel
                        newActuator.ActuatorType.Add(dataReader[1].ToString().Trim());
                        newActuator.ActuatorTypeDescription.Add(dataReader[3].ToString());




                    }
                    conSql.Close();//Closing connection to the database.
                }
            }
            catch (Exception ex)
            {
                //throw;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



        }

        //Add sensors to database (Stored procedure)
        public bool AddSensor( int roomId, int sensorTypeId, int ioID, string sensorName)
        {
            // From stored procedure: 
            //  @RoomId int, @SensorTypeId int,@IOID int, @SensorName char(15)
        


            // Creates a new sensor in the DB


            //Error handling
            try
            {
                //set up sql connection
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    //Select the stored proceddure to be used
                    SqlCommand cmd = new SqlCommand("CreateSensor", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add stored procedure parameters - with values from sender
                    //( @DaqId,@IoName,@IoAddress,@IoType,@IoInputOutput)
                    cmd.Parameters.Add(new SqlParameter("@RoomId", roomId));
                    cmd.Parameters.Add(new SqlParameter("@SensorTypeId", sensorTypeId));
                    cmd.Parameters.Add(new SqlParameter("@IOID", ioID));
                    cmd.Parameters.Add(new SqlParameter("@SensorName", sensorName));
                    
                    //open sql an try command (stored procedure)
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //close sql
                    con.Close();
                    return true;
                }

            }
            //get sql errors
            catch (SqlException ex)
            {
                return false;

               
            }

        }
        //Add acxtuators to database (Stored procedure)
        public bool AddActuator(bool actuatorValue ,int roomId ,int actuator_TypeID  ,int ioID ,string actuatorName )
        {
            //@ActuatorValue int, @RoomId int,@Actuator_TypeID int ,@IOID int, @ActuatorName char(15)


            // Creates a new sensor in the DB


            //Error handling
            try
            {
                //set up sql connection
                using (SqlConnection con = new SqlConnection(sqlConfig))
                {
                    //Select the stored proceddure to be used
                    SqlCommand cmd = new SqlCommand("CreateActuator", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add stored procedure parameters - with values from sender
                    //( @DaqId,@IoName,@IoAddress,@IoType,@IoInputOutput)
                    cmd.Parameters.Add(new SqlParameter("@ActuatorValue", actuatorValue));
                    cmd.Parameters.Add(new SqlParameter("@RoomId", roomId));
                    cmd.Parameters.Add(new SqlParameter("@Actuator_TypeID", actuator_TypeID));
                    cmd.Parameters.Add(new SqlParameter("@IOID", ioID));
                    cmd.Parameters.Add(new SqlParameter("@ActuatorName", actuatorName));

                    //open sql an try command (stored procedure)
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //close sql
                    con.Close();
                    return true;
                }

            }
            //get sql errors
            catch (SqlException ex)
            {

                return false;

            }

        }
        //Create database 
        public void CreateDatabase()
        {
            //unique connection string for database breation 
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=master;User ID=sa;Password=UsnPassword2020");
            try
            {

                conn.Open();
                //set sqlcreation script path
                string script = File.ReadAllText("DatabaseCreationWithSetup.sql");

                // split script on GO command
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        new SqlCommand(commandString, conn).ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Database created successfully.");

            }
            catch (SqlException er)
            {
                Console.WriteLine("Database creation failed.\r\n" + er.Message);

            }
        }

    }


}
