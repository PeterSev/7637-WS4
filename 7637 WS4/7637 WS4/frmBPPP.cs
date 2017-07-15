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
    public partial class frmBPPP : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        Board curBoard = null;

        public frmBPPP()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;

            this.Text = curBoard.Name + " БППП";
            this.BackColor = Color.RoyalBlue;
        }

        private void frmBPPP_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBPPP_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            this.Hide();
            _frmMain._frmTests.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmMain._frmBPPP_Help.Show();
           
        }
    }
}
