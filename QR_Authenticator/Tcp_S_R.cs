using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PC_Protected_App
{
    class Tcp_S_R
    {
        public string IP { get; set; } = "127.0.0.1";   //"192.168.100.3";
        public int Port { get; set; } = 8001;
        public Tcp_S_R() { }
        public Tcp_S_R(string ip) : this(ip, 8001) { }
        public Tcp_S_R(int port) : this("127.0.0.1", port) { }
        public Tcp_S_R(string ip, int port)
        {
            IP = ip;
            Port = port;
        }
        public void SendMessage(string message)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IP, Port);
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                socket.Send(buffer);
                socket.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ReceiveMessage()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Any, Port));
                socket.Listen(10);
                Socket client = socket.Accept();
                ///Устройство подключено. можно это показать
                byte[] buffer = new byte[2048];
                client.Receive(buffer);
                socket.Close();
                client.Close();
                string response = Encoding.UTF8.GetString(buffer);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
