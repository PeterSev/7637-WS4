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

            _frmMain.niControl.statusDCUpdate += NiControl_statusUpdate;
            _frmMain.niControl.warningDCUpdate += NiControl_warningUpdate;
            _frmMain.niControl.updateStateDC += NiControl_updateStateDC;

            _frmMain.niControl.bufReadDMMReceived += NiControl_bufReadDMMReceived;
            _frmMain.niControl.statusDMMUpdate += NiControl_statusDMMUpdate;
            _frmMain.niControl.warningDMMUpdate += NiControl_warningDMMUpdate;
        }

        #region EVENTS
        //DMM events
        private void NiControl_warningDMMUpdate(string msg)
        {
            txtDMMWarning.Text = msg;
        }

        private void NiControl_statusDMMUpdate(string msg)
        {
            txtDMMStatus.Text = msg;
        }

        private void NiControl_bufReadDMMReceived(double[] buf)
        {
            lstDMMValues.Items.Clear();
            foreach (double d in buf)
                lstDMMValues.Items.Add(d);
        }


        //DC events
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
                lblV1.Text = "V: " + Math.Round(obj.Volt1, 6).ToString();
                lblV2.Text = "V: " + Math.Round(obj.Volt2, 6).ToString();
                ind1.BackColor = obj.B1 ? Color.LightGreen : Color.Red;
                ind2.BackColor = obj.B2 ? Color.LightGreen : Color.Red;
                ind1OVP.BackColor = obj.BOVP1 ? SystemColors.Control : Color.Red;
                ind2OVP.BackColor = obj.BOVP2 ? SystemColors.Control : Color.Red;

                if(obj.B1 || obj.B2)
                    //Инициируем запуск чтения мультиметра после прихода данных
                    _frmMain.niControl.ReadDMM();

            });
        }

        public void NiControl_statusUpdate(string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtDCStatus.Text = msg;
            });
            
        }
#endregion

        private void frmNI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            
            _frmMain.niControl.statusDCUpdate -= NiControl_statusUpdate;
            _frmMain.niControl.updateStateDC -= NiControl_updateStateDC;
            _frmMain.niControl.warningDCUpdate -= NiControl_warningUpdate;

            _frmMain.niControl.statusDMMUpdate -= NiControl_statusDMMUpdate;
            _frmMain.niControl.warningDMMUpdate -= NiControl_warningDMMUpdate;
            _frmMain.niControl.bufReadDMMReceived -= NiControl_bufReadDMMReceived;
            this.Hide();
        }

        private void frmNI_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.ReadDMM();
        }
    }
}
