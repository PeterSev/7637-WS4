 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _7637_WS4
{
    public delegate void Received(Command com_in, IPEndPoint endPoint);
    public delegate void WarningException(string message);
    public enum STATE_RX { DESCR, DATA};

    public class Udp
    {
        protected Socket socket;                    //Класс, через который реализуем отправку пакетов и прослушивание портов    
        int _servicePort, _debugPort, _portSendTo;  //порты
        IPAddress _addr;                            //ай-пи адрес, на котором ведем работу
        string strIPAddr = "127.0.0.1";             
        private Command command_in_servicePort, command_in_debugPort;   //принятые команды по служебному и отладочному портах
        Queue<byte> rx_queue = new Queue<byte>();                       //в очередь принимаем пришедшие байты
        STATE_RX state_rx = STATE_RX.DESCR;                             //текущий статус приема
        IPEndPoint remotePoint, pointPort, pointServicePort;            //конечные точки. 

        public event Received received;                                 //событие прихода пакета
        public event WarningException warningException;                 //событие возникшего исключения

        /// <summary>
        /// Конструктор класса UDP
        /// </summary>
        /// <param name="servicePort">локальный служебный порт (ПИ)</param>
        /// <param name="debugPort">локальный отладочный порт (ПИ)</param>
        /// <param name="portSendTo">удаленный служебный порт (ПУС)</param>
        public Udp(int servicePort, int debugPort, int portSendTo)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _addr = IPAddress.Parse(strIPAddr);
            _servicePort = servicePort;
            _debugPort = debugPort;
            _portSendTo = portSendTo;
            state_rx = STATE_RX.DESCR;
            command_in_servicePort = new Command();
            command_in_debugPort = new Command();
            remotePoint = new IPEndPoint(_addr, _portSendTo);

            Task listenTaskPort = new Task(ListenPort);     //Запускаем прослушивание портов в отдельных потоках
            listenTaskPort.Start();

            Task listenTaskServicePort = new Task(ListenServicePort);
            listenTaskServicePort.Start();
        }

        void ListenServicePort()
        {
            Listen(_debugPort, command_in_debugPort);
        }

        void ListenPort()
        {
            Listen(_servicePort, command_in_servicePort);
        }

        /// <summary>
        /// Обработчик прослушивания порта. Поток для приема подключений
        /// </summary>
        /// <param name="port">Порт для прослушивания</param>
        /// <param name="com">В какую команду формируем входящие данные</param>
        void Listen(int port, Command com)
        {
            try
            {
                //Привязываем сокет к нужному адресу и порту, который будем прослушивать
                pointPort = new IPEndPoint(_addr, port);
                socket.Bind(pointPort);

                //Адрес, с которого пришли данные.
                EndPoint remoteIP = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    int bytes = 0;
                    //byte[] data = new byte[256];

                    if (socket.Available > 1)
                    {
                        byte[] tmp = new byte[socket.Available];
                        bytes = socket.ReceiveFrom(tmp, ref remoteIP);
                        foreach (byte b in tmp) rx_queue.Enqueue(b);
                    }
                    if (state_rx == STATE_RX.DESCR)
                    {
                        com.descriptor = rx_queue.Dequeue();
                        state_rx = STATE_RX.DATA;
                    }
                    if (state_rx == STATE_RX.DATA)
                    {
                        com.data = new byte[rx_queue.Count];
                        for (int i = 0; i < com.data.Length; i++)
                            com.data[i] = rx_queue.Dequeue();

                        state_rx = STATE_RX.DESCR;
                        rx_queue.Clear();

                        IPEndPoint remoteFullIp = remoteIP as IPEndPoint;   //получаем данные о подключении
                        received?.Invoke(com, remoteFullIp);                //генерируем событие
                    }
                }
            }
            catch(Exception ex)
            {
                warningException?.Invoke(ex.Message);       //генерируем событие о возникшей ошибке
            }
            finally
            {
                Close();
            }
        }

        public void SendCommand(byte[] buf)
        {
            socket.SendTo(buf, remotePoint);        //отправка сообщения на удаленный адрес
        }

        public void Close()
        {
            if(socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);   //блокируем передачу и отправку по всем портам нашего сокета
                socket.Close();                         //закрываем подключение
                socket = null;
            }
        }
    }
}
