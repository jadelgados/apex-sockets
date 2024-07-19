

using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections;

namespace _003_Sockets
{
    internal class Server
    {
        public ManualResetEvent allDone = new ManualResetEvent(false);
        Socket _server;
        AsyncCallback _workerCallBack;

        //Coleccion de socket que representan a cada cliente conectado
        //Creamos la colección com Sunchronized para uso seguro con los hilos
        private System.Collections.ArrayList _workerSocketList =
                ArrayList.Synchronized(new System.Collections.ArrayList());

        //Variable para controlar el número de clientes conectados
        //Debido a que multiples hilos pueden modificar esta variable
        //la debemos actualizar de una forma controlada
        private int _clientCount = 0;
        private int _connectedClients = 0;

        public Server()
        {
            
        }

        public void Start()
        {
            // Dirección IP del servidor y puerto
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 11000;

            _server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            IPEndPoint ipLocal = new IPEndPoint(ipAddress, port);

            _server.Bind(ipLocal);
            _server.Listen(100);

            Console.WriteLine("Servidor listo, esperando conexiones.");
            while (true) 
            {
                // Set the event to nonsignaled state.
                allDone.Reset();
                _server.BeginAccept(new AsyncCallback(OnClientConnect), null);
                allDone.WaitOne();
            }
        }

        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                // Terminamos de aceptar la conexión del cliente
                // llamando a EndAccept lo que nos devuelve un socket
                // que representa al cliente conectado
                Socket workerSocket = _server.EndAccept(asyn);

                // Incrementamos el número de clientes conectados de una forma segura
                Interlocked.Increment(ref _clientCount);
                Interlocked.Increment(ref _connectedClients);

                Console.WriteLine($"Clientes conectados: {_connectedClients}");
                
                _workerSocketList.Add(workerSocket);

                // Enviamos confirmación de conexión al cliente
                string msg = $"Connection success, {_clientCount}";
                SendMsgToClient(msg, _clientCount);

                // llamamos al método WaitForData para comenzar
                // a recibir datos del cliente que se acaba de conectar
                WaitForData(workerSocket, _clientCount);

                // En este punto el socket principal ya esta disponible para
                // recibir nuevas solicitudes de conexión
                // Nuevamente invocamos al método BeginAccept para aceptar 
                // Nuevas conexión y el siclo se repite
                _server.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                
            }

        }
        public class SocketPacket
        {
            // Constructor which takes a Socket and a client number
            public SocketPacket(System.Net.Sockets.Socket socket, int clientNumber)
            {
                CurrentSocket = socket;
                ClientNumber = clientNumber;
            }
            public System.Net.Sockets.Socket CurrentSocket;
            public int ClientNumber;
            public byte[] DataBuffer = new byte[1024];
        }
        
        // Start waiting for data from the client
        public void WaitForData(System.Net.Sockets.Socket soc, int clientNumber)
        {
            //En este método preparamos al socket-cliente para recibir
            //datos y configuramos el método encargado de leer los 
            //datos cuando lleguen
            try
            {
                if (_workerCallBack == null)
                {
                    // Asignamos el método que se ejecutará cuando 
                    // el cliente envié datos
                    _workerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket(soc, clientNumber);

                soc.BeginReceive(theSocPkt.DataBuffer, 0,
                    theSocPkt.DataBuffer.Length,
                    SocketFlags.None,
                    _workerCallBack,
                    theSocPkt);
            }
            catch (SocketException se)
            {
               
            }
        }

        // Este método se ejecuta cuando llegan datos enviados por el cliente
        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            try
            {
                //Completamos la acción de recibir datos 
                //El método EndReceive nos devuelve el número total de bytes recibidos
                int receivedBytes = socketData.CurrentSocket.EndReceive(asyn);
                char[] chars = new char[receivedBytes + 1];
                //Convertimos los bytes a texto
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.DataBuffer,
                    0, receivedBytes, chars, 0);

                System.String messageReceived = new System.String(chars);
               
                ProcessMessage(socketData.ClientNumber, messageReceived);

                // Enviamos al cliente acuse de recibido
                string replyMsg = "OK";
                // Convert the reply to byte array
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(replyMsg);

                Socket workerSocket = (Socket)socketData.CurrentSocket;
                workerSocket.Send(byData);

                // Continue the waiting for data on the Socket
                WaitForData(socketData.CurrentSocket, socketData.ClientNumber);

            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket cerrado.\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for Connection reset by peer
                {
                    string msg = $"Cliente CN: {socketData.ClientNumber} desconectado.";

                    // Quitamos el socket de nuestra lista
                    _workerSocketList[socketData.ClientNumber - 1] = null;

                    //Acualizamos el número de clientes conectados.
                    Interlocked.Decrement(ref _connectedClients);

                    Console.WriteLine(msg);
                    Console.WriteLine($"Clientes conectados: {_connectedClients}");
                }
                else
                {
                    //MessageBox.Show(se.Message);
                }
            }
        }

        void SendMsgToClient(string msg, int clientNumber)
        {
            // Convertimos el mensaje en un arrego de bytes
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(msg);

            Socket workerSocket = (Socket)_workerSocketList[clientNumber - 1];
            workerSocket.Send(byData);
        }

        private void ProcessMessage(int clientNumber, string message)
        {
            string[] data = message.Split(new char[] { ':' });
            switch (data[0].ToLower().Trim())
            {
                case "error":
                    Console.WriteLine("{0}:[ERROR]>>>{1}<<<", clientNumber, data[1]);
                    break;
                case "init":
                    break;
                case "ok":
                    Console.WriteLine(data[1]);
                    break;
                default:
                    break;
            }
        }
    }
}
