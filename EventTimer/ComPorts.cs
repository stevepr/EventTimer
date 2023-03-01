/******************************************
 * ComPorts
 * 
 * Date: Feb 2023
 * 
 * Description
 * This class helps with reading and writing the serial port
 * 
 * Based on the following posts regarding limitations of the default implementation of 
 * SerialPort in .NET.  But I decided to go with the simple version based on .ReadExisting from the first post.
 *      - https://stackoverflow.com/questions/65957066/serial-to-usb-cable-from-a-scale-to-pc-some-values-are-just-question-marks/65971845#65971845
 *      - https://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport
 *      - https://stackoverflow.com/questions/68777489/what-is-the-proper-use-of-serialport-basestream-beginread
 * 
*******************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTimer
{
    public class ComPorts
    {
        public List<ComPortInfo> Ports { get; set; } = new List<ComPortInfo>();
    }

    public class ComPortInfo
    {
        public string Name { get; set; }
        public string PortName { get; set; }

        public ComPortInfo()
        {

        }

        public ComPortInfo(string name, string portName)
        {
            this.Name = name;
            this.PortName = portName;
        }
    }
}
