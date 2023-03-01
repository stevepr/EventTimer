/******************************************
 * dlgSelectPort
 * 
 * Date: Feb 2023
 * 
 * Description
 * This dialog asks the user to select a COM port for the timer device
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
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;

namespace EventTimer
{
    public partial class dlgSelectPort : Form
    {

        //============================================================
        //    Properties
        //============================================================
        public string strPortName;

        private ComPorts comPorts;

        //============================================================
        //    METHODS
        //============================================================

        //*************************************
        //  Init
        //
        //  OUTPUTS:
        //      strPortName - reference ptr for name of serial port to be used
        //
        //  ERRORS:
        //      Exception if null pointers for objects or index < 0
        //
        //*************************************
        public dlgSelectPort(ComPorts In_comPorts)
        {
            InitializeComponent();

            // init
            //
            strPortName = String.Empty;
            comPorts = In_comPorts;

            if (comPorts.Ports.Count == 0)
            {
                MessageBox.Show("No COM ports available!");
                DialogResult = DialogResult.Cancel;
                return;
            }

            for(int i = 0; i < comPorts.Ports.Count; i++)
            {
                cbxPorts.Items.Add(comPorts.Ports[i].Name);
            }
            cbxPorts.SelectedIndex = 0;

        } // end of form init

        private void cb_OK_Click(object sender, EventArgs e)
        {
            int iPos;

            iPos = cbxPorts.SelectedIndex;
            strPortName = comPorts.Ports[iPos].PortName;
            DialogResult = DialogResult.OK;
        }

        private void cb_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
