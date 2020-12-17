using System;
using TaskException;

namespace WorkWithFile
{
    /// <summary>
    /// File.
    /// </summary>
    public abstract class File
    {
        /// <summary>
        /// Way to file.
        /// </summary>
        public string Way { get; set; }

        /// <summary>
        /// Create new way to file.
        /// </summary>
        /// <param name="way">Way to file.</param>
        protected File(string way)
        {
            if (String.IsNullOrWhiteSpace(way))
            {
                throw new NotValidWayToFileException("Way to file cannot be null.");
            }

            this.Way = way;
        }

        /// <summary>
        /// Information about way.
        /// </summary>
        /// <returns>Information about way.</returns>
        public override string ToString()
        {
            return $"Way to file: {Way}";
        }
    }
}
