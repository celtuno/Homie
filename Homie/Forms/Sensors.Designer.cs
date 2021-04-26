namespace Homie.Forms
{
    partial class frmSensors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSensors));
            this.roomFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.grpRoom = new System.Windows.Forms.GroupBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.btnGetSenorRoom = new System.Windows.Forms.Button();
            this.lstboxSensor = new System.Windows.Forms.ListBox();
            this.tmrSensor = new System.Windows.Forms.Timer(this.components);
            this.btnGraph = new System.Windows.Forms.Button();
            this.grpRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomFlow
            // 
            this.roomFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomFlow.AutoScroll = true;
            this.roomFlow.Location = new System.Drawing.Point(2, 19);
            this.roomFlow.Name = "roomFlow";
            this.roomFlow.Size = new System.Drawing.Size(643, 329);
            this.roomFlow.TabIndex = 0;
            // 
            // grpRoom
            // 
            this.grpRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoom.AutoSize = true;
            this.grpRoom.BackColor = System.Drawing.SystemColors.Control;
            this.grpRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grpRoom.Controls.Add(this.roomFlow);
            this.grpRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpRoom.Location = new System.Drawing.Point(137, 12);
            this.grpRoom.Name = "grpRoom";
            this.grpRoom.Size = new System.Drawing.Size(651, 424);
            this.grpRoom.TabIndex = 1;
            this.grpRoom.TabStop = false;
            this.grpRoom.Text = "Rooms";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(12, 31);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(121, 21);
            this.cmbRoom.TabIndex = 0;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(12, 12);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(35, 13);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room";
            // 
            // btnGetSenorRoom
            // 
            this.btnGetSenorRoom.Location = new System.Drawing.Point(12, 58);
            this.btnGetSenorRoom.Name = "btnGetSenorRoom";
            this.btnGetSenorRoom.Size = new System.Drawing.Size(121, 23);
            this.btnGetSenorRoom.TabIndex = 1;
            this.btnGetSenorRoom.Text = "Get sensors";
            this.btnGetSenorRoom.UseVisualStyleBackColor = true;
            this.btnGetSenorRoom.Click += new System.EventHandler(this.btnGetSenorRoom_Click);
            // 
            // lstboxSensor
            // 
            this.lstboxSensor.FormattingEnabled = true;
            this.lstboxSensor.Location = new System.Drawing.Point(15, 88);
            this.lstboxSensor.Name = "lstboxSensor";
            this.lstboxSensor.Size = new System.Drawing.Size(116, 121);
            this.lstboxSensor.TabIndex = 4;
            // 
            // tmrSensor
            // 
            this.tmrSensor.Interval = 5000;
            this.tmrSensor.Tick += new System.EventHandler(this.tmrSensor_Tick);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGraph.Location = new System.Drawing.Point(15, 407);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(116, 23);
            this.btnGraph.TabIndex = 2;
            this.btnGraph.Text = "Show graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // frmSensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstboxSensor);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnGetSenorRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.grpRoom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 350);
            this.Name = "frmSensors";
            this.Text = "SensorStatus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSensors_FormClosing);
            this.Load += new System.EventHandler(this.frmSensorStatus_Load);
            this.grpRoom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel roomFlow;
        private System.Windows.Forms.GroupBox grpRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Button btnGetSenorRoom;
        private System.Windows.Forms.ListBox lstboxSensor;
        private System.Windows.Forms.Timer tmrSensor;
        private System.Windows.Forms.Button btnGraph;
    }
}