/******************************************
 * HelperSerialPort
 * 
 * Date: Feb 2023
 * 
 * Description
 * This class helps with reading and writing the serial port
 * 
 * Based on the following posts regarding limitations of the default implementation of 
 * SerialPort in .NET.  I decided to use a mix of options from the following posts.
 *      - https://stackoverflow.com/questions/38507955/c-sharp-gui-refresh-and-async-serial-port-communication
 *      - https://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport
 *      - https://stackoverflow.com/questions/68777489/what-is-the-proper-use-of-serialport-basestream-beginread
 *      - https://stackoverflow.com/questions/65957066/serial-to-usb-cable-from-a-scale-to-pc-some-values-are-just-question-marks/65971845#65971845
 * 
*******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Management;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace EventTimer
{

    public enum PortBaudRate : int
    {
        Baud1200 = 1200,
        Baud2400 = 2400,
        Baud4800 = 4800,
        Baud9600 = 9600,
        Baud14400 = 14400,
        Baud19200 = 19200,
        Baud28800 = 28800,
        Baud38400 = 38400,
        Baud56000 = 56000,
        Baud57600 = 57600,
        Baud76800 = 76800,
        Baud115200 = 115200,
        Baud128000 = 128000,
        Baud230400 = 230400,
        Baud250000 = 250000,
        Baud256000 = 256000
    };


    //=====================================
    //
    // C L A S S - HelperSerialPort
    //
    //=====================================
    //
    public class HelperSerialPort : IDisposable
    {
        //************************************
        //
        // DELEGATES
        //      
        //
        //************************************
        public delegate void SerialPortErrorReceivedEventHandler(object sender, SerialErrorReceivedEventArgs e);

        public event SerialPortDataReceivedEventHandler DataReceived;
        public event SerialPortErrorReceivedEventHandler ErrorReceived;

        //************************************
        //
        // P R O P E R T I E S
        //
        //************************************
        private string _dataReceived = string.Empty;
        public System.IO.Ports.SerialPort Port { get; private set; }

        private StringBuilder CurrentLine;

        private Task ReadSerialTask;
        private CancellationTokenSource CTS_ReadSerial;
        private CancellationToken ct_ReadSerial;

        //************************************
        //
        // M E T H O D S
        //
        //************************************

        //--------------------------------------------------
        //  Constructor
        //--------------------------------------------------
        public HelperSerialPort()
        {
            //create new instance
            Port = new SerialPort();
            CurrentLine = new StringBuilder();
        }

        public void Connect(string comPort, PortBaudRate baudRate = PortBaudRate.Baud9600)
        {
            string portName = string.Empty;
            string result = string.Empty;

            if (String.IsNullOrEmpty(comPort))
            {
                System.Windows.Forms.MessageBox.Show("COM port not selected.", "Error - COM Port", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw new ArgumentException(" No Comm port specified");
            }

            try
            {
                if (Port == null)
                {
                    //create new instance
                    Port = new SerialPort();
                }

                if (!Port.IsOpen)
                {

                    //create new instance
                    Port = new SerialPort(comPort);

                    //set properties
                    Port.BaudRate = (int)baudRate;
                    Port.Handshake = Handshake.None;
                    Port.Parity = Parity.None; 			//Even,None,Odd supported
                    Port.DataBits = 8;
                    Port.StopBits = StopBits.One;
                    Port.ReadTimeout = 200;
                    Port.WriteTimeout = 50;

                    //open port
                    Port.Open();
                    Port.DiscardInBuffer();

                    /*
                                        //subscribe to events 
                                        Port.DataReceived += Port_DataReceived;
                                        Port.ErrorReceived += Port_ErrorReceived;
                    */

                    // start reading...
                    //
                    BeginLoop_ReadSerialPort();

                }
            }
            catch (Exception ex)
            {
                throw new IOException( ex.Message );
            }

        }


        public void Close()
        {
            EndLoop_ReadSerialPort();
            Dispose();
        }

        public void Dispose()
        {
            if (Port != null)
            {
                if (Port.IsOpen)
                {
                    Port.Close();
                }

                //unsubscribe from events
                Port.DataReceived -= Port_DataReceived;
                Port.ErrorReceived -= Port_ErrorReceived;

                Port.Dispose();

                Port = null;
            }

        }


        public ComPorts GetComPortInfo()
        {
            ComPorts comPorts = new ComPorts();

            SortedDictionary<string, string> comPortNameDict = new SortedDictionary<string, string>();
            SortedDictionary<string, string> portDict = new SortedDictionary<string, string>();

            string[] portNames = SerialPort.GetPortNames();

            //get USB COM ports
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_PnPEntity"))
            {
                ManagementObjectCollection pnpEntityItems = searcher.Get();

                if (portNames != null && pnpEntityItems != null)
                {
                    var props = pnpEntityItems.GetEnumerator();

                    foreach (ManagementBaseObject mbo in pnpEntityItems)
                    {
                        if (mbo != null)
                        {
                            object nameObj = mbo.GetPropertyValue("Name");
                            object pnpClassObj = mbo.GetPropertyValue("PNPClass");

                            if (nameObj != null && pnpClassObj != null)
                            {
                                if (pnpClassObj.ToString() == "Ports" && nameObj.ToString().ToLower().Contains("(com"))
                                {
                                    string name = mbo.GetPropertyValue("Name").ToString().Trim();
                                    //Debug.WriteLine("name: " + name);

                                    string portName = string.Empty;

                                    if (name.Contains("(") && name.Contains(")"))
                                    {
                                        portName = name.Substring(name.IndexOf("(") + 1, name.IndexOf(")") - name.IndexOf("(") - 1);
                                        //Debug.WriteLine("Port Name: '" + portName + "'");
                                    }

                                    if (!portDict.ContainsKey(name))
                                    {
                                        //add to dictionary - ex: Voyager 1450g, COM1
                                        portDict.Add(name, portName);

                                        //add to dictionary - ex: COM1, Voyager 1450g
                                        comPortNameDict.Add(portName, name);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //add any ports that aren't USB -- ie: RS-232 (serial) devices
            //USB devices are already in the dictionary, so only add devices 
            //that don't already exist in the dictionary
            if (portNames != null && portDict != null && comPortNameDict != null)
            {
                foreach (string name in portNames)
                {
                    if (!comPortNameDict.ContainsKey(name))
                    {
                        //add to dictionary
                        portDict.Add(name, name);
                    }
                }
            }

            foreach (KeyValuePair<string, string> kvp in portDict)
            {
                //add to list
                comPorts.Ports.Add(new ComPortInfo(kvp.Key, kvp.Value));
            }

            return comPorts;
        }

        private void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Debug.WriteLine("Error: (sp_ErrorReceived) - " + e.EventType);

            if (this.ErrorReceived != null)
            {
                ErrorReceived(this, e);
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _dataReceived = Port.ReadExisting();
//            Debug.WriteLine("Port_DataReceived: " + _dataReceived);

            if (this.DataReceived != null)
            {
                SerialPortDataReceivedEventArgs eventArgs = new SerialPortDataReceivedEventArgs(_dataReceived);
                DataReceived(this, eventArgs);
            }
        }

        public void SerialCmdSend(string data)
        {
            if (Port.IsOpen)
            {
                try
                {
                    // Send the binary data out the port
                    byte[] hexstring = Encoding.ASCII.GetBytes(data);

                    //write to SerialPort
                    foreach (byte hexval in hexstring)
                    {
                        byte[] _hexval = new byte[] { hexval }; // need to convert byte to byte[] to write
                        Port.Write(_hexval, 0, 1);
                        System.Threading.Thread.Sleep(1);
                    }
                }
                catch (Exception ex)
                {
                    throw new IOException("Send error <" + ex.Message + ">");
                }
            }
            else
            {
                throw new IOException("Error: Port is not open. Please open the connection and try again.");
            }
        }

        protected void BeginLoop_ReadSerialPort()
        {
            // New token required for each connection
            // because EndLoop() cancels and disposes it each time.
            CTS_ReadSerial?.Dispose();  // should already be disposed
            CTS_ReadSerial = new CancellationTokenSource();
            ct_ReadSerial = CTS_ReadSerial.Token;

            ReadSerialTask = Task.Run(() => { ReadSerialBytes_AsyncLoop(ct_ReadSerial); }, ct_ReadSerial);
        }

        private async void ReadSerialBytes_AsyncLoop(CancellationToken ct)
        {
            const int bytesToRead = 1024;

            try
            {
                while (Port.IsOpen && (!ct.IsCancellationRequested))
                {
                    var receiveBuffer = new byte[bytesToRead];
                    var numBytesRead = await Port.BaseStream?.ReadAsync(receiveBuffer, 0, bytesToRead, ct);


                    _dataReceived = System.Text.Encoding.ASCII.GetString(receiveBuffer, 0, numBytesRead);
                    Debug.WriteLine("Port_DataReceived: " + _dataReceived);

                    // collect data into lines before calling delegate
                    //
                    foreach (char c in _dataReceived)
                    {
                        // add this to the line...
                        //
                        CurrentLine.Append(c);

                        // if we have reached the end of a line, call datareceived delegate
                        if (c == '\n')
                        {
                            // call delegate
                            //
                            if (this.DataReceived != null)
                            {
                                SerialPortDataReceivedEventArgs eventArgs = new SerialPortDataReceivedEventArgs(CurrentLine.ToString());
                                DataReceived(this, eventArgs);
                            }

                            // clear the current line
                            CurrentLine.Clear();

                        } // end check for end of line

                    }  // end of loop through all received chars
                } // end of basic read loop

            }
            catch (Exception ex)
            {
                // Any exception means the connection is gone or the port is gone, so the session must be stopped.
                // Note that an IOException is always thrown by the serial port basestream when exit is requested.
                // for now... dispose of port on any error...
                //
                if (ex.Message.Contains("thread exit"))
                {
                    return;
                }

                if (Port?.BaseStream != null)
                {
                    Port?.Dispose();
                }
                throw new Exception("serial read loop error <" + ex.Message + ">");

            }
        } // end of read async loop

        protected void EndLoop_ReadSerialPort()
        {
            try
            {
                CTS_ReadSerial?.Cancel();
                ReadSerialTask?.Wait();
            }
            finally
            {
                CTS_ReadSerial?.Dispose();
            }
        }



    } // end of class



} // end of namespace
