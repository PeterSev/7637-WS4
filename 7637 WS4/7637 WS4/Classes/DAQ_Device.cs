using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;

namespace _7637_WS4
{
    public class DAQ_Device
    {
        NationalInstruments.DAQmx.Task inputTask, outputTask, runningTask;
        AnalogSingleChannelReader reader/*, readerDAQMeasured*/;
        AnalogSingleChannelWriter writer;
        //AsyncCallback inputCallback/*, inputCallbackDAQMeasured*/;
        double[] output;
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
            dRateIO = 400000;                           //частота дискретизации АЦП и ЦАП
            iInputOutputSamples = 500;                  //количество точек для отправки/считывания
            sAmplitude = "10";                          //амплитуда генерируемого сигнала
            dRateGen = 4000;                            //частота формирования сигнала
            //bSynchronizeCallbacks = false;

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

                output = fGen.Data;

                writer = new AnalogSingleChannelWriter(outputTask.Stream);
                writer.WriteMultiSample(false, output);

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
            runningTask = null;
            inputTask.Stop();
            outputTask.Stop();

            inputTask.Dispose();
            outputTask.Dispose();

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
