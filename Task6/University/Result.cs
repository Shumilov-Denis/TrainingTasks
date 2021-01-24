using System;

namespace University
{
    /// <summary>
    /// Exam results.
    /// </summary>
    public class Result : IUniversity
    {
        /// <summary>
        /// Student id.
        /// </summary>
        public int Student { get; set; }

        /// <summary>
        /// Exam id.
        /// </summary>
        public int Exams { get; set; }

        /// <summary>
        /// Grade.
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Create new exam grade.
        /// </summary>
        /// <param name="studentID">Student id.</param>
        /// <param name="examID">Exam id.</param>
        /// <param name="grade">Grade.</param>
        public Result(int studentID, int examID, int grade)
        {
            if (grade > 10 || grade <= 0)
            {
                throw new ArgumentException("Grade cannot be more then 10 or less then 1.");
            }

            this.Student = studentID;
            this.Exams = examID;
            this.Grade = grade;
        }
    }
}