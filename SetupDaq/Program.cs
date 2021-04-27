using System;
using System.Xml;
using HomieLibrary;
//using Homie;
//using Homie.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SetupDaq
{
    class Program
    {
        static LoginUser loginUser = new LoginUser();
        static string daqName = "";
        static string daqModel;
        static string username;
        static int houseid;
        static string homieDBName = "HomeAutoDB";
        static SqlCommunication sqlCommunication = new SqlCommunication();
        static void Main(string[] args)
        {
            // int.TryParse(Console.ReadLine(), out hou);

            string myArgs = args[0];
            string[] argRef1 = { "-p", "/p", "-pw", "/password", "-password" };
            if (myArgs.Contains(argRef1[0])) // && args.Length >1 )
            {
                Console.WriteLine("\r\nPassword change mode!\r\n\r\n");
                UserLogin();
                Console.WriteLine("\r\nEnter new password:");
                string newPassw = Console.ReadLine();
                string hashpw = loginUser.ComputeSha256HashTmp(newPassw);
                loginUser.SetNewPassword(loginUser.UserId,hashpw);
                Console.WriteLine("\r\nPassword changed in database!\r\nNew password is :" + newPassw);
                Console.ReadLine();

                Environment.Exit(1337);
            }
            
            string addAll;
            string localDB;
            string readLineCheck;
            Console.WriteLine("Homie DAQ & DB 1st time setup.\r\n");
            Console.WriteLine("\r\nCreate local database?");
            readLineCheck = Console.ReadLine();
            readLineCheck = readLineCheck.ToLower();
            if (readLineCheck.Contains("y"))
            {
                try
                {
                    sqlCommunication.CreateDatabase();

                    Console.WriteLine("Sucsessfully created local database");
                }
                catch (Exception error)
                {
                    Console.WriteLine("Failed to create local database : " + error.Message);

                }               

            }
            else
            {
                Console.WriteLine("\r\nSkipped add: New local DB");                
            }

            Console.WriteLine("\r\n!Now, Use the web application to add a user!\r\nOpen Webbrowser?");
            readLineCheck = Console.ReadLine();
            readLineCheck = readLineCheck.ToLower();
            if (readLineCheck.Contains("y"))
            {
               /*OpenUrl("http://homie.gravastrand.no");*/

                OpenUrl("http://homieusn.azurewebsites.net/");

                //started web application site in browser, press enter to continue
                Console.WriteLine("Started the web application site in browser, press enter to continue");
                Console.ReadLine();
            }
            //Console.WriteLine("\r\nUsing a locally installed database?");
            //readLineCheck= Console.ReadLine();
            //readLineCheck = readLineCheck.ToLower();
            //if (!readLineCheck.Contains("y"))
            //{

            //    Console.WriteLine("\r\nEnter database address (dmoain name or ip):");
            //    localDB = Console.ReadLine();
            //    SetRemoteDB(localDB);
            //    Console.ReadLine();
            //}

            Console.WriteLine("\r\nLogin (to get houseid):");
            //username = Console.ReadLine();


            UserLogin();
           houseid = loginUser.UserHouse;
            Console.WriteLine("\r\n\r\nAdd all connected daq's? (Y/N):");
           
            addAll = Console.ReadLine();
            readLineCheck = addAll.ToLower();
            if (readLineCheck.Contains("y"))
            {
                AddDaq(houseid);
                
            }
            else
            {
                Console.WriteLine("\r\nSkipped add: DAQ to DB");
                ;
            }
            Room room = new Room();
            Console.WriteLine("\r\n\r\nAdd a room? (Y/N):");
            string addRoom = Console.ReadLine();
            readLineCheck = addRoom.ToLower();


            if (readLineCheck.Contains("y"))
            {

            addroom:
                try
                {
                    Console.WriteLine("\r\nType in roomname:");
                    string roomName = Console.ReadLine();
                    room.CreateNewRoom(houseid, roomName);
                    Console.WriteLine("\r\nRoom: " + roomName + " added succsessfully to house: " + loginUser.UserHouseName);
                }
                catch (XmlException error)
                {
                    Console.WriteLine("Error adding room :\r\n" + error.Message);
                }


                Console.WriteLine("\r\n\r\nAdd another room? (Y/N):");

      
                string addAnotherRoom = Console.ReadLine();
                readLineCheck = addAnotherRoom.ToLower();                
                if (readLineCheck.Contains("y"))
                {
                    goto addroom;
                }
            }
            else
            {
                Console.WriteLine("\r\nSkipped add: Room to DB");
                
            }
            

           
            

           
            
        }
        static private  void UserLogin()
        {
        login:
            string passw;
            //int.TryParse(Console.ReadLine(), out houseid);
            Console.WriteLine("\r\nEnter Username:");
            username =  Console.ReadLine();
            Console.WriteLine("\r\nEnter password:");
            passw = Console.ReadLine();
            loginUser = new LoginUser(username, passw);
            
            if (loginUser.UserValidated)
            {
                Console.WriteLine("\r\nSucsessfull login to house:\r\n" + loginUser.UserHouseName + "!");             

            }

            else
            {
                Console.WriteLine("Login failed!");
                goto login;
            
            }


        }

       static void AddDaq(int houseId)
        {
           
            DaqCommunication daqCommunication = new DaqCommunication();
            foreach (string daq in daqCommunication.AvailableDaq)
            { 
                Console.WriteLine("Daq address: " + daq);
                Console.WriteLine("Enter daq name:");
                daqName = Console.ReadLine();
                Console.WriteLine("Enter daq model:");
                daqModel = Console.ReadLine();
                try
                {
                    daqCommunication.DaqToDb(daqName, daq, daqModel, houseId);
                    
                    Console.WriteLine("Adding:\t" + daq + "\t  to house:\t" + loginUser.UserHouseName);
                }
                catch(Exception error)
                {
                    Console.WriteLine("\r\nFailed to add DAQ:\r\n"+ error.Message);
                }
            }
        }

        //open custom url based on os
        static private void OpenUrl(string url)
        {

            //Process myProcess = new Process();

            //try
            //{
            //    // true is the default, but it is important not to set it to false
            //    myProcess.StartInfo.UseShellExecute = true;
            //    myProcess.StartInfo.FileName = url;
            //    myProcess.Start();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        static private void SetRemoteDB(string dbAddress)
        {
           

            //
            //****

            //Assign new connection string to a variable
            //string newCnnStr = "Data Source=" + dbAddress + "\\SQLExpress;Initial Catalog=" + homieDBName + ";Persist Security Info=True;User ID=sa;Password=UsnPassword2020";

            //app.config path Homie Desktop
            //string appConfigPath = "..\\..\\..\\..\\Homie\\app.config"; //Environment.CurrentDirectory + "\\Lapp.config";

            //string environment = ConfigurationManager.AppSettings["Environment"];
            //ConfigurationManager.ConnectionStrings[environment].ConnectionString;
            //And Finally replace the value of setting
            //change in consoleapp
            //This method replaces the value at run time and also don't needs app.config for the same setting. It will have the va;ue till the application runs.

            //Properties.Settings.Default["Nameof_ConnectionString_inSettingFile"] = newCnnStr;



            //change in desktop
            //try
            //{
            //    XmlDocument doc = new XmlDocument();
            //    XmlNodeList itemNodes = doc.GetElementsByTagName("name");
            //    if (itemNodes.Count > 0)
            //    {
            //        foreach (XmlElement node in itemNodes)
            //        {
            //            node.InnerText = newCnnStr;
            //            Console.WriteLine($"StudentId {node.Attributes["sqlConnection"].Value} :name {node.InnerText}");
            //        }
                        
            //    }
            //    //XmlDocument doc = new XmlDocument();
            //    //doc.Load(appConfigPath);
            //    ////XmlNode root = doc.DocumentElement;
            //    ////"/Projects/Project[@ID=" + nodeId + "]"
            //    //XmlNode myNode = doc.SelectSingleNode("/configuration/connectionStrings[@name=sqlConnection]");//[@sqlConnection]");
            //   // myNode.Attributes[0].Value = newCnnStr;//Attributes["connectionString"].Value = newCnnStr;
            //    ////myNode.Value = newCnnStr;
            //    //doc.Save(appConfigPath);

            //    Console.WriteLine("Sucsessfully changed config to exsternal db address : " + dbAddress);
            //}
            //catch (XmlException error)
            //{
            //    Console.WriteLine("Error changing db address:\r\n"  + error.Message);
            //}
            

            //// Option2: Using Attribute.Value()   
            //var doc = XElement.Parse(tempXml);
            //var target = doc.Elements("Project")
            //        .Where(e => e.Attribute("ID").Value == "2")
            //        .Single();

            //target.Attribute("Name").Value = "Project2_Update";
            //doc.Save(Console.Out);
        }



    }
}
