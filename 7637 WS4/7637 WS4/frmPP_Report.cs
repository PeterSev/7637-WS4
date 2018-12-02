using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7637_WS4
{
    public partial class frmPP_Report : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        bool bNeedReload = true;
        StringBuilder sb = null;
        Int16 listCount;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            sb = _frmMain._frmPP_Test.sbTestResult;
            this.Text = curBoard.Name + " Board checking "+ _frmMain._frmPP.selectedBoard + ". Report";
            this.BackColor = Color.RoyalBlue;
            listCount = 0;
            lstTest.BackColor = Color.RoyalBlue;
            lstTest.ForeColor = Color.White;
            lstTest.Items.Clear();

            int cn = Regex.Matches(sb.ToString(), Environment.NewLine).Count;
            this.Height = 39 + (cn + 1) * lstTest.ItemHeight;

            ShowTests();
        }

        void ShowTests()
        {
            string[] strAr = sb.ToString().Split('\n').ToArray();
            foreach (string st in strAr)
                lstTest.Items.Add(st);
        }

        public frmPP_Report()
        {
            InitializeComponent();
        }

        private void frmPP_Report_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmPP_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
            }
        }
    }
}
