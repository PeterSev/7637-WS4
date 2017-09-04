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

            _frmMain.niControl.relayR1.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR1.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR2.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR2.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR3.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR3.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR4.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR4.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR5.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR5.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR6.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR6.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR7.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR7.warningSWITCH += Relay_warningSWITCH;
            _frmMain.niControl.relayR8.statusSWITCH += Relay_statusSWITCH;
            _frmMain.niControl.relayR8.warningSWITCH += Relay_warningSWITCH;

            _frmMain.niControl.warningDAQUpdate += NiControl_warningDAQUpdate;
            _frmMain.niControl.bufReadDAQEtalonReceived += NiControl_bufReadDAQReceived;
            _frmMain.niControl.bufReadDAQMeasuredReceived += NiControl_bufReadDAQMeasuredReceived;
        }

        private void NiControl_bufReadDAQMeasuredReceived(double[] buf)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                lstDAQMeasuredValues.Items.Clear();
                foreach (double d in buf)
                    lstDAQMeasuredValues.Items.Add(d);
                lblMaxMeasured.Text = "Measured MAX: " + buf.Max();

                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].Points.Clear();
                for (int i = 0; i < buf.Length; i++)
                {
                    chart1.Series[1].Points.AddXY(i, buf[i]);
                }

            });
        }

        private void NiControl_bufReadDAQReceived(double[] buf)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                lstDAQEtalonValues.Items.Clear();
                foreach (double d in buf)
                    lstDAQEtalonValues.Items.Add(d);
                lblMaxEtalon.Text = "Etalon MAX: " + buf.Max();

                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].Points.Clear();
                for(int i = 0; i < buf.Length; i++)
                {
                    chart1.Series[0].Points.AddXY(i, buf[i]);
                }
            });
        }

        private void NiControl_warningDAQUpdate(string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtDAQWarning.Text = msg;
            });
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

        private void NiControl_bufReadDMMReceived(DMMResult dmmResult)
        {
            lstDMMValues.Items.Clear();
            foreach (double d in dmmResult.buf)
                lstDMMValues.Items.Add(d);
            txtDMMMeasurementMode.Text = dmmResult.measurementMode;

            //if (_frmMain.bNeedRewrite)
            //{
                _frmMain.resultOfMeasurementDMM = dmmResult.buf[0];
                //_frmMain.cntOfResMeasurementDMM++;
                //_frmMain.bNeedRewrite = false;
                //_frmMain.bReadyToRead = true;
            //}
        }

        //SWITCH events
        private void Relay_warningSWITCH(string name, string msg)
        {
            TextBox txt;
            switch (name)
            {
                case "R1": txt = txtR1Warning; break;
                case "R2": txt = txtR2Warning; break;
                case "R3": txt = txtR3Warning; break;
                case "R4": txt = txtR4Warning; break;
                case "R5": txt = txtR5Warning; break;
                case "R6": txt = txtR6Warning; break;
                case "R7": txt = txtR7Warning; break;
                case "R8": txt = txtR8Warning; break;
                default: txt = txtR1Warning; break;
            }
            txt.Text = msg;
        }

        private void Relay_statusSWITCH(string name, string msg)
        {
            ListBox lst;
            switch (name)
            {
                case "R1": lst = lstR1; break;
                case "R2": lst = lstR2; break;
                case "R3": lst = lstR3; break;
                case "R4": lst = lstR4; break;
                case "R5": lst = lstR5; break;
                case "R6": lst = lstR6; break;
                case "R7": lst = lstR7; break;
                case "R8": lst = lstR8; break;
                default: lst = lstR1; break;
            }
            lst.Items.Add(msg);
            lst.ClearSelected();
            lst.SelectedIndex = lst.Items.Count - 1;
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

                //if(obj.B1 || obj.B2)
                //Инициируем запуск чтения мультиметра после прихода данных
                //_frmMain.niControl.ReadDMM("Resistance");
                //_frmMain.niControl.ReadDMM("Resistance");
                /*if (obj.B1 && obj.BOVP1)
                    _frmMain.bNeedRewrite = true;*/
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

        private void lstR6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lst = (ListBox)sender;
            lst.Items.Clear();
        }
    }
}
