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
using NationalInstruments.DAQmx;

namespace _7637_WS4
{
    public delegate void delStatusUpdate(string msg);
    public delegate void delSwitchStatus(string name, string msg);
    public delegate void delStateDC(StateDC obj);
    public delegate void delDMMBudReadReceived(DMMResult dmmResult);
    public delegate void delDAQBufReadReceived(double[] buf);

    public class NIControl
    {
        //Переменные для источника питания-----
        IIviDCPwr iviDCPower;
        Thread thrDC;
        volatile bool bNeedUpdate = false, bOnOff1 = false, bOnOff2 = false, bUpdateDone = true;
        bool bNeedExit = false, bInitialized = false;
        static string DC_DeviceName = "DC";
        CurrentLimitBehavior curLimitBehavior = CurrentLimitBehavior.Regulate;
        double curLimit1 = 0.02, voltageLevel1 = 1.0, curLimit2 = 0.02, voltageLevel2 = 1.0;
        List<string> listDCChannels = new List<string>();
        string curDCChannel = string.Empty;
        List<CurrentLimitBehavior> listDCCurLimitBehaviour = new List<CurrentLimitBehavior>();
        public event delStatusUpdate StatusDCUpdate, WarningDCUpdate, WarningDMMUpdate, StatusDMMUpdate;
        public event delStateDC UpdateStateDC;

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
        DMMResult dmmResult;
        public event delDMMBudReadReceived bufReadDMMReceived;
        //--------------------------------------------


        //Переменные для работы с блоками реле 2530В и 2569------------
        public SwitchRelay relayR1, relayR2, relayR3, relayR4, relayR5, relayR6, relayR7, relayR8;
        //-------------------------------------------------------------


        //Переменные для работы с DAQ--------------------------
        public DAQ_Device daqEtalon, daqMeasured;

        //----------------------------------------------------



        public NIControl()
        {
            Init();
        }

        void Init()
        {
            InitDC();
            InitDMM();
            InitSwitch();
            InitDAQ();
        }

        #region Работа с блоками реле SWITCH RELAY
        void InitSwitch()
        {
            relayR1 = new SwitchRelay("R1");
            relayR2 = new SwitchRelay("R2");
            relayR3 = new SwitchRelay("R3");
            relayR4 = new SwitchRelay("R4");
            relayR5 = new SwitchRelay("R5");
            relayR6 = new SwitchRelay("R6");
            relayR7 = new SwitchRelay("R7");
            relayR8 = new SwitchRelay("R8");
        }

        public void OpenCloseRelay(bool b, string name, string channel)
        {
            name = name.ToLower();
            SwitchRelay curRelay = null;
            switch (name)
            {
                case "r1": curRelay = relayR1; break;
                case "r2": curRelay = relayR2; break;
                case "r3": curRelay = relayR3; break;
                case "r4": curRelay = relayR4; break;
                case "r5": curRelay = relayR5; break;
                case "r6": curRelay = relayR6; break;
                case "r7": curRelay = relayR7; break;
                case "r8": curRelay = relayR8; break;
                default: return;
            }
            //curRelay.ChangeRelayState(b, "k"+channel);
            curRelay.ChangeRelayState(b, "ch" + channel);
        }

        public void CloseRelaySession()
        {
            relayR1.CloseRelay();
            relayR2.CloseRelay();
            relayR3.CloseRelay();
            relayR4.CloseRelay();
            relayR5.CloseRelay();
            relayR6.CloseRelay();
            relayR7.CloseRelay();
            relayR8.CloseRelay();
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
                iviDCPower.DriverOperation.Warning += DriverOperationDC_Warning;

                //iviDCPower.Outputs["0"].OvpEnabled = true;
                ConfigureChannelName();
                ConfigureCurrentlimitBehavior();
                StatusDCUpdate?.Invoke("SUCCESS");
                //bOnOff1 = true;
                bInitialized = true;


                thrDC = new Thread(updateDCProcessing);
                thrDC.Start();
            }
            catch (Exception ex)
            {
                StatusDCUpdate?.Invoke(ex.Message);
            }
        }

