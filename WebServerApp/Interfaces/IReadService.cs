using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebServerApp.Interfaces
{
    internal interface IReadService
    {
        Task ReadDataAsync(Socket socket);
    }
}
