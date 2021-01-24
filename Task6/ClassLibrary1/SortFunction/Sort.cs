using System.Collections.Generic;
using System.Linq;

namespace Excels.SortFunction
{
    /// <summary>
    /// Class for sort table.
    /// </summary>
    internal static class Sort
    {
        /// <summary>
        /// Choose type for sort.
        /// </summary>
        /// <param name="typeForSort">Sort by.</param>
        /// <param name="typeSort">Type sort.</param>
        /// <returns>Sorted list.</returns>
        public static List<Rows> ChooseSort(SortBy typeForSort, TypeOfSort typeSort)
        {
            List<Rows> rows = null;

            switch (typeSort)
            {
                case TypeOfSort.Ascending: rows = SortAscending(typeForSort); break;
                case TypeOfSort.Descending: rows = SortDescending(typeForSort); break;
                default: rows = Rows.GetRows(); break;
            }

            return rows;
        }

        /// <summary>
        /// Sort by ascending.
        /// </summary>
        /// <param name="typeForSort">Sort type.</param>
        /// <returns>Sorted list.</returns>
        private static List<Rows> SortAscending(SortBy typeForSort)
        {
            List<Rows> rows = Rows.GetRows();
            IEnumerable<Rows> sortedRows;
            switch (typeForSort)
            {
                case SortBy.ExamsDate:
                    sortedRows = from row in rows
                                 orderby row.ExamsDate ascending
                                 select row;
                    break;
                case SortBy.StudentsDateBirth:
                    sortedRows = from row in rows
                                 orderby row.StudentsDateBirth ascending
                                 select row;
                    break;
                case SortBy.Group:
                    sortedRows = from row in rows
                                 orderby row.Group ascending
                                 select row;
                    break;
                case SortBy.Grade:
                    sortedRows = from row in rows
                                 orderby row.Grade ascending
                                 select row;
                    break;
                default: sortedRows = rows; break;
            }


            return sortedRows.ToList();
        }

        /// <summary>
        /// Sort by descending.
        /// </summary>
        /// <param name="typeForSort">Sort type</param>
        /// <returns>Sorted list.</returns>
        private static List<Rows> SortDescending(SortBy typeForSort)
        {
            List<Rows> rows = Rows.GetRows();
            IEnumerable<Rows> sortedRows;
            switch (typeForSort)
            {
                case SortBy.ExamsDate:
                    sortedRows = from row in rows
                                 orderby row.ExamsDate descending
                                 select row;
                    break;
                case SortBy.StudentsDateBirth:
                    sortedRows = from row in rows
                                 orderby row.StudentsDateBirth descending
                                 select row;
                    break;
                case SortBy.Group:
                    sortedRows = from row in rows
                                 orderby row.Group descending
                                 select row;
                    break;
                case SortBy.Grade:
                    sortedRows = from row in rows
                                 orderby row.Grade descending
                                 select row;
                    break;
                default: sortedRows = rows; break;
            }


            return sortedRows.ToList();
        }
    }
}
