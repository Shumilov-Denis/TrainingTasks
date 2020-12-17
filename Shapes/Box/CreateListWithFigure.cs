using Shapes;
using System;
using System.Collections.Generic;

namespace Boxes
{
    /// <summary>
    /// A class for creating a list of shapes with a specific material.
    /// </summary>
    internal static class CreateListWithFigure
    {
        /// <summary>
        /// Create new list of shapes with a specific materials.
        /// </summary>
        /// <param name="figures">List with figure.</param>
        /// <param name="materialMethod">Method for determining the material of a shape, implemented in Shapes.Cutting.CheckMaterial.</param>
        /// <returns>List of figures.</returns>
        public static List<Figure> FoundFigure(this List<Figure> figures, Func<Figure, bool> materialMethod)
        {
            List<Figure> materialFigure = new List<Figure>();

            for (int index = 0; index < figures.Count; index++)
            {
                if (materialMethod(figures[index]))
                {
                    materialFigure.Add(figures[index]);
                    figures.RemoveAt(index);
                    index--;
                }
            }

            return materialFigure;
        }
    }
}
