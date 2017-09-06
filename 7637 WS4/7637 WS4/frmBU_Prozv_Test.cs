using System;
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
        bool bNeedStop = false;

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

            badTests = new List<DAQTest>();

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

            eventDAQEtalonUpdate.Reset();
            _frmMain.niControl.daqEtalon.RunDAQ();
            eventDAQEtalonUpdate.WaitOne(50);
            Thread.Sleep(50);

            RunDAQTest(num);
        }

        void RunDAQTest(int num)
        {
            DAQTest test = tests[num];

            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev1, ch1);

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev2, ch2);
            //--------------------------------------
            //Thread.Sleep(500);


            //Проведение измерений и вычисление результата------------
            eventDAQMeasuredUpdate.Reset();
            _frmMain.niControl.daqMeasured.RunDAQ();
            eventDAQMeasuredUpdate.WaitOne(50);
            Thread.Sleep(50);

            string sRes = string.Empty;
            if (_frmMain.maxOfMeasuredSignal >= _frmMain.maxOfEtalonSignal)
            {
                lblResultOfDAQ.ForeColor = Color.LightGreen;
                sRes = "PASSED";
            }
            else
            {
                lblResultOfDAQ.ForeColor = Color.Red;
                badTests.Add(tests[num]);             //только в циклической проверке
                sRes = "FAILED";
            }

            lblResultOfDAQ.Text = sRes;

            tests[num].Result = sRes;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DAQTest test = tests[54];

            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev1, ch1);

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev2, ch2);
            //--------------------------------------
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAQTest test = tests[54];

            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(false, dev1, ch1);

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(false, dev2, ch2);
            //--------------------------------------
        }
        void RunDAQAllTests(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                lblRunCount.Text = "Выполняется № " + (i + 1).ToString();
                int v = ((i + 1) * 100 / cnt);
                if (colorProgressBar.Value != v) colorProgressBar.Value = v;

                if (bNeedStop) break;
                RunDAQTest(i);
                //Thread.Sleep(50);
            }
        }


        private void btnRunAllDAQTest_Click(object sender, EventArgs e)
        {
            bNeedStop = false;
            btnRunAllDAQTest.Enabled = false;
            btnStopAllTest.Enabled = true;
            colorProgressBar.Visible = true;
            badTests.Clear();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            eventDAQEtalonUpdate.Reset();
            _frmMain.niControl.daqEtalon.RunDAQ();
            eventDAQEtalonUpdate.WaitOne(50);
            Thread.Sleep(20);

            RunDAQAllTests(tests.Length);

            sw.Stop();
            lblT.Text = sw.Elapsed.ToString();
            btnStopAllTest.Enabled = false;
            btnRunAllDAQTest.Enabled = true;
            colorProgressBar.Visible = false;

            try
            {
                //Excel.SaveBPPP(tests, catalog + "Report.xls");
                //MessageBox.Show(Excel.SaveBPPP(tests, Application.StartupPath + @"\"+catalog + "Report_" + listBPPPTestFileName));
                if (Excel.SaveDAQ(tests, Application.StartupPath + @"\" + catalog + "Report_" + listBUProzvTest) != "Success")
                {
                    MessageBox.Show("Ошибка сохранения файла репорта! Проверьте в отладчике причину", "Ошибка");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения файла отчета Excel " + ex.Message, "Сохранение");
            }
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            bNeedStop = true;

            btnStopAllTest.Enabled = false;
            btnRunAllDAQTest.Enabled = true;
        }
    }
}
