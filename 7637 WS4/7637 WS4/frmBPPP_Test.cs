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

            if(Utils.isFileExist(catalog + listBPPPTestFileName))
            {
                tests = Excel.ParseBPPP(catalog + listBPPPTestFileName);    //открываем список тестов из экселевского файла
                lblTEstCount.Text = tests.Length.ToString();

                //RunTests(tests);
                
            }
            else
            {
                MessageBox.Show("File " + catalog + listBPPPTestFileName + " isn't found!", "Load error");
            }
        }

        void RunTests(BPPPTest[] tests)
        {

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
            _frmMain.niControl.DCSetOnOff("0", 2.2, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("1", 3.3, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("0", 2.2, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _frmMain.niControl.DCSetOnOff("1", 3.3, false);
        }
    }
}
