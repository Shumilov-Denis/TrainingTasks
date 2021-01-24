using System;

namespace University
{
    /// <summary>
    /// Group of student.
    /// </summary>
    public class Group : IUniversity
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Group name.
        /// </summary>
        public string GroupName { get; set; }

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
    }
}