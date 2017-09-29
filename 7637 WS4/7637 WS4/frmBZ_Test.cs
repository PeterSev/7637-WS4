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

namespace _7637_WS4
{
    public partial class frmBZ_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBZTestFileName = string.Empty; //"BZ_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        bool bNeedStop = false;
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

            this.Text = curBoard.Name + " Блок зеркала. Плата " + _frmMain._frmBZ.curBZBoard.Name + ". Прохождение тестов";
            this.BackColor = Color.RoyalBlue;
            grpBPPPTest.ForeColor = Color.White;

            badTests = new List<BPPPTest>();

            if (Utils.isFileExist(catalog + listBZTestFileName))
            {
                tests = Excel.ParseBPPP(catalog + listBZTestFileName);    //открываем список тестов из экселевского файла
                if (tests != null)
                {
                    lblTEstCount.Text = tests.Length.ToString();
                    _frmMain.niControl.DCSetOnOff(0.1, 0.02, false, 0.1, 0.02, false);
                }
                else
                {
                    MessageBox.Show("Файл поврежден или имеет неверный формат");
                }
            }
            else
            {
                MessageBox.Show("File " + catalog + listBZTestFileName + " isn't found!", "Load error");
            }
        }

        void RunBPPPAllTests(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                lblRunCount.Text = "Выполняется № " + (i + 1).ToString();
                int v = ((i + 1) * 100 / cnt);
                if (colorProgressBar.Value != v) colorProgressBar.Value = v;

                if (bNeedStop) break;
                RunBPPPTest(i, cnt);
            }
        }

        private void RunBPPPTest(int num, int cntTotal)
        {
            BPPPTest test = tests[num]; //получаем текущий тест из общего списка

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


            //Проведение измерений---------------------------------------------
            _frmMain.niControl.ReadDMM( MultimeterMode.TwoWireResistance, test.Range);   //инициирование чтения мультиметра

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
                bNeedStop = true;
                this.Hide();
                _frmMain._frmTests.Show();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBZ_Report.Show();
        }

        private void btnRunBPPPTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            if (num >= tests.Length)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }
            RunBPPPTest(num, 1);
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            bNeedStop = true;

            btnStopAllTest.Enabled = false;
            btnRunAllBPPPTest.Enabled = true;
        }

        private void btnRunAllBPPPTest_Click(object sender, EventArgs e)
        {
            btnShowReport.Visible = false;
            bNeedStop = false;
            btnStopAllTest.Enabled = true;
            btnRunAllBPPPTest.Enabled = false;
            colorProgressBar.Visible = true;
            badTests.Clear();
            if (_frmMain._frmBZ_Report.IsHandleCreated)
                _frmMain._frmBZ_Report.Close();
            else
                _frmMain._frmBZ_Report.Hide();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            txtDAQInfo.Text = "Идет тестирование..";
            txtDAQInfo.BackColor = Color.RoyalBlue;

            RunBPPPAllTests(tests.Length);

            sw.Stop();
            lblT.Text = sw.Elapsed.ToString();
            btnStopAllTest.Enabled = false;
            btnRunAllBPPPTest.Enabled = true;
            colorProgressBar.Visible = false;
            btnShowReport.Visible = true;

            if(badTests.Count>0)
                _frmMain._frmBZ_Report.Show();

            try
            {
                txtDAQInfo.Text = "Сохраняем отчет..";
                txtDAQInfo.BackColor = Color.DarkOrange;
                if (Excel.SaveBPPP(tests, Application.StartupPath + @"\" + catalog + "Report_" + listBZTestFileName) != "Success")
                {
                    MessageBox.Show("Ошибка сохранения файла репорта! Проверьте в отладчике причину", "Ошибка");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения файла отчета Excel " + ex.Message, "Сохранение");
            }

            if (badTests.Count > 0)
            {
                txtDAQInfo.BackColor = Color.Red;
                txtDAQInfo.Text = "ТЕСТ НЕ ПРОЙДЕН";
            }
            else
            {
                txtDAQInfo.BackColor = Color.Green;
                txtDAQInfo.Text = "ТЕСТ ПРОЙДЕН";
            }
        }
    }
}
