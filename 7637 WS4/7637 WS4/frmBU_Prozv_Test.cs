﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLib;
using System.Threading;

namespace _7637_WS4
{
    public partial class frmBU_Prozv_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUProzvTest = "BU_Prozv_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        DAQTest[] tests;
        DAQTest lastTest = null;
        public List<DAQTest> badTests;

        public AutoResetEvent eventDAQEtalonUpdate = new AutoResetEvent(false);
        public AutoResetEvent eventDAQMeasuredUpdate = new AutoResetEvent(false);

        public frmBU_Prozv_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            string curMode = string.Empty;
            switch (_frmMain._frmBU_Prozv_Mode.curMode)
            {
                default:
                case ProzvMode.КонтрольОбрыв: curMode = "Контроль на отсутствие цепей"; break;
                case ProzvMode.КонтрольКЗ: curMode = "Контроль на отсутствие КЗ"; break;
                case ProzvMode.Выборочная: curMode = "Выборочная проверка"; break;
            }

            tests = null;
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";

            this.Text = curBoard.Name + " БУ. Прозвонка. " + curMode +  ". Тесты";
            this.BackColor = Color.RoyalBlue;

            if(Utils.isFileExist(catalog + listBUProzvTest))
            {
                tests = Excel.ParseDAQ(catalog + listBUProzvTest);
                if (tests != null)
                {
                    lblTestCount.Text = tests.Length.ToString();
                }
                else
                {
                    MessageBox.Show("Файл поврежден или имеет неверный формат");
                }
            }
            else
            {
                MessageBox.Show("File " + catalog + listBUProzvTest + " isn't found!", "Load error");
            }


        }

        private void frmBZ_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }
        private void frmBZ_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
                _frmMain._frmBU_Prozv_Mode.Show();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBU_Prozv_Report.Show();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            if (num >= tests.Length)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }
            //_frmMain.niControl.RunDAQ("/DAQ/ai1");   //получаем и измеряем эталонные значения сигнала
            //Thread.Sleep(500);
            
            //eventDAQEtalonUpdate.Reset();
            RunDAQTest(num);
        }

        void RunDAQTest(int num)
        {
            //_frmMain.niControl.RunDAQ("/DAQ/ai1");   //получаем и измеряем эталонные значения сигнала
            //eventDAQEtalonUpdate.WaitOne();

            DAQTest test = tests[num];

            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev1, ch1);

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev2, ch2);
            //--------------------------------------



            //Проведение измерений и вычисление результата------------
            //_frmMain.niControl.RunDAQ("/DAQ/ai0"); //получаем и сохраняем значения сигнала измеренного фактического
            //eventDAQMeasuredUpdate.WaitOne();

            string sRes = string.Empty;
            if (_frmMain.maxOfMeasuredSignal >= _frmMain.maxOfEtalonSignal)
            {
                lblResultOfDAQ.ForeColor = Color.LightGreen;
                sRes = "PASSED";
            }
            else
            {
                lblResultOfDAQ.ForeColor = Color.Red;
                //badTests.Add(tests[num]);             //только в циклической проверке
                sRes = "FAILED";
            }

            lblResultOfDAQ.Text = sRes;
            //-------------------------------------------------------




            //Выключение необходимых реле-------------
            _frmMain.niControl.OpenCloseRelay(false, dev1, ch1);
            _frmMain.niControl.OpenCloseRelay(false, dev2, ch2);
            //--------------------------------------
        }

        private void btnRunDAQ_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.daqEtalon.RunDAQ();
            Thread.Sleep(50);
            _frmMain.niControl.daqMeasured.RunDAQ();

            /*_frmMain.niControl.RunDAQ("/DAQ/ai1");
            Thread.Sleep(200);
            _frmMain.niControl.RunDAQ("/DAQ/ai0");*/
        }
    }
}
