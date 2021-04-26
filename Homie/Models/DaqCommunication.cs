using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments;

using Homie.Models;

namespace Homie.Models
{
    public class DaqCommunication 
    {
        public double analogdataRead;
        public bool digitalDataRead;
        //public double analogDataWrite;
        


            //Lists with daq device and channel info
        public List<string> AvailableDaq = new List<string>();
        
        public List<string> AllChannels = new List<string>();
        static List<string> analogInchannels = new List<string>();
        public List<string> AnalogOutchannels = new List<string>();
        public List<string> DigitalInPorts = new List<string>();
        public List<string> DigitalOutPorts = new List<string>();
        public List<string> DigitalInLines = new List<string>();
        public List<string> DigitalOutLines = new List<string>();
        static List<int> sqlDigitalIoID = new List<int>();
        static List<string> sqlDigitalIoName = new List<string>();
        static List<int> sqlAnalogIoID = new List<int>();
        static List<string> sqlAnalogIoName = new List<string>();

        public List<int> SqlDigitalIoID
        {
            get { return sqlDigitalIoID; }
            set { sqlDigitalIoID= value; }
        }
        public List<string> SqlDigitalIoName
        {
            get { return sqlDigitalIoName; }
            set { sqlDigitalIoName= value; }
        }

        public List<int> SqlAnalogIoID
        {
            get { return sqlAnalogIoID; }
            set { sqlAnalogIoID= value; }
        }
        public List<string> SqlAnalogIoName
        {
            get { return sqlAnalogIoName; }
            set { sqlAnalogIoName = value; }
        }

        public List<string> AnalogInchannels
        {
            get { return analogInchannels; }
            set { analogInchannels = value; }
        }
        //Array of digital output statuses
        static bool[] digitalValueArray = new bool[12];

        static double[] analogValueArray = new double[32];// analogInchannels.Count];
        public double[] analogValueArray1 = new double[4];

        public double[] AnalogValueArray
        {
            get { return analogValueArray; }
            //set { analogValueArray = value; }
        }

        public bool[] DigitalValueArray
        {
            get { return digitalValueArray; }
            //set { digitalValueArray = value; }
        }


        public enum IOTypes
        {
            Input,
            Output
        }
        public enum channelList
        {
            All_Channels, Analog_In_Channels, Analog_Out_Channels,
            Digital_In_Ports, Digital_Out_Ports, Digital_In_Lines, Digital_Out_Lines
        }
        public enum ioTypeList
        {
            Analog, Digital
        }




        public DaqCommunication()
        {
            //Get daq information
           ReadDaqDevices();

        }

        
        //Read all device and channel info from NI dll class.
        public void ReadDaqDevices()

        {
            AllChannels.Clear();
            //NationalInstruments.DAQmx.
            AvailableDaq.Clear();
            //Read availble daq devices         

            if (NationalInstruments.DAQmx.DaqSystem.Local.Devices == null){
                throw new DaqException("No daqdevices found, check your DAQ(s) and try to login again.");

                
            }
            foreach (string device in NationalInstruments.DAQmx.DaqSystem.Local.Devices)
            {
                
                
                //Save Daq device to list 
                AvailableDaq.Add(device);
            }

            //Read All Available DAQ channels
            foreach (string channel in NationalInstruments.DAQmx.DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.All, PhysicalChannelAccess.All))
            {
                //Save daq channel to list
                AllChannels.Add(channel);
            }

