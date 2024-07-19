

using System.Net.Sockets;
using System.Net;
using System.Text;

namespace _001_Sockets
{
    internal class Server
    {
        Socket _server;
        public Server()
        {
            // Dirección IP del servidor y puerto
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 11000;

            // Crear un socket TCP/IP
            _server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Enlazar el socket al puerto y comenzar a escuchar
            _server.Bind(new IPEndPoint(ipAddress, port));
            _server.Listen();

        }
        public void Start()
        {
            try 
            {
                Console.WriteLine("Servidor iniciado.\n\rEsperando una conexión...");
                Socket client = _server.Accept();

                // Buffer para almacenar datos recibidos
                byte[] bytes = new byte[1024];
                int bytesRec = client.Receive(bytes);

                // Convertir los bytes recibidos en una cadena
                string messageReceived = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Mensaje recibido: {0}", messageReceived);

                // Responder al cliente
                byte[] msg = Encoding.Default.GetBytes("Recibí tu mensaje.");
                client.Send(msg);

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            } 
            catch 
            { 
            }
        }
    }
}
