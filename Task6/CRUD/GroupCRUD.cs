using System.Collections.Generic;
using University;
using Databases;

namespace CRUD
{
    /// <summary>
    /// CRUD for groups table.
    /// </summary>
    public class GroupCRUD : ICRUD<Group>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        private Database database = Database.GetDatabase();

        /// <summary>
        /// Delete group from database.
        /// </summary>
        /// <param name="deleteData">Group for delete.</param>
        public void Delete(Group deleteData)
        {
            if (IsGroupWasInTable(deleteData))
            {
                database.AddParameter("@GroupName", deleteData.GroupName)
                        .ExecuteNonQuery("delete from Groups where GroupName=@GroupName");
            }
        }

        /// <summary>
        /// Add new group in database.
        /// </summary>
        /// <param name="insertData">Group for add.</param>
        public void Insert(Group insertData)
        {
            if (!IsGroupWasInTable(insertData))
            {
                database.AddParameter("@GroupName", insertData.GroupName)
                        .ExecuteNonQuery("insert into Groups values(@GroupName)");
            }
        }

        /// <summary>
        /// Get all groups in list.
        /// </summary>
        /// <returns>List with groups.</returns>
        public List<Group> Select()
        {
            List<Group> groups = database.ExecuteQuery<Group>("select id,GroupName from Groups");
            return groups;
        }

        /// <summary>
        /// Update date in the table.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">New data.</param>
        public void Update(int indexForUpdate, Group data)
        {
            if (!IsGroupWasInTable(data))
            {
                database.AddParameter("@id", indexForUpdate)
                    .AddParameter("@GroupName", data.GroupName)
                    .ExecuteNonQuery("Update Groups set GroupName=@GroupName where id=@id");
            }
        }

        /// <summary>
        /// Checking group in table.
        /// </summary>
        /// <param name="data">Group for checking.</param>
        /// <returns>True if this group was in table.</returns>
        private bool IsGroupWasInTable(Group data)
        {
            List<Group> groups = Select();
            bool isWas = false;

            foreach (var group in groups)
            {
                if (group.GroupName == data.GroupName)
                {
                    isWas = true;
                    break;
                }
            }

            return isWas;
        }
    }
}
