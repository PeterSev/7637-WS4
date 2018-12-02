using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7637_WS4
{
    public partial class frmComPort : Form
    {
        public frmMain _frmMain;
        public frmComPort()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            FillComPorts();
        }
        void FillComPorts()
        {
            cmbCom.Items.Clear();
            
            cmbCom.Items.AddRange(SerialPort.GetPortNames());
            if (cmbCom.Items.Count > 0)
                cmbCom.SelectedItem = cmbCom.Items[0];
            else
                cmbCom.Text = "No port!";
        }

        private void btnOKCom_Click(object sender, EventArgs e)
        {
            _frmMain._frmUDPDebug.sComport = cmbCom.SelectedText;
            this.Close();
        }
    }
}
