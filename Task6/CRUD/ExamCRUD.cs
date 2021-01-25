using Databases;
using System;
using System.Collections.Generic;
using University;

namespace CRUD
{
    /// <summary>
    /// Exam CRUD.
    /// </summary>
    internal class ExamCRUD : ICRUD<Exam>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        private Database database = Database.GetDatabase();

        /// <summary>
        /// Delete exam from the table.
        /// </summary>
        /// <param name="deleteData">Exam for delete.</param>
        public void Delete(Exam deleteData)
        {
            if (IsExamWasInTable(deleteData))
            {
                database.AddParameter("@Title", deleteData.Title)
                        .AddParameter("@Date", deleteData.Date)
                        .AddParameter("@Groups", deleteData.Groups)
                        .AddParameter("@Session", deleteData.Session)
                        .ExecuteNonQuery("delete from Exams where Title=@Title and Date=@Date  and Groups=@Groups and Session=@Session");
            }
        }

        /// <summary>
        /// Add new exam on the table.
        /// </summary>
        /// <param name="insertData">Data for add.</param>
        public void Insert(Exam insertData)
        {
            try
            {
                if (!IsExamWasInTable(insertData))
                {
                    database.AddParameter("@Title", insertData.Title)
                            .AddParameter("@Date", insertData.Date)
                            .AddParameter("@Groups", insertData.Groups)
                            .AddParameter("@Session", insertData.Session)
                            .ExecuteNonQuery("insert into Exams values(@Title,@Date,@Groups,@Session)");
                }
            }
            catch
            {
                Console.WriteLine("Unable to add new data. The index group or session may not exist");
            }
        }

        /// <summary>
        /// Select an exam from the table.
        /// </summary>
        /// <returns>Exams list.</returns>
        public List<Exam> Select()
        {
            List<Exam> exams = database.ExecuteQuery<Exam>("select id,Title,Session,Groups,Date from Exams");
            return exams;
        }

        /// <summary>
        /// Update data in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New data.</param>
        public void Update(int indexForUpdate, Exam data)
        {
            try
            {
                if (!IsExamWasInTable(data))
                {
                    database.AddParameter("@id", indexForUpdate)
                            .AddParameter("@Title", data.Title)
                            .AddParameter("@Date", data.Date)
                            .AddParameter("@Groups", data.Groups)
                            .AddParameter("@Session", data.Session)
                            .ExecuteNonQuery("Update Exams set Title=@Title,Date=@Date,Groups=@Groups,Session=@Session where id=@id");
                }
            }
            catch
            {
                Console.WriteLine("Unable to update new data. The index group or session may not exist");
            }
        }

        /// <summary>
        /// Checking exam in table.
        /// </summary>
        /// <param name="data">Exam for checking.</param>
        /// <returns>True if this exam was in table.</returns>
        private bool IsExamWasInTable(Exam data)
        {
            List<Exam> exams = Select();
            bool isWas = false;

            foreach (var exam in exams)
            {
                if (exam.Date == data.Date &&
                    exam.Groups == data.Groups &&
                    exam.Session == data.Session &&
                    exam.Title == data.Title)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}
