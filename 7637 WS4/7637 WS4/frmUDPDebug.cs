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
    public partial class frmUDPDebug : Form
    {
        public frmMain _frmMain;
        bool bNeedReload = true;
        int ListCount = 0;
        public frmUDPDebug()
        {
            InitializeComponent();
        }

        void Init()
        {
            bNeedReload = false;
        }

        private void frmUDPDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;

            _frmMain._frmPP_Test.udp.received -= Udp_received;
            _frmMain._frmPP_Test.udp.warningException -= Udp_warningException;

            this.Hide();
        }

        private void frmUDPDebug_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void btnCreateUDP_Click(object sender, EventArgs e)
        {
            int servicePort = 55060, debugPort = 55061;
            int remotePort = 55062;
            _frmMain._frmPP_Test.udp = new Udp(servicePort, debugPort, remotePort);
            _frmMain._frmPP_Test.udp.received += Udp_received;
            _frmMain._frmPP_Test.udp.warningException += Udp_warningException;
        }

        void AddToList(Command com_in, System.Net.IPEndPoint endPoint)
        {
            ListCount++;
            if(ListCount > 9999)
            {
                lstLog.Items.Clear();
                ListCount = 1;
            }
            string date = String.Format("{0:00}:{1:00}:{2:00}:{3:000}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            string s1 = string.Empty, s2 = string.Empty;
            byte descr = com_in.descriptor;
            string tmp;
            switch (descr)
            {
                case 0x1:
                    s1 = "№ служ. порта " + ((ushort)(com_in.data[0] + (com_in.data[1] << 8))).ToString();
                    s2 = "№ отлад. порта " + ((ushort)(com_in.data[2] + (com_in.data[3] << 8))).ToString();
                    break;
                case 0x2:
                    
                    switch (com_in.data[0])
                    {
                        default:
                        case 0: tmp = "Штатная работа"; break;
                        case 1: tmp = "Ошибка открытия файла"; break;
                        case 2: tmp = "Потеряна связь со стендом"; break;
                        case 3: tmp = "Ошибка открытия ком-порта"; break;
                    }
                    s1 = "Статус: " + tmp;
                    s2 = "Количество шагов в тесте: " + ((ushort)(com_in.data[1] + (com_in.data[2] << 8))).ToString();
                    break;
                case 0x3:
                    switch (com_in.data[0])
                    {
                        default:
                        case 0: tmp = "Штатная работа"; break;
                        case 1: tmp = "Ошибка выполнения теста"; break;
                        case 2: tmp = "Потеряна связь со стендом"; break;
                        case 3: tmp = "Номер шага больше чем кол-во шагов в открытом тесте"; break;
                    }
                    s1 = "Статус: " + tmp;
                    break;
                case 0x10:
                    s1 = Encoding.Default.GetString(com_in.data, 0, com_in.data.Length - 1);
                    break;
            }
            string outstr = string.Format("{0:0000}:{1}    Descr: {2}      {3} {4} {5}",
                ListCount,
                date,
                descr.ToString("X2").PadRight(10),
                s1.PadRight(40),
                s2.PadRight(25),
                endPoint.Address.ToString() + ":" + endPoint.Port.ToString());

            if (InvokeRequired)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lstLog.BeginUpdate();
                        lstLog.Items.Add(outstr);
                        lstLog.EndUpdate();
                        lstLog.ClearSelected();
                        lstLog.SelectedIndex = lstLog.Items.Count - 1;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try
                {
                    lstLog.BeginUpdate();
                    lstLog.Items.Add(outstr);
                    lstLog.EndUpdate();
                    lstLog.ClearSelected();
                    lstLog.SelectedIndex = lstLog.Items.Count - 1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        void AddToList(string msg)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lstLog.BeginUpdate();
                        lstLog.Items.Add(msg);
                        lstLog.EndUpdate();
                        lstLog.ClearSelected();
                        lstLog.SelectedIndex = lstLog.Items.Count - 1;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try
                {
                    lstLog.BeginUpdate();
                    lstLog.Items.Add(msg);
                    lstLog.EndUpdate();
                    lstLog.ClearSelected();
                    lstLog.SelectedIndex = lstLog.Items.Count - 1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        void AddToExcList(string msg)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lstLogExc.BeginUpdate();
                        lstLogExc.Items.Add(msg);
                        lstLogExc.EndUpdate();
                        //lstLogExc.ClearSelected();
                        //lstLogExc.SelectedIndex = lstLog.Items.Count - 1;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try
                {
                    lstLogExc.BeginUpdate();
                    lstLogExc.Items.Add(msg);
                    lstLogExc.EndUpdate();
                    //lstLogExc.ClearSelected();
                    //lstLogExc.SelectedIndex = lstLog.Items.Count - 1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Udp_warningException(string message)
        {
            AddToExcList(message);
        }

        private void Udp_received(Command com_in, System.Net.IPEndPoint endPoint)
        {
            AddToList(com_in, endPoint);
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            List<byte> list = new List<byte>();
            ushort servPort = 55062, debugPort = 55063, numTest = 13707;
            list.Add((byte)numDescr.Value);
            switch (numDescr.Value)
            {
                default:
                case 1:
                    //list.Add(1);
                    list.Add((byte)servPort);
                    list.Add((byte)(servPort >> 8));
                    list.Add((byte)debugPort);
                    list.Add((byte)(debugPort >> 8));
                    break;
                case 2:
                    {
                        //list.Add(2);
                        list.Add(1);
                        list.Add((byte)numTest);
                        list.Add((byte)(numTest >> 8));

                        //string s = "COM1";
                        //foreach (byte b in Encoding.Default.GetBytes(s)) list.Add(b);
                    }
                    break;
                case 3:
                    {
                        //list.Add(3);
                        list.Add(4);
                    }
                    break;
                case 0x10:
                    //list.Add(0x10);
                    string s = "Тестовый комментарий";
                    foreach (byte b in Encoding.Default.GetBytes(s))
                        list.Add(b);
                    break;
            }
            byte[] buf = list.ToArray();
            AddToList(BitConverter.ToString(buf));

            if(_frmMain._frmPP_Test.udp!=null)
                _frmMain._frmPP_Test.udp.SendCommand(buf);
        }

        private void btnCloseUDP_Click(object sender, EventArgs e)
        {
            if (_frmMain._frmPP_Test.udp != null)
                _frmMain._frmPP_Test.udp.Close();
        }
    }
}
