using System;

namespace Students
{
    /// <summary>
    /// Student.
    /// </summary>
    /// <typeparam name="TResult">Test result type.</typeparam>
    public class Student<TResult> where TResult : IComparable<TResult>
    {
        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Test title.
        /// </summary>
        public string TitleOfTest { get; }

        /// <summary>
        /// Date passed.
        /// </summary>
        public DateTime DatePassed { get; }

        /// <summary>
        /// Test result.
        /// </summary>
        public TResult TestResults { get; set; }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        private Student()
        {
        }

        /// <summary>
        /// Create new student.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="titleOfTest">Test title.</param>
        /// <param name="datePassed">Date passed.</param>
        /// <param name="testResults">Test result.</param>
        public Student(string name, string titleOfTest, DateTime datePassed, TResult testResults)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(titleOfTest))
            {
                throw new ArgumentException("Name of student or title of test cannot be null.");
            }

            this.Name = name;
            this.TitleOfTest = titleOfTest;
            this.DatePassed = datePassed;
            this.TestResults = testResults;
        }

        /// <summary>
        /// Information about student.
        /// </summary>
        /// <returns>Information about student.</returns>
        public override string ToString()
        {
            return $"{TestResults}";
        }
    }
}
