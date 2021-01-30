using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace University
{
    /// <summary>
    /// Exam.
    /// </summary>
    [Table(Name = "Exams")]
    public class Exam : IUniversity
    {
        /// <summary>
        /// Exam id.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Exam's title.
        /// </summary>
        [Column]
        public string Title { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        [Column]
        public DateTime Date { get; set; }

        /// <summary>
        /// Group.
        /// </summary>
        [Column]
        public int Groups { get; set; }

        /// <summary>
        /// Session.
        /// </summary>
        [Column]
        public int Session { get; set; }

        /// <summary>
        /// Examener.
        /// </summary>
        [Column]
        public string Examiner { get; set; }

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
        /// Create new exam.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="date">Date.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        /// <param name="examiner">Examener.</param>
        public Exam(string title, DateTime date, int group, int session, string examiner) : this (title, date, group, session)
        {
            this.Examiner = examiner;
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