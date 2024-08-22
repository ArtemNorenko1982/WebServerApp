using System;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;

namespace WebServer.Application.Services
{
    internal class LogService : ILogService
    {
        public async Task LogAsync(string data)
        {
            Console.WriteLine(data);
        }
    }
}
