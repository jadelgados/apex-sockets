

using System.Net.Sockets;

namespace _003_Sockets
{
    public class SocketData
    {
        // Constructor which takes a Socket and a client number
        public SocketData(Socket socket, int clientNumber)
        {
            CurrentSocket = socket;
            ClientNumber = clientNumber;
        }
        public Socket CurrentSocket;
        public int ClientNumber;
        public byte[] DataBuffer = new byte[10];
    }
}
