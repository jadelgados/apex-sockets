

namespace _001_Sockets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.ReadLine();
        }
    }
}
