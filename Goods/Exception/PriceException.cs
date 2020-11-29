using System;

namespace Exceptions
{
    /// <summary>
    /// Price exception.
    /// </summary>
    public class PriceException : Exception
    {
        /// <summary>
        /// Value of price.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message of error.</param>
        /// <param name="value">Value of error.</param>
        public PriceException(string message, double value)
            : base(message)
        {
            this.Value = value;
        }

    }
}