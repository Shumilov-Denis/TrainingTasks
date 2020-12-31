using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using StringProcessing;
using TaskException;

namespace Servers
{
    /// <summary>
    /// Client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// IP-address.
        /// </summary>
        private readonly IPAddress _ip;

        /// <summary>
        /// Name of client.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of port.
        /// </summary>
        private readonly int _port;

        /// <summary>
        /// Network endpoint
        /// </summary>
        private readonly IPEndPoint _endPoint;

        /// <summary>
        /// Socket.
        /// </summary>
        private readonly Socket _socket;

        /// <summary>
        /// Delegate for messages processing.
        /// </summary>
        /// <param name="messages">Message for processing.</param>
        internal delegate void Messages(string messages);

        /// <summary>
        /// Event with start, when we send message.
        /// </summary>
        internal event Messages MakeMessages;

        /// <summary>
        /// Create new client.
        /// </summary>
        /// <param name="ip">IP for connecting.</param>
        /// <param name="port">Port for connecting.</param>
        /// <param name="name">Client name.</param>
        public Client(string ip, int port, string name)
        {
            if (!IPAddress.TryParse(ip, out this._ip))
            {
                throw new NotValidIpException("Cannot parse this string to IP-address.", ip);
            }

            if (port < 0 || port > 65535)
            {
                throw  new NotValidNumberOfPortException("Port number cannot be negative and cannot be more then 65535", port);
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("Name cannot be null.");
            }

            this.Name = name;
            this._port = port;
            _endPoint = new IPEndPoint(_ip, _port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MakeMessages += SendMessage;
            _socket.Connect(_endPoint);
            Thread thread = new Thread(GetMessage);
            thread.Start();
        }

        /// <summary>
        /// Method for check message from user.
        /// </summary>
        /// <param name="message">Message for sending.</param>
        public void TrySendMessage(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                MakeMessages?.Invoke(message);
            }
        }

        private void GetMessage()
        {
            while (true)
            {
                string message = null;

                do
                {
                    byte[] bytes = new byte[256];
                    int size = _socket.Receive(bytes);
                    message = Encoding.UTF8.GetString(bytes, 0, size);
                } while (_socket.Available > 0);

                if (!String.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message);
                }
            }
        }

        /// <summary>
        /// Method for send method.
        /// </summary>
        /// <param name="message">Message for sending.</param>
        private void SendMessage(string message)
        {
            message = Name + ": " + message;
            message = message.TransliterationMessages();
            byte[] bytes = Encoding.UTF8.GetBytes(message.ToString());
            _socket.Send(bytes);
        }
    }
}
