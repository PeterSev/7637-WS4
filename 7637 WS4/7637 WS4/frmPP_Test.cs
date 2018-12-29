using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7637_WS4
{
    public partial class frmPP_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listPPTest = string.Empty;
        string catalog = string.Empty;
        Board curBoard = null;
        int timeout = 20000;
        public bool bIsPPTestFailed = false;
        public Udp udp;
        public CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        event DelFinishTests delFinishTests;
        public AutoResetEvent ansEvent = new AutoResetEvent(false);
        public AutoResetEvent descr1Event = new AutoResetEvent(false);
        public AutoResetEvent descr2Event = new AutoResetEvent(false);

        public StringBuilder sbTestResult = new StringBuilder();

        Stopwatch sw = new System.Diagnostics.Stopwatch();

        void Init()
        {
            delFinishTests += FrmPP_Test_delFinishTests;
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/PP/" + _frmMain._frmPP.selectedBoard + "/";
            listPPTest = _frmMain._frmPP.selectedBoard + ".csvx";
            this.Text = curBoard.Name + " Board checking №" + _frmMain._frmPP.selectedBoard;
            this.BackColor = Color.RoyalBlue;
            grpPPTest.ForeColor = Color.White;
            txtDAQInfo.Text = string.Empty;
            txtDAQInfo.BackColor = Color.RoyalBlue;
            lblRunCount.Text = "0";

            
            _frmMain._frmUDPDebug.Show();
            _frmMain._frmUDPDebug.WindowState = FormWindowState.Minimized;
            _frmMain._frmUDPDebug.SendCommandDescr2(catalog + listPPTest);
            _frmMain._frmUDPDebug.Hide();
            //descr2Event.WaitOne(10000);
        }

        private void FrmPP_Test_delFinishTests()
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
            btnRunAllPPTest.Enabled = true;
            colorProgressBar.Visible = false;
            btnShowReport.Visible = true;

            Invoke((MethodInvoker)delegate ()
            {
                if (bIsPPTestFailed)
                {
                    txtDAQInfo.BackColor = Color.Red;
                    txtDAQInfo.Text = "FAILED";
                    _frmMain._frmPP_Report.Show();
                }
                else
                {
                    txtDAQInfo.BackColor = Color.Green;
                    txtDAQInfo.Text = "PASSED";
                }
                
            });

        }

        public frmPP_Test()
        {
            InitializeComponent();
        }

        private void frmPP_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmPP_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();

                //Utils.KillProcess(_frmMain._frmUDPDebug.LexaFileName);

                _frmMain._frmPP.Show();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmPP_Report.Show();
        }

        private void btnShowUDPDebug_Click(object sender, EventArgs e)
        {
            _frmMain._frmUDPDebug.Show();
        }

        private void btnRunPPTest_Click(object sender, EventArgs e)
        {
            UInt16 num = (UInt16)numTest.Value;
            if (num > int.Parse(lblTestCount.Text))
            {
                MessageBox.Show("There is NO such a test!", "Error");
                return;
            }
            RunPPTest(num);
        }

        private void RunPPTest(UInt16 num)
        {
            Invoke((MethodInvoker)delegate ()
            {
                lblResult.Text = "...";
                lblRunCount.Text = num.ToString();
            });
            
            _frmMain._frmUDPDebug.SendCommandDescr3(num);
        }

        private void RunAllPPTest(object cnt_)
        {
            int cnt = (int)cnt_;
            sbTestResult.Clear();
            sbTestResult.AppendLine(this.Text);
            sbTestResult.AppendLine(DateTime.Now.ToLongDateString());
            sbTestResult.AppendLine(string.Empty);

            sw.Restart();
            for(ushort i=0; i < cnt; i++)
            {
                if (token.IsCancellationRequested)
                {
                    delFinishTests?.Invoke();
                    return;
                }

                Invoke((MethodInvoker)delegate ()
                {
                    lblRunCount.Text = (i+1).ToString();
                    int v = ((i) * 100 / cnt);
                    if (colorProgressBar.Value != v) colorProgressBar.Value = v;
                });

                RunPPTest((ushort)(i+1));
                ansEvent.WaitOne(timeout);
                sbTestResult.AppendLine(String.Empty);
                sbTestResult.AppendFormat("{0} Result of test #{1} is {2}",
                    DateTime.Now.ToString().PadLeft(30),
                    (i + 1).ToString().PadLeft(3),
                    lblResult.Text);
            }

            sw.Stop();
            delFinishTests?.Invoke();
        }

        void PrepareToTest()
        {
            btnShowReport.Visible = false;
            //bNeedStop = false;
            btnStopAllTest.Enabled = true;
            btnRunAllPPTest.Enabled = false;
            colorProgressBar.Visible = true;
            bIsPPTestFailed = false;
            if (_frmMain._frmBPPP_Report.IsHandleCreated)
                _frmMain._frmBPPP_Report.Close();
            else
                _frmMain._frmBPPP_Report.Hide();


            txtDAQInfo.Text = "Testing in progress..";
            txtDAQInfo.BackColor = Color.RoyalBlue;
        }

        private void btnRunAllPPTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            

            PrepareToTest();

            RunAllTestAsync();
            //RunAllPPTest(Convert.ToInt32(lblTestCount.Text));
        }

        async void RunAllTestAsync()
        {
            await Task.Factory.StartNew(RunAllPPTest, Convert.ToInt32(lblTestCount.Text));
        }

        private void btnStopAllTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void frmPP_Test_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _frmMain._frmUDPDebug.Show();
        }
    }
}
