using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _7637_WS4
{
    public partial class frmNI : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        int cntToPaint2 = 0;
        double[] bufToPaintGraph = new double[1000];


        public frmNI()
        {
            InitializeComponent();
            //Init();
        }

        void Init()
        {
            bNeedReload = false;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[0].LegendText = "Эталон";
            chart1.Series[1].LegendText = "Фактич.";

            _frmMain.niControl = new NIControl();
            _frmMain.niControl.StatusDCUpdate += NiControl_statusUpdate;
            _frmMain.niControl.WarningDCUpdate += NiControl_warningUpdate;
            _frmMain.niControl.UpdateStateDC += NiControl_updateStateDC;
            
            _frmMain.niControl.bufReadDMMReceived += NiControl_bufReadDMMReceived;
            _frmMain.niControl.StatusDMMUpdate += NiControl_statusDMMUpdate;
            _frmMain.niControl.WarningDMMUpdate += NiControl_warningDMMUpdate;

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

            _frmMain.niControl.daqEtalon.BufReadDAQReceived += NiControl_bufReadDAQReceived;
            _frmMain.niControl.daqEtalon.WarningDAQUpdate += NiControl_warningDAQUpdate;
            _frmMain.niControl.daqMeasured.BufReadDAQReceived += NiControl_bufReadDAQMeasuredReceived;
            _frmMain.niControl.daqMeasured.WarningDAQUpdate += NiControl_warningDAQUpdate;

            //_frmMain.niControl.Init();
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

            //_frmMain.resultOfMeasurementDMM = dmmResult.buf[0];
            _frmMain.resultOfMeasurementDMM = dmmResult.buf.Average();

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
            if (!chkShowSwitch.Checked) return;
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
                lblV1.Text = "V: " + Math.Round(obj.Volt1, 2).ToString();
                lblV2.Text = "V: " + Math.Round(obj.Volt2, 2).ToString();
                lblILim1.Text = "ILim: " + Math.Round(obj.Curlim1, 2).ToString();
                lblILim2.Text = "ILim: " + Math.Round(obj.Curlim2, 2).ToString();
                lblI1.Text = "ICur: " + Math.Round(obj.Cur1, 3).ToString();
                lblI2.Text = "ICur: " + Math.Round(obj.Cur2, 3).ToString();
                ind1.BackColor = obj.B1 ? Color.LightGreen : Color.Red;
                ind2.BackColor = obj.B2 ? Color.LightGreen : Color.Red;
                ind1OVP.BackColor = obj.BOVP1 ? SystemColors.Control : Color.Red;
                ind2OVP.BackColor = obj.BOVP2 ? SystemColors.Control : Color.Red;

                if (obj.B2)
                {
                    //Ловушка
                }

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


        //int cntToPaint = 0, cntToPaint2 = 0;

        //DAQ Events
        
        private void NiControl_bufReadDAQMeasuredReceived(double[] buf)
        {
            _frmMain.maxOfMeasuredSignal = buf.Max();
            _frmMain.amplOfMeasuredSignal = Math.Round((Math.Abs(_frmMain.maxOfMeasuredSignal) + Math.Abs(buf.Min())), 3);
            _frmMain._frmBU_Prozv_Test.eventDAQMeasuredUpdate.Set();

            //BeginInvoke((MethodInvoker)delegate
            //{
            /*lstDAQMeasuredValues.Items.Clear();
            foreach (double d in buf)
                lstDAQMeasuredValues.Items.Add(d);*/
            if (_frmMain._frmBU_Prozv_Test.curMode == ProzvMode.Выборочная)
            {
                cntToPaint2++;

                if (_frmMain.amplOfMeasuredSignal >= _frmMain.amplOfEtalonSignal - 2)
                {
                    _frmMain._frmBU_Prozv_Test.lblResultOfDAQ.ForeColor = Color.LightGreen;
                    _frmMain._frmBU_Prozv_Test.lblResultOfDAQ.Text = "PASSED";
                }
                else
                {
                    _frmMain._frmBU_Prozv_Test.lblResultOfDAQ.ForeColor = Color.Red;
                    _frmMain._frmBU_Prozv_Test.lblResultOfDAQ.Text = "FAILED";
                }
            }
            else if (_frmMain._frmBU_Prozv_Test.curMode == ProzvMode.КонтрольОбрыв)
                cntToPaint2 = 50;
            //else if (_frmMain._frmBU_Prozv_Test.curMode == ProzvMode.КонтрольКЗ)
                //cntToPaint2 = 0;

            if (cntToPaint2 >= 50)          //прореживаем отрисовку графика
            {
                lblMaxMeasured.Text = "Measured MAX: ".PadRight(16) + Math.Round(_frmMain.maxOfMeasuredSignal, 3).ToString("F3").PadLeft(7);
                lblMeasuredSum.Text = "Measured AMPL: ".PadRight(16) + _frmMain.amplOfMeasuredSignal.ToString("F3").PadLeft(7);


                chart1.Series[1].Points.Clear();
                Array.Copy(buf, bufToPaintGraph, bufToPaintGraph.Length);   //чтобы не нагружать график, рисуем лишь первых 1000 точек входящего буфера
                for (int i = 0; i < bufToPaintGraph.Length; i++)
                {
                    chart1.Series[1].Points.AddXY(i, bufToPaintGraph[i]);
                }

                cntToPaint2 = 0;
            }
        }

        
        private void NiControl_bufReadDAQReceived(double[] buf)
        {
            _frmMain.maxOfEtalonSignal = buf.Max();
            _frmMain.amplOfEtalonSignal = Math.Round((Math.Abs(_frmMain.maxOfEtalonSignal) + Math.Abs(buf.Min())), 3);
            _frmMain._frmBU_Prozv_Test.eventDAQEtalonUpdate.Set();


            //BeginInvoke((MethodInvoker)delegate
            //{
            /*lstDAQEtalonValues.Items.Clear();
            foreach (double d in buf)
                lstDAQEtalonValues.Items.Add(d);*/
            //cntToPaint++;
            //if (cntToPaint >= 10)
            //{
                lblMaxEtalon.Text = "Etalon MAX: ".PadRight(16) + Math.Round(_frmMain.maxOfEtalonSignal, 3).ToString("F3").PadLeft(7);

                chart1.Series[0].Points.Clear();
                Array.Copy(buf, bufToPaintGraph, bufToPaintGraph.Length);   //чтобы не нагружать график, рисуем лишь первых 100 точек входящего буфера

                for (int i = 0; i < bufToPaintGraph.Length; i++)
                {
                    chart1.Series[0].Points.AddXY(i, bufToPaintGraph[i]);
                }

                //cntToPaint = 0;
            //}
            //});
        }

        private void NiControl_warningDAQUpdate(string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txtDAQWarning.Text = msg;
                _frmMain._frmBU_Prozv_Test.ResetControls(true);
            });
        }

        #endregion

        private void frmNI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            
            _frmMain.niControl.StatusDCUpdate -= NiControl_statusUpdate;
            _frmMain.niControl.UpdateStateDC -= NiControl_updateStateDC;
            _frmMain.niControl.WarningDCUpdate -= NiControl_warningUpdate;

            _frmMain.niControl.StatusDMMUpdate -= NiControl_statusDMMUpdate;
            _frmMain.niControl.WarningDMMUpdate -= NiControl_warningDMMUpdate;
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

        private void txtDAQWarning_MouseClick(object sender, MouseEventArgs e)
        {
            txtDAQWarning.Text = string.Empty;
        }

        private void txtR1Warning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = string.Empty;
        }
    }
}
