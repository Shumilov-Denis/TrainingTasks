using Goods;
using System.Collections.Generic;

namespace WorkWithFile
{
    /// <summary>
    /// Interface for work with file.
    /// </summary>
    internal interface IFile
    {
        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <returns>List with information.</returns>
        List<Product> Read();

        /// <summary>
        /// Save information to file.
        /// </summary>
        /// <param name="products">List with products.</param>
        void Save(List<Product> products);
    }
}