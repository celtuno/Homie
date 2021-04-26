using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace Homie.Models
{
    public class Graphing
    {

        //for sql
        string sqlConfig = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;// Connectionstring to the database.

        public Graphing()
        {

        }
            public Graphing(Color chartcolor, Color chartcolor2, Chart chart, int days)
        {
            InitGraph(chartcolor, chartcolor2, chart, days);
        }
        public Graphing(Color chartcolor, Color chartcolor2, Chart chart, int sensorid ,DateTime startdate, DateTime enddate)
        {
            InitGraph(chartcolor, chartcolor2, chart,sensorid , startdate, enddate);
        }
        //for sql init
        readonly string conTempChart = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;



        public Graphing(Chart chart, int days, int sensorid)
        {
            GetDataFromSql(chart, days, sensorid);
        }


            public void InitGraph(Color color1,Color color2,Chart tmpChart, int days)
            {
                //chart settings
                
                //set up gridline colors
                tmpChart.ChartAreas[0].AxisX.MajorGrid.LineColor = color1;
                tmpChart.ChartAreas[0].AxisY.MajorGrid.LineColor = color1;
       
                //set up dates as tyle for x-axis 
                tmpChart.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                
                tmpChart.ChartAreas[0].AxisY.Interval = 2.0;

                tmpChart.Series["Temperature"].Color = color2;
         

                //Read data from sql with this method  (run this in your own -method / button / chart display solution)
                GetDataFromSql(tmpChart, days);
            }

            private void GetDataFromSql(Chart chart ,int days)
            {

                //Set up start stop dates in chart (beginning / end values)
                DateTime StopDate = DateTime.Today;
            DateTime StartDate = StopDate.AddDays(-days);//4);
                // DateTime StartDate = new DateTime(2019, 1, 1);
                chart.ChartAreas[0].AxisX.Minimum = StartDate.ToOADate();
                chart.ChartAreas[0].AxisX.Maximum = StopDate.ToOADate();

                //define variables
                double tempRead;
                DateTime tempDate;
            
                //Set up sql commands for query
         /*       string sqlTempQuery = "Select * from SENSOR_LOG" ;
                //string sqlAlarmQuery = "Select * from Alarms";

                //set up sql connection
                SqlConnection sqlCon = new SqlConnection(conTempChart);

                //initialize sql query command
                SqlCommand sqlTempRead = new SqlCommand(sqlTempQuery, sqlCon);
                //SqlCommand sqlAlarmRead = new SqlCommand(sqlAlarmQuery, sqlCon);

                //set up try catch for error handling
                try
                {

                    //read temperatures form sql
                    sqlCon.Open();
                    //Initialize sqlreader
                    SqlDataReader tempDataRow = sqlTempRead.ExecuteReader();

                    //while data is available, read date and temperature 
                    while (tempDataRow.Read() == true)
                    {
                        //convert sqldata for chart
                        tempRead = Convert.ToDouble(tempDataRow[2]);
                        tempDate = Convert.ToDateTime(tempDataRow[1]);

                        //Plot temperatur values into chart
                        chart.Series["Temperature"].Points.AddXY(tempDate, tempRead);

                    }
                    sqlCon.Close();



                }
                catch (Exception sqlRead)
                {
                    MessageBox.Show("SQL-Error:  " + sqlRead.Message.ToString(), "SQL_Read_Error");
                }
                */
            }

        public void InitGraph(Color color1, Color color2, Chart tmpChart, int sensorid, DateTime startdate, DateTime enddate)
        {
            //chart settings

            //set up gridline colors
            tmpChart.ChartAreas[0].AxisX.MajorGrid.LineColor = color1;
            tmpChart.ChartAreas[0].AxisY.MajorGrid.LineColor = color1;
            //chartTempAlarm.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.Gray;
            //chartTempAlarm.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Gray;

            //set up dates as tyle for x-axis 
            tmpChart.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            //chartTempAlarm.ChartAreas[0].AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            tmpChart.ChartAreas[0].AxisY.Interval = 2.0;
            string seriname = "Temp-C";
            Series series = new Series(seriname);
            //Chart chartArea = new Chart();
            //chartArea.Series.Add(series);
            if(tmpChart.Series.Count == 1)
            tmpChart.Series.Add(series);
            
           
            
            tmpChart.Series[seriname].Color = color2;
            tmpChart.Series[seriname].ChartType = SeriesChartType.Line;
            tmpChart.Series["Temperature"].Color = Color.DarkOliveGreen;
            //chartTempAlarm.Series["Alarm"].Color = Color.Red;


            //Read data from sql with this method  (run this in your own -method / button / chart display solution)
            GetDataFromSql(tmpChart, sensorid , startdate, enddate);
        }


        private void GetDataFromSql(Chart chart, int days, int sensorid)
        {

            //Set up start stop dates in chart (beginning / end values)
            DateTime StopDate = DateTime.Today;
            DateTime StartDate = StopDate.AddDays(-days);//4);
                                                         // DateTime StartDate = new DateTime(2019, 1, 1);
            chart.ChartAreas[0].AxisX.Minimum = StartDate.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = StopDate.ToOADate();

            //define variables
            double tempRead;
            DateTime tempDate;

            //Set up sql commands for query


            //set up sql connection

            chart.Series[0].Points.Clear();
            //chart.Series[1].Points.Clear();
            string[] SensorLog = new string[7];// array for information of the selected user.
            try
            {
                SqlConnection conSql = new SqlConnection(sqlConfig);
                //Connection to database

                SqlCommand sqlCommand = new SqlCommand("Select * from GetSensorLog WHERE SensorID = " +sensorid, conSql);//sqlCommand with parameters for name of the stored precedure and connection.

                sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                conSql.Open();//Opening the connection
                
                sqlCommand.ExecuteNonQuery();// Executing
                
 
                //read temperatures form sql
             
                //Initialize sqlreader
                SqlDataReader tempDataRow = sqlCommand.ExecuteReader();

                //while data is available, read date and temperature 
                while (tempDataRow.Read() == true)
                {
                    //convert sqldata for chart
                    tempRead = Convert.ToDouble(tempDataRow[2]);
                    tempDate = Convert.ToDateTime(tempDataRow[3]);

                    //Plot temperatur values into chart
                    chart.Series["Temperature"].Points.AddXY(tempDate, tempRead);

                }
                conSql.Close();



            }
            catch (Exception sqlRead)
            {
                MessageBox.Show("SQL-Error:  " + sqlRead.Message.ToString(), "SQL_Read_Error");
            }

        }

        private void GetDataFromSql(Chart chart, int sensorid, DateTime startdate, DateTime enddate)
        {

            //Set up start stop dates in chart (beginning / end values)
            DateTime StopDate = enddate;
            DateTime StartDate = startdate;//4);
                                                         // DateTime StartDate = new DateTime(2019, 1, 1);
            chart.ChartAreas[0].AxisX.Minimum = StartDate.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = StopDate.ToOADate();

            //define variables
            double tempRead;
            DateTime tempDate;

            //Set up sql commands for query


            //set up sql connection

            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            string[] SensorLog = new string[7];// array for information of the selected user.
            try
            {
                //Connection to database
                SqlConnection conSql = new SqlConnection(sqlConfig);
                //Connection to database
                string sqlFormattedStartDate = StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlFormattedEndDate = StopDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                SqlCommand sqlCommand;
                    sqlCommand= new SqlCommand("Select * from GetSensorLog WHERE SensorID = " + sensorid  + " AND LogTime BETWEEN '" + sqlFormattedStartDate + "' AND '"  + sqlFormattedEndDate + "'", conSql);
                //sqlCommand with parameters for name of the stored precedure and connection.

                sqlCommand.CommandType = CommandType.Text;// Selecting command type.
                conSql.Open();//Opening the connection

                sqlCommand.ExecuteNonQuery();// Executing


                //read temperatures form sql

                //Initialize sqlreader
                SqlDataReader tempDataRow = sqlCommand.ExecuteReader();

                //while data is available, read date and temperature 
                while (tempDataRow.Read() == true)
                {
                    //convert sqldata for chart
                    tempRead = Convert.ToDouble(tempDataRow[2]);
                    tempDate = Convert.ToDateTime(tempDataRow[3]);

                    //Plot temperatur values into chart
                    chart.Series["Temperature"].Points.AddXY(tempDate, tempRead);

                }
                conSql.Close();
               



            }
            catch (Exception sqlRead)
            {
                MessageBox.Show("SQL-Error:  " + sqlRead.Message.ToString(), "SQL_Read_Error");
            }

        }


    }

}

