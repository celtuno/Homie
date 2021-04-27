namespace Homie.Forms
{
    partial class frmGraphing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphing));
            this.tabTemp = new System.Windows.Forms.TabControl();
            this.tabDays = new System.Windows.Forms.TabPage();
            this.btnShowDays = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDays = new System.Windows.Forms.ComboBox();
            this.chrtSensorData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabDate = new System.Windows.Forms.TabPage();
            this.btnSetDate = new System.Windows.Forms.Button();
            this.dateTimestartdate = new System.Windows.Forms.DateTimePicker();
            this.dateTimeenddate = new System.Windows.Forms.DateTimePicker();
            this.chrtSensorData2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSensorGraph = new System.Windows.Forms.ComboBox();
            this.cmbRoomList = new System.Windows.Forms.ComboBox();
            this.btnGetSensor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabTemp.SuspendLayout();
            this.tabDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSensorData)).BeginInit();
            this.tabDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSensorData2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTemp
            // 
            this.tabTemp.Controls.Add(this.tabDays);
            this.tabTemp.Controls.Add(this.tabDate);
            this.tabTemp.Location = new System.Drawing.Point(27, 111);
            this.tabTemp.Name = "tabTemp";
            this.tabTemp.SelectedIndex = 0;
            this.tabTemp.Size = new System.Drawing.Size(761, 426);
            this.tabTemp.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabTemp.TabIndex = 1;
            // 
            // tabDays
            // 
            this.tabDays.Controls.Add(this.btnShowDays);
            this.tabDays.Controls.Add(this.label2);
            this.tabDays.Controls.Add(this.label1);
            this.tabDays.Controls.Add(this.cmdDays);
            this.tabDays.Controls.Add(this.chrtSensorData);
            this.tabDays.Location = new System.Drawing.Point(4, 22);
            this.tabDays.Name = "tabDays";
            this.tabDays.Padding = new System.Windows.Forms.Padding(3);
            this.tabDays.Size = new System.Drawing.Size(753, 400);
            this.tabDays.TabIndex = 0;
            this.tabDays.Text = "Last days";
            this.tabDays.UseVisualStyleBackColor = true;
            this.tabDays.Click += new System.EventHandler(this.tabDays_Click);
            // 
            // btnShowDays
            // 
            this.btnShowDays.Location = new System.Drawing.Point(255, 20);
            this.btnShowDays.Name = "btnShowDays";
            this.btnShowDays.Size = new System.Drawing.Size(100, 23);
            this.btnShowDays.TabIndex = 6;
            this.btnShowDays.Text = "Show graph";
            this.btnShowDays.UseVisualStyleBackColor = true;
            this.btnShowDays.Click += new System.EventHandler(this.btnShowDays_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "days ago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Show data from";
            // 
            // cmdDays
            // 
            this.cmdDays.FormattingEnabled = true;
            this.cmdDays.Location = new System.Drawing.Point(123, 22);
            this.cmdDays.Name = "cmdDays";
            this.cmdDays.Size = new System.Drawing.Size(46, 21);
            this.cmdDays.TabIndex = 1;
            // 
            // chrtSensorData
            // 
            chartArea1.Name = "SensorDataArea1";
            this.chrtSensorData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtSensorData.Legends.Add(legend1);
            this.chrtSensorData.Location = new System.Drawing.Point(6, 71);
            this.chrtSensorData.Name = "chrtSensorData";
            series1.ChartArea = "SensorDataArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chrtSensorData.Series.Add(series1);
            this.chrtSensorData.Size = new System.Drawing.Size(741, 323);
            this.chrtSensorData.TabIndex = 0;
            this.chrtSensorData.Text = "chart1";
            // 
            // tabDate
            // 
            this.tabDate.Controls.Add(this.btnSetDate);
            this.tabDate.Controls.Add(this.dateTimestartdate);
            this.tabDate.Controls.Add(this.dateTimeenddate);
            this.tabDate.Controls.Add(this.chrtSensorData2);
            this.tabDate.Location = new System.Drawing.Point(4, 22);
            this.tabDate.Name = "tabDate";
            this.tabDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabDate.Size = new System.Drawing.Size(753, 400);
            this.tabDate.TabIndex = 1;
            this.tabDate.Text = "Date range";
            this.tabDate.UseVisualStyleBackColor = true;
            // 
            // btnSetDate
            // 
            this.btnSetDate.Location = new System.Drawing.Point(255, 20);
            this.btnSetDate.Name = "btnSetDate";
            this.btnSetDate.Size = new System.Drawing.Size(100, 23);
            this.btnSetDate.TabIndex = 3;
            this.btnSetDate.Text = "Change date";
            this.btnSetDate.UseVisualStyleBackColor = true;
            this.btnSetDate.Click += new System.EventHandler(this.btnSetDate_Click);
            // 
            // dateTimestartdate
            // 
            this.dateTimestartdate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimestartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimestartdate.Location = new System.Drawing.Point(41, 23);
            this.dateTimestartdate.Name = "dateTimestartdate";
            this.dateTimestartdate.ShowUpDown = true;
            this.dateTimestartdate.Size = new System.Drawing.Size(150, 20);
            this.dateTimestartdate.TabIndex = 2;
            this.dateTimestartdate.Value = new System.DateTime(2020, 3, 25, 0, 0, 0, 0);
            // 
            // dateTimeenddate
            // 
            this.dateTimeenddate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimeenddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeenddate.Location = new System.Drawing.Point(41, 49);
            this.dateTimeenddate.Name = "dateTimeenddate";
            this.dateTimeenddate.ShowUpDown = true;
            this.dateTimeenddate.Size = new System.Drawing.Size(150, 20);
            this.dateTimeenddate.TabIndex = 1;
            this.dateTimeenddate.Value = new System.DateTime(2020, 4, 26, 0, 0, 0, 0);
            // 
            // chrtSensorData2
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtSensorData2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtSensorData2.Legends.Add(legend2);
            this.chrtSensorData2.Location = new System.Drawing.Point(6, 71);
            this.chrtSensorData2.Name = "chrtSensorData2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Temperature";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chrtSensorData2.Series.Add(series2);
            this.chrtSensorData2.Size = new System.Drawing.Size(741, 323);
            this.chrtSensorData2.TabIndex = 0;
            this.chrtSensorData2.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sensor";
            // 
            // cmbSensorGraph
            // 
            this.cmbSensorGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorGraph.FormattingEnabled = true;
            this.cmbSensorGraph.Location = new System.Drawing.Point(27, 63);
            this.cmbSensorGraph.Name = "cmbSensorGraph";
            this.cmbSensorGraph.Size = new System.Drawing.Size(121, 21);
            this.cmbSensorGraph.TabIndex = 4;
            // 
            // cmbRoomList
            // 
            this.cmbRoomList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomList.FormattingEnabled = true;
            this.cmbRoomList.Location = new System.Drawing.Point(27, 23);
            this.cmbRoomList.Name = "cmbRoomList";
            this.cmbRoomList.Size = new System.Drawing.Size(121, 21);
            this.cmbRoomList.TabIndex = 2;
            // 
            // btnGetSensor
            // 
            this.btnGetSensor.Location = new System.Drawing.Point(154, 21);
            this.btnGetSensor.Name = "btnGetSensor";
            this.btnGetSensor.Size = new System.Drawing.Size(75, 63);
            this.btnGetSensor.TabIndex = 6;
            this.btnGetSensor.Text = "Get sensors";
            this.btnGetSensor.UseVisualStyleBackColor = true;
            this.btnGetSensor.Click += new System.EventHandler(this.btnGetSensor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Room";
            // 
            // frmGraphing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetSensor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSensorGraph);
            this.Controls.Add(this.cmbRoomList);
            this.Controls.Add(this.tabTemp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGraphing";
            this.Text = "Graphing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGraphing_FormClosing);
            this.Load += new System.EventHandler(this.Graphing_Load);
            this.tabTemp.ResumeLayout(false);
            this.tabDays.ResumeLayout(false);
            this.tabDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSensorData)).EndInit();
            this.tabDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtSensorData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabTemp;
        private System.Windows.Forms.TabPage tabDays;
        private System.Windows.Forms.Button btnShowDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSensorGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmdDays;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSensorData;
        private System.Windows.Forms.TabPage tabDate;
        private System.Windows.Forms.Button btnSetDate;
        private System.Windows.Forms.DateTimePicker dateTimestartdate;
        private System.Windows.Forms.DateTimePicker dateTimeenddate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSensorData2;
        private System.Windows.Forms.ComboBox cmbRoomList;
        private System.Windows.Forms.Button btnGetSensor;
        private System.Windows.Forms.Label label4;
    }
}