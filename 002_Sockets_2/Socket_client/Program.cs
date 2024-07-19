namespace Socket_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientService service = new ClientService();
            service.Start();
        }
    }
}
