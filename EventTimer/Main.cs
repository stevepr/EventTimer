/******************************************
 * EventTimer
 * 
 * Date: Feb 2023
 * 
 * Description
 * This program controls EventTimer devices via a USB port connection.
 * 
 * 
*******************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Data.SqlClient;

namespace EventTimer
{
    public partial class Main : Form
    {

        //************************************
        //
        // P R O P E R T I E S
        //
        //************************************

        private HelperSerialPort helperSerialPort = new HelperSerialPort();
        private ComPorts comPorts = null;


        private SerialPort sPort;
        private string _portName;

        private StreamWriter swLog;
        private string log_filename = string.Empty;

        // incoming lines from device
        //
        private StringBuilder CurrentLine;

        // device command logic
        //
        private enum cmdStates
        {
            WaitingForEcho,
            WaitingForResult,
            Done
        }
        class cmdPacket
        {
            public DateTime dteTimeOut;
            public string strCommand;
            public cmdStates cmdState;
            public string strResult;
        }
        private Queue<cmdPacket> cmdQueue;

        // device info
        //
        string strDeviceName = string.Empty;
        string strDeviceVersion = string.Empty;

        //************************************
        //
        // M E T H O D S
        //
        //************************************

        //--------------------------------------------------
        //  Init method for main form
        //--------------------------------------------------
        public Main()
        {

            InitializeComponent();

            // init
            //
            swLog = null;
            CurrentLine = new StringBuilder();
            cmdQueue = new Queue<cmdPacket>();

            // get comm ports
            //
            comPorts = helperSerialPort.GetComPortInfo();


        } // end of main

        //--------------------------------------------------
        //  closing...
        //--------------------------------------------------
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // tidy up
            //  close serial port
            //  close file
            //

            if (helperSerialPort != null && helperSerialPort.Port != null)
            {
                helperSerialPort.Dispose();
                helperSerialPort = null;
            }

            if (swLog != null)
            {
                swLog.Close();
                swLog.Dispose();
            }

        }

        //--------------------------------------------------
        //      Menu: Device / Connect 
        //--------------------------------------------------
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {


            // Connect to Timing Device
            //      Connect to USB / Serial
            //      Start logging input
            //
            using (dlgSelectPort dlgGetPort = new dlgSelectPort(comPorts))
            {
                if (dlgGetPort.ShowDialog() == DialogResult.OK)
                {
                    // open the selected serial port
                    //
                    _portName = dlgGetPort.strPortName;

                    if (helperSerialPort.Port == null || !helperSerialPort.Port.IsOpen)
                    {
                        try
                        {
                            helperSerialPort.Connect(_portName, PortBaudRate.Baud115200);
                        }
                        catch ( Exception ex)
                        {
                            MessageBox.Show("Error connecting <" + ex.Message + ">");
                        }
                        sPort = helperSerialPort.Port;
                        helperSerialPort.DataReceived += main_DataReceived;
                    }

                }
            }

           

            //*************************
            //  OPEN LOG FILE  and enable logging to file
            //
            // open file
            try
            {
                log_filename = Path.Combine(Application.StartupPath, string.Format("{0:yyyy-MM-dd HH}h{0:mm}m Recording.txt", DateTime.UtcNow));
                swLog = new StreamWriter(log_filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating output file [" + log_filename + "] <" + ex.Message + ">");
                swLog = null;
                return;
            }
            lbl_logStatus.Text = "Logging: Active.";

            //***************************************
            //  DEVICE INIT
            //      send null command to clear send buffer
            //      request device name
            //

            try
            {
                helperSerialPort.SerialCmdSend("null\r\n");
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending command <" + ex.Message + ">");
            }

            try
            {
                DeviceCommand("device", 2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Device name <" + ex.Message + ">");
            }


            try
            {
                DeviceCommand("version", 2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Device version <" + ex.Message + ">");
            }

        }  // end of Device/Connect

        //--------------------------------------------------
        //      Menu: Tools/Device Console 
        //--------------------------------------------------
        private void deviceConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (helperSerialPort == null || helperSerialPort.Port == null)
            {
                MessageBox.Show("Timer Device not connected!");
                return;
            }

            using( dlgConsole dlgConsoleWindow = new dlgConsole(helperSerialPort))
            {
                dlgConsoleWindow.ShowDialog();
            }

        } // end of device/console window

        //--------------------------------------------------
        //  data received event handler
        //--------------------------------------------------
        private void main_DataReceived(object sender, SerialPortDataReceivedEventArgs e)
        {

            //Debug.WriteLine("main_DataReceived: " + e.Data);


            // we have a new line
            //   write to the to file
            //
            if (swLog != null)
            {
                try
                {
                    swLog.Write(e.Data);
                }
                catch ( Exception ex)
                {
                    throw new IOException("log write error <" + ex.Message + ">");
                }
            }

            //
            //   if this is command info and command queue is NOT empty
            //      process the command state machine
            //
            if ((e.Data[0] == '[') && (cmdQueue.Count > 0))
            {
                // we have a command packet
                //  check the state of the front command in the queue

                cmdPacket pCmd;

                pCmd=cmdQueue.Peek();
                
                switch (pCmd.cmdState)
                {
                    case cmdStates.WaitingForEcho:
                        // we are expecting an echo for THIS command
                        //
                        if (e.Data.Contains(pCmd.strCommand))
                        {
                            // ok... we got the echo
                            //      change state of this command to waiting for the result
                            //
                            pCmd.cmdState = cmdStates.WaitingForResult;
                        }
                        else
                        {
                            // received message not this command... do nothing
                            return;
                        }
                        break;

                    case cmdStates.WaitingForResult:
                        // this must be the result!
                        //  remove this command from the queue
                        //  add the result
                        //  and hand off result to processing...
                        //

                        pCmd = cmdQueue.Dequeue();
                        pCmd.strResult = e.Data;
                        pCmd.cmdState = cmdStates.Done;
                        ProcessCommand(pCmd);
                        break;

                    case cmdStates.Done:
                        // shouldn't be here => just ignore it
                        //
                        return;

                } // end of command state machine

            }  // end of command checking entry in command queue



        } // end of datareceived handler

        //--------------------------------------------------
        //  DeviceCommand - send command to device
        //--------------------------------------------------
        public void DeviceCommand(string strCommand, long msTimeout)
        {
            cmdPacket cmdSent = new cmdPacket();

            // add this command to Queue
            //
            cmdSent.strCommand = strCommand;
            cmdSent.dteTimeOut = DateTime.UtcNow.AddMilliseconds(msTimeout);
            cmdSent.strResult = string.Empty;
            cmdSent.cmdState = cmdStates.WaitingForEcho;
            cmdQueue.Enqueue(cmdSent);

            // send command to device
            //
            try
            {
                helperSerialPort.SerialCmdSend(strCommand + "\r\n");
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending command <" + ex.Message + ">");
            }

        } // end of DeviceCommand

        //--------------------------------------------------
        //  ProcessCommand - handle result from device command
        //--------------------------------------------------
        private void ProcessCommand(cmdPacket pCmd)
        {
            int iLen = pCmd.strResult.LastIndexOf("]");     // index of terminating ] char

            // which command?
            //

            // device command
            //
            if (pCmd.strCommand.Contains("device"))
            {
                // update local variable
                if (iLen < 1)
                {
                    strDeviceName = "ERROR";
                    return;
                }
                strDeviceName = pCmd.strResult.Substring(1,iLen-1);

                // update GUI
                //
                gb_Timer.Invoke(() =>
                {
                    gb_Timer.Text = strDeviceName + " " + strDeviceVersion;
                });

            }  // end of "device" command

            // version command
            //
            else if (pCmd.strCommand.Contains("version"))
            {
                // update local variable
                if (iLen < 1)
                {
                    strDeviceVersion = "ERROR";
                    return;
                }
                strDeviceVersion = pCmd.strResult.Substring(1, iLen - 1);

                // update GUI
                //
                gb_Timer.Invoke(() =>
                {
                    gb_Timer.Text = strDeviceName + " " + strDeviceVersion;
                });

            }  // end of "device" command

        } // end of ProcessCommand

    } // end of form
}
