using System;
using System.Collections.Generic;
using System.Text;

namespace TaskExceptions
{
    /// <summary>
    /// This exception will be if date start session be more then date end session.
    /// </summary>
    public class SessionException : Exception
    {
        /// <summary>
        /// Start date.
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// End date.
        /// </summary>
        public DateTime EndDate { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        public SessionException(string message, DateTime startDate, DateTime endDate) : base(message)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}
