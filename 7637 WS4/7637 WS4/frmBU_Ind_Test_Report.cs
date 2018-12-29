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
    public partial class frmBU_Ind_Test_Report : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        bool bNeedReload = true;
        Int16 listCount;
        StringBuilder sb = null;

        public frmBU_Ind_Test_Report()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            sb = _frmMain._frmBU_Ind_Test.sbTestINDResult;

            this.Text = curBoard.Name + " CU. Indication. Report. Failed tests";
            this.BackColor = Color.RoyalBlue;
            lstTest.BackColor = Color.RoyalBlue;
            lstTest.ForeColor = Color.White;
            lstTest.Items.Clear();
            listCount = 0;

            int cn = Regex.Matches(sb.ToString(), Environment.NewLine).Count;
            this.Height = 39 + (cn + 1) * lstTest.ItemHeight;

            //this.Height = 39 + (lstBad.Count + 1) * lstTest.ItemHeight;

            ShowTests();
        }

        void ShowTests()
        {
            string[] strAr = sb.ToString().Split('\n').ToArray();
            foreach (string st in strAr)
                lstTest.Items.Add(st);
        }

        private void frmBU_Ind_Test_Report_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBU_Ind_Test_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
            }
        }

        private void очиститьЛогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstTest.Items.Clear();
            listCount = 0;
        }

        private void скопироватьВБуферToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (object o in lstTest.SelectedItems) s += o.ToString() + "\r\n";
            Clipboard.SetText(s);
        }

        private void печататьВыделенныеСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (object o in lstTest.SelectedItems) s += o.ToString() + "\r\n";
            PrintClass.Print(s);
        }
    }
}
