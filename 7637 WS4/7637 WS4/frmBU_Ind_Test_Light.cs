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
    public partial class frmBU_Ind_Test_Light : Form
    {
        public frmMain _frmMain;
        Board curBoard = null;
        string catalog = string.Empty;
        int numOfCurTest = 0;

        public frmBU_Ind_Test_Light()
        {
            InitializeComponent();
        }

        void Init(int i)
        {
            numOfCurTest = i;
            curBoard = _frmMain.curBoard;
            this.CenterToScreen();
            this.Text = curBoard.Name + ". Board " + _frmMain._frmBU_Board.curBUBoard.Name + ". CU. Indication. Tests";
            this.BackColor = Color.RoyalBlue;
            catalog = curBoard.Catalog + "/BU/bin/";
            btnOK.BackColor = Color.LightGreen;
            btnNo.BackColor = Color.Red;
            pict.SizeMode = PictureBoxSizeMode.Zoom;

            string file = string.Empty;
            if (curBoard.Name == "7064")
            {
                switch (numOfCurTest)
                {
                    default:
                    case 14: file = "Error.jpg"; break;
                    case 15: file = "30V.jpg"; break;
                    case 16: file = "5V.jpg"; break;
                    case 17: file = "-15V.jpg"; break;
                    case 18: file = "15V.jpg"; break;
                    case 19: file = "ELOK.jpg"; break;
                    case 20: file = "AZOK.jpg"; break;
                    case 21: file = "Heater.jpg"; break;
                    case 23: file = "1PH.jpg"; break;
                    case 25: file = "AZTR.jpg"; break;
                    case 27: file = "2PH.jpg"; break;
                    case 29: file = "3PH.jpg"; break;
                    case 31: file = "ELTR.jpg"; break;
                }
            }
            else if(curBoard.Name == "7194")
            {
                switch (numOfCurTest)
                {
                    default:
                    case 6: file = "Error.jpg"; break;
                    case 7: file = "30V.jpg"; break;
                    case 8: file = "5V.jpg"; break;
                    case 9: file = "-15V.jpg"; break;
                    case 10: file = "15V.jpg"; break;
                    case 11: file = "ELOK.jpg"; break;
                    case 12: file = "AZOK.jpg"; break;
                    case 13: file = "Heater.jpg"; break;
                }
            }
            if(Utils.isFileExist(catalog + file))
                pict.Image = Image.FromFile(catalog + file);
            else
                pict.Image = Properties.Resources.pictLoadError;
            txtComment.Text = "If the shown on the picture indicator is glowing press Y! Press N if not.";
        }

        private void frmBU_Ind_Test_Light_Activated(object sender, EventArgs e)
        {
            Init(_frmMain._frmBU_Ind_Test.numOfCurTest);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _frmMain._frmBU_Ind_Test.sbTestINDResult.Append("SUCCESS");
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            _frmMain._frmBU_Ind_Test.cntOfBadTests++;
            _frmMain._frmBU_Ind_Test.sbTestINDResult.Append("FAILED");
            this.Close();
        }
    }
}
