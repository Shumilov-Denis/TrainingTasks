using Databases;
using System.Collections.Generic;
using University;

namespace CRUD
{
    /// <summary>
    /// Session CRUD.
    /// </summary>
    public class SessionCRUD : ICRUD<Session>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        private Database database = Database.GetDatabase();

        /// <summary>
        /// Delete session from the table.
        /// </summary>
        /// <param name="deleteData">Data for delete.</param>
        public void Delete(Session deleteData)
        {
            if (IsSessionWasInTable(deleteData))
            {
                database.AddParameter("@DateStart", deleteData.DateStart)
                        .AddParameter("@DateFinish", deleteData.DateFinish)
                        .ExecuteNonQuery("delete from Sessions where DateStart=@DateStart and DateFinish=@DateFinish");
            }
        }

        /// <summary>
        /// Add new session in the table.
        /// </summary>
        /// <param name="insertData">Data for add.</param>
        public void Insert(Session insertData)
        {
            if (!IsSessionWasInTable(insertData))
            {
                database.AddParameter("@DateStart", insertData.DateStart)
                        .AddParameter("@DateFinish", insertData.DateFinish)
                        .ExecuteNonQuery("insert into Sessions values(@DateStart,@DateFinish)");
            }
        }

        /// <summary>
        /// Get all information about session from table.
        /// </summary>
        /// <returns>Sessions list.</returns>
        public List<Session> Select()
        {
            List<Session> sessions = database.ExecuteQuery<Session>("select id, DateStart, DateFinish from Sessions");
            return sessions;
        }

        /// <summary>
        /// Update date in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New data.</param>
        public void Update(int indexForUpdate, Session data)
        {
            if (!IsSessionWasInTable(data))
            {
                database.AddParameter("@id", indexForUpdate)
                    .AddParameter("@DateStart", data.DateStart)
                    .AddParameter("@DateFinish", data.DateFinish)
                    .ExecuteNonQuery("Update Sessions set DateStart=@DateStart,DateFinish=@DateFinish where id=@id");
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