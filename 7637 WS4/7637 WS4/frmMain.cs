﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLib;
using System.Threading;
using System.Globalization;

namespace _7637_WS4
{
    public partial class frmMain : Form
    {
        //TEst
        List<Board> listBoards = new List<Board>();
        public Board curBoard = null;

        public double resultOfMeasurementDMM = 0;
        public double maxOfEtalonSignal = 0, maxOfMeasuredSignal = 0, amplOfEtalonSignal = 0, amplOfMeasuredSignal = 0;

        //public int cntOfResMeasurementDMM = 0;
        public bool bNeedRewrite = false;
        public bool bReadyToRead = false;

        //new comment Попробовал открыть репозиторий с домашнего компьютера

        public frmTests _frmTests;
        public frmBZ_Help _frmBZ_Help;
        public frmBZ_Test _frmBZ_Test;
        public frmBZ_Report _frmBZ_Report;
        public frmBPPP _frmBPPP;
        public frmBPPP_Help _frmBPPP_Help;
        public frmBPPP_Test _frmBPPP_Test;
        public frmBPPP_Report _frmBPPP_Report;
        public frmPP_Help _frmPP_Help;
        public frmPP _frmPP;
        public frmPP_InnerHelp _frmPP_InnerHelp;
        public frmPP_Test _frmPP_Test;
        public frmPP_Report _frmPP_Report;
        public frmBU _frmBU;
        public frmBU_Prozv_Help _frmBU_Prozv_Help;
        public frmBU_Prozv_Mode _frmBU_Prozv_Mode;
        public frmBU_Prozv_Test _frmBU_Prozv_Test;
        public frmBU_Prozv_Report _frmBU_Prozv_Report;
        public frmBU_Ind_Help _frmBU_Ind_Help;
        public frmBU_Ind_Test _frmBU_Ind_Test;
        public frmBU_Osc_Help _frmBU_Osc_Help;
        public frmBU_Osc_Test _frmBU_Osc_Test;
        public frmNI _frmNI;
        public frmBZ _frmBZ;
        public frmBU_Board _frmBU_Board;
        public frmUDPDebug _frmUDPDebug;
        public NIControl niControl;
        public frmBU_Ind_Test_Report _frmBU_Ind_Test_Report;
        public frmComPort _frmComPort;
        public frmBU_Ind_Test_Light _frmBU_Test_Light;

        public string ListBoardsFileName { get; } = "bin\\ListBoards.xml";

        public frmMain()
        {
            InitializeComponent();

            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            /*MessageBox.Show(
                    "CurrentUI: " + Thread.CurrentThread.CurrentUICulture +
                    Environment.NewLine +
                    "CurrentCulture: " + Thread.CurrentThread.CurrentCulture);
            try
            {
                double d = double.Parse("∞");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Программа не сможет открыть файлы Excel и будет закрыта!" + 
                    Environment.NewLine + 
                    ex.Message);
                Environment.Exit(1);
            }*/
            

            //byte[] buf = { 0x05 };
            //string str = Encoding.ASCII.GetString(buf);
            //byte[] b = Encoding.ASCII.GetBytes(str);

        }