        private void DriverOperationDC_Warning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            WarningDCUpdate?.Invoke(e.Code.ToString() + " " + e.Text);
        }

        private void updateDCProcessing()
        {
            while (!bNeedExit)
            {
                if (bNeedUpdate)
                {
                    bUpdateDone = false;
                    UpdateIVIDCPwrOutput();
                    bNeedUpdate = false;
                }
                Thread.Sleep(10);

                try
                {
                    UpdateStateDC?.Invoke(new StateDC(
                        "0",
                        iviDCPower.Outputs["0"].Measure(MeasurementType.Voltage),
                        iviDCPower.Outputs["0"].CurrentLimit,
                        iviDCPower.Outputs["0"].Measure(MeasurementType.Current),
                        iviDCPower.Outputs["0"].Enabled,
                        iviDCPower.Outputs["0"].QueryState(OutputState.ConstantVoltage),
                        "1",
                        iviDCPower.Outputs["1"].Measure(MeasurementType.Voltage),
                        iviDCPower.Outputs["1"].CurrentLimit,
                        iviDCPower.Outputs["1"].Measure(MeasurementType.Current),
                        iviDCPower.Outputs["1"].Enabled,
                        iviDCPower.Outputs["1"].QueryState(OutputState.ConstantVoltage)));
                }
                catch(Exception ex)
                {
                    WarningDCUpdate?.Invoke(ex.Message);
                }
            }
        }

        void UpdateIVIDCPwrOutput()
        {
            if (iviDCPower == null) return;
            try
            {
                //конфигурация и запуск источника питания
                iviDCPower.Outputs["0"].ConfigureCurrentLimit(curLimitBehavior, curLimit1);
                iviDCPower.Outputs["0"].VoltageLevel = voltageLevel1;
                iviDCPower.Outputs["0"].Enabled = bOnOff1; //непосредственный запуск

                iviDCPower.Outputs["1"].ConfigureCurrentLimit(curLimitBehavior, curLimit2);
                iviDCPower.Outputs["1"].VoltageLevel = voltageLevel2;
                iviDCPower.Outputs["1"].Enabled = bOnOff2; //непосредственный запуск

                if (iviDCPower.Outputs["1"].Enabled != bOnOff2 || iviDCPower.Outputs["0"].Enabled != bOnOff1)
                {
                    int k = 9;
                    k++;
                }
                bUpdateDone = true;
            }
            catch (Exception ex) { StatusDCUpdate?.Invoke(ex.Message); }
        }

        /// <summary>
        /// Функция включения/выключения ИП с параметрами вольтажа и ограничения по току для каждого из двух каналов
        /// </summary>
        /// <param name="voltage1">Напряжение канала 1</param>
        /// <param name="currentLimit1">Ограничение по току канала 1</param>
        /// <param name="on_off1">Включить/выключить канал 1</param>
        /// <param name="voltage2">Напряжение канала 2</param>
        /// <param name="currentLimit2">Ограничение по току канала 2</param>
        /// <param name="on_off2">Включить/выключить канал 2</param>
        public void DCSetOnOff(double voltage1, double currentLimit1, bool on_off1, double voltage2, double currentLimit2, bool on_off2)
        {
            if (!bInitialized) InitDC();
            //curDCChannel = channel;
            voltageLevel1 = voltage1;
            curLimit1 = currentLimit1;
            bOnOff1 = on_off1;
            voltageLevel2 = voltage2;
            curLimit2 = currentLimit2;
            bOnOff2 = on_off2;

            while (!bUpdateDone) Application.DoEvents();
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
                    StatusDCUpdate?.Invoke(ex.Message);
                }
            }
        }

        #endregion

        #region Управление DMM, мультиметром, считывание данных
        void InitDMM()
        {
            //aqusitionStopped = false;
            dmmResult = new DMMResult();
            listDeviceDMM.Clear();
            listMeasureModeDMM.Clear();

            //powerlineFrequencyDMM = powerlineFrequencyValues[1]; //60
            //resolutionDMM = resolutionValues[2]; //6.5

            //Составляем список DMM оборудования
            ModularInstrumentsSystem modularInstrumentsSystem = new ModularInstrumentsSystem("NI-DMM");
            foreach (DeviceInfo device in modularInstrumentsSystem.DeviceCollection)
                listDeviceDMM.Add(device.Name);
            if (listDeviceDMM.Count < 1)
                WarningDMMUpdate?.Invoke("No DMM device found!");
            else
                WarningDMMUpdate?.Invoke("Device " + listDeviceDMM[0] + " found");

            //Составляем список режимов измерения DMM
            listMeasureModeDMM.AddRange(Enum.GetNames(typeof(DmmMeasurementFunction)));
            listMeasureModeDMM.Remove(DmmMeasurementFunction.WaveformCurrent.ToString());
            listMeasureModeDMM.Remove(DmmMeasurementFunction.WaveformVoltage.ToString());


        }

        public void CreateDMM()
        {
            dmmSession = new NIDmm(listDeviceDMM[0], true, true);
        }

        public void CloseDMM()
        {
            if (dmmSession != null)
                dmmSession.Close();
            Application.DoEvents();
        }

        void ConfigureDMM(MultimeterMode measurementFunction, double range, double accuracy)
        {
            if (dmmSession == null) return;
            DmmMeasurementFunction measurementMode = DmmMeasurementFunction.DCVolts;
            /*if(measurementFunction == "DCVolts")
                measurementMode = (DmmMeasurementFunction)Enum.Parse(typeof(DmmMeasurementFunction), listMeasureModeDMM[0]);
            else if(measurementFunction == "Resistance")
                measurementMode = (DmmMeasurementFunction)Enum.Parse(typeof(DmmMeasurementFunction), listMeasureModeDMM[4]);*/

            measurementMode = (DmmMeasurementFunction)Enum.Parse(typeof(DmmMeasurementFunction), measurementFunction.ToString());
            //DmmMeasurementFunction measurementMode = (DmmMeasurementFunction)Enum.Parse(typeof(DmmMeasurementFunction), listMeasureModeDMM[0]);
            DmmTriggerSource triggerSource = "Immediate";              //"Immediate", "External", "Software Trigger", "Ttl0", "Ttl1"
            //double range = 100000;
            //double triggerDelay = 0;
            powerlineFrequencyDMM = powerlineFrequencyValues[1]; //60
            //resolutionDMM = resolutionValues[2]; //6.5
            samplesPerReading = 7;
            if (accuracy == 0) accuracy = resolutionValues[2];   //если в таблице неверно указан параметр, то по умолчанию берем точность 4.5
            dmmSession.ConfigureMeasurementDigits(measurementMode, range, accuracy);
            dmmSession.Advanced.PowerlineFrequency = powerlineFrequencyDMM;
            
            //dmmSession.Trigger.Configure(triggerSource, PrecisionTimeSpan.FromSeconds(triggerDelay));  //не находит почему то класс точного времени
            dmmSession.Trigger.Configure(triggerSource, true);
            dmmSession.Trigger.MultiPoint.SampleCount = samplesPerReading;
        }

        public void ReadDMM(MultimeterMode measurementFunction, double range, double accuracy)
        {
            //Application.DoEvents();
            double[] readBuf;
            try
            {
                //dmmSession = new NIDmm(listDeviceDMM[0], true, true);

                
                ConfigureDMM(measurementFunction, range, accuracy);                

                dmmSession.Measurement.Initiate();

                Application.DoEvents();
                readBuf = dmmSession.Measurement.FetchMultiPoint(samplesPerReading);
                StatusDMMUpdate?.Invoke("SUCCESS");

                dmmResult.buf = readBuf;
                //dmmResult.temp = dmmSession.Temperature.ToString();
                dmmResult.measurementMode = dmmSession.MeasurementFunction.ToString();

                bufReadDMMReceived?.Invoke(dmmResult);

            }
            catch (Exception ex)
            {
                WarningDMMUpdate?.Invoke(ex.Message);
            }
            finally
            {
                /*if (dmmSession != null)
                    dmmSession.Close();
                Application.DoEvents();*/
            }
        }

        #endregion

        #region Управление DAQ

        public void InitDAQ()
        {
            daqEtalon = new DAQ_Device("/ai1");
            daqMeasured = new DAQ_Device("/ai0");
        }

        #endregion
    }

    //хранит текущее состояние ИП, его обоих каналов
    public class StateDC
    {
        string _ch1;
        double _volt1;
        double _curlim1;
        double _cur1;
        bool _b1;
        bool _bOVP1;
        string _ch2;
        double _volt2;
        double _curlim2;
        double _cur2;
        bool _b2;
        bool _bOVP2;

        public StateDC(string ch1, double volt1, double curlim1, double cur1, bool b1, bool bOVP1, string ch2, double volt2, double curlim2, double cur2, bool b2, bool bOVP2)
        {
            _ch1 = ch1;
            _volt1 = volt1;
            _curlim1 = curlim1;
            _cur1 = cur1;
            _b1 = b1;
            _bOVP1 = bOVP1;
            _ch2 = ch2;
            _volt2 = volt2;
            _curlim2 = curlim2;
            _cur2 = cur2;
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
        public double Curlim1 { get => _curlim1; }
        public double Curlim2 { get => _curlim2; }
        public double Cur1 { get => _cur1; }
        public double Cur2 { get => _cur2;  }
    }

    public class SwitchRelay
    {
        NISwitch relay;
        const string sTopology2530 = "2530/1-Wire 128x1 Mux";
        const string sTopology2569 = "2569/100-SPST";
        string curTopology = string.Empty;
        public event delSwitchStatus warningSWITCH, statusSWITCH;
        PrecisionTimeSpan maxTime;
        string _name;
        public SwitchRelay(string name)
        {
            maxTime = new PrecisionTimeSpan(500);
            _name = name;
            InitRelay();
        }
        /// <summary>
        /// Инициализация блока реле. Топология будет выбрана автоматически в соответствии с указанным именем.
        /// </summary>
        /// <param name="name">Имя, указанное в NI MAX</param>
        public void InitRelay()
        {
            curTopology = _name.Contains("R6") || _name.Contains("R7") || _name.Contains("R8") ? sTopology2569 : sTopology2530;
            try
            {
                Init(curTopology);
                //_name = name;
            }
            catch (Exception ex)
            {
                warningSWITCH?.Invoke(_name, ex.Message);
            }
        }

        /// <summary>
        /// Закрытие текущего реле
        /// </summary>
        public void CloseRelay()
        {
            if (relay != null)
            {
                try
                {
                    relay.Utility.Reset();
                    relay.Close();
                    relay = null;
                }
                catch (Exception ex)
                {
                    warningSWITCH(_name, "Невозможно закрыть сессию  " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Управление реле. Открывает и закрывает определенный канал.
        /// </summary>
        /// <param name="action">Действие над каналом. true - закрыть, false - открыть</param>
        /// <param name="curChannelToWorkWith">Канал, над которым производится действия. Например, ch17</param>
        public void ChangeRelayState(bool action, string curChannelToWorkWith)
        {
            if (relay != null)
            {
                try
                {
                    /*SwitchRelayAction relayAction = action ? SwitchRelayAction.CloseRelay : SwitchRelayAction.OpenRelay;
                    relay.RelayOperations.RelayControl(curChannelToWorkWith, relayAction);
                    relay.Path.WaitForDebounce(maxTime);*/

                    //curChannelToWorkWith = "ch"+curChannelToWorkWith.Remove(0, 1);
                    if (action)
                    {
                        if (curTopology == sTopology2530)
                        {
                            SwitchPathCapability switchCap = relay.Path.CanConnect(curChannelToWorkWith, "com0");
                            if (switchCap == SwitchPathCapability.Available)
                            {
                                relay.Path.Connect(curChannelToWorkWith, "com0");
                                statusSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + " соединено");
                            }
                            else
                                warningSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + ". " + switchCap.ToString());

                        }
                        else if (curTopology == sTopology2569)
                        {
                            string n = "com" + curChannelToWorkWith.Remove(0, 2);
                            SwitchPathCapability switchCap = relay.Path.CanConnect(curChannelToWorkWith, n);
                            if (switchCap == SwitchPathCapability.Available)
                            {
                                relay.Path.Connect(curChannelToWorkWith, n);
                                statusSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + " соединено");
                            }
                            else
                                warningSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + "-" + n + ". " + switchCap.ToString());
                        }
                    }
                    else
                    {
                        if (curTopology == sTopology2530)
                        {
                            SwitchPathCapability switchCap = relay.Path.CanConnect(curChannelToWorkWith, "com0");
                            if (switchCap == SwitchPathCapability.Exists)
                            {
                                relay.Path.Disconnect(curChannelToWorkWith, "com0");
                                statusSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + " отключено");
                            }
                            else
                                warningSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + ". " + switchCap.ToString());
                        }
                        else if (curTopology == sTopology2569)
                        {
                            string n = "com" + curChannelToWorkWith.Remove(0, 2);
                            SwitchPathCapability switchCap = relay.Path.CanConnect(curChannelToWorkWith, n);
                            if (switchCap == SwitchPathCapability.Exists)
                            {
                                relay.Path.Disconnect(curChannelToWorkWith, n);
                                statusSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + " отключено");
                            }
                            else
                                warningSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + "-" + n + ". " + switchCap.ToString());
                        }
                    }

                    relay.Path.WaitForDebounce(maxTime);

                    //string res = action ? " закрыто" : " открыто";
                    //statusSWITCH?.Invoke(_name, "Реле " + curChannelToWorkWith + res);
                }
                catch (Exception ex)
                {
                    warningSWITCH(_name, ex.Message);
                }
            }
            else
                warningSWITCH(_name, "указанный блок реле не существует или не инициализирован");
        }

        void Init(string topology)
        {
            relay = new NISwitch(_name, topology, false, true);
            relay.DriverOperation.Warning += DriverOperation_Warning;
        }

        private void DriverOperation_Warning(object sender, SwitchWarningEventArgs e)
        {
            warningSWITCH(_name, e.Message);
        }
    }

    public class DMMResult
    {
        public double[] buf;
        public string measurementMode;
        //public string temp;
    }
}
