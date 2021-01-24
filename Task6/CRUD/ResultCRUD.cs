using Databases;
using System;
using System.Collections.Generic;
using University;

namespace CRUD
{
    /// <summary>
    /// Result CRUD.
    /// </summary>
    public class ResultCRUD : ICRUD<Result>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        private Database database = Database.GetDatabase();

        /// <summary>
        /// Delete grade from the table.
        /// </summary>
        /// <param name="deleteData">Data for delete.</param>
        public void Delete(Result deleteData)
        {
            if (IsResultWasInTable(deleteData))
            {
                database.AddParameter("@Student", deleteData.Student)
                        .AddParameter("@Exam", deleteData.Exams)
                        .ExecuteNonQuery("delete from Grades where Student=@Student and Exam=@Exam");
            }
        }

        /// <summary>
        /// Add new data in the table.
        /// </summary>
        /// <param name="insertData">New data.</param>
        public void Insert(Result insertData)
        {
            try
            {
                if (!IsResultWasInTable(insertData))
                {
                    database.AddParameter("@Student", insertData.Student)
                            .AddParameter("@Exam", insertData.Exams)
                            .AddParameter("@Grade", insertData.Grade)
                            .ExecuteNonQuery("insert into Grades values(@Student,@Exam,@Grade)");
                }
            }
            catch
            {
                Console.WriteLine("Unable to add new data. The index exam or student may not exist");
            }
        }

        /// <summary>
        /// Select data from the table.
        /// </summary>
        /// <returns>Grades list.</returns>
        public List<Result> Select()
        {
            List<Result> sessions = database.ExecuteQuery<Result>("select Student,Exams,Grade from Grades");
            return sessions;
        }

        /// <summary>
        /// Updata data in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New data.</param>
        public void Update(int indexForUpdate, Result data)
        {
            try
            {
                if (!IsResultWasInTable(data))
                {
                    database.AddParameter("@Student", data.Student)
                            .AddParameter("@Exam", data.Exams)
                            .AddParameter("@Grade", data.Grade)
                            .ExecuteNonQuery("Update Grades set Student=@Student,Exam=@Exam, Grade=@Grade where id=@id");
                }
            }
            catch
            {
                Console.WriteLine("Unable to update new data. The index exam or student may not exist");
            }
        }

        /// <summary>
        /// Checking result in the table.
        /// </summary>
        /// <param name="data">Data for checking.</param>
        /// <returns>True if this data was in the table.</returns>
        private bool IsResultWasInTable(Result data)
        {
            List<Result> results = Select();
            bool isWas = false;

            foreach (var result in results)
            {
                if (result.Exams == data.Exams &&
                    result.Student == data.Student)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}
