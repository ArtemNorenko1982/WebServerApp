using System;
using System.Threading.Tasks;
using WebServerApp.Interfaces;

namespace WebServerApp.Services
{
    internal class ErrorService : IErrorService
    {
        public async Task PostErrorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
