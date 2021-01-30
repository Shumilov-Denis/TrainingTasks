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
    class ExamCRUD : ICRUD<Exam>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        DataContext database = new DataContext(Database.ConnectionString);

        public void Delete(Exam deleteData)
        {
            Exam examForDelete = database.GetTable<Exam>()
                                         .Where(exam => exam.Title == deleteData.Title &&
                                                        exam.Groups == deleteData.Groups &&
                                                        exam.Date == deleteData.Date)
                                         .First<Exam>();
            if (examForDelete != null)
            {
                database.GetTable<Exam>().DeleteOnSubmit(examForDelete);
                database.SubmitChanges();
            }
        }

        public void Insert(Exam insertData)
        {
            database.GetTable<Exam>().InsertOnSubmit(insertData);
            database.SubmitChanges();
        }

        public List<Exam> Select()
        {
            List<Exam> exams = database.GetTable<Exam>().ToList<Exam>();
            return exams;
        }

        public void Update(int indexForUpdate, Exam data)
        {
            Exam exam = database.GetTable<Exam>().Where(s => s.Id == indexForUpdate).SingleOrDefault();
            if (exam != null)
            {
                exam.Date = data.Date;
                exam.Groups = data.Groups;
                exam.Session = data.Session;
                exam.Title = data.Title;
                exam.Examiner = data.Examiner;
                database.SubmitChanges();
            }
        }
    }
}
