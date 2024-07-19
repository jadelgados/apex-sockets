

using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Socket_client
{
    public class ClientService
    {
        private readonly string _host;
        private readonly int _port;
        Socket _sender;
        public ClientService(string host, string port)
        {
            _host = host;
            _port = Convert.ToInt32(port);
        }

        public void Connect()
        {
            // Dirección IP del servidor y puerto
            IPAddress ipAddress = IPAddress.Parse(_host);

            // Crear un socket TCP/IP
            _sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Conectar al servidor
            _sender.Connect(new IPEndPoint(ipAddress, _port));

            ReceiveData();
        }

        public void Stop()
        {
            _sender.Shutdown(SocketShutdown.Both);
            _sender.Close();
        }

        public void SendDataToServer(string message)
        {
            // Convertir mensaje en arreglo be bytes
            byte[] msg = Encoding.ASCII.GetBytes(message);

            //Enviar datos al servidor
            int bytesSent = _sender.Send(msg);
        }

        private void ReceiveData()
        {
            // Buffer para almacenar la respuesta del servidor
            byte[] bytes = new byte[1024];
            int bytesRec = _sender.Receive(bytes);
            string response = $"<< {Encoding.Default.GetString(bytes, 0, bytesRec)}";
            Console.WriteLine(response);
        }
    }
}
