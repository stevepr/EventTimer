namespace EventTimer
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSystemTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_Timer = new System.Windows.Forms.GroupBox();
            this.lbl_expStatus = new System.Windows.Forms.Label();
            this.lbl_timingMode = new System.Windows.Forms.Label();
            this.lbl_logStatus = new System.Windows.Forms.Label();
            this.lbl_gpsStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_eventTitle = new System.Windows.Forms.Label();
            this.lbl_eventCountdown = new System.Windows.Forms.Label();
            this.lbl_eventTimeTo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_flashLevel = new System.Windows.Forms.TextBox();
            this.lbl_flashIntensity = new System.Windows.Forms.Label();
            this.trackBar_flashLevel = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gb_Timer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_flashLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerToolStripMenuItem,
            this.eventsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.logToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(282, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.propertiesToolStripMenuItem1});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties...";
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.listToolStripMenuItem});
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.eventsToolStripMenuItem.Text = "Event";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listToolStripMenuItem.Text = "List...";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSystemTimeToolStripMenuItem,
            this.deviceConsoleToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // setSystemTimeToolStripMenuItem
            // 
            this.setSystemTimeToolStripMenuItem.Name = "setSystemTimeToolStripMenuItem";
            this.setSystemTimeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.setSystemTimeToolStripMenuItem.Text = "Set System Time";
            // 
            // deviceConsoleToolStripMenuItem
            // 
            this.deviceConsoleToolStripMenuItem.Name = "deviceConsoleToolStripMenuItem";
            this.deviceConsoleToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.deviceConsoleToolStripMenuItem.Text = "Device Console Window...";
            this.deviceConsoleToolStripMenuItem.Click += new System.EventHandler(this.deviceConsoleToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gb_Timer
            // 
            this.gb_Timer.Controls.Add(this.lbl_expStatus);
            this.gb_Timer.Controls.Add(this.lbl_timingMode);
            this.gb_Timer.Controls.Add(this.lbl_gpsStatus);
            this.gb_Timer.Location = new System.Drawing.Point(12, 347);
            this.gb_Timer.Name = "gb_Timer";
            this.gb_Timer.Size = new System.Drawing.Size(258, 127);
            this.gb_Timer.TabIndex = 2;
            this.gb_Timer.TabStop = false;
            this.gb_Timer.Text = "Timer - not connected";
            // 
            // lbl_expStatus
            // 
            this.lbl_expStatus.AutoSize = true;
            this.lbl_expStatus.Location = new System.Drawing.Point(7, 66);
            this.lbl_expStatus.Name = "lbl_expStatus";
            this.lbl_expStatus.Size = new System.Drawing.Size(99, 13);
            this.lbl_expStatus.TabIndex = 3;
            this.lbl_expStatus.Text = "EXP:  Not detected";
            // 
            // lbl_timingMode
            // 
            this.lbl_timingMode.AutoSize = true;
            this.lbl_timingMode.Location = new System.Drawing.Point(7, 42);
            this.lbl_timingMode.Name = "lbl_timingMode";
            this.lbl_timingMode.Size = new System.Drawing.Size(61, 13);
            this.lbl_timingMode.TabIndex = 2;
            this.lbl_timingMode.Text = "Mode: PPS";
            // 
            // lbl_logStatus
            // 
            this.lbl_logStatus.AutoSize = true;
            this.lbl_logStatus.Location = new System.Drawing.Point(7, 117);
            this.lbl_logStatus.Name = "lbl_logStatus";
            this.lbl_logStatus.Size = new System.Drawing.Size(89, 13);
            this.lbl_logStatus.TabIndex = 1;
            this.lbl_logStatus.Text = "Logging: Inactive";
            // 
            // lbl_gpsStatus
            // 
            this.lbl_gpsStatus.AutoSize = true;
            this.lbl_gpsStatus.Location = new System.Drawing.Point(7, 20);
            this.lbl_gpsStatus.Name = "lbl_gpsStatus";
            this.lbl_gpsStatus.Size = new System.Drawing.Size(38, 13);
            this.lbl_gpsStatus.TabIndex = 0;
            this.lbl_gpsStatus.Text = "GPS:  ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_eventTitle);
            this.groupBox2.Controls.Add(this.lbl_eventCountdown);
            this.groupBox2.Controls.Add(this.lbl_logStatus);
            this.groupBox2.Controls.Add(this.lbl_eventTimeTo);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 147);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Status";
            // 
            // lbl_eventTitle
            // 
            this.lbl_eventTitle.AutoSize = true;
            this.lbl_eventTitle.Location = new System.Drawing.Point(6, 25);
            this.lbl_eventTitle.Name = "lbl_eventTitle";
            this.lbl_eventTitle.Size = new System.Drawing.Size(97, 13);
            this.lbl_eventTitle.TabIndex = 5;
            this.lbl_eventTitle.Text = "(xxx) AsteroidName";
            // 
            // lbl_eventCountdown
            // 
            this.lbl_eventCountdown.AutoSize = true;
            this.lbl_eventCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eventCountdown.Location = new System.Drawing.Point(6, 80);
            this.lbl_eventCountdown.Name = "lbl_eventCountdown";
            this.lbl_eventCountdown.Size = new System.Drawing.Size(71, 20);
            this.lbl_eventCountdown.TabIndex = 4;
            this.lbl_eventCountdown.Text = "00:00:00";
            // 
            // lbl_eventTimeTo
            // 
            this.lbl_eventTimeTo.AutoSize = true;
            this.lbl_eventTimeTo.Location = new System.Drawing.Point(6, 67);
            this.lbl_eventTimeTo.Name = "lbl_eventTimeTo";
            this.lbl_eventTimeTo.Size = new System.Drawing.Size(95, 13);
            this.lbl_eventTimeTo.TabIndex = 3;
            this.lbl_eventTimeTo.Text = "Start Recording in:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_flashLevel);
            this.groupBox3.Controls.Add(this.lbl_flashIntensity);
            this.groupBox3.Controls.Add(this.trackBar_flashLevel);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(12, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 138);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLASH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "%";
            // 
            // tb_flashLevel
            // 
            this.tb_flashLevel.Location = new System.Drawing.Point(90, 62);
            this.tb_flashLevel.Name = "tb_flashLevel";
            this.tb_flashLevel.Size = new System.Drawing.Size(28, 20);
            this.tb_flashLevel.TabIndex = 3;
            this.tb_flashLevel.Text = "100";
            // 
            // lbl_flashIntensity
            // 
            this.lbl_flashIntensity.AutoSize = true;
            this.lbl_flashIntensity.Location = new System.Drawing.Point(7, 65);
            this.lbl_flashIntensity.Name = "lbl_flashIntensity";
            this.lbl_flashIntensity.Size = new System.Drawing.Size(77, 13);
            this.lbl_flashIntensity.TabIndex = 2;
            this.lbl_flashIntensity.Text = "Flash Intensity:";
            // 
            // trackBar_flashLevel
            // 
            this.trackBar_flashLevel.Location = new System.Drawing.Point(6, 87);
            this.trackBar_flashLevel.Maximum = 100;
            this.trackBar_flashLevel.Name = "trackBar_flashLevel";
            this.trackBar_flashLevel.Size = new System.Drawing.Size(246, 45);
            this.trackBar_flashLevel.TabIndex = 1;
            this.trackBar_flashLevel.TickFrequency = 10;
            this.trackBar_flashLevel.Value = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Flash NOW";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_Timer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "EventTimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_Timer.ResumeLayout(false);
            this.gb_Timer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_flashLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSystemTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_Timer;
        private System.Windows.Forms.Label lbl_expStatus;
        private System.Windows.Forms.Label lbl_timingMode;
        private System.Windows.Forms.Label lbl_logStatus;
        private System.Windows.Forms.Label lbl_gpsStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_eventCountdown;
        private System.Windows.Forms.Label lbl_eventTimeTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_flashIntensity;
        private System.Windows.Forms.TrackBar trackBar_flashLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_eventTitle;
        private System.Windows.Forms.TextBox tb_flashLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

