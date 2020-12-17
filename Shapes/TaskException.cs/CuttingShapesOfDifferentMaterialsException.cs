using System;
using System.Collections.Generic;
using System.Text;

namespace TaskException
{
    /// <summary>
    /// Cutting shapes of different materials exception.
    /// </summary>
    public class CuttingShapesOfDifferentMaterialsException : Exception
    {
        /// <summary>
        /// Create new exception.
        /// </summary>
        /// <param name="message">Message error.</param>
        public CuttingShapesOfDifferentMaterialsException(string message) : base(message)
        {
        }
    }
}
