using Colors;
using Shapes.Cutting;
using System;
using TaskException;

namespace Shapes.ShapesOfFigure
{
    /// <summary>
    /// Equilateral triangle.
    /// </summary>
    [Serializable]
    public abstract class EquilateralTriangle : Figure
    {
        /// <summary>
        /// Side of the triangle.
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Is the circle painted.
        /// </summary>
        public override bool HasBeenPainting { get; set; }

        /// <summary>
        /// Color of circle.
        /// </summary>
        public sealed override Color FigureColor { get; set; }

        /// <summary>
        /// An empty constructor for serialization.
        /// </summary>
        protected EquilateralTriangle()
        {

        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="side">Side of new figure.</param>
        protected EquilateralTriangle(Figure figureBefore, double side)
        {
            if (figureBefore == null)
            {
                throw new NullReferenceException();
            }

            if (side <= 0)
            {
                throw new NegativeSizeException(side, "Radius cannot be negative or be zero.");
            }

            if (CheckMaterial.CheckSameMaterial(figureBefore, this) && Cut.CutTriangle(figureBefore, side))
            {
                this.Side = side;
                this.HasBeenPainting = figureBefore.HasBeenPainting;
                this.FigureColor = figureBefore.FigureColor;

                figureBefore = null;
            }
            else
            {
                throw new CuttingShapesOfDifferentMaterialsException("You cannot cut out a figure consisting of another material from one figure.");
            }
        }

        /// <summary>
        /// Create new triangle.
        /// </summary>
        /// <param name="side"></param>
        protected EquilateralTriangle(double side)
        {
            if (side <= 0)
            {
                throw new NegativeSizeException(side, "Radius cannot be negative or be zero.");
            }

            this.Side = side;
        }

        /// <summary>
        /// Count area of circle.
        /// </summary>
        public override double Area => (Math.Pow(Side, 2) * Math.Pow(3, 0.5)) / 2;

        /// <summary>
        /// Count perimeter.
        /// </summary>
        public override double Perimeter => 3 * Side;
    }
}
