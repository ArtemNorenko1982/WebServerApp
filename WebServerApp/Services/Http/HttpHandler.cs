using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;
using WebServer.Application.Interfaces.Http;
using WebServer.Common;

namespace WebServer.Application.Services.Http
{
    internal class HttpHandler : IHttpHandler
    {
        private readonly IReadService _readService;
        private readonly IHandler _requestHandler;
        private readonly IHandler _responseHandler;
        private readonly ILogService _logService;

        public HttpHandler(ILogService logService)
        {
            _logService = logService;
            _readService = new ReadService();
            _requestHandler = new RequestHandler(_logService);
            _responseHandler = new ResponseHandler(_logService);
        }

        public async Task HandleAsync(Socket socket)
        {
            var socketMethod = DetermineSocketMethod(socket);
            await _logService.LogAsync($"\n*** incoming {socketMethod} request ***");
            
            await _requestHandler.ProceedAsync(socket);
            await _responseHandler.ProceedAsync(socket);
            socket.Close();
        }

        private async Task<string> DetermineSocketMethod(Socket socket) => 
            (await _readService.ReadDataAsync(socket))
            .Split(AppValues.WhiteSpace)[0];
    }
}
