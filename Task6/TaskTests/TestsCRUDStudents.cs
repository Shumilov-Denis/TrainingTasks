using Databases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using University;
using CRUD;
using System;
using System.Collections.Generic;

namespace TaskTests
{
    /// <summary>
    /// Test CRUD student.
    /// </summary>
    [TestClass]
    public class TestsCRUDStudents
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
        /// Test add data in student table.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="group">Group.</param>
        [DataTestMethod]
        [DataRow("Ivan", "Ivanov", 2001, 01, 01, "Man", 1)]
        [DataRow("Egor", "Egorov", 2002, 02, 02, "Man", 2)]
        [DataRow("Pety", "Petrov", 2003, 03, 03, "Man", 3)]
        [DataRow("Sergey", "Sergeev", 2004, 04, 04, "Man", 1)]
        [DataRow("Denis", "Denisov", 2005, 05, 05, "Man", 2)]
        public void TestAddDataInStudentsBase(string name, string surname, int year,
                                              int month, int day, string gender, int group)
        {
            Student student = new Student(name, surname, new DateTime(year, month, day), gender, group);
            int numberOfStudent = factory.StudentFactory().Select().Count;

            factory.StudentFactory().Insert(student);

            Assert.AreEqual(numberOfStudent + 1, factory.StudentFactory().Select().Count);
        }

        /// <summary>
        /// Test update date in student's table.
        /// </summary>
        /// <param name="oldName">Old name.</param>
        /// <param name="oldSurname">Old surname.</param>
        /// <param name="oldYear">Old year.</param>
        /// <param name="oldMonth">Old month.</param>
        /// <param name="oldDay">Old day.</param>
        /// <param name="oldGender">Old gender.</param>
        /// <param name="oldGroup">Old group.</param>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="group">Group.</param>
        [DataTestMethod]
        [DataRow("Ivan", "Ivanov", 2001, 01, 01, "Man", 1, "Ivan", "Ivanov", 2001, 01, 01, "Man",2)]
        [DataRow("Egor", "Egorov", 2002, 02, 02, "Man", 2, "Egor", "Kurchenok", 2002, 02, 02, "Man", 1)]
        [DataRow("Pety", "Petrov", 2003, 03, 03, "Man", 3, "Petia", "Petrov", 2003, 03, 03, "Man", 1)]
        [DataRow("Sergey", "Sergeev", 2004, 04, 04, "Man", 1, "Sergey", "Sergeev", 2003, 04, 04, "Man", 1)]
        [DataRow("Denis", "Denisov", 2005, 05, 05, "Man", 2, "Denis", "Denisov", 2002, 05, 05, "Man", 2)]
        public void TestUpdateDataInStudentsBase(string oldName, string oldSurname, int oldYear,
                                                 int oldMonth, int oldDay, string oldGender, int oldGroup,
                                                 string name, string surname, int year,
                                                 int month, int day, string gender, int group)
        {
            Student studentNew = new Student(name, surname, new DateTime(year, month, day), gender, group);
            Student studentOld = new Student(oldName, oldSurname, new DateTime(oldYear, oldMonth, oldDay), oldGender, oldGroup);

            List<Student> students = factory.StudentFactory().Select();
            int id = studentOld.GetId(students);

            factory.StudentFactory().Update(id, studentNew);
        }

        /// <summary>
        /// Test delete data from table.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="group">Group.</param>
        [DataTestMethod]
        [DataRow("Ivan", "Ivanov", 2001, 01, 01, "Man", 2)]
        [DataRow("Egor", "Kurchenok", 2002, 02, 02, "Man", 1)]
        [DataRow("Petia", "Petrov", 2003, 03, 03, "Man", 1)]
        [DataRow("Sergey", "Sergeev", 2003, 04, 04, "Man", 1)]
        [DataRow("Denis", "Denisov", 2002, 05, 05, "Man", 2)]
        public void TestZDeleteDataInStudentsBase(string name, string surname, int year,
                                                 int month, int day, string gender, int group)
        {
            Student student = new Student(name, surname, new DateTime(year, month, day), gender, group);
            int numberOfStudent = factory.StudentFactory().Select().Count;

            factory.StudentFactory().Delete(student);

            Assert.AreEqual(numberOfStudent - 1, factory.StudentFactory().Select().Count);
        }
    }
}
