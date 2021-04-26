using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
namespace HomieLibrary 
{ 

    public class LoginUser : SqlCommunication
    {

        readonly string sqlCon = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;

        static bool userValidated;
        static string userName, returnError;
        static int userHouse, userId;
        static string userHouseName;


        public string ReturnError
        {
            get { return returnError; }
            set { returnError = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public bool UserValidated

        {
            get { return userValidated; }
            set { userValidated = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public int UserHouse
        {
            get { return userHouse; }
            set { userHouse = value; }
        }
        public string UserHouseName
        {
            get { return userHouseName; }
            set { userHouseName = value; }
        }


        public LoginUser()
        {
            
        }


        public LoginUser(string user, string passw)
        {
            //bool loginOk = false;
            try
            {
                //loginOk = 
                string tmpPass = ComputeSha256HashTmp(passw);

                checkLogin(user, tmpPass);
                if (UserValidated)
                {
                    SqlCommunication sqlCom = new SqlCommunication();
                    sqlCom.GetuserData(userName);
                    string tt = sqlCom.UserData[2].ToString();
                    
                    userHouseName = sqlCom.UserData[7].ToString();
                    userId = Convert.ToInt32(sqlCom.UserData[0]);
                    int.TryParse(tt, out int tmpHouse);
                    userHouse = tmpHouse;
                }
                //ReturnError = "Username or password is: " + loginOk;
                //MessageBox.Show("Login vas valid:  " + loginOk + "\r\n");
            }
            catch (SqlException loginError)
            {
                //MessageBox.Show(loginError.Message);

                
                ReturnError = loginError.Message;
                throw new InvalidLogin(loginError);
            }
        }



        public bool checkLogin(string strUser, string strPass)
        {

            string userNameParam = "@UserName";
            string passwordParam = "@password";
            SqlCommunication sqlCom = new SqlCommunication();

            SqlConnection conSql = new SqlConnection(sqlCon);//Connection to database
            //SqlCommand sqlCommand = new SqlCommand(StoredProcedure, conSql);//sqlCommand with parameters for name of the stored precedure and connection.

            SqlCommand sqlCommand = new SqlCommand("uspLogIn", conSql);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter tmpuserName = new SqlParameter(userNameParam, SqlDbType.VarChar, 15);
            tmpuserName.Direction = ParameterDirection.Input;
            tmpuserName.Value = strUser;
            SqlParameter password = new SqlParameter(passwordParam, SqlDbType.VarChar, 64);
            password.Direction = ParameterDirection.Input;
            password.Value = strPass;
            SqlParameter loginSuccessful = new SqlParameter("@tmp", SqlDbType.Bit);
            loginSuccessful.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(tmpuserName);
            sqlCommand.Parameters.Add(password);
            sqlCommand.Parameters.Add(loginSuccessful);
            conSql.Open();
            sqlCommand.ExecuteNonQuery();
            conSql.Close();
            bool result = Convert.ToBoolean(loginSuccessful.Value);

            if (result)
            {
                userValidated = result;
                UserName = strUser;

                return true;

            }
            else
            {
                userValidated = false;
                UserName = "";
                return false;

            }


        }

        public void SetNewPassword(int userId, string newHashPassw)
        {
            string userNameParam = "@UserID";
            string passwordParam = "@password";
            SqlCommunication sqlCom = new SqlCommunication();

            SqlConnection conSql = new SqlConnection(sqlCon);//Connection to database
            //SqlCommand sqlCommand = new SqlCommand(StoredProcedure, conSql);//sqlCommand with parameters for name of the stored precedure and connection.

            SqlCommand sqlCommand = new SqlCommand("UpdatePassw", conSql);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter tmpuserName = new SqlParameter(userNameParam, SqlDbType.Int);
            tmpuserName.Direction = ParameterDirection.Input;
            tmpuserName.Value = userId;
            SqlParameter password = new SqlParameter(passwordParam, SqlDbType.VarChar, 64);
            password.Direction = ParameterDirection.Input;
            password.Value = newHashPassw;
            
            sqlCommand.Parameters.Add(tmpuserName);
            sqlCommand.Parameters.Add(password);
            
            conSql.Open();
            sqlCommand.ExecuteNonQuery();
            conSql.Close();
        }

        public string ComputeSha256HashTmp(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
    class InvalidLogin : Exception
    {
        public InvalidLogin(SqlException sqlException)
            : base(String.Format("Database error: \r\n" + sqlException.Message ),sqlException)
        {

        }

        public InvalidLogin(string userName)
            : base(String.Format("Invalid Username or password\r\nUsername: {0}", userName))
        {

        }

    }
}
