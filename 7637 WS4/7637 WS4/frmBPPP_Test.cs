﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ExcelLib;
using Ivi.DCPwr;

namespace _7637_WS4
{
    public partial class frmBPPP_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBPPPTestFileName = String.Empty; //"BPPP_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        BPPPTest[] tests;

        //Переменные для источника питания
        IIviDCPwr iviDCPower;
        Thread thr;
        bool bNeedUpdate = false, bNeedExit = false;
        static string DC_DeviceName = "DC";
        CurrentLimitBehavior curLimitBehavior = CurrentLimitBehavior.Regulate;
        double curLimit = 0.02, voltageLevel = 1.0;
        List<string> listDCChannels = new List<string>();
        string curDCChannel = string.Empty;
        List<CurrentLimitBehavior> listDCCurLimitBehaviour = new List<CurrentLimitBehavior>();
        //--------------------------------



        void Init()
        {
            bNeedReload = false;
            tests = null;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BPPP/" +_frmMain._frmBPPP.curBpppBoard.Name + "/";
            listBPPPTestFileName = _frmMain._frmBPPP.curBpppBoard.Name + ".xls";

            this.Text = curBoard.Name + " БППП. " + "Плата " + _frmMain._frmBPPP.curBpppBoard.Name + ". Прохождение тестов";
            this.BackColor = Color.RoyalBlue;
            grpTestInfo.ForeColor = Color.White;

            if(Utils.isFileExist(catalog + listBPPPTestFileName))
            {
                tests = Excel.ParseBPPP(catalog + listBPPPTestFileName);    //открываем список тестов из экселевского файла
                lblTEstCount.Text = tests.Length.ToString();

                InitDC();
            }
            else
            {
                MessageBox.Show("File " + catalog + listBPPPTestFileName + " isn't found!", "Load error");
            }
        }


        #region Методы и функции, описывающие работу с источником питания DC

        /// <summary>
        /// Инициализация источника питания
        /// </summary>
        void InitDC()
        {
            try
            {
                iviDCPower = IviDCPwr.Create(DC_DeviceName, true, true);
                ConfigureChannelName();
                ConfigureCurrentlimitBehavior();
                txtDCStatus.Text = "SUCCESS";

                
                thr = new Thread(updateDCProcessing);
                thr.Start();
            }
            catch(Exception ex)
            {
                txtDCStatus.Text = ex.Message;
            }
        }

        private void updateDCProcessing()
        {
            while (!bNeedExit)
            {
                if (bNeedUpdate)
                {
                    UpdateIVIDCPwrOutput();
                    bNeedUpdate = false;
                }
                Thread.Sleep(100);
            }
        }

        void UpdateIVIDCPwrOutput()
        {
            if (iviDCPower == null) return;

            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    //конфигурация и запуск источника питания
                    curDCChannel = listDCChannels[0];
                    iviDCPower.Outputs[curDCChannel].ConfigureCurrentLimit(curLimitBehavior, curLimit);
                    iviDCPower.Outputs[curDCChannel].VoltageLevel = voltageLevel;

                    iviDCPower.Outputs[curDCChannel].Enabled = true; //непосредственный запуск
                });
            }
            catch(Exception ex)
            {
                txtDCStatus.Text = ex.Message;
            }
        }

        void ConfigureChannelName()
        {
            listDCChannels.Clear();
            foreach (IIviDCPwrOutput channel in iviDCPower.Outputs)
            {
                listDCChannels.Add(channel.Name);
            }
        }

        void ConfigureCurrentlimitBehavior()
        {
            listDCCurLimitBehaviour.Clear();
            foreach (CurrentLimitBehavior item in Enum.GetValues(typeof(CurrentLimitBehavior)))
            {
                listDCCurLimitBehaviour.Add(item);
            }
        }

        void CloseDCIVISession()
        {
            bNeedExit = true;
            if (iviDCPower != null)
            {
                try
                {
                    iviDCPower.Outputs[curDCChannel].Enabled = false;
                    iviDCPower.Close();
                    iviDCPower = null;
                }
                catch(Exception ex)
                {
                    txtDCStatus.Text = ex.Message;
                }
            }
        }
        #endregion









        public frmBPPP_Test()
        {
            InitializeComponent();
        }

        private void frmBPPP_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBPPP_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            CloseDCIVISession();
            this.Hide();
            _frmMain._frmBPPP.Show();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBPPP_Report.Show();
        }
    }
}
