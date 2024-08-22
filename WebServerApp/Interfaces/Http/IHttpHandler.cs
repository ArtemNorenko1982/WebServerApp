using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebServer.Application.Interfaces.Http
{
    internal interface IHttpHandler
    {
        Task HandleAsync(Socket socket);
    }
}
