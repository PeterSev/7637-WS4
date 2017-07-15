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

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;

            this.Text = curBoard.Name + " БППП. Отчет";
            this.BackColor = Color.RoyalBlue;
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
            e.Cancel = true;
            bNeedReload = true;
            this.Hide();
        }
    }
}
