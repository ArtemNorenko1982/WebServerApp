using System;
using System.Threading.Tasks;

namespace WebServer.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(args[0], out int port);
            var rootDirectory = args[1];

            var server = new WebServer(port, rootDirectory);

            Task.Factory.StartNew(() => server.StartAsync());
            Console.ReadLine();
        }
    }
}
