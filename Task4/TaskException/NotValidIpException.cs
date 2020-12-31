using System;

namespace TaskException
{
    /// <summary>
    /// Not valid IP.
    /// </summary>
    public class NotValidIpException : Exception
    {
        /// <summary>
        /// IP - address.
        /// </summary>
        public string Ip { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ip">IP - address.</param>
        public NotValidIpException(string message, string ip) : base(message)
        {
            this.Ip = ip;
        }
    }
}
