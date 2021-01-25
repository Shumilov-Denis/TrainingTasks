using System;
using System.Collections.Generic;
using University;
using Databases;

namespace CRUD
{
    /// <summary>
    /// Student CRUD.
    /// </summary>
    internal class StudentCRUD : ICRUD<Student>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        private Database database = Database.GetDatabase();

        /// <summary>
        /// Delet student from Student's table.
        /// </summary>
        /// <param name="deleteData">Student for delete.</param>
        public void Delete(Student deleteData)
        {
            if (IsStudentWasInTable(deleteData))
            {
                database.AddParameter("@Name", deleteData.Name)
                        .AddParameter("@Surname", deleteData.Surname)
                        .AddParameter("@DateBirth", deleteData.DateBirth)
                        .AddParameter("@Gender", deleteData.Gender)
                        .AddParameter("@StudentGroup", deleteData.StudentGroup)
                        .ExecuteNonQuery("delete from Students where Name=@Name");
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
                    database.AddParameter("@Name", insertData.Name)
                            .AddParameter("@Surname", insertData.Surname)
                            .AddParameter("@DateBirth", insertData.DateBirth)
                            .AddParameter("@Gender", insertData.Gender)
                            .AddParameter("@StudentGroup", insertData.StudentGroup)
                            .ExecuteNonQuery("insert into Students values (@Name,@Surname,@DateBirth,@Gender,@StudentGroup)");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to add new data. The index group may not exist. " + ex.ToString());
            }
        }

        /// <summary>
        /// Select all student from table.
        /// </summary>
        /// <returns>Students list.</returns>
        public List<Student> Select()
        {
            List<Student> students = database.ExecuteQuery<Student>("select id, Name, Surname, DateBirth, Gender, StudentGroup from Students");
            return students;
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
                    database.AddParameter("@id", indexForUpdate)
                            .AddParameter("@Name", data.Name)
                            .AddParameter("@Surname", data.Surname)
                            .AddParameter("@DateBirth", data.DateBirth)
                            .AddParameter("@Gender", data.Gender)
                            .AddParameter("@StudentGroup", data.StudentGroup)
                            .ExecuteNonQuery("Update Students set Name=@Name,Surname=@Surname,DateBirth=@DateBirth,Gender=@Gender,StudentGroup=@StudentGroup where id=@id");
                }
            }
            catch
            {
                Console.WriteLine("Unable to update new data. The index group may not exist");
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
                    student.Gender == studentForAdd.Gender)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}
