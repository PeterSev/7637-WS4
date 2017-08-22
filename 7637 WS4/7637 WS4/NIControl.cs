using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ivi.DCPwr;
using NationalInstruments.ModularInstruments.NIDmm;
using NationalInstruments;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using NationalInstruments.ModularInstruments.NISwitch;

namespace _7637_WS4
{
    public delegate void delStatusUpdate(string msg);
    public delegate void delStateDC(StateDC obj);
    public delegate void delDMMBudReadReceived(double[] buf);

    public class NIControl
    {
        //Переменные для источника питания-----
        IIviDCPwr iviDCPower;
        Thread thrDC;
        bool bNeedUpdate = false, bNeedExit = false, bOnOff = false, bInitialized = false;
        static string DC_DeviceName = "DC";
        CurrentLimitBehavior curLimitBehavior = CurrentLimitBehavior.Regulate;
        double curLimit = 0.02, voltageLevel = 1.0;
        List<string> listDCChannels = new List<string>();
        string curDCChannel = string.Empty;
        List<CurrentLimitBehavior> listDCCurLimitBehaviour = new List<CurrentLimitBehavior>();
        public event delStatusUpdate statusDCUpdate, warningDCUpdate, warningDMMUpdate, statusDMMUpdate;
        public event delStateDC updateStateDC;
        public event delDMMBudReadReceived bufReadDMMReceived;
        //-------------------------------------

        //Переменные для мультиметра------------------
        NIDmm dmmSession;
        //const int maxSamplesPerReading = 10000;
        int samplesPerReading;
        //int totalNumberOfSamples = 0;
        //double averageReading, minReading = Double.PositiveInfinity, maxReading = double.NegativeInfinity;
        //bool aqusitionStopped;
        //double[] readBuf = new double[maxSamplesPerReading];
        //bool isStartSuccessful = false;
        List<string> listDeviceDMM = new List<string>(), listMeasureModeDMM = new List<string>();
        static double[] powerlineFrequencyValues = { 50, 60 };
        static double[] resolutionValues = { 3.5, 4.5, 5.5, 6.5, 7.5 };
        double powerlineFrequencyDMM;
        double resolutionDMM;
        //--------------------------------------------


        //Переменные для работы с блоками реле 2530В и 2569------------
        NISwitch switchRelay;
        PrecisionTimeSpan maxTime = new PrecisionTimeSpan(50);
        string currentRelayToWorkWith = string.Empty;
        const string sTopology2530 = "2530/1-Wire 128x1 Mux";
        const string sTopology2569 = "2569/100-SPST";
        List<string> listSwitchName = new List<string>();
        //-------------------------------------------------------------




        public NIControl()
        {
            InitDC();
            InitDMM();
        }

        #region Работа с блоками реле SWITCH RELAY
        void LoadSwitchDeviceNames()
        {
            ModularInstrumentsSystem modularInstrumentsSystem = new ModularInstrumentsSystem("NI-SWITCH");
            foreach (DeviceInfo device in modularInstrumentsSystem.DeviceCollection)
            {
                listSwitchName.Add(device.Name);
            }
                listSwitchName.Sort();
        }


        #endregion

        #region Управление источником питания
        /// <summary>
        /// Инициализация источника питания
        /// </summary>
        void InitDC()
        {
            try
            {
                iviDCPower = IviDCPwr.Create(DC_DeviceName, true, true);
                iviDCPower.DriverOperation.Warning += DriverOperation_Warning;

                //iviDCPower.Outputs["0"].OvpEnabled = true;
                ConfigureChannelName();
                ConfigureCurrentlimitBehavior();
                statusDCUpdate("SUCCESS");
                bOnOff = true;
                bInitialized = true;
                

                thrDC = new Thread(updateDCProcessing);
                thrDC.Start();
            }
            catch (Exception ex)
            {
                statusDCUpdate?.Invoke(ex.Message);
            }
        }

        private void DriverOperation_Warning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            warningDCUpdate?.Invoke(e.Code.ToString() + " " + e.Text);
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
                updateStateDC?.Invoke(new StateDC(
                    "0",
                    iviDCPower.Outputs["0"].Measure(MeasurementType.Voltage),
                    iviDCPower.Outputs["0"].Enabled,
                    iviDCPower.Outputs["0"].QueryState(OutputState.ConstantVoltage),
                    "1",
                    iviDCPower.Outputs["1"].Measure(MeasurementType.Voltage),
                    iviDCPower.Outputs["1"].Enabled,
                    iviDCPower.Outputs["1"].QueryState(OutputState.ConstantVoltage)));
                //updateStateDC?.Invoke(new StateDC("1", iviDCPower.Outputs["1"].Measure(MeasurementType.Voltage), iviDCPower.Outputs["1"].Enabled, iviDCPower.Outputs["1"].QueryState(OutputState.ConstantVoltage)));
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

