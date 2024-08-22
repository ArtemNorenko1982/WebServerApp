using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebServer.Application.Interfaces
{
    internal interface IWriteService
    {
        Task WriteDataAsync(Socket socket);
    }
}
