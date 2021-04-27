namespace Homie.Forms
{
    partial class frmActuators
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActuators));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnGetActuatorsRoom = new System.Windows.Forms.Button();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.grpRoom = new System.Windows.Forms.GroupBox();
            this.roomFlowAct = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrUpdateActuator = new System.Windows.Forms.Timer(this.components);
            this.grpRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 89);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(116, 121);
            this.listBox1.TabIndex = 9;
            // 
            // btnGetActuatorsRoom
            // 
            this.btnGetActuatorsRoom.Location = new System.Drawing.Point(12, 59);
            this.btnGetActuatorsRoom.Name = "btnGetActuatorsRoom";
            this.btnGetActuatorsRoom.Size = new System.Drawing.Size(121, 23);
            this.btnGetActuatorsRoom.TabIndex = 6;
            this.btnGetActuatorsRoom.Text = "Get actuators";
            this.btnGetActuatorsRoom.UseVisualStyleBackColor = true;
            this.btnGetActuatorsRoom.Click += new System.EventHandler(this.btnGetActuatorsRoom_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(12, 13);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(35, 13);
            this.lblRoom.TabIndex = 8;
            this.lblRoom.Text = "Room";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(12, 32);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(121, 21);
            this.cmbRoom.TabIndex = 5;
            // 
            // grpRoom
            // 
            this.grpRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoom.AutoSize = true;
            this.grpRoom.BackColor = System.Drawing.SystemColors.Control;
            this.grpRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grpRoom.Controls.Add(this.roomFlowAct);
            this.grpRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpRoom.Location = new System.Drawing.Point(137, 13);
            this.grpRoom.Name = "grpRoom";
            this.grpRoom.Size = new System.Drawing.Size(647, 578);
            this.grpRoom.TabIndex = 7;
            this.grpRoom.TabStop = false;
            this.grpRoom.Text = "Rooms";
            this.grpRoom.Enter += new System.EventHandler(this.grpRoom_Enter);
            // 
            // roomFlowAct
            // 
            this.roomFlowAct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomFlowAct.AutoScroll = true;
            this.roomFlowAct.Location = new System.Drawing.Point(2, 19);
            this.roomFlowAct.Name = "roomFlowAct";
            this.roomFlowAct.Size = new System.Drawing.Size(639, 553);
            this.roomFlowAct.TabIndex = 0;
            // 
            // tmrUpdateActuator
            // 
            this.tmrUpdateActuator.Interval = 6000;
            this.tmrUpdateActuator.Tick += new System.EventHandler(this.tmrUpdateActuator_Tick);
            // 
            // frmActuators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 604);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnGetActuatorsRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.grpRoom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActuators";
            this.Text = "Actuators";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmActuators_FormClosed);
            this.Load += new System.EventHandler(this.frmActuators_Load);
            this.grpRoom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnGetActuatorsRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.GroupBox grpRoom;
        private System.Windows.Forms.FlowLayoutPanel roomFlowAct;
        private System.Windows.Forms.Timer tmrUpdateActuator;
    }
}