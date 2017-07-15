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
        string listHelpFilename = "BU.xml";
        string catalog = string.Empty;

        void Init()
        {
            bNeedReload = false;
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            curBoard = _frmMain.curBoard;
            catalog = curBoard.Catalog + "/BU/";

            this.Text = curBoard.Name + " Блок управления";
            this.BackColor = Color.RoyalBlue;
            txtComment.BackColor = Color.LightBlue;

            if (Utils.isFileExist(catalog + listHelpFilename))
            {
                //Требуется реализация открытия хмл файла. Аналогично главной формы
            }
            else
            {

            }
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
            e.Cancel = true;
            bNeedReload = true;
            this.Hide();
            _frmMain._frmTests.Show();
        }
    }
}
