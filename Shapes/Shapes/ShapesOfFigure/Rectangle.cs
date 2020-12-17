using Colors;
using Shapes.Cutting;
using System;
using TaskException;

namespace Shapes.ShapesOfFigure
{
    /// <summary>
    /// Rectangle.
    /// </summary>
    [Serializable]
    public abstract class Rectangle : Figure
    {
        /// <summary>
        /// First side of rectangle.
        /// </summary>
        public double SideFirst { get; }

        /// <summary>
        /// Second side of rectangle.
        /// </summary>
        public double SideSecond { get; }

        /// <summary>
        /// Is the rectangle painted.
        /// </summary>
        public override bool HasBeenPainting { get; set; }

        /// <summary>
        /// Rectangle color. 
        /// </summary>
        public override Color FigureColor { get; set; }

        /// <summary>
        /// An empty constructor for serialization.
        /// </summary>
        protected Rectangle()
        {
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="sideFirst">First side.</param>
        /// <param name="sideSecond">Second side.</param>
        protected Rectangle(Figure figureBefore, double sideFirst, double sideSecond)
        {
            if (figureBefore == null)
            {
                throw new NullReferenceException();
            }

            if (sideFirst <= 0)
            {
                throw new NegativeSizeException(sideFirst, "Radius cannot be negative or be zero.");
            }

            if (sideSecond <= 0)
            {
                throw new NegativeSizeException(sideSecond, "Radius cannot be negative or be zero.");
            }

            if (CheckMaterial.CheckSameMaterial(figureBefore, this) && Cut.CutRectangle(figureBefore, sideFirst, SideSecond))
            {
                this.SideFirst = sideFirst;
                this.SideSecond = sideSecond;
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
        /// Create new circle.
        /// </summary>
        /// <param name="sideFirst">First side of rectangle.</param>
        /// <param name="sideSecond">Second side of rectangle.</param>
        protected Rectangle(double sideFirst, double sideSecond)
        {
            if (sideFirst <= 0)
            {
                throw new NegativeSizeException(sideFirst, "Radius cannot be negative or be zero.");
            }

            if (sideSecond <= 0)
            {
                throw new NegativeSizeException(sideSecond, "Radius cannot be negative or be zero.");
            }

            this.SideFirst = sideFirst;
            this.SideSecond = sideSecond;
            this.HasBeenPainting = false;
            this.FigureColor = FirstColor;
        }

        /// <summary>
        /// Count Area.
        /// </summary>
        public override double Area => SideFirst * SideSecond;

        /// <summary>
        /// Count perimeter.
        /// </summary>
        public override double Perimeter => 2 * (SideFirst + SideSecond);
    }
}