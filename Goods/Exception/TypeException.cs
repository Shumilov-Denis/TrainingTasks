using System;

namespace Exceptions
{
    /// <summary>
    /// Type exception.
    /// </summary>
    public class TypeException : Exception
    {
        /// <summary>
        /// The type that caused the exception.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message of error.</param>
        /// <param name="type">Type of error.</param>
        public TypeException(string message, Type type)
            : base(message)
        {
            this.Type = Type;
        }
    }
}