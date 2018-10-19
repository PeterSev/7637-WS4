using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLib;
using Ivi.DCPwr;

namespace _7637_WS4
{
    public enum MultimeterMode { DCVolts, TwoWireResistance, Diode };
    delegate void DelFinishTests();

    public partial class frmBPPP_Test : Form
    {
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        event DelFinishTests delFinishTests;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        


        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBPPPTestFileName = String.Empty; //"BPPP_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        //bool bNeedStop = false;
        //int numCurTest = 0;
        BPPPTest[] tests;
        public List<BPPPTest> badTests;
        BPPPTest lastTest = null;
        //--------------------------------

        void Init()
        {
            //cancelTokenSource = new CancellationTokenSource();
            //token = cancelTokenSource.Token;
            delFinishTests += FrmBPPP_Test_delFinishTests;
            bNeedReload = false;
            tests = null;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BPPP/" +_frmMain._frmBPPP.curBpppBoard.Name + "/";
            listBPPPTestFileName = _frmMain._frmBPPP.curBpppBoard.Name + ".xls";

            this.Text = curBoard.Name + " BPPP. Board " + _frmMain._frmBPPP.curBpppBoard.Name + ". Passing tests";
            this.BackColor = Color.RoyalBlue;
            grpBPPPTest.ForeColor = Color.White;
            grpDC.ForeColor = Color.White;
            grpSwitch.ForeColor = Color.White;
            cmbSwitchName.SelectedIndex = 0;
            //numCurTest = 0;
            badTests = new List<BPPPTest>();

            if(Utils.isFileExist(catalog + listBPPPTestFileName))
            {
                string str;
                tests = Excel.ParseBPPP(catalog + listBPPPTestFileName, out str);    //открываем список тестов из экселевского файла
                if (tests != null)
                {
                    lblTEstCount.Text = tests.Length.ToString();
                    _frmMain.niControl.DCSetOnOff(0.1, 0.02, false, 0.1, 0.02, false);


                    //тестово!!!
                    _frmMain.niControl.CreateDMM();
                }
                else
                {
                    MessageBox.Show(str);
                }
                //RunTests(tests);

            }
            else
            {
                MessageBox.Show("File " + catalog + listBPPPTestFileName + " isn't found!", "Load error");
            }
        }

        private void FrmBPPP_Test_delFinishTests()
        {
            Invoke((MethodInvoker)delegate ()
            {
                SaveReportAndShowResult();
            });
            
        }

