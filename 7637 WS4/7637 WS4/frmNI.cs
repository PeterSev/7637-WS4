using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7637_WS4
{
    public partial class frmNI : Form
    {
        public frmMain _frmMain;
        public frmNI()
        {
            InitializeComponent();
        }

        public void NiControl_warningUpdate(string msg)
        {
            txtDCWarning.Text = msg;
        }

        public void NiControl_updateStateDC(StateDC obj)
        {
            throw new NotImplementedException();
        }

        public void NiControl_statusUpdate(string msg)
        {
            txtDCStatus.Text = msg;
        }
    }
}
