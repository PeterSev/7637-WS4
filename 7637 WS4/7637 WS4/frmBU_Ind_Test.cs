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
    public partial class frmBU_Ind_Test : Form
    {
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        event DelFinishTests delFinishTests;
        AutoResetEvent ansFromRes = new AutoResetEvent(false);
        bool isResSuccessed = false;

        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUIndTest = "BU_IndTest.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        IndTest[] tests;
        public int numOfCurTest = 0;
        public int cntOfBadTests = 0;

        public StringBuilder sbTestINDResult = new StringBuilder();

        public frmBU_Ind_Test()
        {
            InitializeComponent();
            //Hello
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/bin/";
            tests = null;
            colorProgressBar.Visible = false;
            lblTestCount.Text = "0";
            lblTestCount.Text = "0";
            this.Text = curBoard.Name + ". Board " + _frmMain._frmBU_Board.curBUBoard.Name + ". CU. Indication. Tests";
            this.BackColor = Color.RoyalBlue;
            delFinishTests += FrmBU_Ind_Test_delFinishTests;
            if (Utils.isFileExist(catalog + listBUIndTest))
            {
                tests = Excel.ParseInd(catalog + listBUIndTest);
                if (tests != null)
                {
                    lblTestCount.Text = tests.Length.ToString();
                    _frmMain.niControl.DCSetOnOff(0.1, 0.02, false, 0.1, 0.02, false);
                    _frmMain.niControl.CreateDMM();
                }
            }
            else
            {
                MessageBox.Show("File " + catalog + listBUIndTest + " isn't found!", "Load error");
            }
        }

        private void FrmBU_Ind_Test_delFinishTests()
        {
            Invoke((MethodInvoker)delegate ()
            {
                SaveReportAndShowResult();
            });
        }

        private void frmBU_Ind_Tests_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBU_Ind_Tests_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
                _frmMain._frmBU.Show();
                _frmMain.niControl.CloseDMM();
            }
        }

        private void btnRunIndTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            if (num > tests.Length)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }

            ResetControls(false);
            RunIndTest(num - 1);
        }

        private void ResetControls(bool b)
        {
            Invoke((MethodInvoker)delegate ()
            {
                btnRunIndTest.Enabled = b;
                btnStopIndTest.Visible = !b;
                numTest.Enabled = b;
            });
        }

        void RunIndTest(int num)
        {
            IndTest test = tests[num];

            //Включение источников питания---------------
            double v1 = test.VoltSupply.V1 != 0 ? test.VoltSupply.V1 : 0.1;
            double v2 = test.VoltSupply.V2 != 0 ? test.VoltSupply.V2 : 0.1;
            double curLim1 = test.VoltSupply.V1 != 0 ? (double)test.CurrSource[0].CurrSource / 1000 : 0.02;
            double curLim2 = test.VoltSupply.V2 != 0 ? (double)test.CurrSource[1].CurrSource / 1000 : 0.02;

            _frmMain.niControl.DCSetOnOff(
                v1, 
                curLim1,
                test.VoltSupply.V1 != 0,
                v2,
                curLim2,
                test.VoltSupply.V2 != 0);
            //-----------------------------------------

            //Включение реле---------------------------
            for(int i = 0; i < test.Input.Length; i++)
            {
                string dev = test.Input[i].Device;
                string ch = test.Input[i].Channel.ToString();
                _frmMain.niControl.OpenCloseRelay(true, dev, ch);
            }
            //-----------------------------------------

            Thread.Sleep(500);

            TakeMeasureDMM(num);

            Thread.Sleep(100);
            //StopIndTest(num);
        }

        void StopIndTest(int num)
        {
            IndTest test = tests[num];

            //Выключение реле---------------------------
            for (int i = 0; i < test.Input.Length; i++)
            {
                string dev = test.Input[i].Device;
                string ch = test.Input[i].Channel.ToString();
                _frmMain.niControl.OpenCloseRelay(false, dev, ch);
            }
            //-----------------------------------------


            //Выключение источников питания------------
            double v1 = test.VoltSupply.V1 != 0 ? test.VoltSupply.V1 : 0.1;
            double v2 = test.VoltSupply.V2 != 0 ? test.VoltSupply.V2 : 0.1;
            double curLim1 = test.VoltSupply.V1 != 0 ? (double)test.CurrSource[0].CurrSource / 1000 : 0.02;
            double curLim2 = test.VoltSupply.V2 != 0 ? (double)test.CurrSource[1].CurrSource / 1000 : 0.02;

            _frmMain.niControl.DCSetOnOff(
                v1,
                curLim1,
                false,
                v2,
                curLim2,
                false);
            //--------------------------------------


            ResetControls(true);
        }

        private void btnStopIndTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            StopIndTest(num - 1);
        }

        void TakeMeasureDMM(int num)
        {
            IndTest test = tests[num];
            if (test.ValMax > 1000000)
                test.ValMax = double.PositiveInfinity;
            try
            {
                //Проведение измерений---------------------
                switch (test.Control)
                {
                    case ExcelLib.Control.Напряжение:
                        _frmMain.niControl.ReadDMM(MultimeterMode.DCVolts, 50, 0); break;
                    case ExcelLib.Control.ПадениеНапряженияБк:
                    case ExcelLib.Control.ПадениеНапряженияБэ:
                    case ExcelLib.Control.ПадениеНапряженияКб:
                    case ExcelLib.Control.ПадениеНапряженияЭб:
                    case ExcelLib.Control.ПадениеНапряженияЭк:
                        _frmMain.niControl.ReadDMM(MultimeterMode.Diode, 10, 0); break;
                    case ExcelLib.Control.Сопротивление:
                        _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, 100, 1); break;
                    default:
                        break;
                }
            }
            catch { }

            _frmMain._frmNI.dmmMeasuredEvent.WaitOne(2000);
            if (tests[num].Control != ExcelLib.Control.Индикация)
            {
                if (((double.IsNaN(_frmMain.resultOfMeasurementDMM)) || (_frmMain.resultOfMeasurementDMM >= test.ValMin)) &&
                    ((_frmMain.resultOfMeasurementDMM <= test.ValMax) || (_frmMain.resultOfMeasurementDMM.Equals(test.ValMax))))
                {
                    isResSuccessed = true;
                    lblResultOfInd.ForeColor = Color.LightGreen;
                    if (curBoard.Name == "7064")
                    {
                        if (num < 14 || num > 21) sbTestINDResult.Append("SUCCESS");
                    }
                    else if (curBoard.Name == "7194")
                        if (num < 7) sbTestINDResult.Append("SUCCESS");
                }
                else
                {
                    isResSuccessed = false;
                    cntOfBadTests++;
                    if (curBoard.Name == "7064")
                    {
                        if (num < 14 || num > 21) sbTestINDResult.Append("FAILED");
                    }
                    else if (curBoard.Name == "7194")
                        if (num < 7) sbTestINDResult.Append("FAILED");

                    lblResultOfInd.ForeColor = Color.Red;
                }
            }
            
            //инициируем признак осуществления измерения
            ansFromRes.Set();

            Invoke((MethodInvoker)delegate ()
            {
                if (tests[num].Control != ExcelLib.Control.Индикация)
                    lblResultOfInd.Text = Math.Round(_frmMain.resultOfMeasurementDMM, 3).ToString();
                else
                    lblResultOfInd.Text = string.Empty;
            });
            //-----------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _frmMain._frmNI.txtDMMWarning.Text = "";
            int num = (int)numTest.Value;
            TakeMeasureDMM(num - 1);
        }

        private void btnRunAllTests_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            if (tests == null) return;

            PrepareToTest();

            RunAllIndTestsAsync();
        }

        void PrepareToTest()
        {
            btnShowReport.Visible = false;
            btnStopAllTests.Visible = true;
            btnRunAllTests.Enabled = false;
            btnRunIndTest.Enabled = false;
            btnMeasure.Visible = false;
            colorProgressBar.Visible = true;

            if (_frmMain._frmBU_Ind_Test_Report.IsHandleCreated)
                _frmMain._frmBU_Ind_Test_Report.Close();
            else
                _frmMain._frmBU_Ind_Test_Report.Hide();


            txtDAQInfo.Text = "Test in progress..";
            txtDAQInfo.BackColor = Color.RoyalBlue;
        }

        async void RunAllIndTestsAsync()
        {
            //await Task.Factory.StartNew(RunAllIndTests, tests.Length);
            //Асинхронный запуск функции выполнения всех тестов.
            await Task.Factory.StartNew(RunAllIndTests, tests.Length);
        }

        void RunAllIndTests(object cnt_)
        {
            int cnt = (int)cnt_;
            cntOfBadTests = 0;
            sbTestINDResult.Clear();
            sbTestINDResult.AppendLine(this.Text);
            sbTestINDResult.AppendLine(DateTime.Now.ToLongDateString());
            sbTestINDResult.AppendLine(string.Empty);

            for (int i = 0; i < cnt; i++)
            {
                numOfCurTest = i;
                if (token.IsCancellationRequested) //выходим из цикла при отмене токена
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

                sbTestINDResult.AppendLine(string.Empty);
                sbTestINDResult.AppendFormat("{0} Result of test #{1} is:      ",
                    DateTime.Now.ToString().PadLeft(30),
                    (i + 1).ToString().PadLeft(3));

                //алгоритм проверки индикации в блоке 7064. По своему файлу тестов.
                if (curBoard.Name == "7064")
                {
                    if(i >=0 && i < 14)    //тесты стандартные по типу проверки плат в БППП
                    {
                        RunIndTest(i);
                        StopIndTest(i);
                        Thread.Sleep(200);
                    }
                    //тесты для проверки индикации. Нужен запуск отдельной формы 
                    //с отображением изображения индикатора на блоке управления
                    else if (i >= 14 && i < 22)   
                    {
                        RunIndTest(i);

                        _frmMain._frmBU_Test_Light.ShowDialog();

                        StopIndTest(i);
                        Thread.Sleep(200);
                    }
                    else if (i >= 22) //прописываем логику для тестов требующих предварительной проверки сопротивления
                    {
                        if (i % 2 == 0) //сначала идет четный (при отсчете с 0), требуемый проверки.                        
                        {
                            RunIndTest(i);
                            StopIndTest(i);
                            Thread.Sleep(200);
                        }
                        else //а тут мы уже проверяем нечетный (при отсчете от 0) сигнал в зависимости от результата предыдущего
                        {
                            ansFromRes.WaitOne(1000); //убеждаемся в завершении выполнения измерения
                            if (!isResSuccessed)   //если получено значение УСПЕХ, то вызываем форму с проверкой индикатора
                            {
                                RunIndTest(i);

                                _frmMain._frmBU_Test_Light.ShowDialog();

                                StopIndTest(i);
                                Thread.Sleep(200);
                            }
                            else    //если не прошел тест предохранителя, нужно вывести предупреждение с комментарием вынуть 
                                    //ОПРЕДЕЛЕННЫЙ предохранитель с кнопкой ОК. При ОК выполняем проверку
                            {
                                //тут вызываем форму с предупреждением вынуть предохранитель
                                if(MessageBox.Show(string.Format("Please remove fuse '{0}'. Press OK when ready or CANCEL to interrupt testing.", tests[i-1].Comment), "Follow instructions", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    i-=2; //и заново выполнить четный тест на проверку сопротивления
                                }
                            }
                        }
                    }
                }
                //алгоритм проверки индикации в блоке 7194. По своему файлу тестов.
                else if (curBoard.Name == "7194")
                {
                    if(i >= 0 && i < 7)
                    {
                        RunIndTest(i);
                        StopIndTest(i);
                        Thread.Sleep(200);
                    }
                    else if(i >= 7)
                    {
                        RunIndTest(i);

                        _frmMain._frmBU_Test_Light.ShowDialog();

                        StopIndTest(i);
                        Thread.Sleep(200);
                    }
                }
            }

            delFinishTests?.Invoke();
        }

        void SaveReportAndShowResult()
        {
            btnStopAllTests.Visible = false;
            btnRunAllTests.Enabled = true;
            colorProgressBar.Visible = false;
            btnShowReport.Visible = true;
            btnRunIndTest.Enabled = true;
            btnMeasure.Visible = true;

            if (cntOfBadTests > 0)
            {
                txtDAQInfo.BackColor = Color.Red;
                txtDAQInfo.Text = "FAILED";
                _frmMain._frmBU_Ind_Test_Report.Show();
            }
            else
            {
                txtDAQInfo.BackColor = Color.Green;
                txtDAQInfo.Text = "PASSED";
            }

        }

        private void btnStopAllTests_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }
    }
}
