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

namespace _7637_WS4
{
    public partial class frmBU_Ind_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUIndTest = "BU_IndTest.xls";
        string catalog = string.Empty;
        Board curBoard = null;
        IndTest[] tests;

        public frmBU_Ind_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/bin/";
            tests = null;
            this.Text = curBoard.Name + ". Плата " + _frmMain._frmBU_Board.curBUBoard.Name + ". БУ. Индикация. Тесты";
            this.BackColor = Color.RoyalBlue;

            if(Utils.isFileExist(catalog + listBUIndTest))
            {
                tests = Excel.ParseInd(catalog + listBUIndTest);
            }
            else
            {
                MessageBox.Show("File " + catalog + listBUIndTest + " isn't found!", "Load error");
            }
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
            }
        }

        private void btnRunIndTest_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            if (num >= tests.Length)
            {
                MessageBox.Show("Такого номера теста в файле тестов нет!", "Ошибка");
                return;
            }

            ResetControls(false);

            RunIndTest(num);
        }

        private void ResetControls(bool b)
        {
            btnRunIndTest.Enabled = b;
            btnStopIndTest.Visible = !b;
            numTest.Enabled = b;
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
            StopIndTest(num);
        }

        void TakeMeasureDMM(int num)
        {
            IndTest test = tests[num];

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
                    _frmMain.niControl.ReadDMM(MultimeterMode.TwoWireResistance, 100, 0); break;
                default:
                    break;
            }

            if (_frmMain.resultOfMeasurementDMM >= test.ValMin && _frmMain.resultOfMeasurementDMM <= test.ValMax)
                lblResultOfInd.ForeColor = Color.LightGreen;
            else
                lblResultOfInd.ForeColor = Color.Red;

            lblResultOfInd.Text = Math.Round(_frmMain.resultOfMeasurementDMM, 3).ToString();
            //-----------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = (int)numTest.Value;
            TakeMeasureDMM(num);
        }
    }
}
