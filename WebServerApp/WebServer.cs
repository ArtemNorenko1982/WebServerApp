using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServerApp
{
    internal class WebServer
    {
        private readonly Socket _server;
        private readonly ASCIIEncoding _encoding;
        private readonly string _rootDirectory;

        public WebServer(int port, string rootDirectory)
        {
            _encoding = new ASCIIEncoding();
            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _server.Bind(new IPEndPoint(IPAddress.Loopback, port));
            _rootDirectory = rootDirectory;
            Console.WriteLine($"server is running on {_server.LocalEndPoint}");
        }

        public void Start()
        {
            _server.Listen(10);
            for (;;)
            {
                var socket = _server.Accept();
                HandleActiveSession(socket);
            }
        }

        private void HandleActiveSession(Socket socket)
        {
            Console.WriteLine("\n*** incoming request ***");
            var socketMethod = ReadSocketData(socket);
            Console.WriteLine(socketMethod);

            string socketHeaders;

            do
            {
                socketHeaders = ReadSocketData(socket);
                if (!string.IsNullOrEmpty(socketHeaders))
                {
                    Console.WriteLine(socketHeaders);
                }
                
            } while (!string.IsNullOrEmpty(socketHeaders));

            WriteSocketData(socket, "HTTP/1.1 200 OK");
            WriteSocketData(socket, "");
            WriteSocketData(socket, "<html>");
            WriteSocketData(socket, "<head><title>Sample WebServer</title></head>");
            WriteSocketData(socket, "<body>");
            WriteSocketData(socket, $"Success {DateTime.Now}");
            WriteSocketData(socket, "</body>");

            socket.Close();
        }

        private string ReadSocketData(Socket socket)
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
        }

        private void WriteSocketData(Socket server, string data)
        {
            server.Send(_encoding.GetBytes(data));
            server.Send(_encoding.GetBytes("\r\n"));
        }
    }
}
