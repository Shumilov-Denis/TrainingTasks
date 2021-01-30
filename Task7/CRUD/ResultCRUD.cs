using Databases;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace CRUD
{
    class ResultCRUD : ICRUD<Result>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        DataContext database = new DataContext(Database.ConnectionString);

        public void Delete(Result deleteData)
        {
            Result resultForDelete = database.GetTable<Result>()
                                             .Where(result => result.Exams == deleteData.Exams &&
                                                                 result.Student == deleteData.Student)
                                             .First<Result>();
            if (resultForDelete != null)
            {
                database.GetTable<Result>().DeleteOnSubmit(resultForDelete);
                database.SubmitChanges();
            }
        }

        public void Insert(Result insertData)
        {
            database.GetTable<Result>().InsertOnSubmit(insertData);
            database.SubmitChanges();
        }

        public List<Result> Select()
        {
            List<Result> results = database.GetTable<Result>().ToList<Result>();
            return results;
        }

        public void Update(int indexForUpdate, Result data)
        {
            Result result = database.GetTable<Result>().Where(s => s.Exams == data.Exams && s.Student == data.Student).SingleOrDefault();
            if (result != null)
            {
                result.Exams = data.Exams;
                result.Grade = data.Grade;
                result.Student = data.Student;
                database.SubmitChanges();
            }
        }
    }
}
