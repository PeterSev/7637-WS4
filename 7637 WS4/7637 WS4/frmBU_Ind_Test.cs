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
    public partial class frmBU_Ind_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUIndTest = "BU_Ind_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;

        public frmBU_Ind_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";

            this.Text = curBoard.Name + " БУ. Индикация. Тесты";
            this.BackColor = Color.RoyalBlue;
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
    }
}
