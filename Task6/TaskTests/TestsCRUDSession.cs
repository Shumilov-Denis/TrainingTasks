using CRUD;
using Databases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using University;

namespace TaskTests
{
    [TestClass]
    public class TestsCRUDSession
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
        /// Test add data in session base.
        /// </summary>
        /// <param name="yearStart">Year start.</param>
        /// <param name="monthStart">Month start.</param>
        /// <param name="dayStart">Day start.</param>
        /// <param name="yearFinish">Year finish.</param>
        /// <param name="monthFinish">Month finish.</param>
        /// <param name="dayFinish">Day finish.</param>
        [DataTestMethod]
        [DataRow(2020, 12, 20, 2021, 1, 10)]
        [DataRow(2021, 1, 10, 2021, 2, 10)]
        public void TestAddDataInGroupBase(int yearStart, int monthStart, int dayStart, int yearFinish, int monthFinish, int dayFinish)
        {
            Session session = new Session(new DateTime(yearStart, monthStart, dayStart), new DateTime(yearFinish, monthFinish, dayFinish));
            int numberOfSessions = factory.SessionFactory().Select().Count;

            factory.SessionFactory().Insert(session);

            Assert.AreEqual(numberOfSessions + 1, factory.SessionFactory().Select().Count);
        }

        /// <summary>
        /// Test update session infoemation.
        /// </summary>
        /// <param name="oldYearStart">Old year start.</param>
        /// <param name="oldMonthStart">Old month start.</param>
        /// <param name="oldDayStart">Old day start.</param>
        /// <param name="oldYearFinish">Old year finish.</param>
        /// <param name="oldMonthFinish">Old month finish.</param>
        /// <param name="oldDayFinish">Old day finish.</param>
        /// <param name="yearStart">Year start.</param>
        /// <param name="monthStart">Month start.</param>
        /// <param name="dayStart">Day start.</param>
        /// <param name="yearFinish">Year finish.</param>
        /// <param name="monthFinish">Month finish.</param>
        /// <param name="dayFinish">Day finish.</param>
        [DataTestMethod]
        [DataRow(2020, 12, 20, 2021, 1, 10, 2021, 1, 1, 2021, 1, 10)]
        [DataRow(2021, 1, 10, 2021, 2, 10, 2021, 1, 10, 2021, 2, 20)]
        public void TestUpdateDataInGroupBase(int oldYearStart, int oldMonthStart, int oldDayStart, int oldYearFinish, int oldMonthFinish, int oldDayFinish,
                                              int yearStart, int monthStart, int dayStart, int yearFinish, int monthFinish, int dayFinish)
        {
            Session sessionNew = new Session(new DateTime(yearStart, monthStart, dayStart), new DateTime(yearFinish, monthFinish, dayFinish)); ;
            Session sessionOld = new Session(new DateTime(oldYearStart, oldMonthStart, oldDayStart), new DateTime(oldYearFinish, oldMonthFinish, oldDayFinish));

            List<Session> groups = factory.SessionFactory().Select();
            int id = sessionOld.GetId(groups);

            factory.SessionFactory().Update(id, sessionNew);
        }

        /// <summary>
        /// Test delete data from database.
        /// </summary>
        /// <param name="yearStart">Year start.</param>
        /// <param name="monthStart">Month start.</param>
        /// <param name="dayStart">Day start.</param>
        /// <param name="yearFinish">Year finish.</param>
        /// <param name="monthFinish">Month finish.</param>
        /// <param name="dayFinish">Day finish.</param>
        [DataTestMethod]
        [DataRow(2021, 1, 1, 2021, 1, 10)]
        [DataRow(2021, 1, 10, 2021, 2, 20)]
        public void TestZDeleteDataInStudentsBase(int yearStart, int monthStart, int dayStart, int yearFinish, int monthFinish, int dayFinish)
        {
            Session session = new Session(new DateTime(yearStart, monthStart, dayStart), new DateTime(yearFinish, monthFinish, dayFinish));
            int numberOfSession = factory.SessionFactory().Select().Count;

            factory.SessionFactory().Delete(session);

            Assert.AreEqual(numberOfSession - 1, factory.SessionFactory().Select().Count);
        }
    }
}
