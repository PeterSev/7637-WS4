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
        List<Board> listPPBoards = new List<Board>();
        public Board curPPBoard = null;
        string catalog = string.Empty;
        string listPPBoardsFileName = "listPPBoards.xml";
        public string selectedBoard = string.Empty;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            grpBoards.ForeColor = Color.White;
            this.Text = curBoard.Name + " Boards checking. Select the board";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;

            listPPBoards = null;
            catalog = curBoard.Catalog + "/PP/";
            panel.Controls.Clear();

            if (Utils.isFileExist(catalog + listPPBoardsFileName))
            {
                try
                {
                    listPPBoards = XMLParser.OpenListBoards(catalog + listPPBoardsFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
                pict.SizeMode = PictureBoxSizeMode.StretchImage;
                pict.Image = Properties.Resources.ListBpppBoardInitmage;
                txtComment.Text = Properties.Resources.comment_ListBpppBoards_Initial;

                ShowBoards(listPPBoards);
            }
            else
            {
                MessageBox.Show("Список плат " + listPPBoardsFileName + " не найден!", "Ошибка");
            }
        }

        void ShowBoards(List<Board> list)
        {
            panel.Controls.Clear();
            panel.SuspendLayout();

            for (int i = 0; i < list.Count; i++)
            {
                Button btn = new Button();
                string name = list[i].Name;
                if (name.Length > 20) name = name.Substring(0, 20) + "..";
                btn.Text = name;

                btn.Name = "btn" + i.ToString();
                btn.Click += Btn_Click;
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                btn.MouseHover += Btn_MouseHover;
                btn.Enter += Btn_MouseEnter;
                btn.Leave += Btn_MouseLeave;
                btn.Font = new Font("Verdana", 16);
                btn.Left = 10;
                btn.Top = i * 50 + 0;
                btn.Height = 42;
                btn.Width = 260;

                panel.Controls.Add(btn);
            }

            panel.ResumeLayout();
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            tip.SetToolTip(btn, listPPBoards[index].Name);
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.RoyalBlue;
            btn.ForeColor = Color.White;
            pict.Image = Properties.Resources.ListBpppBoardInitmage;

            txtComment.Text = Properties.Resources.comment_ListBpppBoards_Initial;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            txtComment.Text = listPPBoards[index].Comment;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.Black;

            string filename = catalog + listPPBoards[index].Catalog + "/" + listPPBoards[index].Imagelink;
            if (Utils.isFileExist(filename))
                pict.Image = Image.FromFile(filename);
            else
                pict.Image = Properties.Resources.pictLoadError;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            selectedBoard = ((Button)sender).Text;
            this.Hide();
            _frmMain._frmPP_InnerHelp.Show();
            //throw new NotImplementedException();
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
                _frmMain._frmUDPDebug.CloseUDP();
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
