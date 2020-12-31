using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TaskException;

namespace Servers
{ 
    /// <summary>
    /// Server.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Network endpoint
        /// </summary>
        private readonly IPEndPoint _endPoint;

        /// <summary>
        /// Socket.
        /// </summary>
        private readonly Socket _socket;

        /// <summary>
        /// Event for processing message.
        /// </summary>
        internal event Action<Socket> ServerSideMessageProcessing;

        /// <summary>
        /// List with all message from clients.
        /// </summary>
        public List<string> ListWithMessages = new List<string>();

        /// <summary>
        /// List with clients.
        /// </summary>
        private readonly List<Socket> _listWithSockets = new List<Socket>();

        /// <summary>
        /// Create new server.
        /// </summary>
        /// <param name="ip">IP - address.</param>
        /// <param name="port">Number of port.</param>
        public Server(string ip, int port)
        {
            if (!IPAddress.TryParse(ip, out var ipAddress))
            {
                throw new NotValidIpException("Cannot parse this string to IP-address.", ip);
            }

            if (port < 0 || port > 65535)
            {
                throw new NotValidNumberOfPortException("Port number cannot be negative and cannot be more then 65535", port);
            }

            _endPoint = new IPEndPoint(ipAddress, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(_endPoint);
            _socket.Listen(10);
            ServerSideMessageProcessing += GetMessage;
        }

        /// <summary>
        /// Get message. 
        /// </summary>
        /// <param name="listener">Socket.</param>
        private void GetMessage(Socket listener)
        {
            string message = null;

            do
            {
                byte[] bytes = new byte[256];
                int size = listener.Receive(bytes);
                message = Encoding.UTF8.GetString(bytes, 0, size);
            } while (listener.Available > 0);

            if (!String.IsNullOrWhiteSpace(message))
            {
                ListWithMessages.Add(message.ToString());
                BroadCastSendMessage(listener, message);
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Send message all clients.
        /// </summary>
        /// <param name="socket">Socket.</param>
        /// <param name="message">Message for sending.</param>
        private void BroadCastSendMessage(Socket socket, string message)
        {
            for (var index = 0; index < _listWithSockets.Count; index++)
            {
                if (_listWithSockets[index] != socket)
                {
                    _listWithSockets[index].Send(Encoding.UTF8.GetBytes(message.ToString()));
                }
            }
        }

        /// <summary>
        /// Listen connected users.
        /// </summary>
        public void Listen()
        {
            try
            {
                while (true)
                {
                    Socket socket = _socket.Accept();
                    _listWithSockets.Add(socket);
                    Thread thread = new Thread(() => OnServerSideMessageProcessing(socket));
                    Thread.Sleep(100);
                    thread.Start();
                }
            }
            finally
            {
                CloseServer();
            }
        }

        /// <summary>
        /// Side message all users.
        /// </summary>
        /// <param name="socket">Socket.</param>
        protected virtual void OnServerSideMessageProcessing(Socket socket)
        {
            while (socket.Connected)
            {
                ServerSideMessageProcessing?.Invoke(socket);
            }
        }

        /// <summary>
        /// Close server.
        /// </summary>
        private void CloseServer()
        {
            _socket.Close();

            foreach (var socket in _listWithSockets)
            {
                socket.Close();
            }

            Environment.Exit(0);
        }
    }
}
