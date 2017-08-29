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
    public partial class frmBU : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        private bool bNeedReload = true;
        string listTestFilename = "BU.xml";
        string catalog = string.Empty;
        List<TestInfo> lstTests = null;

        void Init()
        {
            bNeedReload = false;
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";

            this.Text = curBoard.Name + " Блок управления";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;

            if (Utils.isFileExist(catalog + listTestFilename))
            {
                //Требуется реализация открытия хмл файла. Аналогично главной формы
                lstTests = XMLParser.OpenListTests(catalog + listTestFilename);
                FillButtons(lstTests);
            }
            else
            {
                MessageBox.Show("File " + catalog + listTestFilename + " isn't found!", "Load error");
            }
        }

        void FillButtons(List<TestInfo> lst)
        {
            btn0.Text = lst[0].Name.Length <= 11 ? lst[0].Name : lst[0].Name.Remove(11);
            btn1.Text = lst[1].Name.Length <= 11 ? lst[1].Name : lst[1].Name.Remove(11);
            btn2.Text = lst[2].Name.Length <= 11 ? lst[2].Name : lst[2].Name.Remove(11);

            btn0.MouseEnter += Btn_MouseEnter;
            btn1.MouseEnter += Btn_MouseEnter;
            btn2.MouseEnter += Btn_MouseEnter;
            btn0.Enter += Btn_MouseEnter;
            btn1.Enter += Btn_MouseEnter;
            btn2.Enter += Btn_MouseEnter;
            btn0.Leave += Btn_Leave;
            btn1.Leave += Btn_Leave;
            btn2.Leave += Btn_Leave;
            btn0.MouseLeave += Btn_Leave;
            btn1.MouseLeave += Btn_Leave;
            btn2.MouseLeave += Btn_Leave;
            btn0.MouseHover += Btn_MouseHover;
            btn1.MouseHover += Btn_MouseHover;
            btn2.MouseHover += Btn_MouseHover;
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            tip.SetToolTip(btn, lstTests[index].Name);
        }

        private void Btn_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.RoyalBlue;
            btn.ForeColor = Color.White;
            pict.Image = Properties.Resources.ListBpppBoardInitmage;

            txtComment.Text = Properties.Resources.comment_ListBU_Initial;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Name.Substring(3, btn.Name.Length - 3));
            txtComment.Text = lstTests[index].Comment;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.Black;

            string filename = catalog + lstTests[index].Imagelink;
            if (Utils.isFileExist(filename))
                pict.Image = Image.FromFile(filename);
            else
                pict.Image = Properties.Resources.pictLoadError;
        }


        public frmBU()
        {
            InitializeComponent();
        }

        private void frmBU_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBU_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                bNeedReload = true;
                this.Hide();
                _frmMain._frmTests.Show();
            }
        }

        private void btnProzvonka_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmMain._frmBU_Prozv_Help.Show();
        }

        private void btnIndic_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmMain._frmBU_Ind_Help.Show();
        }

        private void btnOscill_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmMain._frmBU_Osc_Help.Show();
        }
    }
}
