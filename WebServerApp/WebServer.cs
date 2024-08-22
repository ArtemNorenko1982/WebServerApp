using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;
using WebServer.Application.Interfaces.Http;
using WebServer.Application.Services;
using WebServer.Application.Services.Http;

namespace WebServer.Application
{
    internal class WebServer
    {
        private readonly Socket _server;
        private readonly IHttpHandler _httpHandler;

        public WebServer(int port, string rootDirectory)
        {
            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _server.Bind(new IPEndPoint(IPAddress.Loopback, port));
            
            ILogService logService = new LogService();
            _httpHandler = new HttpHandler(logService);
            logService.LogAsync($"Server is running on {_server.LocalEndPoint}");
            logService.LogAsync("To terminate the execution press \"ENTER\"");
        }

        public async Task StartAsync()
        {
            _server.Listen(10);
            for (;;)
            {
                var socket = await _server.AcceptAsync();
                await _httpHandler.HandleAsync(socket);
            }
        }
    }
}
