

using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Socket_client
{
    public class ClientService
    {
        Socket _sender;
        public ClientService()
        {
            // Dirección IP del servidor y puerto
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 11000;

            // Crear un socket TCP/IP
            _sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Conectar al servidor
            _sender.Connect(new IPEndPoint(ipAddress, port));
            Console.WriteLine("Conectado al servidor");
        }
        public void Start()
        {
            try
            {
                string strMessage;
                while (true) 
                {
                    strMessage = Console.ReadLine();
                    // Datos a enviar al servidor
                    byte[] msg = Encoding.ASCII.GetBytes(strMessage ?? ".");

                    // Enviar datos al servidor
                    int bytesSent = _sender.Send(msg);

                    // Buffer para almacenar la respuesta del servidor
                    byte[] bytes = new byte[1024];
                    int bytesRec = _sender.Receive(bytes);
                    Console.WriteLine("Respuesta del servidor: {0}", Encoding.Default.GetString(bytes, 0, bytesRec));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
