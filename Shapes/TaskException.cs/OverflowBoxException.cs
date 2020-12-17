using System;
using System.Collections.Generic;
using System.Text;

namespace TaskException
{
    /// <summary>
    /// The exception that is thrown when a box is overflowed.
    /// </summary>
    public class OverflowBoxException : Exception
    {
        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message error.</param>
        public OverflowBoxException(string message) : base(message)
        {
        }
    }
}
