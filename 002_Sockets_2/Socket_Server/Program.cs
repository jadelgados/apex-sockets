using System.Net.Sockets;
using System.Net;
using System.Text;

namespace _001_Sockets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
