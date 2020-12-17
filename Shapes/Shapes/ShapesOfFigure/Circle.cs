using Colors;
using Shapes.Cutting;
using System;
using TaskException;

namespace Shapes.ShapesOfFigure
{
    /// <summary>
    /// Circle.
    /// </summary>
    [Serializable]
    public abstract class Circle : Figure
    {
        /// <summary>
        /// Radius of circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Count area of circle.
        /// </summary>
        public override double Area => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Count perimeter.
        /// </summary>
        public override double Perimeter => 2 * Math.PI * Radius;

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
        protected Circle()
        {
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="radius">New radius.</param>
        protected Circle(Figure figureBefore, double radius)
        {
            if (figureBefore == null)
            {
                throw new NullReferenceException();
            }

            if (radius <= 0)
            {
                throw new NegativeSizeException(radius, "Radius cannot be negative or be zero.");
            }

            if (CheckMaterial.CheckSameMaterial(figureBefore, this) && Cut.CutCircle(figureBefore, radius))
            {
                this.Radius = radius;
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
        /// <param name="radius"></param>
        protected Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new NegativeSizeException(radius, "Radius cannot be negative or be zero.");
            }

            this.Radius = radius;
            this.FigureColor = FirstColor;
            this.HasBeenPainting = false;
        }
    }
}
