using Shapes;
using System.Collections.Generic;

namespace WorkWithFile
{
    /// <summary>
    /// Interface for working with file.xml.
    /// </summary>
    interface IFile
    {
        /// <summary>
        /// Save list with figure in XML file.
        /// </summary>
        /// <param name="figures"></param>
        void Save(List<Figure> figures);

        /// <summary>
        /// Read list with figure from XML file.
        /// </summary>
        /// <returns></returns>
        List<Figure> Read();
    }
}