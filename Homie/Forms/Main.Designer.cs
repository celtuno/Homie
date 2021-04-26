namespace Homie
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chkTimer = new System.Windows.Forms.CheckBox();
            this.tmrCheckStuff = new System.Windows.Forms.Timer(this.components);
            this.radioTimer = new System.Windows.Forms.RadioButton();
            this.grpRoom = new System.Windows.Forms.GroupBox();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblActuators = new System.Windows.Forms.Label();
            this.flowActuator = new System.Windows.Forms.FlowLayoutPanel();
            this.flowSensor = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUptime = new System.Windows.Forms.TextBox();
            this.myStatus = new System.Windows.Forms.StatusStrip();
            this.toolTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLinklabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolUptime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSensorForm = new System.Windows.Forms.Button();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.btnRoomData = new System.Windows.Forms.Button();
            this.cmbDaqList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDaqData = new System.Windows.Forms.Button();
            this.btnShowActuators = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAddDevicesForm = new System.Windows.Forms.Button();
            this.lblRoom = new System.Windows.Forms.Label();
            this.contextMenuTop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDatalogger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuStartLogger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuStopLogger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuManuals = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.grpRoom.SuspendLayout();
            this.myStatus.SuspendLayout();
            this.contextMenuTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkTimer
            // 
            this.chkTimer.AutoSize = true;
            this.chkTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkTimer.Location = new System.Drawing.Point(0, 59);
            this.chkTimer.MaximumSize = new System.Drawing.Size(161, 30);
            this.chkTimer.MinimumSize = new System.Drawing.Size(200, 35);
            this.chkTimer.Name = "chkTimer";
            this.chkTimer.Padding = new System.Windows.Forms.Padding(1);
            this.chkTimer.Size = new System.Drawing.Size(200, 35);
            this.chkTimer.TabIndex = 6;
            this.chkTimer.Text = "Enable datalogging";
            this.chkTimer.UseVisualStyleBackColor = true;
            this.chkTimer.CheckedChanged += new System.EventHandler(this.btnTimer_Click);
            // 
            // tmrCheckStuff
            // 
            this.tmrCheckStuff.Enabled = true;
            this.tmrCheckStuff.Interval = 5000;
            this.tmrCheckStuff.Tick += new System.EventHandler(this.tmrCheckStuff_Tick);
            // 
            // radioTimer
            // 
            this.radioTimer.AutoSize = true;
            this.radioTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioTimer.ForeColor = System.Drawing.Color.Maroon;
            this.radioTimer.Location = new System.Drawing.Point(0, 24);
            this.radioTimer.MaximumSize = new System.Drawing.Size(78, 17);
            this.radioTimer.MinimumSize = new System.Drawing.Size(200, 35);
            this.radioTimer.Name = "radioTimer";
            this.radioTimer.Padding = new System.Windows.Forms.Padding(1);
            this.radioTimer.Size = new System.Drawing.Size(200, 35);
            this.radioTimer.TabIndex = 16;
            this.radioTimer.Text = "Datalogger status";
            this.radioTimer.UseVisualStyleBackColor = true;
            // 
            // grpRoom
            // 
            this.grpRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpRoom.Controls.Add(this.lblSensor);
            this.grpRoom.Controls.Add(this.lblActuators);
            this.grpRoom.Controls.Add(this.flowActuator);
            this.grpRoom.Controls.Add(this.flowSensor);
            this.grpRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoom.Location = new System.Drawing.Point(233, 159);
            this.grpRoom.Name = "grpRoom";
            this.grpRoom.Size = new System.Drawing.Size(421, 305);
            this.grpRoom.TabIndex = 17;
            this.grpRoom.TabStop = false;
            this.grpRoom.Text = "Devices";
            // 
            // lblSensor
            // 
            this.lblSensor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSensor.AutoSize = true;
            this.lblSensor.Location = new System.Drawing.Point(76, 27);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(45, 13);
            this.lblSensor.TabIndex = 16;
            this.lblSensor.Text = "Sensors";
            // 
            // lblActuators
            // 
            this.lblActuators.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActuators.AutoSize = true;
            this.lblActuators.Location = new System.Drawing.Point(285, 27);
            this.lblActuators.Name = "lblActuators";
            this.lblActuators.Size = new System.Drawing.Size(52, 13);
            this.lblActuators.TabIndex = 15;
            this.lblActuators.Text = "Actuators";
            // 
            // flowActuator
            // 
            this.flowActuator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowActuator.AutoScroll = true;
            this.flowActuator.Location = new System.Drawing.Point(217, 43);
            this.flowActuator.Name = "flowActuator";
            this.flowActuator.Padding = new System.Windows.Forms.Padding(2);
            this.flowActuator.Size = new System.Drawing.Size(198, 256);
            this.flowActuator.TabIndex = 66;
            // 
            // flowSensor
            // 
            this.flowSensor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowSensor.AutoScroll = true;
            this.flowSensor.Location = new System.Drawing.Point(6, 43);
            this.flowSensor.Name = "flowSensor";
            this.flowSensor.Padding = new System.Windows.Forms.Padding(2);
            this.flowSensor.Size = new System.Drawing.Size(198, 256);
            this.flowSensor.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(747, 83);
            this.label4.MaximumSize = new System.Drawing.Size(40, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Uptime";
            this.label4.Visible = false;
            // 
            // txtUptime
            // 
            this.txtUptime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUptime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUptime.Location = new System.Drawing.Point(752, 98);
            this.txtUptime.Margin = new System.Windows.Forms.Padding(2);
            this.txtUptime.MaximumSize = new System.Drawing.Size(93, 21);
            this.txtUptime.Multiline = true;
            this.txtUptime.Name = "txtUptime";
            this.txtUptime.ReadOnly = true;
            this.txtUptime.Size = new System.Drawing.Size(93, 21);
            this.txtUptime.TabIndex = 19;
            this.txtUptime.Visible = false;
            // 
            // myStatus
            // 
            this.myStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTimer,
            this.toolLinklabel,
            this.toolSpacer,
            this.toolUptime});
            this.myStatus.Location = new System.Drawing.Point(0, 507);
            this.myStatus.Name = "myStatus";
            this.myStatus.Size = new System.Drawing.Size(867, 24);
            this.myStatus.TabIndex = 20;
            this.myStatus.Text = "statusStrip1";
            this.myStatus.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.myStatus_ItemClicked);
            // 
            // toolTimer
            // 
            this.toolTimer.Name = "toolTimer";
            this.toolTimer.Size = new System.Drawing.Size(105, 19);
            this.toolTimer.Text = "Datalogger active: ";
            // 
            // toolLinklabel
            // 
            this.toolLinklabel.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.toolLinklabel.IsLink = true;
            this.toolLinklabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolLinklabel.LinkColor = System.Drawing.Color.MediumBlue;
            this.toolLinklabel.Name = "toolLinklabel";
            this.toolLinklabel.Size = new System.Drawing.Size(648, 19);
            this.toolLinklabel.Spring = true;
            this.toolLinklabel.Text = "Goto to the HOMIE web application";
            this.toolLinklabel.Click += new System.EventHandler(this.toolLinklabel_Click);
            // 
            // toolSpacer
            // 
            this.toolSpacer.Name = "toolSpacer";
            this.toolSpacer.Size = new System.Drawing.Size(49, 19);
            this.toolSpacer.Text = "Uptime:";
            this.toolSpacer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolUptime
            // 
            this.toolUptime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolUptime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolUptime.Name = "toolUptime";
            this.toolUptime.Size = new System.Drawing.Size(50, 19);
            this.toolUptime.Text = "Uptime";
            // 
            // btnSensorForm
            // 
            this.btnSensorForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSensorForm.Location = new System.Drawing.Point(0, 431);
            this.btnSensorForm.MaximumSize = new System.Drawing.Size(150, 481);
            this.btnSensorForm.Name = "btnSensorForm";
            this.btnSensorForm.Size = new System.Drawing.Size(150, 38);
            this.btnSensorForm.TabIndex = 4;
            this.btnSensorForm.Text = "Sensor values";
            this.btnSensorForm.UseVisualStyleBackColor = true;
            this.btnSensorForm.Click += new System.EventHandler(this.btnSensorForm_Click);
            // 
            // cmbRoom
            // 
            this.cmbRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(0, 175);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(150, 21);
            this.cmbRoom.TabIndex = 0;
            this.cmbRoom.Visible = false;
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // btnRoomData
            // 
            this.btnRoomData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRoomData.Location = new System.Drawing.Point(0, 202);
            this.btnRoomData.Name = "btnRoomData";
            this.btnRoomData.Size = new System.Drawing.Size(150, 23);
            this.btnRoomData.TabIndex = 1;
            this.btnRoomData.Text = "Get device data from room";
            this.btnRoomData.UseVisualStyleBackColor = true;
            this.btnRoomData.Visible = false;
            this.btnRoomData.Click += new System.EventHandler(this.btnRoomData_Click);
            // 
            // cmbDaqList
            // 
            this.cmbDaqList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDaqList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDaqList.FormattingEnabled = true;
            this.cmbDaqList.Location = new System.Drawing.Point(748, 20);
            this.cmbDaqList.Name = "cmbDaqList";
            this.cmbDaqList.Size = new System.Drawing.Size(110, 21);
            this.cmbDaqList.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(760, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Available DAQ\'s";
            // 
            // btnDaqData
            // 
            this.btnDaqData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDaqData.Location = new System.Drawing.Point(750, 47);
            this.btnDaqData.MaximumSize = new System.Drawing.Size(128, 481);
            this.btnDaqData.Name = "btnDaqData";
            this.btnDaqData.Size = new System.Drawing.Size(108, 23);
            this.btnDaqData.TabIndex = 26;
            this.btnDaqData.TabStop = false;
            this.btnDaqData.Text = "View daq data";
            this.btnDaqData.UseVisualStyleBackColor = true;
            this.btnDaqData.Visible = false;
            this.btnDaqData.Click += new System.EventHandler(this.btnAddSensors_Click);
            // 
            // btnShowActuators
            // 
            this.btnShowActuators.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowActuators.Location = new System.Drawing.Point(0, 469);
            this.btnShowActuators.MaximumSize = new System.Drawing.Size(150, 481);
            this.btnShowActuators.Name = "btnShowActuators";
            this.btnShowActuators.Size = new System.Drawing.Size(150, 38);
            this.btnShowActuators.TabIndex = 5;
            this.btnShowActuators.Text = "Actuator status";
            this.btnShowActuators.UseVisualStyleBackColor = true;
            this.btnShowActuators.Click += new System.EventHandler(this.btnShowActuators_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblWelcome.Location = new System.Drawing.Point(234, 24);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(316, 25);
            this.lblWelcome.TabIndex = 28;
            this.lblWelcome.Text = "Welcome - !NOT LOGGED IN! - ";
            // 
            // btnAddDevicesForm
            // 
            this.btnAddDevicesForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDevicesForm.Location = new System.Drawing.Point(0, 94);
            this.btnAddDevicesForm.MaximumSize = new System.Drawing.Size(150, 481);
            this.btnAddDevicesForm.Name = "btnAddDevicesForm";
            this.btnAddDevicesForm.Size = new System.Drawing.Size(150, 38);
            this.btnAddDevicesForm.TabIndex = 3;
            this.btnAddDevicesForm.Text = "Add Devices";
            this.btnAddDevicesForm.UseVisualStyleBackColor = true;
            this.btnAddDevicesForm.Click += new System.EventHandler(this.btnAddDevicesForm_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(3, 159);
            this.lblRoom.MaximumSize = new System.Drawing.Size(1000, 13);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(63, 13);
            this.lblRoom.TabIndex = 18;
            this.lblRoom.Text = "Select room";
            this.lblRoom.Visible = false;
            // 
            // contextMenuTop
            // 
            this.contextMenuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripDatalogger,
            this.toolStripHelp});
            this.contextMenuTop.Name = "contextMenuTop";
            this.contextMenuTop.Size = new System.Drawing.Size(133, 70);
            this.contextMenuTop.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTop_Opening);
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuExit});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(132, 22);
            this.toolStripFile.Text = "&File";
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuExit.Text = "&Exit";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // toolStripDatalogger
            // 
            this.toolStripDatalogger.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuStatus,
            this.toolStripSeparator1,
            this.toolStripMenuStartLogger,
            this.toolStripMenuStopLogger});
            this.toolStripDatalogger.Name = "toolStripDatalogger";
            this.toolStripDatalogger.Size = new System.Drawing.Size(132, 22);
            this.toolStripDatalogger.Text = "&Datalogger";
            this.toolStripDatalogger.Click += new System.EventHandler(this.toolStripDatalogger_Click);
            // 
            // toolStripMenuStatus
            // 
            this.toolStripMenuStatus.Name = "toolStripMenuStatus";
            this.toolStripMenuStatus.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuStatus.Text = "Status:  ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // toolStripMenuStartLogger
            // 
            this.toolStripMenuStartLogger.Name = "toolStripMenuStartLogger";
            this.toolStripMenuStartLogger.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuStartLogger.Text = "St&art logger";
            this.toolStripMenuStartLogger.Click += new System.EventHandler(this.toolStripMenuStartLogger_Click);
            // 
            // toolStripMenuStopLogger
            // 
            this.toolStripMenuStopLogger.Name = "toolStripMenuStopLogger";
            this.toolStripMenuStopLogger.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuStopLogger.Text = "St&op logger";
            this.toolStripMenuStopLogger.Click += new System.EventHandler(this.toolStripMenuStopLogger_Click);
            // 
            // toolStripHelp
            // 
            this.toolStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuManuals,
            this.toolStripMenuAbout});
            this.toolStripHelp.Name = "toolStripHelp";
            this.toolStripHelp.Size = new System.Drawing.Size(132, 22);
            this.toolStripHelp.Text = "&Help";
            // 
            // toolStripMenuManuals
            // 
            this.toolStripMenuManuals.Name = "toolStripMenuManuals";
            this.toolStripMenuManuals.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuManuals.Text = "Online &manuals";
            this.toolStripMenuManuals.Click += new System.EventHandler(this.toolStripMenuManuals_Click);
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuAbout.Text = "A&bout";
            this.toolStripMenuAbout.Click += new System.EventHandler(this.toolStripMenuAbout_Click);
            // 
            // menuStripTop
            // 
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(867, 24);
            this.menuStripTop.TabIndex = 31;
            this.menuStripTop.Text = "menuStrip1";
            this.menuStripTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripTop_ItemClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 531);
            this.Controls.Add(this.btnSensorForm);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnShowActuators);
            this.Controls.Add(this.btnDaqData);
            this.Controls.Add(this.btnRoomData);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.myStatus);
            this.Controls.Add(this.txtUptime);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDaqList);
            this.Controls.Add(this.btnAddDevicesForm);
            this.Controls.Add(this.chkTimer);
            this.Controls.Add(this.radioTimer);
            this.Controls.Add(this.menuStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTop;
            this.MinimumSize = new System.Drawing.Size(883, 569);
            this.Name = "frmMain";
            this.Text = "Main screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpRoom.ResumeLayout(false);
            this.grpRoom.PerformLayout();
            this.myStatus.ResumeLayout(false);
            this.myStatus.PerformLayout();
            this.contextMenuTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkTimer;
        private System.Windows.Forms.Timer tmrCheckStuff;
        private System.Windows.Forms.RadioButton radioTimer;
        private System.Windows.Forms.GroupBox grpRoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUptime;
        private System.Windows.Forms.StatusStrip myStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolUptime;
        private System.Windows.Forms.FlowLayoutPanel flowSensor;
        private System.Windows.Forms.Button btnSensorForm;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Button btnRoomData;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblActuators;
        private System.Windows.Forms.FlowLayoutPanel flowActuator;
        private System.Windows.Forms.ComboBox cmbDaqList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDaqData;
        private System.Windows.Forms.Button btnShowActuators;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAddDevicesForm;
        private System.Windows.Forms.ToolStripStatusLabel toolLinklabel;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuTop;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripDatalogger;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuStartLogger;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuStopLogger;
        private System.Windows.Forms.ToolStripMenuItem toolStripHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuManuals;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
       
    }
}

