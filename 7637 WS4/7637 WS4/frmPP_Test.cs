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
    public partial class frmPP_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listPPTest = string.Empty;
        string catalog = string.Empty;
        Board curBoard = null;

        public Udp udp;

        void Init()
        {
            listPPTest = _frmMain._frmPP.selectedBoard + "_test.xml";

            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/PP/" + _frmMain._frmPP.selectedBoard + "/";

            this.Text = curBoard.Name + " Проверка платы №" + _frmMain._frmPP.selectedBoard;
            this.BackColor = Color.RoyalBlue;
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
    }
}
