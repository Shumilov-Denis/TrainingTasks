using System;
using Shapes;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;

namespace CheckingMaterialsOfFigures
{
    /// <summary>
    /// Class for checking material of figure.
    /// </summary>
    public static class CheckMaterial
    {
        /// <summary>
        /// Material check figure: film.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>True, if the figure consists of film material.</returns>
        public static bool IsFilmFigure(Figure figure)
        {
            return figure is FilmCircle || figure is FilmTriangle || figure is FilmRectangle;
        }

        /// <summary>
        /// Material check figure: paper.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>True, if the figure consists of paper material.</returns>
        public static bool IsPaperFigure(Figure figure)
        {
            return figure is PaperCircle || figure is PaperTriangle || figure is PaperRectangle;
        }

        /// <summary>
        /// Material check figure: plastic.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>True, if the figure consists of plastic material.</returns>
        public static bool IsPlasticFigure(Figure figure)
        {
            return figure is PlasticCircle || figure is PlasticTriangle || figure is PlasticRectangle;
        }
    }
}
