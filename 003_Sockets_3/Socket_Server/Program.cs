
namespace _003_Sockets
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
