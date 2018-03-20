 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _7637_WS4
{
    public delegate void Received(UDPCommand com_in, IPEndPoint endPoint);
    public delegate void WarningException(string message);
    public enum STATE_RX { DESCR, DATA};

    public class Udp
    {
        protected Socket socketService;                    //Класс, через который реализуем отправку пакетов и прослушивание служебного порта   
        protected Socket socketDebug;
        int _servicePort, _debugPort, _portSendTo;  //порты
        IPAddress _addr;                            //ай-пи адрес, на котором ведем работу
        string strIPAddr = "127.0.0.1";             
        private UDPCommand command_in_servicePort, command_in_debugPort;   //принятые команды по служебному и отладочному портах
        Queue<byte> rx_queue = new Queue<byte>();                       //в очередь принимаем пришедшие байты
        STATE_RX state_rx = STATE_RX.DESCR;                             //текущий статус приема
        IPEndPoint remotePoint, pointPort;            //конечные точки. 

        public event Received receivedService, receivedDebug;                                 //событие прихода пакета
        public event WarningException warningException;                 //событие возникшего исключения

        Task listenTaskDebugPort, listenTaskServicePort;

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token;

        bool bIsClosed = false;

        /// <summary>
        /// Конструктор класса UDP
        /// </summary>
        /// <param name="servicePort">локальный служебный порт (ПИ)</param>
        /// <param name="debugPort">локальный отладочный порт (ПИ)</param>
        /// <param name="portSendTo">удаленный служебный порт (ПУС)</param>
        public Udp(int servicePort, int debugPort, int portSendTo)
        {
            //--УДАЛИТЬ нужно! Это временная отладка для другого проекта!
            //servicePort = 0; portSendTo = 40100;
            //strIPAddr = "192.168.0.100";
            //-------------------------------------------


            socketService = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketDebug = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _addr = IPAddress.Parse(strIPAddr);
            _servicePort = servicePort;
            _debugPort = debugPort;
            _portSendTo = portSendTo;
            state_rx = STATE_RX.DESCR;
            command_in_servicePort = new UDPCommand();
            command_in_debugPort = new UDPCommand();
            remotePoint = new IPEndPoint(_addr, _portSendTo);
            bIsClosed = false;
            listenTaskDebugPort = new Task(ListenDebugPort);     //Запускаем прослушивание портов в отдельных потоках
            listenTaskDebugPort.Start();

            listenTaskServicePort = new Task(ListenServicePort);
            listenTaskServicePort.Start();

            token = cancelTokenSource.Token;
        }

        void ListenServicePort()
        {
            ListenService(_servicePort, command_in_servicePort);
        }

        void ListenDebugPort()
        {
            ListenDebug(_debugPort, command_in_debugPort);
        }

        /// <summary>
        /// Обработчик прослушивания порта. Поток для приема подключений
        /// </summary>
        /// <param name="port">Порт для прослушивания</param>
        /// <param name="com">В какую команду формируем входящие данные</param>
        void ListenService(int port, UDPCommand com)
        {
            Socket socket = socketService;
            //Привязываем сокет к нужному адресу и порту, который будем прослушивать
            //_addr = IPAddress.Any;
            pointPort = new IPEndPoint(_addr, port);
            socket.Bind(pointPort);

            //Адрес, с которого пришли данные.
            
            //socket.ReceiveTimeout = 5000;
            byte[] data = new byte[256];
            

            while (true)
            {
                try
                {
                    int bytes = 0;
                    
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    EndPoint remoteIP = new IPEndPoint(IPAddress.Any, 0);
                    do
                    {
                        bytes = socket.ReceiveFrom(data, ref remoteIP);
                    }
                    while (socket.Available > 0);

                    com.descriptor = data[0];
                    com.data = new byte[bytes];
                    Array.Copy(data, 1, com.data, 0, bytes);

                    IPEndPoint remoteFullIp = remoteIP as IPEndPoint;   //получаем данные о подключении
                    receivedService?.Invoke(com, remoteFullIp);                //генерируем событие

                }
                catch (Exception ex)
                {
                    if(!bIsClosed)
                        warningException?.Invoke("SocketService \n\r" + ex.Message);       //генерируем событие о возникшей ошибке
                }
                finally
                {
                    //Close();
                }
            }
        }

        void ListenDebug(int port, UDPCommand com)
        {
            Socket socket = socketDebug;
            //Привязываем сокет к нужному адресу и порту, который будем прослушивать
            pointPort = new IPEndPoint(_addr, port);
            socket.Bind(pointPort);

            //Адрес, с которого пришли данные.

            //socket.ReceiveTimeout = 5000;
            byte[] data = new byte[256];


            while (true)
            {
                try
                {
                    int bytes = 0;

                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    EndPoint remoteIP = new IPEndPoint(IPAddress.Any, 0);
                    do
                    {
                        bytes = socket.ReceiveFrom(data, ref remoteIP);
                    }
                    while (socket.Available > 0);

                    com.descriptor = data[0];
                    com.data = new byte[bytes];
                    Array.Copy(data, 1, com.data, 0, bytes);

                    IPEndPoint remoteFullIp = remoteIP as IPEndPoint;   //получаем данные о подключении
                    receivedDebug?.Invoke(com, remoteFullIp);                //генерируем событие

                    /*if (socket.Available > 0)
                    {
                        byte[] tmp = new byte[socket.Available];
                        bytes = socket.ReceiveFrom(tmp, ref remoteIP);
                        foreach (byte b in tmp) rx_queue.Enqueue(b);
                    }
                    if (state_rx == STATE_RX.DESCR)
                    {
                        if (rx_queue.Count >= 1)
                        {
                            com.descriptor = rx_queue.Dequeue();
                            state_rx = STATE_RX.DATA;
                        }
                    }
                    if (state_rx == STATE_RX.DATA)
                    {
                        if (rx_queue.Count >= 1)
                        {
                            com.data = new byte[rx_queue.Count];
                            for (int i = 0; i < com.data.Length; i++)
                                com.data[i] = rx_queue.Dequeue();

                            state_rx = STATE_RX.DESCR;
                            rx_queue.Clear();

                            IPEndPoint remoteFullIp = remoteIP as IPEndPoint;   //получаем данные о подключении
                            received?.Invoke(com, remoteFullIp);                //генерируем событие
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    warningException?.Invoke("SocketDebug \n\r" + ex.Message);       //генерируем событие о возникшей ошибке
                }
                finally
                {
                    //Close();
                }
            }
        }

        public bool SendCommand(UDPCommand com)
        {
            try
            {
                byte[] buf = new byte[com.data.Length + 1];
                buf[0] = com.descriptor;
                Array.Copy(com.data, 0, buf, 1, com.data.Length);

                socketService.SendTo(buf, remotePoint);        //отправка сообщения на удаленный адрес
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendCommand(byte[] buf)
        {
            try
            {
                socketService.SendTo(buf, remotePoint);
                return true;

            }
            catch { return false; }
        }

        public void Close()
        {
            if(socketService != null)
            {
                cancelTokenSource.Cancel();             //завершаем выполнение потока

                socketService.Shutdown(SocketShutdown.Both);   //блокируем передачу и отправку по всем портам нашего сокета
                socketService.Close();                         //закрываем подключение
                socketService = null;
            }
            if (socketDebug != null)
            {
                cancelTokenSource.Cancel();             //завершаем выполнение потока

                socketDebug.Shutdown(SocketShutdown.Both);   //блокируем передачу и отправку по всем портам нашего сокета
                socketDebug.Close();                         //закрываем подключение
                socketDebug = null;

            }
            bIsClosed = true;
        }
    }
}
