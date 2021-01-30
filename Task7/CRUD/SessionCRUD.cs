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
    /// <summary>
    /// Session CRUD.
    /// </summary>
    class SessionCRUD : ICRUD<Session>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        DataContext database = new DataContext(Database.ConnectionString);

        /// <summary>
        /// Delete session from the table.
        /// </summary>
        /// <param name="deleteData">Data for delete.</param>
        public void Delete(Session deleteData)
        {
            try
            {
                if (IsSessionWasInTable(deleteData))
                {
                    Session sessionForDelete = database.GetTable<Session>()
                                                       .Where(session => session.DateStart == deleteData.DateStart &&
                                                                          session.DateFinish == deleteData.DateFinish)
                                                       .First<Session>();
                    if (sessionForDelete != null)
                    {
                        database.GetTable<Session>().DeleteOnSubmit(sessionForDelete);
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
        /// Add new session in the table.
        /// </summary>
        /// <param name="insertData">Data for add.</param>
        public void Insert(Session insertData)
        {
            try
            {
                if (!IsSessionWasInTable(insertData))
                {
                    database.GetTable<Session>().InsertOnSubmit(insertData);
                    database.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Get all information about session from table.
        /// </summary>
        /// <returns>Sessions list.</returns>
        public List<Session> Select()
        {
            List<Session> sessions = new List<Session>();

            try
            {
                sessions = database.GetTable<Session>().ToList<Session>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return sessions;
        }

        /// <summary>
        /// Update date in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New data.</param>
        public void Update(int indexForUpdate, Session data)
        {
            try
            {
                if (!IsSessionWasInTable(data))
                {
                    Session session = database.GetTable<Session>().Where(s => s.Id == indexForUpdate).SingleOrDefault();
                    if (session != null)
                    {
                        session.DateStart = data.DateStart;
                        session.DateFinish = data.DateFinish;
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
        /// Checking session in the table.
        /// </summary>
        /// <param name="data">Data for checking.</param>
        /// <returns>True if this data was in the table.</returns>
        private bool IsSessionWasInTable(Session data)
        {
            List<Session> sessions = Select();
            bool isWas = false;

            foreach (var session in sessions)
            {
                if (session.DateStart == data.DateStart &&
                    session.DateFinish == data.DateFinish)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}
