namespace Homie.Forms
{
    partial class frmDaqData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaqData));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnReadStatus = new System.Windows.Forms.Button();
            this.cmbInchannels = new System.Windows.Forms.ComboBox();
            this.lblVoltConvert = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cmbDaqAddress = new System.Windows.Forms.ComboBox();
            this.cmbDaqList = new System.Windows.Forms.ComboBox();
            this.txtDaqResult = new System.Windows.Forms.TextBox();
            this.btnReadDaqList = new System.Windows.Forms.Button();
            this.grpDevices = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDigital = new System.Windows.Forms.CheckBox();
            this.btnDigitalArray = new System.Windows.Forms.Button();
            this.btnSingleDigital = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.grpDevices.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(510, 170);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(237, 252);
            this.treeView1.TabIndex = 23;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // btnReadStatus
            // 
            this.btnReadStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReadStatus.Location = new System.Drawing.Point(753, 131);
            this.btnReadStatus.Name = "btnReadStatus";
            this.btnReadStatus.Size = new System.Drawing.Size(120, 23);
            this.btnReadStatus.TabIndex = 22;
            this.btnReadStatus.Text = "Channel status";
            this.btnReadStatus.UseVisualStyleBackColor = true;
            this.btnReadStatus.Click += new System.EventHandler(this.btnReadStatus_Click);
            // 
            // cmbInchannels
            // 
            this.cmbInchannels.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbInchannels.FormattingEnabled = true;
            this.cmbInchannels.Location = new System.Drawing.Point(510, 131);
            this.cmbInchannels.Name = "cmbInchannels";
            this.cmbInchannels.Size = new System.Drawing.Size(237, 21);
            this.cmbInchannels.TabIndex = 24;
            // 
            // lblVoltConvert
            // 
            this.lblVoltConvert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVoltConvert.AutoSize = true;
            this.lblVoltConvert.Location = new System.Drawing.Point(2, 85);
            this.lblVoltConvert.Name = "lblVoltConvert";
            this.lblVoltConvert.Size = new System.Drawing.Size(79, 13);
            this.lblVoltConvert.TabIndex = 34;
            this.lblVoltConvert.Text = "Sensor convert";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "tmp",
            "termo",
            "light"});
            this.comboBox1.Location = new System.Drawing.Point(5, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Available DAQ\'s";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Result List";
            // 
            // lblChannel
            // 
            this.lblChannel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(60, 58);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(99, 13);
            this.lblChannel.TabIndex = 30;
            this.lblChannel.Text = "Device/channel list";
            // 
            // cmbDaqAddress
            // 
            this.cmbDaqAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDaqAddress.FormattingEnabled = true;
            this.cmbDaqAddress.Location = new System.Drawing.Point(63, 74);
            this.cmbDaqAddress.Name = "cmbDaqAddress";
            this.cmbDaqAddress.Size = new System.Drawing.Size(184, 21);
            this.cmbDaqAddress.TabIndex = 28;
            // 
            // cmbDaqList
            // 
            this.cmbDaqList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDaqList.FormattingEnabled = true;
            this.cmbDaqList.Location = new System.Drawing.Point(63, 31);
            this.cmbDaqList.Name = "cmbDaqList";
            this.cmbDaqList.Size = new System.Drawing.Size(184, 21);
            this.cmbDaqList.TabIndex = 29;
            // 
            // txtDaqResult
            // 
            this.txtDaqResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDaqResult.Location = new System.Drawing.Point(8, 144);
            this.txtDaqResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtDaqResult.Multiline = true;
            this.txtDaqResult.Name = "txtDaqResult";
            this.txtDaqResult.Size = new System.Drawing.Size(181, 68);
            this.txtDaqResult.TabIndex = 27;
            // 
            // btnReadDaqList
            // 
            this.btnReadDaqList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReadDaqList.Location = new System.Drawing.Point(0, 36);
            this.btnReadDaqList.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadDaqList.Name = "btnReadDaqList";
            this.btnReadDaqList.Size = new System.Drawing.Size(187, 42);
            this.btnReadDaqList.TabIndex = 26;
            this.btnReadDaqList.Text = "Analog read  from channel list";
            this.btnReadDaqList.UseVisualStyleBackColor = true;
            this.btnReadDaqList.Click += new System.EventHandler(this.btnReadDaqList_Click);
            // 
            // grpDevices
            // 
            this.grpDevices.Controls.Add(this.btnReadDaqList);
            this.grpDevices.Controls.Add(this.lblVoltConvert);
            this.grpDevices.Controls.Add(this.txtDaqResult);
            this.grpDevices.Controls.Add(this.comboBox1);
            this.grpDevices.Controls.Add(this.label2);
            this.grpDevices.Location = new System.Drawing.Point(14, 161);
            this.grpDevices.Name = "grpDevices";
            this.grpDevices.Size = new System.Drawing.Size(200, 261);
            this.grpDevices.TabIndex = 35;
            this.grpDevices.TabStop = false;
            this.grpDevices.Text = "Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDigital);
            this.groupBox1.Controls.Add(this.btnDigitalArray);
            this.groupBox1.Controls.Add(this.btnSingleDigital);
            this.groupBox1.Location = new System.Drawing.Point(242, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 261);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digital";
            // 
            // chkDigital
            // 
            this.chkDigital.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkDigital.AutoSize = true;
            this.chkDigital.Location = new System.Drawing.Point(9, 76);
            this.chkDigital.Name = "chkDigital";
            this.chkDigital.Size = new System.Drawing.Size(76, 17);
            this.chkDigital.TabIndex = 33;
            this.chkDigital.Text = "Led on/off";
            this.chkDigital.UseVisualStyleBackColor = true;
            // 
            // btnDigitalArray
            // 
            this.btnDigitalArray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDigitalArray.Location = new System.Drawing.Point(9, 128);
            this.btnDigitalArray.Name = "btnDigitalArray";
            this.btnDigitalArray.Size = new System.Drawing.Size(133, 23);
            this.btnDigitalArray.TabIndex = 32;
            this.btnDigitalArray.Text = "Digital array- checkbox1";
            this.btnDigitalArray.UseVisualStyleBackColor = true;
            this.btnDigitalArray.Click += new System.EventHandler(this.btnDigitalArray_Click);
            // 
            // btnSingleDigital
            // 
            this.btnSingleDigital.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSingleDigital.Enabled = false;
            this.btnSingleDigital.Location = new System.Drawing.Point(9, 99);
            this.btnSingleDigital.Name = "btnSingleDigital";
            this.btnSingleDigital.Size = new System.Drawing.Size(133, 23);
            this.btnSingleDigital.TabIndex = 31;
            this.btnSingleDigital.Text = "Single line digital";
            this.btnSingleDigital.UseVisualStyleBackColor = true;
            this.btnSingleDigital.Click += new System.EventHandler(this.btnSingleDigital_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(753, 170);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 251);
            this.listBox1.TabIndex = 36;
            // 
            // frmDaqData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 449);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmbDaqAddress);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.grpDevices);
            this.Controls.Add(this.cmbDaqList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInchannels);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnReadStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(931, 487);
            this.Name = "frmDaqData";
            this.Text = "View daq data";
            this.Load += new System.EventHandler(this.frmAddSensor_Load);
            this.grpDevices.ResumeLayout(false);
            this.grpDevices.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnReadStatus;
        private System.Windows.Forms.ComboBox cmbInchannels;
        private System.Windows.Forms.Label lblVoltConvert;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cmbDaqAddress;
        private System.Windows.Forms.ComboBox cmbDaqList;
        private System.Windows.Forms.TextBox txtDaqResult;
        private System.Windows.Forms.Button btnReadDaqList;
        private System.Windows.Forms.GroupBox grpDevices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSingleDigital;
        private System.Windows.Forms.Button btnDigitalArray;
        private System.Windows.Forms.CheckBox chkDigital;
        private System.Windows.Forms.ListBox listBox1;
    }
}