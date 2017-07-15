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
    public partial class frmMain : Form
    {
        List<Board> listBoards = new List<Board>();
        public Board curBoard = null;
        //new comment

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


        string listBoardsFileName = "bin\\ListBoards.xml";

        public string ListBoardsFileName
        {
            get { return listBoardsFileName; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        void Init()
        {
            if (Utils.isFileExist(ListBoardsFileName))
            {
                listBoards = XMLParser.OpenListBoards(ListBoardsFileName);
                ShowBoards(listBoards);
                pict.SizeMode = PictureBoxSizeMode.StretchImage;
                pict.Image = Properties.Resources.ListBoardsInitImage;

                txtComment.Text = Properties.Resources.comment_ListBoards_Initial;


                this.BackColor = Color.RoyalBlue;
                txtComment.BackColor = Color.LightBlue;
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

            _frmTests._frmMain = _frmBZ_Help._frmMain = _frmBZ_Test._frmMain = _frmBZ_Report._frmMain = 
                _frmBPPP._frmMain = _frmBPPP_Help._frmMain = _frmBPPP_Test._frmMain = _frmBPPP_Report._frmMain =
                _frmPP_Help._frmMain = _frmPP._frmMain = _frmPP_InnerHelp._frmMain = _frmPP_Test._frmMain = 
                _frmPP_Report._frmMain = _frmBU._frmMain =  this;
        }

        void ShowBoards(List<Board> list)
        {
            panel.Controls.Clear();
            panel.SuspendLayout();

            for (int i = 0; i < list.Count; i++)
            {
                if (i >= 4) continue;

                Button btn = new Button();

                btn.Text = list[i].Name;
                btn.Name = "btn" + i.ToString();
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
    }
}
