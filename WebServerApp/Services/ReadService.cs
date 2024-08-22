using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServerApp.Interfaces;

namespace WebServerApp.Services
{
    internal class ReadService : IReadService
    {
        public async Task ReadDataAsync(Socket socket)
        {
            throw new NotImplementedException();
        }
    }
}
