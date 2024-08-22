using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServerApp.Interfaces;

namespace WebServerApp.Services
{
    internal class WriteService : IWriteService
    {
        public async Task WriteDataAsync(Socket socket)
        {
            throw new NotImplementedException();
        }
    }
}
