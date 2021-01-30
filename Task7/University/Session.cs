﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using TaskExceptions;

namespace University
{
    /// <summary>
    /// Session.
    /// </summary>
    [Table(Name = "Sessions")]
    public class Session : IUniversity
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Start date.
        /// </summary>
        [Column]
        public DateTime DateStart { get; set; }

        /// <summary>
        /// End date.
        /// </summary>
        [Column]
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

        /// <summary>
        /// Get id.
        /// </summary>
        /// <param name="list">List with sessions.</param>
        /// <returns>Id.</returns>
        public int GetId(List<Session> list)
        {
            int id = -1;

            foreach (var session in list)
            {
                if (this.DateStart == session.DateStart &&
                    this.DateFinish == session.DateFinish)
                {
                    id = session.Id;
                    break;
                }
            }

            return id;
        }
    }
}
