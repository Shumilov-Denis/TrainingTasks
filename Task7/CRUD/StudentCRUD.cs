using Databases;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using University;

namespace CRUD
{
    /// <summary>
    /// Student CRUD.
    /// </summary>
    class StudentCRUD : ICRUD<Student>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        DataContext database = new DataContext(Database.ConnectionString);

        /// <summary>
        /// Delete student from Student's table.
        /// </summary>
        /// <param name="deleteData">Student for delete.</param>
        public void Delete(Student deleteData)
        {
            try
            {
                if (IsStudentWasInTable(deleteData))
                {
                    Student studentForDelete = database.GetTable<Student>()
                                                   .Where(student => student.Name == deleteData.Name &&
                                                                      student.Surname == deleteData.Surname &&
                                                                      student.DateBirth == deleteData.DateBirth &&
                                                                      student.StudentGroup == deleteData.StudentGroup)
                                                   .First<Student>();
                    if (studentForDelete != null)
                    {
                        database.GetTable<Student>().DeleteOnSubmit(studentForDelete);
                        database.SubmitChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Add new student in table.
        /// </summary>
        /// <param name="insertData">Student for add.</param>
        public void Insert(Student insertData)
        {
            try
            {
                if (!IsStudentWasInTable(insertData))
                {
                    database.GetTable<Student>().InsertOnSubmit(insertData);
                    database.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Select all student from table.
        /// </summary>
        /// <returns>Students list.</returns>
        public List<Student> Select()
        {
            List<Student> students = new List<Student>();

            try
            {
                students = database.GetTable<Student>().ToList<Student>();
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        /// <summary>
        /// Update data in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New students.</param>
        public void Update(int indexForUpdate, Student data)
        {
            try
            {
                if (!IsStudentWasInTable(data))
                {
                    Student student = database.GetTable<Student>().Where(s => s.Id == indexForUpdate).SingleOrDefault();
                    if (student != null)
                    {
                        student.Name = data.Name;
                        student.Surname = data.Surname;
                        student.DateBirth = data.DateBirth;
                        student.StudentGroup = data.StudentGroup;
                        student.Gender = data.Gender;
                        database.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Checking students in table.
        /// </summary>
        /// <param name="studentForAdd">Students for cheking.</param>
        /// <returns>True if this student in this table.</returns>
        private bool IsStudentWasInTable(Student studentForAdd)
        {
            List<Student> students = Select();
            bool isWas = false;

            foreach (var student in students)
            {
                if (student.Name == studentForAdd.Name &&
                    student.Surname == studentForAdd.Surname &&
                    student.DateBirth == studentForAdd.DateBirth &&
                    student.Gender == studentForAdd.Gender &&
                    student.StudentGroup == studentForAdd.StudentGroup)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}