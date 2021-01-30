using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace University
{
    /// <summary>
    /// Group of student.
    /// </summary>
    [Table(Name = "Groups")]
    public class Group : IUniversity
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Group name.
        /// </summary>
        [Column]
        public string GroupName { get; set; }

        /// <summary>
        /// Specialty.
        /// </summary>
        [Column]
        public string Specialty { get; set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Group()
        {
        }

        /// <summary>
        /// Create new group.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        public Group(string groupName)
        {
            if (String.IsNullOrWhiteSpace(groupName))
            {
                throw new NullReferenceException("Name group can not be null");
            }

            this.GroupName = groupName;
        }

        /// <summary>
        /// Create new group.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="specialty">Specialty</param>
        public Group(string groupName, string specialty) : this(groupName)
        {
            this.Specialty = specialty;
        }

        /// <summary>
        /// Get id.
        /// </summary>
        /// <param name="list">List with group.</param>
        /// <returns>Id.</returns>
        public int GetId(List<Group> list)
        {
            int id = -1;

            foreach (var group in list)
            {
                if (this.GroupName == group.GroupName)
                {
                    id = group.Id;
                    break;
                }
            }

            return id;
        }
    }
}