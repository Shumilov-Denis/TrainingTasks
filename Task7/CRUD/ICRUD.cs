using System.Collections.Generic;
using University;

namespace CRUD
{
    /// <summary>
    /// Interface for CRUD
    /// </summary>
    /// <typeparam name="TUniversity">Type table.</typeparam>
    public interface ICRUD<TUniversity> where TUniversity : IUniversity
    {
        /// <summary>
        /// Insert object in table.
        /// </summary>
        /// <param name="insertData">Data for adding.</param>
        void Insert(TUniversity insertData);

        /// <summary>
        /// Select all data from table.
        /// </summary>
        /// <returns>Data list.</returns>
        List<TUniversity> Select();

        /// <summary>
        /// Update data.
        /// </summary>
        /// <param name="indexForUpdate">Index for update.</param>
        /// <param name="data">Data for update.</param>
        void Update(int indexForUpdate, TUniversity data);

        /// <summary>
        /// Delete data.
        /// </summary>
        /// <param name="deleteData">Data for delete.</param>
        void Delete(TUniversity deleteData);
    }
}