                //updateStateDC(new StateDC(curDCChannel, iviDCPower.Outputs[curDCChannel].Measure(MeasurementType.Voltage), bOnOff));
            }
            catch (Exception ex)
            {
                statusDCUpdate?.Invoke(ex.Message);
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
                    statusDCUpdate?.Invoke(ex.Message);
                }
            }
        }

        #endregion

        #region Управление DMM, мультиметром, считывание данных
        void InitDMM()
        {
            //aqusitionStopped = false;
            listDeviceDMM.Clear();
            listMeasureModeDMM.Clear();

            powerlineFrequencyDMM = powerlineFrequencyValues[1]; //60
            resolutionDMM = resolutionValues[1]; //6.5

            //Составляем список DMM оборудования
            ModularInstrumentsSystem modularInstrumentsSystem = new ModularInstrumentsSystem("NI-DMM");
            foreach (DeviceInfo device in modularInstrumentsSystem.DeviceCollection)
                listDeviceDMM.Add(device.Name);
            if (listDeviceDMM.Count < 1)
                warningDMMUpdate?.Invoke("No DMM device found!");
            else
                warningDMMUpdate?.Invoke("Device " + listDeviceDMM[0] + " found");

            //Составляем список режимов измерения DMM
            listMeasureModeDMM.AddRange(Enum.GetNames(typeof(DmmMeasurementFunction)));
            listMeasureModeDMM.Remove(DmmMeasurementFunction.WaveformCurrent.ToString());
            listMeasureModeDMM.Remove(DmmMeasurementFunction.WaveformVoltage.ToString());

            
        }

        void ConfigureDMM()
        {
            DmmMeasurementFunction measurementMode = (DmmMeasurementFunction)Enum.Parse(typeof(DmmMeasurementFunction), listMeasureModeDMM[0]);
            DmmTriggerSource triggerSource = "Immediate";              //"Immediate", "External", "Software Trigger", "Ttl0", "Ttl1"
            double range = 100;
            //double triggerDelay = 0;
            samplesPerReading = 10;
            dmmSession.ConfigureMeasurementDigits(measurementMode, range, resolutionDMM);
            dmmSession.Advanced.PowerlineFrequency = powerlineFrequencyDMM;

            //dmmSession.Trigger.Configure(triggerSource, PrecisionTimeSpan.FromSeconds(triggerDelay));  //не находит почему то класс точного времени
            dmmSession.Trigger.Configure(triggerSource, true);
            dmmSession.Trigger.MultiPoint.SampleCount = samplesPerReading;
        }

        public void ReadDMM()
        {
            //Application.DoEvents();
            double[] readBuf;
            try
            {
                dmmSession = new NIDmm(listDeviceDMM[0], true, true);
                ConfigureDMM();

                dmmSession.Measurement.Initiate();

                Application.DoEvents();
                readBuf = dmmSession.Measurement.FetchMultiPoint(samplesPerReading);
                statusDMMUpdate?.Invoke("SUCCESS");
                bufReadDMMReceived?.Invoke(readBuf); 
            }
            catch(Exception ex)
            {
                warningDMMUpdate?.Invoke(ex.Message);
            }
            finally
            {
                if (dmmSession != null)
                    dmmSession.Close();
                Application.DoEvents();
            }
        }

        #endregion

    }








    //хранит текущее состояние ИП, его обоих каналов
    public class StateDC
    {
        string _ch1;
        double _volt1;
        bool _b1;
        bool _bOVP1;
        string _ch2;
        double _volt2;
        bool _b2;
        bool _bOVP2;

        public StateDC(string ch1, double volt1, bool b1, bool bOVP1, string ch2, double volt2, bool b2, bool bOVP2)
        {
            _ch1 = ch1;
            _volt1 = volt1;
            _b1 = b1;
            _bOVP1 = bOVP1;
            _ch2 = ch2;
            _volt2 = volt2;
            _b2 = b2;
            _bOVP2 = bOVP2;
        }

        public string Ch1 { get => _ch1; }
        public double Volt1 { get => _volt1; }
        public bool B1 { get => _b1; }
        public bool BOVP1 { get => _bOVP1; }

        public string Ch2 { get => _ch2; }
        public double Volt2 { get => _volt2; }
        public bool B2 { get => _b2; }
        public bool BOVP2 { get => _bOVP2; }
    }


}
