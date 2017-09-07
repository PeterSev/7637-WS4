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
    public partial class frmBU_Prozv_Report : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        bool bNeedReload = true;
        List<ExcelLib.DAQTest> lstBad = null;
        Int16 listCount;

        public frmBU_Prozv_Report()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            lstBad = _frmMain._frmBU_Prozv_Test.badTests;

            this.Text = curBoard.Name + " БУ. Прозвонка. Отчет. Тесты, не прошедшие проверку";
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
            foreach (ExcelLib.DAQTest test in lstBad)
            {
                AddToList(test);
            }
        }

        void AddToList(ExcelLib.DAQTest test)
        {
            listCount++;
            if (listCount > 9999)
            {
                lstTest.Items.Clear();
                listCount = 1;
            }
            string sInput = String.Format("k{0}{1}",
                test.Input.Channel.ToString(),
                test.Input.Device);
            string sOutput = String.Format("k{0}{1}",
                test.Output.Channel.ToString(),
                test.Output.Device);
            string outstr = string.Format("{0:0000}:    Index - {1}{2}{3}{4}{5}{6}",
                listCount,
                test.Index.ToString().PadRight(10),
                sInput.PadRight(20),
                sOutput.PadRight(20),
                test.Comment.PadRight(20),
                test.Value.PadRight(20),
                test.Result);
            lstTest.Items.Add(outstr);

        }

        private void frmBZ_Report_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBZ_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
            }
        }
    }
}