        void Init()
        {
            if (Utils.isFileExist(ListBoardsFileName))
            {
                listBoards = XMLParser.OpenListBoards(ListBoardsFileName);
                ShowBoards(listBoards);
                pict.SizeMode = PictureBoxSizeMode.Zoom;
                pict.Image = Properties.Resources.ListBoardsInitImage;

                txtComment.Text = Properties.Resources.comment_ListBoards_Initial;


                this.BackColor = Color.RoyalBlue;
                txtComment.BackColor = Color.LightBlue;
                //Hello
            }
            else
            {
                MessageBox.Show("Файл " + ListBoardsFileName + " не найден!", "Ошибка загрузки");
                return;
            }

            _frmTests = new frmTests();
            _frmBZ_Help = new frmBZ_Help();
            _frmBZ_Test = new frmBZ_Test();
            _frmBZ_Report = new frmBZ_Report();
            _frmBPPP = new frmBPPP();
            _frmBPPP_Help = new frmBPPP_Help();
            _frmBPPP_Test = new frmBPPP_Test();
            _frmBPPP_Report = new frmBPPP_Report();
            _frmPP_Help = new frmPP_Help();
            _frmPP = new frmPP();
            _frmPP_InnerHelp = new frmPP_InnerHelp();
            _frmPP_Test = new frmPP_Test();
            _frmPP_Report = new frmPP_Report();
            _frmBU = new frmBU();
            _frmBU_Prozv_Help = new frmBU_Prozv_Help();
            _frmBU_Prozv_Mode = new frmBU_Prozv_Mode();
            _frmBU_Prozv_Report = new frmBU_Prozv_Report();
            _frmBU_Prozv_Test = new frmBU_Prozv_Test();
            _frmBU_Ind_Help = new frmBU_Ind_Help();
            _frmBU_Ind_Test = new frmBU_Ind_Test();
            _frmBU_Osc_Help = new frmBU_Osc_Help();
            _frmBU_Osc_Test = new frmBU_Osc_Test();
            _frmNI = new frmNI();
            _frmBZ = new frmBZ();
            _frmBU_Board = new frmBU_Board();
            _frmUDPDebug = new frmUDPDebug();
            _frmBU_Ind_Test_Report = new frmBU_Ind_Test_Report();
            _frmComPort = new frmComPort();
            _frmBU_Test_Light = new frmBU_Ind_Test_Light();

            _frmTests._frmMain = _frmBZ_Help._frmMain = _frmBZ_Test._frmMain = _frmBZ_Report._frmMain = 
                _frmBPPP._frmMain = _frmBPPP_Help._frmMain = _frmBPPP_Test._frmMain = _frmBPPP_Report._frmMain =
                _frmPP_Help._frmMain = _frmPP._frmMain = _frmPP_InnerHelp._frmMain = _frmPP_Test._frmMain = 
                _frmPP_Report._frmMain = _frmBU._frmMain = _frmBU_Prozv_Help._frmMain = _frmBU_Prozv_Mode._frmMain = 
                _frmBU_Prozv_Report._frmMain = _frmBU_Prozv_Test._frmMain = _frmBU_Ind_Help._frmMain = _frmBU_Ind_Test._frmMain = 
                _frmBU_Osc_Help._frmMain = _frmBU_Osc_Test._frmMain = _frmNI._frmMain = _frmBZ._frmMain = _frmBU_Board._frmMain = 
                _frmUDPDebug._frmMain = _frmBU_Ind_Test_Report._frmMain = _frmComPort._frmMain = _frmBU_Test_Light._frmMain =
                this;

            //niControl = new NIControl();
            /*niControl.statusUpdate += _frmNI.NiControl_statusUpdate;
            niControl.warningUpdate += _frmNI.NiControl_warningUpdate;
            niControl.updateStateDC += _frmNI.NiControl_updateStateDC;*/
            
            
            _frmNI.Show();
            _frmNI.Hide();
        }

        

        void ShowBoards(List<Board> list)
        {
            panel.Controls.Clear();
            panel.SuspendLayout();

            for (int i = 0; i < list.Count; i++)
            {
                if (i >= 4) continue;

                Button btn = new Button
                {
                    Text = list[i].Name,
                    Name = "btn" + i.ToString()
                };
                btn.Click += btn_Click;
                btn.MouseHover += btn_MouseHover;
                btn.MouseEnter += btn_MouseEnter;
                btn.Enter += btn_MouseEnter;
                btn.Leave += btn_MouseLeave;
                btn.MouseLeave += btn_MouseLeave;
                btn.Font = new Font("Verdana", 26);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.BackColor = Color.RoyalBlue;
                btn.ForeColor = Color.White;
                btn.Left = i * panel.Width / list.Count;
                btn.Top = 0;
                btn.Height = panel.Height;
                btn.Width = panel.Width / list.Count;

                panel.Controls.Add(btn);


            }

            panel.ResumeLayout();
        }

        void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.RoyalBlue;
            btn.ForeColor = Color.White;
            pict.Image = Properties.Resources.ListBoardsInitImage;

            txtComment.Text = Properties.Resources.comment_ListBoards_Initial;
        }

        void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            txtComment.Text = listBoards[index].Comment;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.Black;

            string filename = listBoards[index].Catalog + "/" + listBoards[index].Imagelink;
            //string filename = "bin/"+listBoards[index].Imagelink;
            if (Utils.isFileExist(filename))
                pict.Image = Image.FromFile(filename);
            else
                pict.Image = Properties.Resources.pictLoadError;
        }

        void btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            tip.SetToolTip(btn, listBoards[index].Name);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            curBoard = listBoards[index];

            this.Hide();
            _frmTests.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmNI.Close();
            Thread.Sleep(200);

            try
            {
                niControl?.CloseDCIVISession();
                niControl?.CloseRelaySession();
                niControl?.daqEtalon.Dispose();
                niControl?.daqMeasured.Dispose();
            }
            catch { }

            Utils.KillProcess(_frmUDPDebug.LexaFileName);
        }

        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //niControl = new NIControl();
            _frmNI.Show();
        }
    }
}
