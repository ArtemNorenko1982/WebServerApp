using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;

namespace WebWebServer.ApplicationServerApp.Services
{
    internal class WriteService : IWriteService
    {
        public async Task WriteDataAsync(Socket socket)
        {
            throw new NotImplementedException();
        }
    }
}
