namespace Homie.Forms
{
    partial class frmAddDevices
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
            this.btnTest = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabDevices = new System.Windows.Forms.TabControl();
            this.tabAddDaq = new System.Windows.Forms.TabPage();
            this.grpAddDaq = new System.Windows.Forms.GroupBox();
            this.lblDaqModel = new System.Windows.Forms.Label();
            this.cmbDaq = new System.Windows.Forms.ComboBox();
            this.txtDaqModel = new System.Windows.Forms.TextBox();
            this.lblDaqAddress = new System.Windows.Forms.Label();
            this.lblDaqName = new System.Windows.Forms.Label();
            this.txtDaqName = new System.Windows.Forms.TextBox();
            this.btnAddDaq = new System.Windows.Forms.Button();
            this.tabAddSensor = new System.Windows.Forms.TabPage();
            this.lblSensorName = new System.Windows.Forms.Label();
            this.txtSensorName = new System.Windows.Forms.TextBox();
            this.btnAddSensor = new System.Windows.Forms.Button();
            this.grpDevices = new System.Windows.Forms.GroupBox();
            this.lblSensorType = new System.Windows.Forms.Label();
            this.cmbSensorType = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.cmbSensorChannels = new System.Windows.Forms.ComboBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.tabAddAcuator = new System.Windows.Forms.TabPage();
            this.lblActName = new System.Windows.Forms.Label();
            this.txtActuatorName = new System.Windows.Forms.TextBox();
            this.btnAddActuator = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblActType = new System.Windows.Forms.Label();
            this.lblDefaultValue = new System.Windows.Forms.Label();
            this.cmbDefaultValue = new System.Windows.Forms.ComboBox();
            this.cmbActType = new System.Windows.Forms.ComboBox();
            this.lblbActRoom = new System.Windows.Forms.Label();
            this.cmbActRoom = new System.Windows.Forms.ComboBox();
            this.cmbActChannel = new System.Windows.Forms.ComboBox();
            this.lblActChannels = new System.Windows.Forms.Label();
            this.tabAddRoom = new System.Windows.Forms.TabPage();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.tabDimActuatur = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.addDeviceErrorProv = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabDevices.SuspendLayout();
            this.tabAddDaq.SuspendLayout();
            this.grpAddDaq.SuspendLayout();
            this.tabAddSensor.SuspendLayout();
            this.grpDevices.SuspendLayout();
            this.tabAddAcuator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabAddRoom.SuspendLayout();
            this.tabDimActuatur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDeviceErrorProv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(247, 136);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Analog out Test  - ao1";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(247, 82);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tabDevices
            // 
            this.tabDevices.Controls.Add(this.tabAddDaq);
            this.tabDevices.Controls.Add(this.tabAddSensor);
            this.tabDevices.Controls.Add(this.tabAddAcuator);
            this.tabDevices.Controls.Add(this.tabAddRoom);
            this.tabDevices.Controls.Add(this.tabDimActuatur);
            this.tabDevices.Location = new System.Drawing.Point(12, 12);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.SelectedIndex = 0;
            this.tabDevices.Size = new System.Drawing.Size(422, 353);
            this.tabDevices.TabIndex = 2;
            // 
            // tabAddDaq
            // 
            this.tabAddDaq.Controls.Add(this.grpAddDaq);
            this.tabAddDaq.Controls.Add(this.lblDaqName);
            this.tabAddDaq.Controls.Add(this.txtDaqName);
            this.tabAddDaq.Controls.Add(this.btnAddDaq);
            this.tabAddDaq.Location = new System.Drawing.Point(4, 22);
            this.tabAddDaq.Name = "tabAddDaq";
            this.tabAddDaq.Size = new System.Drawing.Size(414, 327);
            this.tabAddDaq.TabIndex = 0;
            this.tabAddDaq.Text = "Add Daq";
            this.tabAddDaq.UseVisualStyleBackColor = true;
            this.tabAddDaq.Enter += new System.EventHandler(this.txtDaqModel_TextChanged);
            // 
            // grpAddDaq
            // 
            this.grpAddDaq.Controls.Add(this.lblDaqModel);
            this.grpAddDaq.Controls.Add(this.cmbDaq);
            this.grpAddDaq.Controls.Add(this.txtDaqModel);
            this.grpAddDaq.Controls.Add(this.lblDaqAddress);
            this.grpAddDaq.Location = new System.Drawing.Point(26, 33);
            this.grpAddDaq.Name = "grpAddDaq";
            this.grpAddDaq.Size = new System.Drawing.Size(200, 261);
            this.grpAddDaq.TabIndex = 48;
            this.grpAddDaq.TabStop = false;
            this.grpAddDaq.Text = "Input";
            // 
            // lblDaqModel
            // 
            this.lblDaqModel.AutoSize = true;
            this.lblDaqModel.Location = new System.Drawing.Point(6, 73);
            this.lblDaqModel.Name = "lblDaqModel";
            this.lblDaqModel.Size = new System.Drawing.Size(58, 13);
            this.lblDaqModel.TabIndex = 5;
            this.lblDaqModel.Text = "Daq model";
            // 
            // cmbDaq
            // 
            this.cmbDaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDaq.FormattingEnabled = true;
            this.cmbDaq.Location = new System.Drawing.Point(9, 49);
            this.cmbDaq.Name = "cmbDaq";
            this.cmbDaq.Size = new System.Drawing.Size(160, 21);
            this.cmbDaq.TabIndex = 0;
            // 
            // txtDaqModel
            // 
            this.txtDaqModel.Location = new System.Drawing.Point(9, 89);
            this.txtDaqModel.MaxLength = 50;
            this.txtDaqModel.Name = "txtDaqModel";
            this.txtDaqModel.Size = new System.Drawing.Size(160, 20);
            this.txtDaqModel.TabIndex = 4;
            this.txtDaqModel.TextChanged += new System.EventHandler(this.txtDaqModel_TextChanged);
            this.txtDaqModel.Leave += new System.EventHandler(this.txtDaqModel_Leave);
            // 
            // lblDaqAddress
            // 
            this.lblDaqAddress.AutoSize = true;
            this.lblDaqAddress.Location = new System.Drawing.Point(6, 33);
            this.lblDaqAddress.Name = "lblDaqAddress";
            this.lblDaqAddress.Size = new System.Drawing.Size(68, 13);
            this.lblDaqAddress.TabIndex = 3;
            this.lblDaqAddress.Text = "Daq Address";
            // 
            // lblDaqName
            // 
            this.lblDaqName.AutoSize = true;
            this.lblDaqName.Location = new System.Drawing.Point(244, 66);
            this.lblDaqName.Name = "lblDaqName";
            this.lblDaqName.Size = new System.Drawing.Size(56, 13);
            this.lblDaqName.TabIndex = 3;
            this.lblDaqName.Text = "Daq name";
            // 
            // txtDaqName
            // 
            this.txtDaqName.Location = new System.Drawing.Point(247, 82);
            this.txtDaqName.MaxLength = 15;
            this.txtDaqName.Name = "txtDaqName";
            this.txtDaqName.Size = new System.Drawing.Size(100, 20);
            this.txtDaqName.TabIndex = 2;
            this.txtDaqName.TextChanged += new System.EventHandler(this.txtDaqName_TextChanged);
            this.txtDaqName.Enter += new System.EventHandler(this.txtDaqName_Enter);
            // 
            // btnAddDaq
            // 
            this.btnAddDaq.Location = new System.Drawing.Point(247, 136);
            this.btnAddDaq.Name = "btnAddDaq";
            this.btnAddDaq.Size = new System.Drawing.Size(100, 23);
            this.btnAddDaq.TabIndex = 1;
            this.btnAddDaq.Text = "Add daq";
            this.btnAddDaq.UseVisualStyleBackColor = true;
            this.btnAddDaq.Click += new System.EventHandler(this.btnAddDaq_Click);
            this.btnAddDaq.Enter += new System.EventHandler(this.txtDaqName_TextChanged);
            // 
            // tabAddSensor
            // 
            this.tabAddSensor.Controls.Add(this.lblSensorName);
            this.tabAddSensor.Controls.Add(this.txtSensorName);
            this.tabAddSensor.Controls.Add(this.btnAddSensor);
            this.tabAddSensor.Controls.Add(this.grpDevices);
            this.tabAddSensor.Location = new System.Drawing.Point(4, 22);
            this.tabAddSensor.Name = "tabAddSensor";
            this.tabAddSensor.Size = new System.Drawing.Size(417, 327);
            this.tabAddSensor.TabIndex = 1;
            this.tabAddSensor.Text = "Add sensor";
            this.tabAddSensor.UseVisualStyleBackColor = true;
            this.tabAddSensor.Enter += new System.EventHandler(this.frmAddDevices_Load);
            // 
            // lblSensorName
            // 
            this.lblSensorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSensorName.AutoSize = true;
            this.lblSensorName.Location = new System.Drawing.Point(244, 66);
            this.lblSensorName.Name = "lblSensorName";
            this.lblSensorName.Size = new System.Drawing.Size(69, 13);
            this.lblSensorName.TabIndex = 46;
            this.lblSensorName.Text = "Sensor name";
            this.lblSensorName.Click += new System.EventHandler(this.lblSensorName_Click);
            // 
            // txtSensorName
            // 
            this.txtSensorName.Location = new System.Drawing.Point(247, 82);
            this.txtSensorName.MaxLength = 15;
            this.txtSensorName.Name = "txtSensorName";
            this.txtSensorName.Size = new System.Drawing.Size(100, 20);
            this.txtSensorName.TabIndex = 43;
            this.txtSensorName.TextChanged += new System.EventHandler(this.txtSensorName_TextChanged);
            // 
            // btnAddSensor
            // 
            this.btnAddSensor.Location = new System.Drawing.Point(247, 136);
            this.btnAddSensor.Name = "btnAddSensor";
            this.btnAddSensor.Size = new System.Drawing.Size(100, 23);
            this.btnAddSensor.TabIndex = 42;
            this.btnAddSensor.Text = "Add sensor";
            this.btnAddSensor.UseVisualStyleBackColor = true;
            this.btnAddSensor.Click += new System.EventHandler(this.btnAddSensor_Click);
            this.btnAddSensor.Enter += new System.EventHandler(this.txtSensorName_TextChanged);
            // 
            // grpDevices
            // 
            this.grpDevices.Controls.Add(this.lblSensorType);
            this.grpDevices.Controls.Add(this.cmbSensorType);
            this.grpDevices.Controls.Add(this.lblRoom);
            this.grpDevices.Controls.Add(this.cmbRoom);
            this.grpDevices.Controls.Add(this.cmbSensorChannels);
            this.grpDevices.Controls.Add(this.lblChannel);
            this.grpDevices.Location = new System.Drawing.Point(26, 33);
            this.grpDevices.Name = "grpDevices";
            this.grpDevices.Size = new System.Drawing.Size(200, 261);
            this.grpDevices.TabIndex = 41;
            this.grpDevices.TabStop = false;
            this.grpDevices.Text = "Input";
            // 
            // lblSensorType
            // 
            this.lblSensorType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSensorType.AutoSize = true;
            this.lblSensorType.Location = new System.Drawing.Point(6, 115);
            this.lblSensorType.Name = "lblSensorType";
            this.lblSensorType.Size = new System.Drawing.Size(63, 13);
            this.lblSensorType.TabIndex = 34;
            this.lblSensorType.Text = "Sensor type";
            // 
            // cmbSensorType
            // 
            this.cmbSensorType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorType.FormattingEnabled = true;
            this.cmbSensorType.Location = new System.Drawing.Point(6, 131);
            this.cmbSensorType.Name = "cmbSensorType";
            this.cmbSensorType.Size = new System.Drawing.Size(163, 21);
            this.cmbSensorType.TabIndex = 33;
            // 
            // lblRoom
            // 
            this.lblRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(6, 73);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(35, 13);
            this.lblRoom.TabIndex = 32;
            this.lblRoom.Text = "Room";
            // 
            // cmbRoom
            // 
            this.cmbRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(9, 89);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(160, 21);
            this.cmbRoom.TabIndex = 31;
            // 
            // cmbSensorChannels
            // 
            this.cmbSensorChannels.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSensorChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorChannels.FormattingEnabled = true;
            this.cmbSensorChannels.Location = new System.Drawing.Point(9, 49);
            this.cmbSensorChannels.Name = "cmbSensorChannels";
            this.cmbSensorChannels.Size = new System.Drawing.Size(160, 21);
            this.cmbSensorChannels.TabIndex = 28;
            // 
            // lblChannel
            // 
            this.lblChannel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(6, 33);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(99, 13);
            this.lblChannel.TabIndex = 30;
            this.lblChannel.Text = "Device/channel list";
            // 
            // tabAddAcuator
            // 
            this.tabAddAcuator.Controls.Add(this.lblActName);
            this.tabAddAcuator.Controls.Add(this.txtActuatorName);
            this.tabAddAcuator.Controls.Add(this.btnAddActuator);
            this.tabAddAcuator.Controls.Add(this.groupBox1);
            this.tabAddAcuator.Location = new System.Drawing.Point(4, 22);
            this.tabAddAcuator.Name = "tabAddAcuator";
            this.tabAddAcuator.Size = new System.Drawing.Size(417, 327);
            this.tabAddAcuator.TabIndex = 2;
            this.tabAddAcuator.Text = "Add Actuator";
            this.tabAddAcuator.UseVisualStyleBackColor = true;
            this.tabAddAcuator.Enter += new System.EventHandler(this.tabAddAcuator_Enter);
            // 
            // lblActName
            // 
            this.lblActName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActName.AutoSize = true;
            this.lblActName.Location = new System.Drawing.Point(244, 66);
            this.lblActName.Name = "lblActName";
            this.lblActName.Size = new System.Drawing.Size(76, 13);
            this.lblActName.TabIndex = 52;
            this.lblActName.Text = "Actuator name";
            // 
            // txtActuatorName
            // 
            this.txtActuatorName.Location = new System.Drawing.Point(247, 82);
            this.txtActuatorName.MaxLength = 15;
            this.txtActuatorName.Name = "txtActuatorName";
            this.txtActuatorName.Size = new System.Drawing.Size(100, 20);
            this.txtActuatorName.TabIndex = 49;
            this.txtActuatorName.TextChanged += new System.EventHandler(this.txtActuatorName_TextChanged);
            // 
            // btnAddActuator
            // 
            this.btnAddActuator.Location = new System.Drawing.Point(247, 136);
            this.btnAddActuator.Name = "btnAddActuator";
            this.btnAddActuator.Size = new System.Drawing.Size(100, 23);
            this.btnAddActuator.TabIndex = 48;
            this.btnAddActuator.Text = "Add actuator";
            this.btnAddActuator.UseVisualStyleBackColor = true;
            this.btnAddActuator.Click += new System.EventHandler(this.btnAddActuator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblActType);
            this.groupBox1.Controls.Add(this.lblDefaultValue);
            this.groupBox1.Controls.Add(this.cmbDefaultValue);
            this.groupBox1.Controls.Add(this.cmbActType);
            this.groupBox1.Controls.Add(this.lblbActRoom);
            this.groupBox1.Controls.Add(this.cmbActRoom);
            this.groupBox1.Controls.Add(this.cmbActChannel);
            this.groupBox1.Controls.Add(this.lblActChannels);
            this.groupBox1.Location = new System.Drawing.Point(26, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 261);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // lblActType
            // 
            this.lblActType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActType.AutoSize = true;
            this.lblActType.Location = new System.Drawing.Point(6, 115);
            this.lblActType.Name = "lblActType";
            this.lblActType.Size = new System.Drawing.Size(70, 13);
            this.lblActType.TabIndex = 34;
            this.lblActType.Text = "Actuator type";
            // 
            // lblDefaultValue
            // 
            this.lblDefaultValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDefaultValue.AutoSize = true;
            this.lblDefaultValue.Location = new System.Drawing.Point(6, 165);
            this.lblDefaultValue.Name = "lblDefaultValue";
            this.lblDefaultValue.Size = new System.Drawing.Size(70, 13);
            this.lblDefaultValue.TabIndex = 51;
            this.lblDefaultValue.Text = "Default value";
            // 
            // cmbDefaultValue
            // 
            this.cmbDefaultValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDefaultValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultValue.FormattingEnabled = true;
            this.cmbDefaultValue.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cmbDefaultValue.Location = new System.Drawing.Point(9, 181);
            this.cmbDefaultValue.Name = "cmbDefaultValue";
            this.cmbDefaultValue.Size = new System.Drawing.Size(100, 21);
            this.cmbDefaultValue.TabIndex = 50;
            // 
            // cmbActType
            // 
            this.cmbActType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbActType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActType.FormattingEnabled = true;
            this.cmbActType.Location = new System.Drawing.Point(9, 131);
            this.cmbActType.Name = "cmbActType";
            this.cmbActType.Size = new System.Drawing.Size(160, 21);
            this.cmbActType.TabIndex = 33;
            // 
            // lblbActRoom
            // 
            this.lblbActRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblbActRoom.AutoSize = true;
            this.lblbActRoom.Location = new System.Drawing.Point(6, 73);
            this.lblbActRoom.Name = "lblbActRoom";
            this.lblbActRoom.Size = new System.Drawing.Size(35, 13);
            this.lblbActRoom.TabIndex = 32;
            this.lblbActRoom.Text = "Room";
            // 
            // cmbActRoom
            // 
            this.cmbActRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbActRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActRoom.FormattingEnabled = true;
            this.cmbActRoom.Location = new System.Drawing.Point(9, 89);
            this.cmbActRoom.Name = "cmbActRoom";
            this.cmbActRoom.Size = new System.Drawing.Size(160, 21);
            this.cmbActRoom.TabIndex = 31;
            // 
            // cmbActChannel
            // 
            this.cmbActChannel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbActChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActChannel.FormattingEnabled = true;
            this.cmbActChannel.Location = new System.Drawing.Point(9, 49);
            this.cmbActChannel.Name = "cmbActChannel";
            this.cmbActChannel.Size = new System.Drawing.Size(160, 21);
            this.cmbActChannel.TabIndex = 28;
            this.cmbActChannel.SelectedIndexChanged += new System.EventHandler(this.cmbActChannel_SelectedIndexChanged);
            // 
            // lblActChannels
            // 
            this.lblActChannels.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActChannels.AutoSize = true;
            this.lblActChannels.Location = new System.Drawing.Point(6, 33);
            this.lblActChannels.Name = "lblActChannels";
            this.lblActChannels.Size = new System.Drawing.Size(99, 13);
            this.lblActChannels.TabIndex = 30;
            this.lblActChannels.Text = "Device/channel list";
            // 
            // tabAddRoom
            // 
            this.tabAddRoom.Controls.Add(this.lblRoomName);
            this.tabAddRoom.Controls.Add(this.txtRoomName);
            this.tabAddRoom.Controls.Add(this.btnAddRoom);
            this.tabAddRoom.Location = new System.Drawing.Point(4, 22);
            this.tabAddRoom.Name = "tabAddRoom";
            this.tabAddRoom.Size = new System.Drawing.Size(417, 327);
            this.tabAddRoom.TabIndex = 4;
            this.tabAddRoom.Text = "Add room";
            this.tabAddRoom.UseVisualStyleBackColor = true;
            // 
            // lblRoomName
            // 
            this.lblRoomName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(244, 66);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(64, 13);
            this.lblRoomName.TabIndex = 55;
            this.lblRoomName.Text = "Room name";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(247, 82);
            this.txtRoomName.MaxLength = 15;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(100, 20);
            this.txtRoomName.TabIndex = 54;
            this.txtRoomName.TextChanged += new System.EventHandler(this.txtRoomName_TextChanged);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(247, 136);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(100, 23);
            this.btnAddRoom.TabIndex = 53;
            this.btnAddRoom.Text = "Add room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // tabDimActuatur
            // 
            this.tabDimActuatur.Controls.Add(this.label1);
            this.tabDimActuatur.Controls.Add(this.btnTest);
            this.tabDimActuatur.Controls.Add(this.numericUpDown1);
            this.tabDimActuatur.Location = new System.Drawing.Point(4, 22);
            this.tabDimActuatur.Name = "tabDimActuatur";
            this.tabDimActuatur.Size = new System.Drawing.Size(417, 327);
            this.tabDimActuatur.TabIndex = 3;
            this.tabDimActuatur.Text = "Dimmable actuator";
            this.tabDimActuatur.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(244, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Volts out";
            // 
            // addDeviceErrorProv
            // 
            this.addDeviceErrorProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.addDeviceErrorProv.ContainerControl = this;
            // 
            // frmAddDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 377);
            this.Controls.Add(this.tabDevices);
            this.MinimumSize = new System.Drawing.Size(460, 415);
            this.Name = "frmAddDevices";
            this.Text = "AddDevices";
            this.Load += new System.EventHandler(this.frmAddDevices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabDevices.ResumeLayout(false);
            this.tabAddDaq.ResumeLayout(false);
            this.tabAddDaq.PerformLayout();
            this.grpAddDaq.ResumeLayout(false);
            this.grpAddDaq.PerformLayout();
            this.tabAddSensor.ResumeLayout(false);
            this.tabAddSensor.PerformLayout();
            this.grpDevices.ResumeLayout(false);
            this.grpDevices.PerformLayout();
            this.tabAddAcuator.ResumeLayout(false);
            this.tabAddAcuator.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabAddRoom.ResumeLayout(false);
            this.tabAddRoom.PerformLayout();
            this.tabDimActuatur.ResumeLayout(false);
            this.tabDimActuatur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDeviceErrorProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TabControl tabDevices;
        private System.Windows.Forms.TabPage tabAddSensor;
        private System.Windows.Forms.TabPage tabAddAcuator;
        private System.Windows.Forms.TabPage tabAddDaq;
        private System.Windows.Forms.Label lblSensorName;
        private System.Windows.Forms.TextBox txtSensorName;
        private System.Windows.Forms.Button btnAddSensor;
        private System.Windows.Forms.GroupBox grpDevices;
        private System.Windows.Forms.Label lblSensorType;
        private System.Windows.Forms.ComboBox cmbSensorType;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.ComboBox cmbSensorChannels;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblActName;
        private System.Windows.Forms.TextBox txtActuatorName;
        private System.Windows.Forms.Button btnAddActuator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblActType;
        private System.Windows.Forms.Label lblDefaultValue;
        private System.Windows.Forms.ComboBox cmbDefaultValue;
        private System.Windows.Forms.ComboBox cmbActType;
        private System.Windows.Forms.Label lblbActRoom;
        private System.Windows.Forms.ComboBox cmbActRoom;
        private System.Windows.Forms.ComboBox cmbActChannel;
        private System.Windows.Forms.Label lblActChannels;
        private System.Windows.Forms.TabPage tabDimActuatur;
        private System.Windows.Forms.ComboBox cmbDaq;
        private System.Windows.Forms.Label lblDaqAddress;
        private System.Windows.Forms.Label lblDaqName;
        private System.Windows.Forms.TextBox txtDaqName;
        private System.Windows.Forms.Button btnAddDaq;
        private System.Windows.Forms.Label lblDaqModel;
        private System.Windows.Forms.TextBox txtDaqModel;
        private System.Windows.Forms.GroupBox grpAddDaq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAddRoom;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.ErrorProvider addDeviceErrorProv;
    }
}