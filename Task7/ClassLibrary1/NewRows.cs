using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace Excels 
{
    /// <summary>
    /// NNew padded row.
    /// </summary>
    internal class NewRows : Rows
    {
        /// <summary>
        /// Specialty.
        /// </summary>
        public string Specialty { get; }
        
        /// <summary>
        /// Examiner.
        /// </summary>
        public string Examiner { get; }

        /// <summary>
        /// Create new row.
        /// </summary>
        /// <param name="student">Student.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        /// <param name="result">Result.</param>
        /// <param name="exam">Exam.</param>
        private NewRows(Student student, Group group, Session session, Result result, Exam exam) : base(student, group, session, result, exam)
        {
            this.Specialty = group.Specialty;
            this.Examiner = exam.Examiner;
        }
    }
}