            //Save   seperate channels to seperate list
            analogInchannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.All).ToList();
            AnalogOutchannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.All).ToList();
            DigitalInPorts = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DIPort, PhysicalChannelAccess.All).ToList();
            DigitalOutPorts = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOPort, PhysicalChannelAccess.All).ToList();
            DigitalInLines = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DILine, PhysicalChannelAccess.All).ToList();
            DigitalOutLines = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOLine, PhysicalChannelAccess.All).ToList();


        }
       
        //Read digfitlal in channels ( NB!! - disables existing digital out channels)
        public void ReadDigitalIn(string channel)
        { try
            {


                bool dataIn;
                using (NationalInstruments.DAQmx.Task digitalInTask = new NationalInstruments.DAQmx.Task())
                {
                    DIChannel dIChannel;
                    dIChannel = digitalInTask.DIChannels.CreateChannel(channel, "DIChannel", ChannelLineGrouping.OneChannelForEachLine);

                    DigitalSingleChannelReader digitalSingleChannel = new DigitalSingleChannelReader(digitalInTask.Stream);


                    dataIn = digitalSingleChannel.ReadSingleSampleSingleLine();// ReadSingleSamplePortByte();

                    digitalDataRead = dataIn;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Read array of analog channels
        public void ReadAnalogIn(string[] channels)
        {
            analogValueArray = new double[analogInchannels.Count];
            //double Temp;
            //Read analog in channel (Hardcoded)

            NationalInstruments.DAQmx.Task analogintask;//= new NationalInstruments.DAQmx.Task();
           

            for (int i = 0 ; i <= channels.Count()-1; i++)//foreach (string channel in channels)
            { analogintask = new NationalInstruments.DAQmx.Task();
                AIChannel aIChannelLoop;
                aIChannelLoop = analogintask.AIChannels.CreateVoltageChannel(channels[i], "AiChannel", AITerminalConfiguration.Rse, 0, 5, AIVoltageUnits.Volts);

                AnalogSingleChannelReader channelReader = new AnalogSingleChannelReader(analogintask.Stream);
                try
                {
                    double analogDataInn = channelReader.ReadSingleSample();
                    //double tempConvert = ((((analogDataInn - 0.5) * 100)));
                    analogdataRead = analogDataInn;//tempConvert;
                    analogValueArray[i] = (analogdataRead*5)/0.1;
                }
                  
                catch (Exception)
                {

                    throw;
                }
            }
        }                                            

        // Read analog channel, WITH conversion depending on sensortype
        public void ReadAnalogIn(string deviceChannel, string sensortype)
        {
            double Temp;
            // Initialize daq, with task and channel
            NationalInstruments.DAQmx.Task analogintask = new NationalInstruments.DAQmx.Task();
            AIChannel aIChannel;
            
            //analog in channel (from input) Unit, and limits
            
            try
            {
                aIChannel = analogintask.AIChannels.CreateVoltageChannel(deviceChannel, "AiChannel", AITerminalConfiguration.Rse, 0, 5, AIVoltageUnits.Volts);
            
               AnalogSingleChannelReader channelReader = new AnalogSingleChannelReader(analogintask.Stream);   
                //conversion constants
                //double Vin = 5;
                //double Ro = 10000;
                double analogDataInn = channelReader.ReadSingleSample();
                analogdataRead =  ConvertAnalog(analogDataInn, sensortype);
                /*switch (sensortype)
                {       
                        case "termo":
                         Vin = 5;
                         Ro = 10000; // 10k Resistor
                        double Rt = (analogDataInn * Ro) / (Vin - analogDataInn);
                        //Rt = 10000; //Used for Testing. Setting Rt = 10k should give TempC = 25
                        //Steinhart Constants
                        double A = 0.001129148;
                        double B = 0.000234125;
                        double C = 0.0000000876741;
                        //Steinhart-Hart Equation
                        double TempK = 1 / (A + (B * Math.Log(Rt)) + C * Math.Pow(Math.Log(Rt), 3));
                        //Convert from Kelvin to Celsius
                        double thermistorTempC = TempK - 273.15;
                        Temp = thermistorTempC;
                        analogdataRead = Temp;

                        break;

                    case "tmp":

                        //convert volts to Celcius
                        double tempConvert = (((analogDataInn-0.5) *100));
                        
                        Temp = tempConvert;
                        analogdataRead = Temp;

                        break;

                    case "light":
                       
                        Ro = 32000; // 32k Resistor
                        double lightConvert;

                        //convert voltage to lux
                        double RtLight = (analogDataInn * Ro) / (Vin - analogDataInn);                        
                        lightConvert = (Math.Pow(10.25,7))*Math.Pow(RtLight,(-1.4059));
                        
                        analogdataRead = lightConvert;
                                                
                        break;

                    default:
                        analogdataRead = analogDataInn;
                        
                        break;

                } */             
                

            }
            catch (DaqException daqError)
            {
                throw (new MyDaqError(daqError.Message));

            }
        }



        //ConvertAnalog values

        public double ConvertAnalog(double analogData, string sensorType)
        {
            double Vin = 5;
            double Ro = 10000;
            double analogDataInn = analogData;
            switch (sensorType)
            {
                case "termo":
                    Vin = 5;
                    Ro = 10000; // 10k Resistor
                    double Rt = (analogDataInn * Ro) / (Vin + analogDataInn);
                    //Rt = 10000; //Used for Testing. Setting Rt = 10k should give TempC = 25
                    //Steinhart Constants
                    double A = 0.001129148;
                    double B = 0.000234125;
                    double C = 0.0000000876741;
                    //Steinhart-Hart Equation
                    double TempK = 1 / (A + (B * Math.Log(Rt)) + C * Math.Pow(Math.Log(Rt), 3));
                    //Convert from Kelvin to Celsius
                    double thermistorTempC = 273.15-TempK +75;
                    //break;
                    return thermistorTempC;
                    

                    

                case "tmp":

                    //convert volts to Celcius
                    double tempConvert = (((analogDataInn - 0.5) * 100));

                    return  tempConvert;
                  

                    //break;

                case "light":

                    Ro = 32000; // 32k Resistor
                    double lightConvert;

                    //convert voltage to lux
                    double RtLight = (analogDataInn * Ro) / (Vin - analogDataInn);
                    lightConvert = (Math.Pow(10.25, 7)) * Math.Pow(RtLight, (-1.4059));

                   return lightConvert;

                    //break;

                default:
                    return analogDataInn;

                    //break;

            }
        }


        //Read digital port sql array



        //Write to analog out channel
        public void WriteAnalogOut(string channel)
        {

            //Write to analog out channel (Hardcoded)
            NationalInstruments.DAQmx.Task analogouttask = new NationalInstruments.DAQmx.Task();
            AOChannel aOChannel;
            aOChannel = analogouttask.AOChannels.CreateVoltageChannel(channel, "AoChannel", 0, 255, AOVoltageUnits.Volts);
            AnalogSingleChannelWriter channelWriter = new AnalogSingleChannelWriter(analogouttask.Stream);
            try
            {
                channelWriter.WriteSingleSample(true, 150);

            }
            catch (Exception)
            {

                throw;
            }

        }

        //Write several (array) digital lines       
       /* public void WriteDigitalOut(bool[] Channelstatus, string[] channel)
        {
            int i = 0;
            int lastValue = 2;
            try
            {
                bool[] boolArray = { Channelstatus[0], Channelstatus[1], Channelstatus[2], Channelstatus[3], Channelstatus[4],
                    Channelstatus[5], Channelstatus[6], Channelstatus[7] };

                for ( i = boolArray.Count() - 1; i >= 0; i--)
                {

                    digitalValueArray[i] = Convert.ToInt32(boolArray[i]);
                    lastValue = digitalValueArray[i];
                }

                //Write digital signal out 
                NationalInstruments.DAQmx.Task digitalOutTask = new NationalInstruments.DAQmx.Task();
                digitalOutTask.DOChannels.CreateChannel(channel[i], //"dev6/Port0/line0:7",
                    "digitalOutChannels",
                    ChannelLineGrouping.OneChannelForAllLines);

                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalOutTask.Stream);
                writer.WriteSingleSampleMultiLine(true, boolArray);

            }
            catch (DaqException daqError)
            {
                throw (new MyDaqError(channel[i], lastValue, daqError.Message));
            }

        }*/


        //Write to several (array) digital lines       
        public void WriteDigitalOut(bool[] Channelstatus, string channel)
        {
            //digitalValueArray = new bool[DigitalInLines.Count];
            bool lastValue = false;
            try
            {
                bool[] boolArray = { Channelstatus[0], Channelstatus[1], Channelstatus[2], Channelstatus[3], Channelstatus[4], 
                    Channelstatus[5], Channelstatus[6], Channelstatus[7] };
                //loop through 
                for (int i = boolArray.Count() - 1; i >= 0; i--)
                {

                    digitalValueArray[i] = boolArray[i];
                    lastValue = digitalValueArray[i];
                }
                
                //Write digital signal out 
                NationalInstruments.DAQmx.Task digitalOutTask = new NationalInstruments.DAQmx.Task();
                digitalOutTask.DOChannels.CreateChannel(channel, 
                    "digitalOutChannels",
                    ChannelLineGrouping.OneChannelForAllLines);                

                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalOutTask.Stream);                
                writer.WriteSingleSampleMultiLine(true, boolArray);                
                
            }
            catch (DaqException daqError)
            {
                throw (new MyDaqError(channel, lastValue, daqError.Message));
            }
            
        }
        
        //Write to singel digital line        
        public void WriteDigitalOut(bool myValue, string channel, int channelIndex)
        {
            digitalValueArray = new bool[DigitalInLines.Count];
            int myValueInt = 2;
            try
            {
                myValueInt = Convert.ToInt16(myValue);
                //Write digital signal out (Hardcoded)
                using (NationalInstruments.DAQmx.Task digitalOutTask = new NationalInstruments.DAQmx.Task())
                {
                    digitalOutTask.DOChannels.CreateChannel(channel,
                        "digitalOutChannels",
                        ChannelLineGrouping.OneChannelForAllLines);


                    DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalOutTask.Stream);
                    writer.WriteSingleSampleSingleLine(true, myValue);


                    int testintind = channelIndex;
                   
                    //DEBUG
                    //Skip port, show onli digital lines
                    //if ( channelIndex >= 9)// ||channelIndex =  )
                    //{
                    //    digitalValueArray[channelIndex -1] = myValue;// myValueInt;
                    //}
                    //else
                    //{
                    //digitalValueArray[channelIndex] = myValue;// myValueInt;

                    //}
                }
            }
            catch(DaqException daqError)
            {
                throw(new MyDaqError(channel, myValue, daqError.Message));
            }


        }
        


        //Read all analog ports and get digital status from array where type is analog/digital -in.
        public List<string> ReadAllPortValues(int channelType)
        {
            digitalValueArray = new bool[DigitalInLines.Count];
            analogValueArray = new double[analogInchannels.Count];
            List<string> returnValuesList = new List<string>();
            ReadDaqDevices();
           // List<double> analogValues = new List<double>();
            //List<bool> digitalValues = new List<bool>();
            
            switch (channelType) {

                case 0:
                    //Get all analog values
                    
                    ReadAnalogIn(AnalogInchannels.ToArray());
                    foreach(double analogValue in analogValueArray)//foreach (string channel in AnalogInchannels)
                    {

                        //string[] testenum = Enum.GetNames(typeof(ioTypeList));
                        
                        returnValuesList.Add(analogValue.ToString(" 0.000"));
                    }
                    break;

                case 1:
                    //Gat digital values from array
                    
                    foreach(bool digitalStatus in digitalValueArray)
                    {
                        returnValuesList.Add(digitalStatus.ToString());

                    }
                                       
                    //read all digital lines(sets all outputs to inputs (0) )
                    /*foreach (string channel in DigitalInLines)
                    {
                        //string[] testenum = Enum.GetNames(typeof(ioTypeList));
                        ReadDigitalIn(channel);//,testenum[channelType]);
                        bool lastValue = digitalDataRead;
                        digitalValues.Add(lastValue);
                        returnValuesList.Add(lastValue.ToString());
                        //MessageBox.Show(lastValue.ToString());                                                                      
                    }*/
                   
                    break;

            }
            return returnValuesList;
        }


        //Write collected daq information to Database
        public bool DaqToDb(string daqName,  string daqAddress,string daqModel, int houseId)
        {
            try
            {
                SqlCommunication sqlCom = new SqlCommunication();
                DaqCommunication daqCom = new DaqCommunication();




                //Daqio:   @DaqId int, @IoName char(30),@IoAddress char(8),@IoType char(30),@IoInputOutput char(15)

                sqlCom.ReadDaqName(daqName, daqAddress, houseId, daqModel);

                List<string> channelList = new List<string>();
                //testList = daq.AnalogInchannels; 
                string tmpIOType;// = Models.daqTest.ioTypeList.Analog.ToString();
                string tmpIO;// = Models.daqTest.IOTypes.Input.ToString();
                int daqId = 0;
                daqId = sqlCom.GetLatestDaq();

                /*
                 * 
                 * Loop through all channels and add to the earlier added daq device id
                 */

                //Analog  input channels
                for (int i = 0; i < daqCom.AnalogInchannels.Count; i++)
                {
                    channelList = daqCom.AnalogInchannels;
                    tmpIOType = ioTypeList.Analog.ToString();
                    tmpIO = IOTypes.Input.ToString();
                    string tmpChnl = channelList[i];
                    //string[] tmp2 = tmpChnl.Split('/');
                    sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                }
                //Analog output channels
                for (int i = 0; i < daqCom.AnalogOutchannels.Count; i++)
                {
                    channelList = daqCom.AnalogOutchannels;
                    tmpIOType = ioTypeList.Analog.ToString();
                    tmpIO = IOTypes.Output.ToString();
                    string tmpChnl = channelList[i];
                    //string[] tmp2 = tmpChnl.Split('/');
                    sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                }
                //Digital input ports(PORT)
                for (int i = 0; i < daqCom.DigitalInPorts.Count; i++)
                {
                    channelList = daqCom.DigitalInPorts;
                    tmpIOType = ioTypeList.Digital.ToString();
                    tmpIO = IOTypes.Input.ToString();
                    string tmpChnl = channelList[i];
                    //string[] tmp2 = tmpChnl.Split('/');
                    sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                }
                //Digital output ports(PORT)
                for (int i = 0; i < daqCom.DigitalOutPorts.Count; i++)
                {
                    string tmpChnl="";
                    channelList = daqCom.DigitalOutPorts;
                    tmpIOType = ioTypeList.Digital.ToString();
                    tmpIO = IOTypes.Output.ToString();
                    if (channelList[i].Contains("line"))
                    {
                         tmpChnl = channelList[i];
                        sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                    }
                    //string[] tmp2 = tmpChnl.Split('/');
                   
                }
                //Digital input lines(LINE)
                for (int i = 0; i < daqCom.DigitalInLines.Count; i++)
                {
                    channelList = daqCom.DigitalInLines;
                    tmpIOType = ioTypeList.Digital.ToString();
                    tmpIO = IOTypes.Input.ToString();
                    string tmpChnl = channelList[i];
                    //string[] tmp2 = tmpChnl.Split('/');
                    sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                }
                //Digital output lines(LINE)
                for (int i = 0; i < daqCom.DigitalOutLines.Count; i++)
                {
                    channelList = daqCom.DigitalOutLines;
                    tmpIOType = ioTypeList.Digital.ToString();
                    tmpIO = IOTypes.Output.ToString();
                    string tmpChnl = channelList[i];
                    //string[] tmp2 = tmpChnl.Split('/');
                    sqlCom.CreateDaqChannel(daqId, tmpIOType + tmpIO + i, tmpChnl, tmpIOType, tmpIO);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        

    }

    //Custom daq error handling
    class MyDaqError : Exception
    {
        public MyDaqError()
        {

        }
        public MyDaqError(string daqError)
            : base(String.Format("Error reading daq: {0}\r\n",daqError))
        {

        }

        public MyDaqError(string channel, bool digitalValue, string daqErrorMessage)
            : base(String.Format("Error writing value: {0}\r\nto channel: {1}",digitalValue, channel))
        {

        }

    }
}
