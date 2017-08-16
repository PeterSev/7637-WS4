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
    public partial class frmBU_Prozv_Mode : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        Board curBoard = null;

        public frmBU_Prozv_Mode()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;

            this.Text = curBoard.Name + " БУ. Прозвонка. Выбор режима проверки";
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
            _frmMain._frmBU.Show();
        }

        private void btnObryv_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmMain._frmBU_Prozv_Test.Show();
        }
    }
}
