using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ivi.DCPwr;

namespace _7637_WS4
{
    public delegate void delStatusUpdate(string msg);
    public delegate void delStateDC(StateDC obj);

    public class NIControl
    {
        //Переменные для источника питания
        IIviDCPwr iviDCPower;
        Thread thrDC;
        bool bNeedUpdate = false, bNeedExit = false, bOnOff = false, bInitialized = false;
        static string DC_DeviceName = "DC";
        CurrentLimitBehavior curLimitBehavior = CurrentLimitBehavior.Regulate;
        double curLimit = 0.02, voltageLevel = 1.0;
        List<string> listDCChannels = new List<string>();
        string curDCChannel = string.Empty;
        List<CurrentLimitBehavior> listDCCurLimitBehaviour = new List<CurrentLimitBehavior>();
        public event delStatusUpdate statusUpdate;
        public event delStatusUpdate warningUpdate;
        public event delStateDC updateStateDC;
        //--------------------------------

        public NIControl()
        {
            InitDC();
        }

        /// <summary>
        /// Инициализация источника питания
        /// </summary>
        void InitDC()
        {
            try
            {
                iviDCPower = IviDCPwr.Create(DC_DeviceName, true, true);
                iviDCPower.DriverOperation.Warning += DriverOperation_Warning;
                ConfigureChannelName();
                ConfigureCurrentlimitBehavior();
                statusUpdate("SUCCESS");
                bOnOff = true;
                bInitialized = true;

                thrDC = new Thread(updateDCProcessing);
                thrDC.Start();
            }
            catch (Exception ex)
            {
                statusUpdate?.Invoke(ex.Message);
            }
        }

        private void DriverOperation_Warning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            warningUpdate(e.Code.ToString() + " " + e.Text);
        }

        private void updateDCProcessing()
        {
            while (!bNeedExit)
            {
                if (bNeedUpdate)
                {
                    UpdateIVIDCPwrOutput();
                    bNeedUpdate = false;
                }
                Thread.Sleep(100);
            }
        }

        void UpdateIVIDCPwrOutput()
        {
            if (iviDCPower == null) return;

            try
            {
                //конфигурация и запуск источника питания
                //curDCChannel = listDCChannels[0];
                iviDCPower.Outputs[curDCChannel].ConfigureCurrentLimit(curLimitBehavior, curLimit);
                iviDCPower.Outputs[curDCChannel].VoltageLevel = voltageLevel;

                iviDCPower.Outputs[curDCChannel].Enabled = bOnOff; //непосредственный запуск

                updateStateDC(new StateDC(curDCChannel, voltageLevel, bOnOff));
            }
            catch (Exception ex)
            {
                statusUpdate(ex.Message);
            }
        }

        /// <summary>
        /// Функция включения/выключения ИП с задачей канала и вольтажа
        /// </summary>
        /// <param name="channel">Номер канала ИП</param>
        /// <param name="voltage">Значение напряжения</param>
        /// <param name="on_off">Включить/Выключить ИП</param>
        public void DCSetOnOff(string channel, double voltage, bool on_off)
        {
            if (!bInitialized) InitDC();
            curDCChannel = channel;
            voltageLevel = voltage;
            bOnOff = on_off;

            bNeedUpdate = true;
        }

        void ConfigureChannelName()
        {
            listDCChannels.Clear();
            foreach (IIviDCPwrOutput channel in iviDCPower.Outputs)
            {
                listDCChannels.Add(channel.Name);
            }
        }

        void ConfigureCurrentlimitBehavior()
        {
            listDCCurLimitBehaviour.Clear();
            foreach (CurrentLimitBehavior item in Enum.GetValues(typeof(CurrentLimitBehavior)))
            {
                listDCCurLimitBehaviour.Add(item);
            }
        }

        public void CloseDCIVISession()
        {
            bNeedExit = true;
            if (iviDCPower != null)
            {
                try
                {
                    iviDCPower.Outputs["0"].Enabled = false;
                    iviDCPower.Outputs["1"].Enabled = false;
                    iviDCPower.Close();
                    iviDCPower = null;
                    bInitialized = false;
                }
                catch (Exception ex)
                {
                    statusUpdate(ex.Message);
                }
            }
        }
    }

    //хранит текущее состояние ИП
    public class StateDC
    {
        string _ch;
        double _volt;
        bool _b;

        public StateDC(string ch, double volt, bool b)
        {
            _ch = ch;
            _volt = volt;
            _b = b;
        }

        public string Ch { get => _ch; }
        public double Volt { get => _volt; }
        public bool B { get => _b; }
    }
}
