using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebServerApp.Interfaces
{
    internal interface IWriteService
    {
        Task WriteDataAsync(Socket socket);
    }
}
