using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using NationalInstruments.DAQmx;

namespace Homie.Models
{
    class DaqWrite
    {
        public static int[] digitalValueArray = new int[13];

        public int[] DigitalValueArray
        {
            get { return digitalValueArray; }
            set { digitalValueArray = value; }
        }

        public DaqWrite() 
        {
            
        }



        public void WriteAnalogOut()
        {

            //Write to analog out channel (Hardcoded)
            Task analogouttask = new NationalInstruments.DAQmx.Task();
            AOChannel aOChannel;
            aOChannel = analogouttask.AOChannels.CreateVoltageChannel("dev6/aO0", "AoChannel", 0, 255, AOVoltageUnits.Volts);
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

        public void WriteDigitalOut(bool[] Channelstatus)
        {
            //Write digital signal out (Hardcoded)
            NationalInstruments.DAQmx.Task digitalOutTask = new NationalInstruments.DAQmx.Task();
            digitalOutTask.DOChannels.CreateChannel("dev6/Port0/line0:7",
                "digitalOutChannels",
                ChannelLineGrouping.OneChannelForAllLines);

            bool[] boolArray = { Channelstatus[0], Channelstatus[1], Channelstatus[2], Channelstatus[3], Channelstatus[4], Channelstatus[5], Channelstatus[6], Channelstatus[7] };

            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalOutTask.Stream);
            writer.WriteSingleSampleMultiLine(true, boolArray);

        }

        public void WriteDigitalOut(bool myValue, string channel, int channelIndex)
        {
            //Write digital signal out (Hardcoded)
            NationalInstruments.DAQmx.Task digitalOutTask = new NationalInstruments.DAQmx.Task();
            digitalOutTask.DOChannels.CreateChannel(channel,
                "digitalOutChannels",
                ChannelLineGrouping.OneChannelForAllLines);
            

            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalOutTask.Stream);
            writer.WriteSingleSampleSingleLine(true, myValue);

            int myValueInt = Convert.ToInt16(myValue);
            //int testintind = channelIndex;
            digitalValueArray[channelIndex] = myValueInt;



        }

    }
}
