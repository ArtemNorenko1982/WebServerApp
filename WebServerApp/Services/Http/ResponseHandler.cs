using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;
using WebServer.Application.Interfaces.Http;

namespace WebServer.Application.Services.Http
{
    internal class ResponseHandler(ILogService logService) : IHandler
    {
        private readonly ASCIIEncoding _encoding = new();

        public async Task ProceedAsync(Socket socket)
        {
            var result = new StringBuilder()
                .Append("HTTP/2.0 200 OK")
                .Append("\n")
                .Append("\n<html>")
                .Append("\n<head><title>Sample WebServer</title></head>")
                .Append("\n<body>")
                .Append($"\nSuccess {DateTime.Now}")
                .Append("\n</body>")
                .ToString();

            await socket.SendAsync(_encoding.GetBytes(result), SocketFlags.None);
            await logService.LogAsync(result);
        }
    }
}