        void RunBPPPAllTests(object cnt_)
        {
            int cnt = (int)cnt_;
            //cnt = 1000000;
            //_frmMain.niControl.DCSetOnOff("0", 24, true);
            //_frmMain.niControl.OpenCloseRelay(true, "R6", "64");
            //_frmMain.niControl.OpenCloseRelay(true, "R7", "66");
            sw.Start();

            for (int i = 0; i < cnt; i++)
            {
                if (token.IsCancellationRequested)
                {
                    delFinishTests?.Invoke();
                    break;
                }

                Invoke((MethodInvoker)delegate ()
                {
                    lblRunCount.Text = (i + 1).ToString();
                    int v = ((i + 1) * 100 / cnt);
                    if (colorProgressBar.Value != v) colorProgressBar.Value = v;

                    RunBPPPTest(i, cnt);
                });
            }

            sw.Stop();

            delFinishTests?.Invoke();
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                //bNeedStop = true;
                cancelTokenSource.Cancel();

                _frmMain.niControl.CloseDMM();
                //CloseDCIVISession();
                this.Hide();
                _frmMain._frmBPPP.Show();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBPPP_Report.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_frmMain.niControl.DCSetOnOff("0", (double)numDCV1.Value, 0.02, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_frmMain.niControl.DCSetOnOff("1", (double)numDCV2.Value, 0.02, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //_frmMain.niControl.DCSetOnOff("0", (double)numDCV1.Value, 0.02, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //_frmMain.niControl.DCSetOnOff("1", (double)numDCV2.Value, 0.02, false);
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
            if (tests == null) return;
            int num = (int)numTest.Value;
            if(num>=tests.Length + 1)
            {
                MessageBox.Show("There is NO such a test!", "Error");
                return;
            }
            RunBPPPTest(num - 1, 1);
        }
        
        private void RunBPPPTest(int num, int cntTotal)
        {
            _frmMain._frmNI.txtDMMWarning.Text = "";
            BPPPTest test = tests[num]; //получаем текущий тест из общего списка

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

            //После включения реле выжидаем паузу
            Thread.Sleep(test.Delay);

            //Проведение измерений---------------------------------------------
            _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, test.Range, test.Accuracy);   //инициирование чтения мультиметра
            

            if (double.IsNaN(_frmMain.resultOfMeasurementDMM))
                _frmMain.resultOfMeasurementDMM = double.PositiveInfinity - 1;

            _frmMain.resultOfMeasurementDMM -= 4;

            if (_frmMain.resultOfMeasurementDMM < 0)     //искусственно зануляем значения ниже 0 Ом
                _frmMain.resultOfMeasurementDMM = 0;

            if (_frmMain.resultOfMeasurementDMM < 6)   //искусственно зануляем значения ниже 6 Ом
                _frmMain.resultOfMeasurementDMM = 0;

            string sRes = string.Empty;
            if (_frmMain.resultOfMeasurementDMM >= tests[num].Min && _frmMain.resultOfMeasurementDMM <= tests[num].Max)   //проверяем измеренное значение на минимум-максимум
            {
                lblResultOfDMM.ForeColor = Color.LightGreen;
                sRes = "PASSED";
            }

            else
            {
                lblResultOfDMM.ForeColor = Color.Red;
                badTests.Add(tests[num]);
                sRes = "FAILED";
            }

            

            lblResultOfDMM.Text = Math.Round(_frmMain.resultOfMeasurementDMM, 6).ToString();    //запоминаем последнее значение от мультиметра
            tests[num].Value = Math.Round(_frmMain.resultOfMeasurementDMM, 6);                  //записываем измеренное значение в текущий тест
            tests[num].Result = sRes;                                                           //записываем результат проверки

            //Видоизменяем комментарии в текущем тесте--------------
            if (char.IsDigit(tests[num].Comment[0]))
            {
                string[] mas = tests[num].Comment.Split(' ');
                for(int i = 0; i < mas.Length; i++)
                {
                    int val = 0;
                    val = int.Parse(mas[i]);
                    if (tests.Length >= 2000)
                    {
                        if (val <= 30)
                            mas[i] = "A" + val.ToString();
                        else
                            mas[i] = "B" + (val - 30).ToString();
                    }
                    else
                    {
                        if (val <= 22)
                            mas[i] = "A" + val.ToString();
                        else
                            mas[i] = "B" + (val - 22).ToString();
                    }
                }
                tests[num].Comment = mas[0] + " " + mas[1];
            }
            //------------------------------------------------------------

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

        private void btnRunAllBPPPTest_ClickAsync(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            if (tests == null) return;

            PrepareToTest();

            //Task.Run(() => RunBPPPAllTests(tests.Length));
            //Task.Factory.StartNew(RunBPPPAllTests, tests.Length);
            RunBPPPAllTests(tests.Length);

            //SaveReportAndShowResult();
        }

        void PrepareToTest()
        {
            btnShowReport.Visible = false;
            //bNeedStop = false;
            btnStopAllTest.Enabled = true;
            btnRunAllBPPPTest.Enabled = false;
            colorProgressBar.Visible = true;
            badTests.Clear();
            //_frmMain._frmBPPP_Report.Close();
            if (_frmMain._frmBPPP_Report.IsHandleCreated)
                _frmMain._frmBPPP_Report.Close();
            else
                _frmMain._frmBPPP_Report.Hide();

            //sw.Start();

            txtDAQInfo.Text = "Testing in progress..";
            txtDAQInfo.BackColor = Color.RoyalBlue;
        }
        void SaveReportAndShowResult()
        {
            lblT.Text = sw.Elapsed.ToString();
            btnStopAllTest.Enabled = false;
            btnRunAllBPPPTest.Enabled = true;
            colorProgressBar.Visible = false;
            btnShowReport.Visible = true;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        txtDAQInfo.Text = "Saving report..";
                        txtDAQInfo.BackColor = Color.DarkOrange;
                    });
                    string filename = "Report_" + curBoard.Name + "_" + listBPPPTestFileName;
                    if (Excel.SaveBPPP(tests, Application.StartupPath + @"\" + catalog + filename) != "Success")
                    {
                        MessageBox.Show("Report file saving ERROR!", "Saving");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel report file saving ERROR!" + ex.Message, "Saving");
                    return;
                }
                Invoke((MethodInvoker)delegate ()
                {
                    if (badTests.Count > 0)
                    {
                        txtDAQInfo.BackColor = Color.Red;
                        txtDAQInfo.Text = "FAILED";
                        //_frmMain._frmBPPP_Report.Activate();
                        _frmMain._frmBPPP_Report.Show();
                    }
                    else
                    {
                        txtDAQInfo.BackColor = Color.Green;
                        txtDAQInfo.Text = "PASSED";
                    }
                });
            });
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            //bNeedStop = true;
            cancelTokenSource.Cancel();

            btnStopAllTest.Enabled = false;
            btnRunAllBPPPTest.Enabled = true;
        }
    }
}
