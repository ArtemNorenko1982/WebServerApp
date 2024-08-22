using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Application.Interfaces;

namespace WebServer.Application.Services
{
    internal class ReadService : IReadService
    {
        public async Task<string> ReadDataAsync(Socket socket)
        => await Task.Factory.StartNew(() =>
            {
                var result = new StringBuilder();
                var buffer = new byte[1];
                while (socket.Receive(buffer) > 0)
                {
                    var symbol = (char)buffer[0];
                    if (symbol == '\n')
                        break;
                    if (symbol != '\r')
                        result.Append(symbol);
                }

                return result.ToString();
            });
    }
}
