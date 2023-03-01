using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EventTimer
{
    public partial class dlgConsole : Form
    {

        //************************************
        //
        // P R O P E R T I E S
        //
        //************************************

        private int MaxLines = 100;
        private int cmdMaxLines = 20;

        private HelperSerialPort hSerial;

        private List<string> dataLines;
        private List<string> cmdLines;

        private bool blnClosing = false;
        private bool blnInvoking = false;

        //************************************
        //
        // M E T H O D S
        //
        //************************************

        //--------------------------------------------------
        //  constructor
        //--------------------------------------------------
        public dlgConsole(HelperSerialPort helperSerialPort)
        {
            InitializeComponent();
            
            // sanity checks
            //
            if (helperSerialPort == null)
            {
                throw new ArgumentNullException("null serial port object.");
            }

            // general init
            //
            hSerial = helperSerialPort;
            
            dataLines = new List<string>();
            cmdLines = new List<string>(); 

            // setup linkage for datareceived
            //
            hSerial.DataReceived += HelperSerialPort_DataReceived;


        } // end of constructor

        //--------------------------------------------------
        //  data received
        //--------------------------------------------------
        private void HelperSerialPort_DataReceived(object sender, SerialPortDataReceivedEventArgs e)
        {
            // data received from Serial port
            //
            //            Debug.WriteLine("Data: " + e.Data);

            // Is the form closing now?
            //      This check is not foolproof.  The form could try to close during an Invoke.  So we also 
            //      use a blnInvoking flag to delay the form close as needed.
            //      https://stackoverflow.com/questions/50947927/objectdisposedexception-when-form-is-being-closed
            //
            if (blnClosing)
            {
                return;     // exit
            }
            // we have a new line,  is it log data or control/status info?
            //
            if (e.Data[0] == '[')
            {
                // this is a control/status line
                //

                cmdLines.Add(e.Data);          // add new line to the list (without \n)

                if (cmdLines.Count > cmdMaxLines)
                {
                    // not recording & too many lines => remove first line from the list
                    //
                    cmdLines.RemoveAt(0);
                }

                // Update List box & save data
                //
                blnInvoking = true;
                tb_CmdHistory.Invoke(() =>
                {
                    StringBuilder sbTmp = new StringBuilder();
                    int FirstLine;

                    // show only the most recent MaxLines entries
                    //
                    FirstLine = (cmdLines.Count <= cmdMaxLines) ? 0 : (cmdLines.Count - cmdMaxLines);
                    for (int i = FirstLine; i < cmdLines.Count; i++)
                    {
                        sbTmp.Append(cmdLines[i]);
                    }

                    tb_CmdHistory.Text = sbTmp.ToString();
                    tb_CmdHistory.AppendText("\r\n");                      // to move the caret to the end ...
                    tb_CmdHistory.ScrollToCaret();

                });
                blnInvoking = false;
            }
            else
            {
                // this line is log data
                //

                dataLines.Add(e.Data);          // add new line to the list (without \n)

                if (dataLines.Count > MaxLines)
                {
                    // not recording & too many lines => remove first line from the list
                    //
                    dataLines.RemoveAt(0);
                }

                // Update List box & save data
                //
                blnInvoking = true;
                tb_EventLog.Invoke(() =>
                {
                    StringBuilder sbTmp = new StringBuilder();
                    int FirstLine;

                    // show only the most recent MaxLines entries
                    //
                    FirstLine = (dataLines.Count <= MaxLines) ? 0 : (dataLines.Count - MaxLines);
                    for (int i = FirstLine; i < dataLines.Count; i++)
                    {
                        sbTmp.Append(dataLines[i]);
                    }

                    tb_EventLog.Text = sbTmp.ToString();
                    tb_EventLog.AppendText("\r\n");                      // to move the caret to the end ...
                    tb_EventLog.ScrollToCaret();

                });
                blnInvoking = false;
            }


        } // end of datareceived handler

        //--------------------------------------------------
        //  Form CLOSING
        //--------------------------------------------------
        private void dlgConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            blnClosing = true;
            hSerial.DataReceived -= HelperSerialPort_DataReceived;

            // if we Invoke in progress, wait up to one second
            //
            for(int i = 0; i < 50; i++)
            {
                if (!blnInvoking)
                {
                    break;
                }
                Application.DoEvents();
            }

        } // end of form closing

        //--------------------------------------------------
        //  SEND command to device
        //--------------------------------------------------
        private void cb_CmdSend_Click(object sender, EventArgs e)
        {

            string cmdNew;

            cmdNew = tb_Cmd_New.Text + "\n";

            try
            {
                hSerial.SerialCmdSend(cmdNew);
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Error sending command <" + ex.Message + ">");
            }


        }  // end of send command
    }
}
