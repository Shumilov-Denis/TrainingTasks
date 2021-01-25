using System;
using System.Collections.Generic;

namespace University
{
    /// <summary>
    /// Exam.
    /// </summary>
    public class Exam : IUniversity
    {
        /// <summary>
        /// Exam id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Exam's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Group.
        /// </summary>
        public int Groups { get; set; }

        /// <summary>
        /// Session.
        /// </summary>
        public int Session { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Exam()
        {
        }

        /// <summary>
        /// Create new exam.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="date">Date.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        public Exam(string title, DateTime date, int group, int session)
        {
            this.Title = title;
            this.Date = date;
            this.Groups = group;
            this.Session = session;
        }

        /// <summary>
        /// Get id.
        /// </summary>
        /// <param name="list">List with exams.</param>
        /// <returns>Id.</returns>
        public int GetId(List<Exam> list)
        {
            int id = -1;

            foreach (var exam in list)
            {
                if (this.Title == exam.Title &&
                    this.Date == exam.Date &&
                    this.Session == exam.Session &&
                    this.Groups == exam.Groups)
                {
                    id = exam.Id;
                    break;
                }
            }

            return id;
        }
    }
}