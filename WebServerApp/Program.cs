namespace WebServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(args[0], out int port);
            var rootDirectory = args[1];

            var server = new WebServer(port, rootDirectory);
            
            server.Start();
        }
    }
}
