using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments;

namespace _7637_WS4
{
    public class DAQ_Device
    {
        NationalInstruments.DAQmx.Task inputTask, outputTask, runningTask;
        AnalogSingleChannelReader reader/*, readerDAQMeasured*/;
        AnalogSingleChannelWriter writer;
        AsyncCallback inputCallback/*, inputCallbackDAQMeasured*/;
        double[] outputData;
        double[] inputData;
        AnalogWaveform<double> data;

        double inputDAQMinValue, inputDAQMaxValue, outputDAQMinValue, outputDAQMaxValue;
        string sDAQDeviceName;
        string sInputName;
        //string sInputMeasuredName;
        string sOutputName;
        double dRateIO; //Частота дискредитизации на приеме/посылке сигнала, Hz
        int iInputOutputSamples;  //Кол-во точек на чтение
        string sAmplitude;    //амплитуда
        double dRateGen;     //частота дискредитизации генератора синусоиды
        string _name;
        //bool bSynchronizeCallbacks;
        public event delDAQBufReadReceived bufReadDAQReceived;
        public event delStatusUpdate warningDAQUpdate;
        FunctionGenerator fGen;
        string terminalNameBase;
        System.Windows.Forms.Timer statusDAQtimer;

        /// <summary>
        /// Управляет DAQ устройством.
        /// </summary>
        /// <param name="name">Имя входа. "/ai1" - для эталона. "/ai0" - для измеряемого сигнала</param>
        public DAQ_Device(string name)
        {
            _name = name;
            inputDAQMinValue = outputDAQMinValue = -10;
            inputDAQMaxValue = outputDAQMaxValue = 10;
            sDAQDeviceName = "DAQ";
            //sInputName = sDAQDeviceName + "/ai1";
            sInputName = sDAQDeviceName + _name;
            sOutputName = sDAQDeviceName + "/ao0";
            dRateIO = 4000000;                           //частота дискретизации АЦП и ЦАП
            iInputOutputSamples = 100000;                  //количество точек для отправки/считывания
            sAmplitude = "10";                          //амплитуда генерируемого сигнала
            dRateGen = 40000;                            //частота формирования сигнала
            //bSynchronizeCallbacks = false;

            statusDAQtimer = new System.Windows.Forms.Timer();
            statusDAQtimer.Enabled = false;
            statusDAQtimer.Interval = 100;
            statusDAQtimer.Tick += StatusDAQtimer_Tick;

            //формирование эталонного сигнала
            fGen = new FunctionGenerator(
                    dRateGen.ToString(),
                    iInputOutputSamples.ToString(),
                    (dRateGen / (dRateIO / iInputOutputSamples)).ToString(),
                    "Sine",
                    sAmplitude);

            terminalNameBase = "/" + GetDAQDeviceName(sDAQDeviceName) + "/";
        }

