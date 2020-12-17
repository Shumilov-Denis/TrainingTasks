using System;
using System.Collections.Generic;
using System.Text;

namespace TaskException
{
    /// <summary>
    /// The exception thrown when the path is incorrectly specified.
    /// </summary>
    public class NotValidWayToFileException : Exception
    {
        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message error.</param>
        public NotValidWayToFileException(string message) : base(message)
        {
        }
    }
}
