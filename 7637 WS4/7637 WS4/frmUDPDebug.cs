using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;

namespace _7637_WS4
{
    public partial class frmUDPDebug : Form
    {
        public UDPCommand comUDPout2, comUDPout3;
        public frmMain _frmMain;
        bool bNeedReload = true;
        int ListCountService = 0;
        int servicePort = 55060, debugPort = 55061;
        int remotePort = 55062;
        public frmUDPDebug()
        {
            InitializeComponent();
            comUDPout2 = new UDPCommand();
            comUDPout3 = new UDPCommand();
        }

        void Init()
        {
            bNeedReload = false;
            
        }

        private void frmUDPDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bNeedReload = true;

            if (_frmMain._frmPP_Test.udp != null)
            {
                _frmMain._frmPP_Test.udp.receivedService -= Udp_received;
                _frmMain._frmPP_Test.udp.receivedDebug -= Udp_received;
                _frmMain._frmPP_Test.udp.warningException -= Udp_warningException;
            }
            this.Hide();
        }

        private void frmUDPDebug_Activated(object sender, EventArgs e)
        {
            if (bNeedReload)
                Init();
        }

        private void btnCreateUDP_Click(object sender, EventArgs e)
        {
            
            _frmMain._frmPP_Test.udp = new Udp(servicePort, debugPort, remotePort);
            _frmMain._frmPP_Test.udp.receivedService += Udp_received;
            _frmMain._frmPP_Test.udp.receivedDebug += Udp_received;
            _frmMain._frmPP_Test.udp.warningException += Udp_warningException;
            AddToList(String.Format("Сокеты созданы. Служебный порт: {0}, Отладочный порт: {1}, Удаленный служебный порт: {2}", servicePort, debugPort, remotePort));
        }



        void AddToServiceList(UDPCommand com_in, System.Net.IPEndPoint endPoint)
        {
            ListBox list;
            list = endPoint.Port == servicePort ? lstLogService : lstLogDebug;

            ListCountService++;
            if(ListCountService > 9999)
            {
                list.Items.Clear();
                ListCountService = 1;
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
                        case 3: tmp = "Номер шага больше, чем кол-во шагов в открытом тесте"; break;
                    }
                    s1 = "Статус: " + tmp;
                    break;
                case 0x10:
                    s1 = Encoding.Default.GetString(com_in.data, 0, com_in.data.Length - 1);
                    break;
            }
            string outstr = string.Format("{0:0000}:{1}    Descr: {2}      {3} {4} {5}",
                ListCountService,
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
                        list.BeginUpdate();
                        list.Items.Add(outstr);
                        list.EndUpdate();
                        list.ClearSelected();
                        list.SelectedIndex = list.Items.Count - 1;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try
                {
                    list.BeginUpdate();
                    list.Items.Add(outstr);
                    list.EndUpdate();
                    list.ClearSelected();
                    list.SelectedIndex = list.Items.Count - 1;
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
                        lstLogService.BeginUpdate();
                        lstLogService.Items.Add(msg);
                        lstLogService.EndUpdate();
                        lstLogService.ClearSelected();
                        lstLogService.SelectedIndex = lstLogService.Items.Count - 1;
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try
                {
                    lstLogService.BeginUpdate();
                    lstLogService.Items.Add(msg);
                    lstLogService.EndUpdate();
                    lstLogService.ClearSelected();
                    lstLogService.SelectedIndex = lstLogService.Items.Count - 1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        void AddToDebugList(string msg)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lstLogDebug.BeginUpdate();
                        lstLogDebug.Items.Add(msg);
                        lstLogDebug.EndUpdate();
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
                    lstLogDebug.BeginUpdate();
                    lstLogDebug.Items.Add(msg);
                    lstLogDebug.EndUpdate();
                    //lstLogExc.ClearSelected();
                    //lstLogExc.SelectedIndex = lstLog.Items.Count - 1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Udp_warningException(string message)
        {
            AddToDebugList(message);
        }

        private void Udp_received(UDPCommand com_in, System.Net.IPEndPoint endPoint)
        {
            AddToServiceList(com_in, endPoint);
        }

        private void SendCommandDescr2()
        {
            UDPCommand com = comUDPout2;
            string sComport = "COM1";
            string filename = Application.StartupPath + "\\ALEKSENKO\\7025.32.04.400.csv";
            //string filename = @"D:\WORK\REPOSITORIES\7637 - WS4\7637 - WS4\7637 WS4\7637 WS4\bin\Debug\ALEKSENKO\7025.32.04.400.csv";
            //string filename = "Hello";

            byte[] bComport = new byte[5];
            Array.Copy(Encoding.Default.GetBytes(sComport), bComport, sComport.Length);
            byte[] bFilename = Encoding.Default.GetBytes(filename);
            UInt16 nameLength = (UInt16)bFilename.Length;
            byte[] bNameLength = BitConverter.GetBytes(nameLength);

            com.descriptor = 0x2;
            com.data = new byte[bComport.Length + bNameLength.Length + bFilename.Length];
            Array.Copy(bComport, 0, com.data, 0, bComport.Length);
            Array.Copy(bNameLength, 0, com.data, bComport.Length, bNameLength.Length);
            Array.Copy(bFilename, 0, com.data, bComport.Length + bNameLength.Length, bFilename.Length);

            SendCommand(com);
        }

        private void SendCommandDescr3(UInt16 step)
        {
            UDPCommand com = comUDPout3;

            byte[] bStep = BitConverter.GetBytes(step);


            com.descriptor = 0x3;
            com.data = new byte[bStep.Length];
            Array.Copy(bStep, com.data, bStep.Length);

            SendCommand(com);
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            switch (numDescr.Value)
            {
                case 2:
                    SendCommandDescr2();
                    break;
                case 3:
                    SendCommandDescr3((UInt16)numStep.Value);
                    break;
                default:
                    break;
            }
        }

        void SendCommand(UDPCommand com)
        {
            if (_frmMain._frmPP_Test.udp != null)
            {
                if (_frmMain._frmPP_Test.udp.SendCommand(com))
                    AddToList($"Отправлена посылка: {com.descriptor}    {BitConverter.ToString(com.data)}");
                else
                    AddToList("Отправка не выполнена");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Process proc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = Assembly.GetExecutingAssembly().Location + "/ALEKSENKO/india_mane_prog.exe";
            startInfo.FileName = Application.StartupPath + "/ALEKSENKO/india_mane_prog.exe";

            startInfo.Arguments = "/nogui";
            proc.StartInfo = startInfo;

            if (File.Exists(startInfo.FileName))
                proc.Start();
            else
                MessageBox.Show($"Файл {startInfo.FileName} не найден");*/

            string filename = Application.StartupPath + "/ALEKSENKO/india_mane_prog.exe";
            if (File.Exists(filename))
                Process.Start(filename, "nogui");
        }

        private void btnCloseUDP_Click(object sender, EventArgs e)
        {
            if (_frmMain._frmPP_Test.udp != null)
            {
                _frmMain._frmPP_Test.udp.Close();
                AddToList("Сокеты закрыты");
            }
        }
    }
}
