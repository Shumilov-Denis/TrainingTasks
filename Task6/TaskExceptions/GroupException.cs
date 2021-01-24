using System;

namespace TaskExceptions
{
    /// <summary>
    /// Group exception. This exception will be if we add new group in group list, but this group was.
    /// </summary>
    public class GroupException : Exception
    {
        /// <summary>
        /// Group which we try add.
        /// </summary>
        public string GroupName { get; }

        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="groupName">Group name.</param>
        public GroupException(string message, string groupName) : base(message)
        {
            this.GroupName = groupName;
        }
    }
}
