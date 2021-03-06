﻿using System;
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
    public partial class frmBU_Osc_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBUOscTest = "BU_Osc_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;

        public frmBU_Osc_Test()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";

            this.Text = curBoard.Name + " CU. Ocsilloscope. Tests";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;
            txtComment.Text = Properties.Resources.comment_OSC_Test;
        }

        private void frmBU_Osc_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
                _frmMain._frmBU.Show();
            }
        }

        private void frmBU_Osc_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintClass.Print("На осциллографе контролировать частоту и амплитуду сигналов Uop1, Uop1L, Uop2, Uop2L. Переключая их с помощью тумблеров блока переходного. U=27±2V, f=400±8 Hz.");
        }
    }
}
