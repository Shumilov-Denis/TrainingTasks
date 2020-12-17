using System;

namespace TaskException
{
    /// <summary>
    /// The exception that is thrown when a negative number hits the shape constructor.
    /// </summary>
    public class NegativeSizeException : Exception
    {
        /// <summary>
        /// Size value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Create new NegativeSizeException.
        /// </summary>
        /// <param name="value">Value of error.</param>
        /// <param name="message">Message of error.</param>
        public NegativeSizeException(double value, string message) : base(message)
        {
            this.Value = value;
        }
    }
}
