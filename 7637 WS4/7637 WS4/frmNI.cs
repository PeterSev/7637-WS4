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
        bool bNeedReload = true;
        public frmNI()
        {
            InitializeComponent();
            //Init();
        }

        void Init()
        {
            bNeedReload = false;

            _frmMain.niControl.statusUpdate += NiControl_statusUpdate;
            _frmMain.niControl.warningUpdate += NiControl_warningUpdate;
            _frmMain.niControl.updateStateDC += NiControl_updateStateDC;
        }
        public void NiControl_warningUpdate(string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtDCWarning.Text = msg;
            });
        }

        public void NiControl_updateStateDC(StateDC obj)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (obj.Ch == "0")
                {
                    lblV1.Text = "V: " + Math.Round(obj.Volt,6).ToString();
                    if (obj.B) ind1.BackColor = Color.LightGreen;
                    else ind1.BackColor = Color.Red;

                    if(obj.BOVP) ind1OVP.BackColor = Color.LightGreen;
                    else ind1OVP.BackColor = Color.Red;
                }
                else
                {
                    lblV2.Text = "V: " + Math.Round(obj.Volt,6).ToString();
                    if (obj.B) ind2.BackColor = Color.LightGreen;
                    else ind2.BackColor = Color.Red;

                    if (obj.BOVP) ind2OVP.BackColor = Color.LightGreen;
                    else ind2OVP.BackColor = Color.Red;
                }
            });
        }

        public void NiControl_statusUpdate(string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtDCStatus.Text = msg;
            });
            
        }

        private void frmNI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            
            _frmMain.niControl.statusUpdate -= NiControl_statusUpdate;
            _frmMain.niControl.updateStateDC -= NiControl_updateStateDC;
            _frmMain.niControl.warningUpdate -= NiControl_warningUpdate;
            this.Hide();
        }

        private void frmNI_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }
    }
}
