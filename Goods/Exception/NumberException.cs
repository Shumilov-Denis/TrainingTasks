using System;

namespace Exceptions
{
    /// <summary>
    /// Number exceptions.
    /// </summary>
    public class NumberException : Exception
    {
        /// <summary>
        /// Value of number.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message of error.</param>
        /// <param name="value">Value of error.</param>
        public NumberException(string message, int value)
            : base(message)
        {
            this.Value = value;
        }
    }
}