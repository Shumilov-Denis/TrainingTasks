using System;
using System.Collections.Generic;
using System.Text;

namespace TaskException
{
    /// <summary>
    /// An exception that occurs when it is impossible to repaint a given figure.
    /// </summary>
    public class CannotPaintingException : Exception
    {
        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message error.</param>
        public CannotPaintingException(string message) : base(message)
        {
        }
    }
}
