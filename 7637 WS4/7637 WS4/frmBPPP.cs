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
    public partial class frmBPPP : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        Board curBoard = null;
        List<Board> listBpppBoards = new List<Board>();
        public Board curBpppBoard = null;
        string catalog = string.Empty;
        string listBpppBoardsFileName = "listBpppBoards.xml";

        public frmBPPP()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            grpBoards.ForeColor = Color.White;

            this.Text = curBoard.Name + " BPPP";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;

            listBpppBoards = null;
            catalog = curBoard.Catalog + "/BPPP/";
            panel.Controls.Clear();

            if(Utils.isFileExist(catalog + listBpppBoardsFileName))
            {
                try
                {
                    listBpppBoards = XMLParser.OpenListBoards(catalog + listBpppBoardsFileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
                pict.SizeMode = PictureBoxSizeMode.Zoom;
                pict.Image = Properties.Resources.ListBpppBoardInitmage;
                txtComment.Text = Properties.Resources.comment_ListBpppBoards_Initial;

                ShowBoards(listBpppBoards);
            }
            else
            {
                MessageBox.Show("File " + listBpppBoardsFileName + " isn't found!", "Load error");
            }
        }

        void ShowBoards(List<Board> list)
        {
            panel.Controls.Clear();
            panel.SuspendLayout();

            for(int i = 0; i < list.Count; i++)
            {
                Button btn = new Button();
                string name = list[i].Name;
                if (name.Length > 25) name = name.Substring(0, 25) + "..";
                btn.Text = name;

                btn.Name = "btn" + i.ToString();
                btn.Click += Btn_Click;
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                btn.MouseHover += Btn_MouseHover;
                btn.Enter += Btn_MouseEnter;
                btn.Leave += Btn_MouseLeave;
                btn.Font = new Font("Verdana", 13);
                btn.Left = 2;
                btn.Top = i * 50 + 0;
                btn.Height = 42;
                btn.Width = 290;

                panel.Controls.Add(btn);
            }

            panel.ResumeLayout();
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            tip.SetToolTip(btn, listBpppBoards[index].Name);
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
            txtComment.Text = listBpppBoards[index].Comment;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.Black;

            string filename = catalog + listBpppBoards[index].Catalog + "/" + listBpppBoards[index].Imagelink;
            if (Utils.isFileExist(filename))
                pict.Image = Image.FromFile(filename);
            else
                pict.Image = Properties.Resources.pictLoadError;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            curBpppBoard = listBpppBoards[index];
            curBpppBoard.Name = curBpppBoard.Name.Substring(0, curBpppBoard.Name.IndexOf('(') - 1);
            this.Hide();
            _frmMain._frmBPPP_Help.Show();
        }

        private void frmBPPP_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBPPP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                curBpppBoard = null;
                this.Hide();
                _frmMain._frmTests.Show();
            }
        }
    }
}
