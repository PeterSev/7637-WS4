using System;
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

        //Переменные для источника питания. Перемещено в отдельный класс
        /*IIviDCPwr iviDCPower;
        Thread thr;
        bool bNeedUpdate = false, bNeedExit = false;
        static string DC_DeviceName = "DC";
        CurrentLimitBehavior curLimitBehavior = CurrentLimitBehavior.Regulate;
        double curLimit = 0.02, voltageLevel = 1.0;
        List<string> listDCChannels = new List<string>();
        string curDCChannel = string.Empty;
        List<CurrentLimitBehavior> listDCCurLimitBehaviour = new List<CurrentLimitBehavior>();*/
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
            grpDC.ForeColor = Color.White;
            grpSwitch.ForeColor = Color.White;
            cmbSwitchName.SelectedIndex = 0;

            if(Utils.isFileExist(catalog + listBPPPTestFileName))
            {
                tests = Excel.ParseBPPP(catalog + listBPPPTestFileName);    //открываем список тестов из экселевского файла
                if (tests != null)
                {
                    lblTEstCount.Text = tests.Length.ToString();
                    _frmMain.niControl.DCSetOnOff("1", 0.1, false);
                    _frmMain.niControl.DCSetOnOff("1", 0.1, false);
                }
                else
                {
                    MessageBox.Show("Файл поврежден или имеет неверный формат");

                }
                //RunTests(tests);

            }
            else
            {
                MessageBox.Show("File " + catalog + listBPPPTestFileName + " isn't found!", "Load error");
            }
        }

        //void RunTests(BPPPTest[] tests)
        void RunBPPPAllTests(int cnt)
        {
            //_frmMain.niControl.DCSetOnOff("0", 24, true);
            //_frmMain.niControl.OpenCloseRelay(true, "R6", "64");
            //_frmMain.niControl.OpenCloseRelay(true, "R7", "66");
            
            for (int i = 0; i < cnt; i++)
            {
                RunBPPPTest(i, cnt);
            }
            


            //_frmMain.niControl.OpenCloseRelay(false, "R6", "64");
            //_frmMain.niControl.OpenCloseRelay(false, "R7", "66");
            //_frmMain.niControl.DCSetOnOff("0", 24, false);
        }

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
            //CloseDCIVISession();
            this.Hide();
            _frmMain._frmBPPP.Show();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBPPP_Report.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("0", (double)numDCV1.Value, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("1", (double)numDCV2.Value, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("0", (double)numDCV1.Value, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("1", (double)numDCV2.Value, false);
        }

        private void btnOpenRelay_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.OpenCloseRelay(true, cmbSwitchName.SelectedItem.ToString(),numSwitchChannel.Value.ToString());
        }

        private void btnCloseRelay_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.OpenCloseRelay(false, cmbSwitchName.SelectedItem.ToString(), numSwitchChannel.Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //RunTests((int)numTest.Value);
            int num = (int)numTest.Value;
            if(num>=tests.Length)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }
            RunBPPPTest(num, 1);

        }

        BPPPTest lastTest = null;
        private void RunBPPPTest(int num, int cntTotal)
        {
            BPPPTest test = tests[num]; //получаем текущий тес из общего списка

            if (lastTest != null) //будет НУЛЛОМ только в первый заход в цикл
            {
                for(int i = 0; i < lastTest.Input.Length; i++)
                {
                    if((lastTest.Input[i].Channel != test.Input[i].Channel) || (lastTest.Input[i].Device != test.Input[i].Device))
                    {
                        //выключение
                        string dev = lastTest.Input[i].Device;
                        string ch = lastTest.Input[i].Channel.ToString();
                        _frmMain.niControl.OpenCloseRelay(false, dev, ch);

                        //включение
                        dev = test.Input[i].Device;
                        ch = test.Input[i].Channel.ToString();
                        _frmMain.niControl.OpenCloseRelay(true, dev, ch);
                    }
                    if ((lastTest.Output[i].Channel != test.Output[i].Channel) || (lastTest.Output[i].Device != test.Output[i].Device))
                    {
                        string dev = lastTest.Output[i].Device;
                        string ch = lastTest.Output[i].Channel.ToString();
                        _frmMain.niControl.OpenCloseRelay(false, dev, ch);


                        dev = test.Output[i].Device;
                        ch = test.Output[i].Channel.ToString();
                        _frmMain.niControl.OpenCloseRelay(true, dev, ch);
                    }
                }
            }
            else
            {
                foreach (Contact input in test.Input)
                {
                    string dev = input.Device;
                    string ch = input.Channel.ToString();
                    _frmMain.niControl.OpenCloseRelay(true, dev, ch);
                }
                foreach (Contact output in test.Output)
                {
                    string dev = output.Device;
                    string ch = output.Channel.ToString();
                    _frmMain.niControl.OpenCloseRelay(true, dev, ch);
                }
            }

            lastTest = test;

            //ВКЛючение определенных каналов в реле
            /*foreach (Contact input in test.Input)
            {
                string dev = input.Device;
                string ch = input.Channel.ToString();
                _frmMain.niControl.OpenCloseRelay(true, dev, ch);
            }
            foreach (Contact output in test.Output)
            {
                string dev = output.Device;
                string ch = output.Channel.ToString();
                _frmMain.niControl.OpenCloseRelay(true, dev, ch);
            }*/
            //-------------------------------------------------------

            //Thread.Sleep((int)numTimeout.Value);

            //_frmMain.bNeedRewrite = true;
            //while (!_frmMain.bReadyToRead) { Application.DoEvents(); Thread.Sleep(50); }

            //_frmMain.bReadyToRead = false;


            //Проведение измерений---------------------------------------------
            _frmMain.niControl.ReadDMM("Resistance", test.Range);   //инициирование чтения мультиметра
            lblResultOfDMM.Text = Math.Round(_frmMain.resultOfMeasurementDMM, 6).ToString();    //запоминаем последнее значение от мультиметра
            tests[num].Value = Math.Round(_frmMain.resultOfMeasurementDMM, 6);
            lblRunCount.Text = "CNT: " + _frmMain.cntOfResMeasurementDMM;
            //-----------------------------------------------------------------

            //if (num >= tests.Length - 1)
            if (num >= cntTotal-1)
            {
                //ВЫКЛючение включенных каналов----------------------------
                foreach (Contact input in test.Input)
                {
                    string dev = input.Device;
                    string ch = input.Channel.ToString();
                    _frmMain.niControl.OpenCloseRelay(false, dev, ch);
                }
                foreach (Contact output in test.Output)
                {
                    string dev = output.Device;
                    string ch = output.Channel.ToString();
                    _frmMain.niControl.OpenCloseRelay(false, dev, ch);
                }
                lastTest = null;
                //-------------------------------------------------------
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //_frmMain.niControl.DCSetOnOff("0", 24, true);
            //_frmMain.niControl.OpenCloseRelay(true, "R6", "64");
            //_frmMain.niControl.OpenCloseRelay(true, "R7", "66");
            //Thread.Sleep(200);

                //RunTest((int)numTest.Value);
            RunBPPPAllTests(tests.Length);

            //_frmMain.niControl.OpenCloseRelay(false, "R6", "64");
            //_frmMain.niControl.OpenCloseRelay(false, "R7", "66");
            //_frmMain.niControl.DCSetOnOff("0", 24, false);
            sw.Stop();
            lblT.Text = sw.Elapsed.ToString();
            //var obj = tests.Where(p => p.Value > 0);

            lstResult.Items.Clear();
            for (int i = 0; i < tests.Length; i++)
            {
                lstResult.Items.Add(tests[i].Index + "  " + tests[i].Value);
            }
        }
    }
}
