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
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        event DelFinishTests delFinishTests;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();


        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUProzvTest = "BU_Prozv_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        DAQTest[] tests;
        //DAQTest lastTest = null;
        public List<DAQTest> badTests;
        bool bNeedStop = false;
        public ProzvMode curMode;
        public AutoResetEvent eventDAQEtalonUpdate = new AutoResetEvent(false);
        public AutoResetEvent eventDAQMeasuredUpdate = new AutoResetEvent(false);

        public frmBU_Prozv_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            curMode = _frmMain._frmBU_Prozv_Mode.curMode;
            /*switch (_frmMain._frmBU_Prozv_Mode.curMode)
            {
                default:
                case ProzvMode.КонтрольОбрыв: curMode = "Контроль на отсутствие цепей"; break;
                case ProzvMode.КонтрольКЗ: curMode = "Контроль на отсутствие КЗ"; break;
                case ProzvMode.Выборочная: curMode = "Выборочная проверка"; break;
            }*/
            delFinishTests += FrmBU_Prozv_Test_delFinishTests;

            tests = null;
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/" + _frmMain._frmBU_Board.curBUBoard.Name + "/";

            this.Text = curBoard.Name + " " + _frmMain._frmBU_Board.curBUBoard.Name + " CU. CONTINUITY " + curMode.ToString() +  ". Tests";
            this.BackColor = Color.RoyalBlue;

            badTests = new List<DAQTest>();

            if(Utils.isFileExist(catalog + listBUProzvTest))
            {
                tests = Excel.ParseDAQ_Old(catalog + listBUProzvTest);
                if (tests != null)
                {
                    lblTestCount.Text = tests.Length.ToString();
                }
                else
                {
                    tests = Excel.ParseDAQ(catalog + listBUProzvTest);
                    if(tests!=null)
                        lblTestCount.Text = tests.Length.ToString();
                    else
                        MessageBox.Show("File is corrupted or wrong formatted");
                }
            }
            else
            {
                MessageBox.Show("File " + catalog + listBUProzvTest + " isn't found!", "Load error");
            }

            EnableFormControl(curMode != ProzvMode.Выборочная);
        }

        private void FrmBU_Prozv_Test_delFinishTests()
        {
            Invoke((MethodInvoker)delegate ()
            {
                SaveReportAndShowResult();
            });
        }

        void SaveReportAndShowResult()
        {
            lblT.Text = sw.Elapsed.ToString();
            btnStopAllTest.Enabled = false;
            btnRunAllDAQTest.Enabled = true;
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
                    string typeCheck = string.Empty;
                    switch (curMode)
                    {
                        case ProzvMode.Выборочная: typeCheck = "_Manual_"; break;
                        case ProzvMode.КонтрольОбрыв: typeCheck = "_Continuity_"; break;
                        case ProzvMode.КонтрольКЗ: typeCheck = "_ShortCircuit_"; break;
                    }
                    string filename = "Report_" + curBoard.Name + "_" + _frmMain._frmBU_Board.curBUBoard.Name + typeCheck + listBUProzvTest;
                    string res = Excel.SaveDAQ(tests, Application.StartupPath + @"\" + catalog + filename);
                    if (res != "Success")
                    {
                        MessageBox.Show(res, "Error");
                    }

                    if (badTests.Count > 0) //сохраняем отчет об ошибках лишь при их наличии
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            txtDAQInfo.Text = "Saving errors..";
                            filename = "BAD_" + curBoard.Name + "_" + _frmMain._frmBU_Board.curBUBoard.Name + typeCheck + listBUProzvTest;
                            res = Excel.SaveDAQ(badTests.ToArray(), Application.StartupPath + @"\" + catalog + filename);
                        });
                        if (res != "Success")
                        {
                            MessageBox.Show(res, "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel saving error  " + ex.Message, "Saving");
                }

                Invoke((MethodInvoker)delegate ()
                {
                    if (badTests.Count > 0)
                    {
                        txtDAQInfo.BackColor = Color.Red;
                        txtDAQInfo.Text = "FAILED";
                        _frmMain._frmBU_Prozv_Report.Show();
                    }
                    else
                    {
                        txtDAQInfo.BackColor = Color.Green;
                        txtDAQInfo.Text = "PASSED";
                    }
                });
            });

        }
        
        /// <summary>
        /// Прячем некоторые контролы на форме, не нужные для проверки "Выборочная"
        /// </summary>
        /// <param name="b">Вкл/Выкл</param>
        void EnableFormControl(bool b)
        {
            btnRunAllDAQTest.Visible = b;
            btnStopAllTest.Visible = b;
            btnShowReport.Visible = b;
            //colorProgressBar.Visible = b;
            txtDAQInfo.Visible = b;
            label6.Visible = lblT.Visible = b;
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
                //bNeedStop = true;
                cancelTokenSource.Cancel();
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
            if (tests == null) return;
            int num = (int)numTest.Value;
            if (num >= tests.Length + 1)
            {
                MessageBox.Show("There is NO such a test!", "Error");
                return;
            }

            if (_frmMain.niControl.daqEtalon == null) return;

            eventDAQEtalonUpdate.Reset();
            _frmMain.niControl.daqEtalon.RunDAQ();
            eventDAQEtalonUpdate.WaitOne(50);
            Thread.Sleep(100);

            if (curMode == ProzvMode.Выборочная)
            {
                ResetControls(false);

                RunGenerationDAQTest(num - 1);
            }
            else if (curMode == ProzvMode.КонтрольОбрыв)
                RunStandartDAQTest(num - 1);
            else if (curMode == ProzvMode.КонтрольКЗ)
            {
                colorProgressBarSmall.Visible = true;
                RunGenerationKZTest(num - 1);
                colorProgressBarSmall.Visible = false;  
            }
        }

        /// <summary>
        /// Прозваниваем точку А (input) каждого теста со всеми подряд точками Б (output)
        /// </summary>
        /// <param name="num">номер выполняемого теста</param>
        void RunGenerationKZTest(int num)
        {
            DAQTest test = tests[num];

            //Включение реле точки А--------
            string dev = test.Input.Device;
            string ch = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev, ch);

            //Включение генерации----------
            //_frmMain.niControl.daqMeasured.RunDAQGeneration();

            string sResult = string.Empty;
            for(int i = 0; i < tests.Length; i++)   //цикл перебора точек Б
            //for (int i = 0; i < 10; i++)
            {
                int v = ((i + 1) * 100 / tests.Length);
                if (colorProgressBarSmall.Value != v) colorProgressBarSmall.Value = v;
                //lblResultOfDAQ.ForeColor = Color.LightGreen;

                //Включение реле точки Б--------
                string devOut = tests[i].Output.Device;
                string chOut = tests[i].Output.Channel.ToString();
                _frmMain.niControl.OpenCloseRelay(true, devOut, chOut);

                //Делаем измерения и сравнение----------
                eventDAQMeasuredUpdate.Reset();
                _frmMain.niControl.daqMeasured.RunDAQ();
                eventDAQMeasuredUpdate.WaitOne(500);


                if (_frmMain.amplOfMeasuredSignal >= _frmMain.amplOfEtalonSignal - 1)
                {
                    if (num != i)
                    {
                        sResult += tests[i].Index.ToString() + " ";
                        badTests.Add(test);
                        //lblResultOfDAQ.ForeColor = Color.Red;
                    }
                }
                //-------------------------------------

                //Выключаем реле точки Б
                _frmMain.niControl.OpenCloseRelay(false, devOut, chOut);

                Application.DoEvents();
            }
            test.Result = sResult == string.Empty ? "PASSED" : sResult;
            lblResultOfDAQ.ForeColor = sResult == string.Empty ? Color.LightGreen : Color.Red;
            lblResultOfDAQ.Text = test.Result;


            //Выключение реле точки А--------
            _frmMain.niControl.OpenCloseRelay(false, dev, ch);
        }

        /// <summary>
        /// Функция включения генерации для указанного номера теста. Выключение генерации вызывай используя метод StopGenerationDAQTest(int num)
        /// </summary>
        /// <param name="num">Номер выполняемого теста</param>
        void RunGenerationDAQTest(int num)
        {
            DAQTest test = tests[num];
            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev1, ch1);

            if(dev1 == "R8")
                _frmMain.niControl.OpenCloseRelay(true, dev1, "3");

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev2, ch2);
            //--------------------------------------

            _frmMain.niControl.daqMeasured.RunDAQGeneration();
        }

        /// <summary>
        /// Однократное выполнение DAQ теста.
        /// </summary>
        /// <param name="num">Номер выполняемого теста</param>
        void RunStandartDAQTest(int num)
        {
            DAQTest test = tests[num];

            //Включение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev1, ch1);
            if (dev1 == "R8")
                _frmMain.niControl.OpenCloseRelay(true, dev1, "3");

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(true, dev2, ch2);
            //--------------------------------------

            Thread.Sleep(500);

            //Проведение измерений и вычисление результата------------
            eventDAQMeasuredUpdate.Reset();
            _frmMain.niControl.daqMeasured.RunDAQ();
            eventDAQMeasuredUpdate.WaitOne(500);
            //Thread.Sleep(50);

            string sRes = string.Empty;

            //проверка на порог
            if(_frmMain.amplOfMeasuredSignal >= _frmMain.amplOfEtalonSignal - 4)    
            {
                lblResultOfDAQ.ForeColor = Color.LightGreen;
                sRes = "PASSED";
            }
            else
            {
                lblResultOfDAQ.ForeColor = Color.Red;
                badTests.Add(tests[num]);            
                sRes = "FAILED";
            }
            Invoke((MethodInvoker)delegate
            {
                lblResultOfDAQ.Text = sRes;
            });

            tests[num].Result = sRes;
            tests[num].Value = string.Format("{0} --> {1}", _frmMain.amplOfEtalonSignal, _frmMain.amplOfMeasuredSignal);
            //-------------------------------------------------------

            //Выключение необходимых реле-------------
            _frmMain.niControl.OpenCloseRelay(false, dev1, ch1);
            if (dev1 == "R8")
                _frmMain.niControl.OpenCloseRelay(false, dev1, "3");
            _frmMain.niControl.OpenCloseRelay(false, dev2, ch2);
            //--------------------------------------
        }

        private void btnRunDAQ_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.daqEtalon.RunDAQ();
            Thread.Sleep(50);
            _frmMain.niControl.daqMeasured.RunDAQ();
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

        void RunDAQAllTests(object cnt_)
        {
            int cnt = (int)cnt_;
            sw.Restart();
            for (int i = 0; i < cnt; i++)
            {
                if (token.IsCancellationRequested)
                {
                    delFinishTests?.Invoke();
                    return;
                }
                Invoke((MethodInvoker)delegate ()
                {
                    lblRunCount.Text = (i + 1).ToString();
                    int v = ((i + 1) * 100 / cnt);
                    if (colorProgressBar.Value != v) colorProgressBar.Value = v;
                });

                if (curMode == ProzvMode.КонтрольОбрыв)
                        RunStandartDAQTest(i);
                else if (curMode == ProzvMode.КонтрольКЗ)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        colorProgressBarSmall.Visible = true;
                        RunGenerationKZTest(i);
                        colorProgressBarSmall.Visible = false;
                    });
                }
                //Application.DoEvents();
                    //RunDAQTestAsync(i);
                
            }
            sw.Stop();
            delFinishTests?.Invoke();
        }

        async void RunDAQTestAsync(int i)
        {
            await Task.Factory.StartNew(RunTest, i);
        }

        void RunTest(object num_)
        {
            int i = (int)num_;
            Invoke((MethodInvoker)delegate ()
            {
                if (curMode == ProzvMode.КонтрольОбрыв)
                    RunStandartDAQTest(i);
                else if (curMode == ProzvMode.КонтрольКЗ)
                {
                    colorProgressBarSmall.Visible = true;
                    RunGenerationKZTest(i);
                    colorProgressBarSmall.Visible = false;
                }
            });
        }

        void PrepareToTest()
        {
            btnShowReport.Visible = false;
            //bNeedStop = false;
            btnStopAllTest.Enabled = true;
            btnRunAllDAQTest.Enabled = false;
            colorProgressBar.Visible = true;
            badTests.Clear();

            if (_frmMain._frmBPPP_Report.IsHandleCreated)
                _frmMain._frmBPPP_Report.Close();
            else
                _frmMain._frmBPPP_Report.Hide();


            txtDAQInfo.Text = "Test in progress..";
            txtDAQInfo.BackColor = Color.RoyalBlue;
        }

        private void btnRunAllDAQTest_Click(object sender, EventArgs e)
        {
            if (_frmMain.niControl.daqEtalon == null)
                return;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
  

            //------Получаем и измеряем эталонный сигнал------------
            eventDAQEtalonUpdate.Reset();
            _frmMain.niControl.daqEtalon.RunDAQ();
            eventDAQEtalonUpdate.WaitOne(50);
            //------------------------------------------------
            PrepareToTest();

            //RunDAQAllTests(tests.Length);
            RunDAQAllTestsAsync(); 
        }

        async void RunDAQAllTestsAsync()
        {
            await Task.Factory.StartNew(RunDAQAllTests, tests.Length);
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void btnStopDAQTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            DAQTest test = tests[num];
            //Выключение необходимых реле-------------
            string dev1 = test.Input.Device;
            string ch1 = test.Input.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(false, dev1, ch1);

            if(dev1 == "R8")
                _frmMain.niControl.OpenCloseRelay(false, dev1, "3");    //хер знает зачем нужно было. Просьба электриков 

            string dev2 = test.Output.Device;
            string ch2 = test.Output.Channel.ToString();
            _frmMain.niControl.OpenCloseRelay(false, dev2, ch2);
            //--------------------------------------

            _frmMain.niControl.daqMeasured.StopDAQGeneration();

            ResetControls(true);
        }

        public void ResetControls(bool b)
        {
            btnRunDAQTest.Enabled = b;
            btnStopDAQTest.Visible = !b;
            numTest.Enabled = b;
        }
    }
}
