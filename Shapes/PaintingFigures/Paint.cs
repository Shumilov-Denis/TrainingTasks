using Colors;
using Shapes;
using Shapes.Cutting;
using TaskException;

namespace PaintingFigures
{
    /// <summary>
    /// Shapes coloring page.
    /// </summary>
    public static class Paint
    {
        /// <summary>
        /// Repainting the figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <param name="color">Color.</param>
        public static void PaintingFigure(this Figure figure, Color color)
        {
            if (CheckMaterial.IsPlasticFigure(figure) || (CheckMaterial.IsPaperFigure(figure) && !figure.HasBeenPainting))
            {
                figure.FigureColor = color;
                figure.HasBeenPainting = true;
            }
            else
            {
                throw new CannotPaintingException("This figure cannot be painting.");
            }
        }
    }
}