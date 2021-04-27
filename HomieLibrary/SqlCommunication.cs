using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;


namespace HomieLibrary
{
    public class SqlCommunication
    {
        // Connectionstring to the database.
        string sqlConfig = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
        public List<string> UserData = new List<string>();
        
        
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
               
            }
        }
        public int GetLatestDaq()
        {
            string sqlQuery = "";
            int tmpDaqId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConfig))
                { 


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
            catch (Exception error)
            {
               
                

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


                    sqlQuery = string.Concat(@"SELECT * FROM GetDaqIo where HouseID = " + houseId + " AND IoType = 'Digital' AND IoInputOutput = 'Output' ORDER BY IoID");


                    SqlCommand command;

                    command = new SqlCommand(sqlQuery, con);
                    command.CommandType = CommandType.Text;// Selecting command type.
                    con.Open();//Opening the connection

                    command.ExecuteNonQuery();    // Executing
                    SqlDataReader dataReader = command.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read())//While loop
                    {
                        int.TryParse(dataReader[0].ToString(), out int tmpIoId);
                        daqCom.SqlDigitalIoID.Add(tmpIoId);
                        daqCom.SqlDigitalIoName.Add(dataReader[1].ToString().Trim());

                    }
                    con.Close();
                }
            }
            catch (Exception error)
            {
               


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


                    sqlQuery = string.Concat(@"SELECT * FROM GetDaqIo where HouseID = " + houseId + " AND IoType = 'Analog' AND IoInputOutput = 'Input' ORDER BY IoID");


                    SqlCommand command;

                    command = new SqlCommand(sqlQuery, con);
                    command.CommandType = CommandType.Text;// Selecting command type.
                    con.Open();//Opening the connection

                    command.ExecuteNonQuery();    // Executing
                    SqlDataReader dataReader = command.ExecuteReader();// Executing reader for the data
                    while (dataReader.Read())//While loop
                    {
                        int.TryParse(dataReader[0].ToString(), out int tmpIoId);
                        daqCom.SqlAnalogIoID.Add(tmpIoId);
                        daqCom.SqlAnalogIoName.Add(dataReader[1].ToString().Trim());

                    }
                    con.Close();
                }
            }
            catch (Exception error)
            {
               


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





        /*
        //Get values from view 
        public List<Object> GetView(string viewName)
        {
            List<object> inData = new List<object>();
            //[] inData;// = new string[7];// array for information of the selected user.
            //inData = viewData;
            try
            {
                SqlConnection conSql = new SqlConnection(sqlConfig);//Connection to database
                SqlCommand sqlCommand = new SqlCommand("Select * from " + viewName, conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                conSql.Open();//Opening the connection
                //sqlCommand.Parameters.Add(new SqlParameter("@RoomId", RoomId));// Using the parameter from the stored procedure and giving it a number.
                //sqlCommand.Parameters.Add(new SqlParameter("@HouseId", HouseId));
                sqlCommand.ExecuteNonQuery();// Executing
                SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                while (dataReader.Read() == true)//While loop
                {

                    
                    int i = dataReader.FieldCount;
                        
                        
                        // Reads the data from the database into the array UserData
                        inData[i] = dataReader[i].ToString();

                   
                    
                    //inData.Add(dataReader[1]);

                    inData.Add(dataReader[2]);
                    
                    //inData[2] = dataReader[2].ToString();

                    //inData[0] = dataReader[3];
                    //inData[1] = dataReader[1];
                    //inData[2] = dataReader[2].ToString();

                    //Sensor[4] = dataReader[4].ToString();
                    //Sensor[5] = dataReader[5].ToString();
                    //SensorData [6] = dataReader[6].ToString();




                }
                conSql.Close();//Closing connection to the database.

            }
            catch (Exception ex)
            {
               System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return inData;// Return the array UserData.

        }
    */
        //Write senordata to Sensor_log
        public void WriteSensorData(double sensorValue, int sensorId)
        {

            // array for information of the selected user.
            try
            {

                using (SqlConnection conSql = new SqlConnection(sqlConfig))
                {//Connection to database
                    SqlCommand sqlCommand = new SqlCommand("AddSensorValues", conSql);//sqlCommand with parameters for name of the stored precedure and connection.
                    sqlCommand.CommandType = CommandType.StoredProcedure;// Selecting command type.
                    conSql.Open();//Opening the connection
                    sqlCommand.Parameters.Add(new SqlParameter("@SensorValue", sensorValue));// Using the parameter from the stored procedure and giving it a number.
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
                                  //sqlCommand.Parameters.Add(new SqlParameter("@UserName", userName));// Using the parameter from the stored procedure and giving it a number.
                                  //sqlCommand.Parameters.Add(new SqlParameter("@HouseId", HouseId));
                    sqlCommand.ExecuteNonQuery();// Executing
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();// Executing reader for the data
                    string[] tmpUserData = new string[dataReader.FieldCount];
                    while (dataReader.Read() == true)//While loop
                    {
                        //string tt = dataReader[2].ToString();
                        //string ttt = tt;
                        int columns = dataReader.FieldCount;
                        for (int i = 0; i < columns - 1; i++)
                        {
                            //tmpUserData[i] = dataReader[i].ToString();// Reads the data from the database into the array UserData
                            string ttt = tmpUserData[2];
                            UserData.Add(dataReader[i].ToString());

                        }


                        //UserData[1] = dataReader[1].ToString();
                        //UserData[2] = dataReader[2].ToString();
                        //UserData[3] = dataReader[3].ToString();
                        //UserData[4] = dataReader[4].ToString();
                        //UserData[5] = dataReader[5].ToString();
                        //UserData[6] = dataReader[6].ToString();
                        //UserData.Add(tmpUserData);
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
        
        
        public void CreateNewRoom(int houseId,string roomName)
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
                }

            }//Error handling
            //get sql errors
            catch (SqlException ex)
            {



            }
        }


        //Get all sensors in a room
       


        public void AddSensor( int roomId, int sensorTypeId, int ioID, string sensorName)
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
                }

            }
            //get sql errors
            catch (SqlException ex)
            {
                

               
            }

        }

        public void AddActuator(bool actuatorValue ,int roomId ,int actuator_TypeID  ,int ioID ,string actuatorName )
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
                }

            }
            //get sql errors
            catch (SqlException ex)
            {



            }

        }
        public void CreateDatabase()
        {

            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=UsnPassword2020");
            try
            {

                conn.Open();

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
