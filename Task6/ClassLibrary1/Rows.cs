using CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using University;

namespace Excels
{
    /// <summary>
    /// Row in table.
    /// </summary>
    class Rows
    {
        /// <summary>
        /// Start session date.
        /// </summary>
        public DateTime StartSession { get; }

        /// <summary>
        /// Finish session date.
        /// </summary>
        public DateTime FinishSession { get; }

        /// <summary>
        /// Student's name.
        /// </summary>
        public string StudentsName { get; }

        /// <summary>
        /// Student's surname.
        /// </summary>
        public string StudentsSurname { get; }

        /// <summary>
        /// Student's date birth.
        /// </summary>
        public DateTime StudentsDateBirth { get; }

        /// <summary>
        /// Student's gender.
        /// </summary>
        public string StudentsGender { get; }

        /// <summary>
        /// Student's group.
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// Exam's title.
        /// </summary>
        public string ExamsTitle { get; }

        /// <summary>
        /// Exam's date.
        /// </summary>
        public DateTime ExamsDate { get; }

        /// <summary>
        /// Grade.
        /// </summary>
        public int Grade { get; }

        /// <summary>
        /// Create new row.
        /// </summary>
        /// <param name="student">Student.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        /// <param name="result">Result.</param>
        /// <param name="exam">Exam.</param>
        private Rows(Student student, Group group, Session session, Result result, Exam exam)
        {
            this.StartSession = session.DateStart;
            this.FinishSession = session.DateFinish;
            this.StudentsName = student.Name;
            this.StudentsSurname = student.Surname;
            this.StudentsGender = student.Gender;
            this.StudentsDateBirth = student.DateBirth;
            this.Group = group.GroupName;
            this.ExamsTitle = exam.Title;
            this.ExamsDate = exam.Date;
            this.Grade = result.Grade;
        }

        /// <summary>
        /// Get all rows with student.
        /// </summary>
        /// <returns>Rows list.</returns>
        public static List<Rows> GetRows()
        {
            List<Rows> rows = new List<Rows>();

            try
            {
                List<Student> students = new StudentCRUD().Select();
                List<Group> groups = new GroupCRUD().Select();
                List<Exam> exams = new ExamCRUD().Select();
                List<Session> sessions = new SessionCRUD().Select();
                List<Result> results = new ResultCRUD().Select();

                foreach (var result in results)
                {
                    var student = from t in students
                                  where t.Id == result.Student
                                  select t;

                    if (student.Count() == 1)
                    {
                        var group = from t in groups
                                    where t.Id == student.ElementAt(0).StudentGroup
                                    select t;

                        var exam = from t in exams
                                   where t.Id == result.Exams
                                   select t;

                        var session = from t in sessions
                                      where t.Id == exam.ElementAt(0).Session
                                      select t;

                        if (group.Count() == 1 &&
                            exam.Count() == 1 &&
                            group.ElementAt(0).Id == exam.ElementAt(0).Groups)
                        {
                            rows.Add(new Rows(student.ElementAt(0),
                                              group.ElementAt(0), session.ElementAt(0),
                                              result, exam.ElementAt(0)));
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Mistak");
            }

            return rows;
        }
    }
}