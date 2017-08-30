using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _7637_WS4
{
    public partial class frmBPPP_Report : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        bool bNeedReload = true;
        List<ExcelLib.BPPPTest> lstBad = null;
        Int16 listCount;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            lstBad = _frmMain._frmBPPP_Test.badTests;
            this.Text = curBoard.Name + " БППП. Отчет. Тесты, не прошедшие проверку";
            this.BackColor = Color.RoyalBlue;
            lstTest.BackColor = Color.RoyalBlue;
            lstTest.ForeColor = Color.White;
            
            lstTest.Items.Clear();
            listCount = 0;

            this.Height = 39 + (lstBad.Count + 1) * lstTest.ItemHeight;

            ShowBadTests();
        }


        void ShowBadTests()
        {
            foreach(ExcelLib.BPPPTest test in lstBad)
            {
                AddToList(test);
            }
        }

        void AddToList(ExcelLib.BPPPTest test)
        {
            listCount++;
            if(listCount > 9999)
            {
                lstTest.Items.Clear();
                listCount = 1;
            }
            
            string sInput = String.Format("k{0}{1}/k{2}{3}",
                test.Input[0].Channel.ToString(),
                test.Input[0].Device,
                test.Input[1].Channel.ToString(),
                test.Input[1].Device);
            string sOutput = String.Format("k{0}{1}/k{2}{3}",
                test.Output[0].Channel.ToString(),
                test.Output[0].Device,
                test.Output[1].Channel.ToString(),
                test.Output[1].Device);
            string outstr = String.Format("{0:0000}:    Index - {1}{2}{3}Min - {4} Max - {5}Value - {6}",
                listCount,
                test.Index.ToString().PadRight(10),
                sInput.PadRight(20),
                sOutput.PadRight(20),
                test.Min.ToString().PadRight(15),
                test.Max.ToString().PadRight(15),
                test.Value
                );
            lstTest.Items.Add(outstr);
        }

        public frmBPPP_Report()
        {
            InitializeComponent();
        }

        private void frmBPPP_Report_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBPPP_Report_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
