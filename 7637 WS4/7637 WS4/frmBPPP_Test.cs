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
    public partial class frmBPPP_Test : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        string listBPPPTest = "BPPP_test.xls";
        string catalog = string.Empty;
        Board curBoard = null;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BPPP/";

            this.Text = curBoard.Name + " БППП. Прохождение тестов";
            this.BackColor = Color.RoyalBlue;
        }

        public frmBPPP_Test()
        {
            InitializeComponent();
        }

        private void frmBPPP_Test_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBPPP_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            this.Hide();
            _frmMain._frmBPPP.Show();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            _frmMain._frmBPPP_Report.Show();
        }
    }
}