namespace EventTimer
{
    partial class dlgConsole
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_Cmd_New = new System.Windows.Forms.TextBox();
            this.cb_CmdSend = new System.Windows.Forms.Button();
            this.tb_CmdHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_EventLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_CmdHistory);
            this.groupBox1.Controls.Add(this.cb_CmdSend);
            this.groupBox1.Controls.Add(this.tb_Cmd_New);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Control I/O:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_EventLog);
            this.groupBox2.Location = new System.Drawing.Point(13, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 300);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Log:";
            // 
            // tb_Cmd_New
            // 
            this.tb_Cmd_New.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Cmd_New.Location = new System.Drawing.Point(7, 20);
            this.tb_Cmd_New.Name = "tb_Cmd_New";
            this.tb_Cmd_New.Size = new System.Drawing.Size(542, 20);
            this.tb_Cmd_New.TabIndex = 0;
            // 
            // cb_CmdSend
            // 
            this.cb_CmdSend.Location = new System.Drawing.Point(556, 16);
            this.cb_CmdSend.Name = "cb_CmdSend";
            this.cb_CmdSend.Size = new System.Drawing.Size(75, 23);
            this.cb_CmdSend.TabIndex = 1;
            this.cb_CmdSend.Text = "Send";
            this.cb_CmdSend.UseVisualStyleBackColor = true;
            this.cb_CmdSend.Click += new System.EventHandler(this.cb_CmdSend_Click);
            // 
            // tb_CmdHistory
            // 
            this.tb_CmdHistory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_CmdHistory.Location = new System.Drawing.Point(6, 59);
            this.tb_CmdHistory.Multiline = true;
            this.tb_CmdHistory.Name = "tb_CmdHistory";
            this.tb_CmdHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_CmdHistory.Size = new System.Drawing.Size(736, 107);
            this.tb_CmdHistory.TabIndex = 2;
            this.tb_CmdHistory.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "History:";
            // 
            // tb_EventLog
            // 
            this.tb_EventLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_EventLog.Location = new System.Drawing.Point(6, 19);
            this.tb_EventLog.Multiline = true;
            this.tb_EventLog.Name = "tb_EventLog";
            this.tb_EventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_EventLog.Size = new System.Drawing.Size(736, 250);
            this.tb_EventLog.TabIndex = 0;
            this.tb_EventLog.WordWrap = false;
            // 
            // dlgConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "dlgConsole";
            this.Text = "dlgConsole";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgConsole_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CmdHistory;
        private System.Windows.Forms.Button cb_CmdSend;
        private System.Windows.Forms.TextBox tb_Cmd_New;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_EventLog;
    }
}