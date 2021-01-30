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
    class GroupCRUD : ICRUD<Group>
    {
        /// <summary>
        /// Datebase.
        /// </summary>
        DataContext database = new DataContext(Database.ConnectionString);

        public void Delete(Group deleteData)
        {
            Group groupForDelete = database.GetTable<Group>()
                                           .Where(group => group.GroupName == deleteData.GroupName)
                                           .First<Group>();
            if (groupForDelete != null)
            {
                database.GetTable<Group>().DeleteOnSubmit(groupForDelete);
                database.SubmitChanges();
            }
        }

        public void Insert(Group insertData)
        {
            database.GetTable<Group>().InsertOnSubmit(insertData);
            database.SubmitChanges();
        }

        public List<Group> Select()
        {
            List<Group> groups = database.GetTable<Group>().ToList<Group>();
            return groups;
        }

        public void Update(int indexForUpdate, Group data)
        {
            Group group = database.GetTable<Group>().Where(s => s.Id == indexForUpdate).SingleOrDefault();
            if (group != null)
            {
                group.GroupName = data.GroupName;
                group.Specialty = data.Specialty;
                database.SubmitChanges();
            }
        }
    }
}
