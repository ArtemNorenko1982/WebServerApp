using System;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;

namespace WebServer.Application.Services
{
    internal class ErrorService : IErrorService
    {
        public async Task PostErrorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
