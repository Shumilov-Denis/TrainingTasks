using System;

namespace Shapes.ShapesOfFigure.Triangles
{
    /// <summary>
    /// Triangle made from film.
    /// </summary>
    [Serializable]
    public class FilmTriangle : EquilateralTriangle, IMaterial
    {
        /// <summary>
        /// Circle cannot be painting.
        /// </summary>
        public bool CanPainting()
        {
            return false;
        }

        /// <summary>
        /// Empty constructor required for serialization.
        /// </summary>
        public FilmTriangle()
        {
        }

        /// <summary>
        /// Create new triangle.
        /// </summary>
        /// <param name="side">Side.</param>
        public FilmTriangle(double side) : base(side)
        {
            this.HasBeenPainting = false;
            this.FigureColor = FirstColor;
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="side">Side of new triangle</param>
        public FilmTriangle(Figure figureBefore, double side) : base(figureBefore, side)
        {
        }

        /// <summary>
        /// Get material.
        /// </summary>
        /// <returns>String with material.</returns>
        public string GetMaterial()
        {
            return "Film";
        }

        /// <summary>
        /// Comparison of two figures.
        /// </summary>
        /// <param name="obj">Comparison object.</param>
        /// <returns>True if two figures are identical.</returns>
        public override bool Equals(object obj)
        {
            return obj is FilmTriangle filmTriangle && filmTriangle.Side == this.Side;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = Side.GetHashCode();
            hashCode += HasBeenPainting.GetHashCode();
            hashCode += FigureColor.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Information about figure.
        /// </summary>
        /// <returns>Information about figure.</returns>
        public override string ToString()
        {
            return $"Film triangle. Side: {Side}.";
        }
    }
}