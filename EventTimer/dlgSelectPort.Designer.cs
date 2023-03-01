namespace EventTimer
{
    partial class dlgSelectPort
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
            this.cbxPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_OK = new System.Windows.Forms.Button();
            this.cb_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxPorts
            // 
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(12, 26);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(283, 21);
            this.cbxPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the COM port for the Timer device:";
            // 
            // cb_OK
            // 
            this.cb_OK.Location = new System.Drawing.Point(13, 82);
            this.cb_OK.Name = "cb_OK";
            this.cb_OK.Size = new System.Drawing.Size(75, 23);
            this.cb_OK.TabIndex = 2;
            this.cb_OK.Text = "OK";
            this.cb_OK.UseVisualStyleBackColor = true;
            this.cb_OK.Click += new System.EventHandler(this.cb_OK_Click);
            // 
            // cb_Cancel
            // 
            this.cb_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_Cancel.Location = new System.Drawing.Point(220, 82);
            this.cb_Cancel.Name = "cb_Cancel";
            this.cb_Cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_Cancel.TabIndex = 3;
            this.cb_Cancel.Text = "CANCEL";
            this.cb_Cancel.UseVisualStyleBackColor = true;
            this.cb_Cancel.Click += new System.EventHandler(this.cb_Cancel_Click);
            // 
            // dlgSelectPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cb_Cancel;
            this.ClientSize = new System.Drawing.Size(314, 135);
            this.Controls.Add(this.cb_Cancel);
            this.Controls.Add(this.cb_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxPorts);
            this.Name = "dlgSelectPort";
            this.Text = "Select COM port for Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cb_OK;
        private System.Windows.Forms.Button cb_Cancel;
    }
}