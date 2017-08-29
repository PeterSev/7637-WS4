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
    public partial class frmBZ_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBZTest = "BZ_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;

        public frmBZ_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BZ/";

            this.Text = curBoard.Name + " Блок зеркала. Прохождение тестов";
            this.BackColor = Color.RoyalBlue;
        }
        private void frmBZ_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBZ_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
                _frmMain._frmTests.Show();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBZ_Report.Show();
        }
    }
}