        public void RunDAQ()
        {
            DigitalEdgeStartTriggerEdge triggerEdge = DigitalEdgeStartTriggerEdge.Rising;
            try
            {
                string s = string.Empty;
                s = _name == "/ai1" ? "etalon" : "measured";
                inputTask = new NationalInstruments.DAQmx.Task(s);
                outputTask = new NationalInstruments.DAQmx.Task(s+"_output");

                inputTask.AIChannels.CreateVoltageChannel(sInputName, "", AITerminalConfiguration.Pseudodifferential, inputDAQMinValue, inputDAQMaxValue, AIVoltageUnits.Volts);
                outputTask.AOChannels.CreateVoltageChannel(sOutputName, "", outputDAQMinValue, outputDAQMaxValue, AOVoltageUnits.Volts);

                inputTask.Timing.ConfigureSampleClock("", dRateIO, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, iInputOutputSamples);
                outputTask.Timing.ConfigureSampleClock("", dRateIO, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, iInputOutputSamples);

                outputTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(terminalNameBase + "ai/StartTrigger", triggerEdge);

                inputTask.Control(TaskAction.Verify);
                outputTask.Control(TaskAction.Verify);

                outputData = fGen.Data;

                writer = new AnalogSingleChannelWriter(outputTask.Stream);
                writer.WriteMultiSample(false, outputData);

                StartTask();
                outputTask.Start();
                inputTask.Start();

                //inputCallback = new AsyncCallback(InputReady);
                reader = new AnalogSingleChannelReader(inputTask.Stream);


                //------------ТЕСТОВЫЙ КУСОК------------ ЧТЕНИЕ В ЭТОМ ЖЕ ПОТОКЕ--
                double[] data = reader.ReadMultiSample(iInputOutputSamples);
                
                bufReadDAQReceived?.Invoke(data);
                StopTask();
                //----------------------------------------------------------------



                /*// Use SynchronizeCallbacks to specify that the object 
                // marshals callbacks across threads appropriately.
                reader.SynchronizeCallbacks = bSynchronizeCallbacks;

                reader.BeginReadMultiSample(iInputOutputSamples, inputCallback, inputTask);*/

            }
            catch (Exception ex)
            {
                StopTask();
                warningDAQUpdate?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Включение постоянной генерации сигнала. Чтение и контроль ошибок при этом производится в CALLBACK. Для завершения генерации используй метод StopDAQGeneration()
        /// </summary>
        public void RunDAQGeneration()
        {
            DigitalEdgeStartTriggerEdge triggerEdge = DigitalEdgeStartTriggerEdge.Rising;
            try
            {
                string s = string.Empty;
                s = _name == "/ai1" ? "etalon" : "measured";
                inputTask = new NationalInstruments.DAQmx.Task(s);
                outputTask = new NationalInstruments.DAQmx.Task(s + "_output");

                inputTask.AIChannels.CreateVoltageChannel(sInputName, "", AITerminalConfiguration.Pseudodifferential, inputDAQMinValue, inputDAQMaxValue, AIVoltageUnits.Volts);
                outputTask.AOChannels.CreateVoltageChannel(sOutputName, "", outputDAQMinValue, outputDAQMaxValue, AOVoltageUnits.Volts);

                inputTask.Timing.ConfigureSampleClock("", dRateIO, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, iInputOutputSamples);
                outputTask.Timing.ConfigureSampleClock("", dRateIO, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, iInputOutputSamples);

                outputTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(terminalNameBase + "ai/StartTrigger", triggerEdge);

                inputTask.Control(TaskAction.Verify);
                outputTask.Control(TaskAction.Verify);

                outputData = fGen.Data;

                writer = new AnalogSingleChannelWriter(outputTask.Stream);
                writer.WriteMultiSample(false, outputData);

                StartTask();
                outputTask.Start();
                //inputTask.Start();

                inputCallback = new AsyncCallback(AnalogInCallback);
                reader = new AnalogSingleChannelReader(inputTask.Stream);
                reader.SynchronizeCallbacks = true;
                //reader.BeginReadMultiSample(iInputOutputSamples, inputCallback, inputTask);
                reader.BeginReadWaveform(iInputOutputSamples, inputCallback, inputTask);




                //statusDAQtimer.Enabled = true;  

            }
            catch (Exception ex)
            {
                StopTask();
                warningDAQUpdate?.Invoke(ex.Message);
            }
        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    data = reader.EndReadWaveform(ar);
                    //data.Samples
                    bufReadDAQReceived(data.GetRawData());

                    reader.BeginMemoryOptimizedReadWaveform(iInputOutputSamples, inputCallback, inputTask, data);

                }
            }
            catch(DaqException ex)
            {
                warningDAQUpdate?.Invoke(ex.Message);
                StopTask();
            }
        }

        private void StatusDAQtimer_Tick(object sender, EventArgs e)
        {
            try
            {
                double[] data = reader.ReadMultiSample(iInputOutputSamples);

                bufReadDAQReceived?.Invoke(data);

                if (outputTask.IsDone)
                {
                    statusDAQtimer.Enabled = false;
                    StopTask();
                }
            }
            catch(DaqException ex)
            {
                statusDAQtimer.Enabled = false;
                warningDAQUpdate?.Invoke(ex.Message);
                StopTask();
            }
        }

        public void StopDAQGeneration()
        {
            statusDAQtimer.Enabled = false;
            StopTask();
        }

        private void InputReady(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    double[] data = reader.EndReadMultiSample(ar);  // Читаем данные
                    bufReadDAQReceived?.Invoke(data);   // Инициируем событие и передаем буфер в обработчик
                    
                    StopTask();
                }
            }
            catch (Exception ex)
            {
                StopTask();
                warningDAQUpdate?.Invoke(ex.Message);
            }
        }

        void StartTask()
        {
            if (runningTask == null)
                runningTask = inputTask;
        }

        void StopTask()
        {
            try
            {
                runningTask = null;

                inputTask.Stop();
                outputTask.Stop();

                inputTask.Dispose();
                outputTask.Dispose();
            }
            catch(Exception ex)
            {
                warningDAQUpdate?.Invoke(ex.Message);
            }
            //Dispose();
        }

        public void Dispose()
        {
            if (inputTask != null)
            {
                runningTask = null;
                inputTask.Dispose();
            }
            if (outputTask != null)
                outputTask.Dispose();
        }

        static string GetDAQDeviceName(string deviceName)
        {
            Device device = DaqSystem.Local.LoadDevice(deviceName);
            if (device.BusType != DeviceBusType.CompactDaq)
                return deviceName;
            else
                return device.CompactDaqChassisDeviceName;
        }
    }
}
