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
    public enum ProzvMode { КонтрольОбрыв, КонтрольКЗ, Выборочная }
    public partial class frmBU_Prozv_Mode : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        Board curBoard = null;
        string listTestFilename = "BU_ProzvMode.xml";
        string catalog = string.Empty;
        List<TestInfo> lstTests = null;
        public ProzvMode curMode = ProzvMode.КонтрольОбрыв;

        void Init()
        {
            bNeedReload = false;
            curBoard = _frmMain.curBoard;
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            catalog = curBoard.Catalog + "/BU/bin/";

            this.Text = curBoard.Name + " CU. Continuity. Select check mode";
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
            btn0.Text = lst[0].Name.Length <= 14 ? lst[0].Name : lst[0].Name.Remove(14);
            btn1.Text = lst[1].Name.Length <= 14 ? lst[1].Name : lst[1].Name.Remove(14);
            btn2.Text = lst[2].Name.Length <= 14 ? lst[2].Name : lst[2].Name.Remove(14);

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

        public frmBU_Prozv_Mode()
        {
            InitializeComponent();
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
                this.Hide();
                _frmMain._frmBU.Show();
            }
        }

        private void btnObryv_Click(object sender, EventArgs e)
        {
            curMode = ProzvMode.КонтрольОбрыв;
            this.Hide();
            _frmMain._frmBU_Prozv_Test.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            curMode = ProzvMode.КонтрольКЗ;
            this.Hide();
            _frmMain._frmBU_Prozv_Test.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            curMode = ProzvMode.Выборочная;
            this.Hide();
            _frmMain._frmBU_Prozv_Test.Show();
        }
    }
}
