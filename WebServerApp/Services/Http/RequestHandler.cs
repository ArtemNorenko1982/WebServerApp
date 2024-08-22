using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;
using WebServer.Application.Interfaces.Http;

namespace WebServer.Application.Services.Http
{
    internal class RequestHandler(ILogService logService) : IHandler
    {
        public async Task ProceedAsync(Socket socket)
        {
            //string socketHeaders;
            //do
            //{
            //    socketHeaders = ReadSocketData(socket);
            //    if (!string.IsNullOrEmpty(socketHeaders))
            //    {
            //        await _logService.LogAsync(socketHeaders);
            //    }

            //} while (!string.IsNullOrEmpty(socketHeaders));
            await logService.LogAsync("Request was successfully proceeded.");
        }
    }
}
