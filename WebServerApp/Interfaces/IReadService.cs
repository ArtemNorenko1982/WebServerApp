using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebServer.Application.Interfaces
{
    internal interface IReadService
    {
        Task<string> ReadDataAsync(Socket socket);
    }
}
