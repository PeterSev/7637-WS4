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

namespace _7637_WS4
{
    public partial class frmBZ_Test : Form
    {
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        event DelFinishTests delFinishTests;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBZTestFileName = string.Empty; //"BZ_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        //bool bNeedStop = false;
        BPPPTest[] tests;
        public List<BPPPTest> badTests;
        BPPPTest lastTest = null;

        public frmBZ_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BZ/" + _frmMain._frmBZ.curBZBoard.Name + "/";
            listBZTestFileName = _frmMain._frmBZ.curBZBoard.Name + ".xls";
            delFinishTests += FrmBZ_Test_delFinishTests;
            this.Text = curBoard.Name + " Mirror unit. Board " + _frmMain._frmBZ.curBZBoard.Name + ". Checking...";
            this.BackColor = Color.RoyalBlue;
            grpBPPPTest.ForeColor = Color.White;

            badTests = new List<BPPPTest>();

            if (Utils.isFileExist(catalog + listBZTestFileName))
            {
                string str;
                tests = Excel.ParseBPPP(catalog + listBZTestFileName, out str);    //открываем список тестов из экселевского файла
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
            }
            else
            {
                MessageBox.Show("File " + catalog + listBZTestFileName + " isn't found!", "Load error");
            }
        }

        private void FrmBZ_Test_delFinishTests()
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
            btnRunAllBPPPTest.Enabled = true;
            colorProgressBar.Visible = false;
            btnShowReport.Visible = true;
            btnRunBPPPTest.Enabled = true;
            numTest.Enabled = true;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        txtDAQInfo.Text = "Saving report..";
                        txtDAQInfo.BackColor = Color.DarkOrange;
                    });
                    if (Excel.SaveBPPP(tests, Application.StartupPath + @"\" + catalog + "Report_" + listBZTestFileName) != "Success")
                    {
                        MessageBox.Show("Ошибка сохранения файла репорта! Проверьте в отладчике причину", "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения файла отчета Excel " + ex.Message, "Сохранение");
                    return;
                }

                Invoke((MethodInvoker)delegate ()
                {
                    if (badTests.Count > 0)
                    {
                        txtDAQInfo.BackColor = Color.Red;
                        txtDAQInfo.Text = "FAILED";
                        _frmMain._frmBZ_Report.Show();
                    }
                    else
                    {
                        txtDAQInfo.BackColor = Color.Green;
                        txtDAQInfo.Text = "SUCCESS";
                    }
                });
            });
        }

        void RunBPPPAllTests(object cnt_)
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

                RunBPPPTest(i, cnt);
            }

            sw.Stop();

            delFinishTests?.Invoke();
        }

        private void RunBPPPTest(int num, int cntTotal)
        {
            BPPPTest test = tests[num]; //получаем текущий тест из общего списка

            /*Invoke((MethodInvoker)delegate ()
            {
                lblRunCount.Text = num.ToString();
            });*/

            if (lastTest != null) //будет НУЛЛОМ только в первый заход в цикл
            {
                for (int i = 0; i < lastTest.Input.Length; i++)
                {
                    if ((lastTest.Input[i].Channel != test.Input[i].Channel) || (lastTest.Input[i].Device != test.Input[i].Device))
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

            

            try
            {
                //Проведение измерений---------------------------------------------
                _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, test.Range, test.Accuracy);   //инициирование чтения мультиметра

                //После включения реле выжидаем паузу
                Thread.Sleep(test.Delay);

                //Проведение измерений---------------------------------------------
                _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, test.Range, test.Accuracy);   //инициирование чтения мультиметра

                //После включения реле выжидаем паузу
                Thread.Sleep(test.Delay);

                //Проведение измерений---------------------------------------------
                _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, test.Range, test.Accuracy);   //инициирование чтения мультиметра
            }
            catch { }

            _frmMain._frmNI.dmmMeasuredEvent.WaitOne(1000);

            if (double.IsNaN(_frmMain.resultOfMeasurementDMM))
                _frmMain.resultOfMeasurementDMM = double.PositiveInfinity - 1;

            _frmMain.resultOfMeasurementDMM -= 4.5;

            if (_frmMain.resultOfMeasurementDMM < 0)     //искусственно зануляем значения ниже 0 Ом
                _frmMain.resultOfMeasurementDMM = 0;

            if (_frmMain.resultOfMeasurementDMM < 2)   //искусственно зануляем значения ниже 2 Ом
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


            Invoke((MethodInvoker)delegate ()
            {
                lblResultOfDMM.Text = Math.Round(_frmMain.resultOfMeasurementDMM, 6).ToString();    //запоминаем последнее значение от мультиметра
            });

            tests[num].Value = Math.Round(_frmMain.resultOfMeasurementDMM, 6);                  //записываем измеренное значение в текущий тест
            tests[num].Result = sRes;                                                           //записываем результат проверки

            //Видоизменяем комментарии в текущем тесте--------------
            /*if (char.IsDigit(tests[num].Comment[0]))
            {
                string[] mas = tests[num].Comment.Split(' ');
                for (int i = 0; i < mas.Length; i++)
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
            }*/
            //------------------------------------------------------------

            if (num >= cntTotal - 1)
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
                if(cancelTokenSource!=null)
                    cancelTokenSource.Cancel();
                this.Hide();
                _frmMain._frmTests.Show();
                _frmMain.niControl.CloseDMM();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBZ_Report.Show();
        }

        private void btnRunBPPPTest_Click(object sender, EventArgs e)
        {
            if (tests == null) return;
            int num = (int)numTest.Value;
            if (num >= tests.Length+1)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }
            btnRunBPPPTest.Enabled = false;
            RunBPPPTest(num - 1, 1);
            btnRunBPPPTest.Enabled = true;
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();

            btnStopAllTest.Enabled = false;
            btnRunAllBPPPTest.Enabled = true;
        }

        void PrepareToTest()
        {
            btnShowReport.Visible = false;
            //bNeedStop = false;
            btnStopAllTest.Enabled = true;
            btnRunAllBPPPTest.Enabled = false;
            colorProgressBar.Visible = true;
            btnRunBPPPTest.Enabled = false;
            numTest.Enabled = false;
            badTests.Clear();
            if (_frmMain._frmBZ_Report.IsHandleCreated)
                _frmMain._frmBZ_Report.Close();
            else
                _frmMain._frmBZ_Report.Hide();

            txtDAQInfo.Text = "Test processing..";
            txtDAQInfo.BackColor = Color.RoyalBlue;
        }

        async void RunBPPPAllTestsAsync()
        {
            await Task.Factory.StartNew(RunBPPPAllTests, tests.Length);
        }

        private void btnRunAllBPPPTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            if (tests == null) return;

            PrepareToTest();

            //RunBPPPAllTests(tests.Length);
            RunBPPPAllTestsAsync();
        }
    }
}
