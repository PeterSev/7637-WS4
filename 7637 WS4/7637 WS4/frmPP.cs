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
    public partial class frmPP : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        Board curBoard = null;
        public string selectedBoard = string.Empty;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;

            this.Text = curBoard.Name + " Проверка плат. Выбор платы";
            this.BackColor = Color.RoyalBlue;
        }

        public frmPP()
        {
            InitializeComponent();
        }

        private void frmPP_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmPP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                selectedBoard = string.Empty;
                this.Hide();
                _frmMain._frmTests.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedBoard = ((Button)sender).Text;
            this.Hide();
            _frmMain._frmPP_InnerHelp.Show();
        }
    }
}
