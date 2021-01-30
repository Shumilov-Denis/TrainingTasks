using CRUD;
using Databases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using University;

namespace TaskTests
{
    [TestClass]
    public class TestsCRUDExam
    {
        /// <summary>
        /// Connectiion string to database.
        /// </summary>
        static string connectionString = @"Data source=(localdb)\MSSQLLocalDB;Database=Task6;Integrated Security=true;";

        /// <summary>
        /// Database.
        /// </summary>
        Database databases = Database.GetDatabase(connectionString);

        /// <summary>
        /// Factory.
        /// </summary>
        CRUDFactory factory = new CRUDFactory();


        /// <summary>
        /// Test add data in group base.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        [DataTestMethod]
        [DataRow("History", 2021, 01, 18, 1, 2)]
        [DataRow("Economics", 2021, 01, 19, 2, 2)]
        [DataRow("Russian", 2021, 01, 20, 3, 2)]
        [DataRow("English", 2021, 01, 21, 1, 2)]
        public void TestAddDataInGroupBase(string title, int year, int month, int day, int group ,int session)
        {
            Exam exam = new Exam(title, new DateTime(year,month,day), group, session);
            int numberOfExams = factory.ExamFactory().Select().Count;

            factory.ExamFactory().Insert(exam);

            Assert.AreEqual(numberOfExams + 1, factory.ExamFactory().Select().Count);
        }

        /// <summary>
        /// Test update group infoemation.
        /// </summary>
        /// <param name="oldTitle">Old title.</param>
        /// <param name="oldYear">Old year.</param>
        /// <param name="oldMonth">Old month.</param>
        /// <param name="oldDay">Old day.</param>
        /// <param name="oldGroup">Old group.</param>
        /// <param name="oldSession">Old session.</param>
        /// <param name="title">Title.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        [DataTestMethod]
        [DataRow("History", 2021, 01, 18, 1, 2, "History", 2021, 01, 18, 3, 2)]
        [DataRow("Economics", 2021, 01, 19, 2, 2, "Economics", 2021, 01, 19, 1, 2)]
        [DataRow("Russian", 2021, 01, 20, 3, 2, "Russian", 2021, 01, 20, 2, 2)]
        [DataRow("English", 2021, 01, 21, 1, 2, "English", 2021, 01, 21, 3, 2)]
        public void TestUpdateDataInGroupBase(string oldTitle, int oldYear, int oldMonth, int oldDay, int oldGroup, int oldSession,
                                              string title, int year, int month, int day, int group, int session)
        {
            Exam examNew = new Exam(title, new DateTime(year, month, day), group, session);
            Exam examOld = new Exam(oldTitle, new DateTime(oldYear, oldMonth, oldDay), oldGroup, oldSession);

            List<Exam> exams = factory.ExamFactory().Select();
            int id = examOld.GetId(exams);

            factory.ExamFactory().Update(id, examNew);
        }

        /// <summary>
        /// Test delete data from database.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="group">Group.</param>
        /// <param name="session">Session.</param>
        [DataTestMethod]
        [DataRow("History", 2021, 01, 18, 3, 2)]
        [DataRow("Economics", 2021, 01, 19, 1, 2)]
        [DataRow("Russian", 2021, 01, 20, 2, 2)]
        [DataRow("English", 2021, 01, 21, 3, 2)]
        public void TestZDeleteDataInStudentsBase(string title, int year, int month, int day, int group, int session)
        {
            Exam exam = new Exam(title, new DateTime(year, month, day), group, session);
            int numberOfExam = factory.ExamFactory().Select().Count;

            factory.ExamFactory().Delete(exam);

            Assert.AreEqual(numberOfExam - 1, factory.ExamFactory().Select().Count);
        }
    }
}
