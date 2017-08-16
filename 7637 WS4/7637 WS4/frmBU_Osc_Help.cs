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
    public partial class frmBU_Osc_Help : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        List<Help> listHelp = null;
        private bool bNeedReload = true;
        private int indexPic = 0;
        string listHelpFilename = "BU_Osc_help.xml";
        string catalog = string.Empty;

        public frmBU_Osc_Help()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
            indexPic = 0;
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";
            btnOK.Visible = false;
            listHelp = null;

            this.Text = curBoard.Name + " БУ. Осциллограф";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;

            if (Utils.isFileExist(catalog + listHelpFilename))
            {
                listHelp = XMLParser.OpenListBZHelp(catalog + listHelpFilename);
                //ShowHelp(indexPic);
            }
            else
            {
                MessageBox.Show("File " + catalog + listHelpFilename + " isn't found!", "Load error");
            }
            ShowHelp(indexPic);
        }

        void ShowHelp(int index)
        {
            if (index < 0 || listHelp == null) return;
            if (listHelp.Count > 0 && Utils.isFileExist(catalog + listHelp[index].Imagelink))
            {
                pict.Image = Image.FromFile(catalog + listHelp[index].Imagelink);
                txtComment.Text = listHelp[index].Comment;

            }
            else
            {
                pict.Image = Properties.Resources.pictLoadError;
                txtComment.Text = "Отсутствует запись о выбранном файле";
            }
            lblNum.Text = (index + 1).ToString() + " из " + listHelp.Count;
        }

        private void lblLeft_Click(object sender, EventArgs e)
        {
            if (listHelp == null) return;
            indexPic--;

            if (indexPic < 0)
                indexPic = listHelp.Count - 1;

            ShowHelp(indexPic);
        }

        private void lblRight_Click(object sender, EventArgs e)
        {
            if (listHelp == null) return;
            indexPic++;
            if (indexPic > listHelp.Count - 1)
            {
                indexPic = 0;
                if (listHelp.Count > 0) btnOK.Visible = true;
            }

            ShowHelp(indexPic);
        }

        private void frmBU_Osc_Help_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void frmBU_Osc_Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;
            this.Hide();
            _frmMain._frmBU.Show();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            bNeedReload = true;
            _frmMain._frmBU_Osc_Test.Show();
        }
    }
}
