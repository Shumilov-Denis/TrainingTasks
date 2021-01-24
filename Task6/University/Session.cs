using System;
using TaskExceptions;

namespace University
{
    /// <summary>
    /// Session.
    /// </summary>
    public class Session : IUniversity
    {
        public int Id { get; set; }

        /// <summary>
        /// Start date.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// End date.
        /// </summary>
        public DateTime DateFinish { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Session()
        {
        }

        /// <summary>
        /// Create new session.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>

        public Session(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new SessionException("End date can not be less then end date.", startDate, endDate);
            }

            this.DateStart = startDate;
            this.DateFinish = endDate;
        }
    }
}
