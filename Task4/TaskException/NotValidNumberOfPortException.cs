using System;

namespace TaskException
{
    /// <summary>
    /// Not valid number of port exception.
    /// </summary>
    public class NotValidNumberOfPortException : Exception
    {
        /// <summary>
        /// Port number.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="port">Port number.</param>
        public NotValidNumberOfPortException(string message, int port) : base(message)
        {
            this.Port = port;
        }
    }
}