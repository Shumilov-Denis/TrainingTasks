using System;

namespace TaskException
{
    /// <summary>
    /// The exception that is thrown when it is impossible to add a shape to a box.
    /// </summary>
    public class CannotAddFigureInBoxException : Exception
    {
        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message error.</param>
        public CannotAddFigureInBoxException(string message) : base(message)
        {
        }
    }
}