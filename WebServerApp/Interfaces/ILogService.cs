using System.Threading.Tasks;

namespace WebServer.Application.Interfaces
{
    internal interface ILogService
    {
        Task LogAsync(string data);
    }
}
