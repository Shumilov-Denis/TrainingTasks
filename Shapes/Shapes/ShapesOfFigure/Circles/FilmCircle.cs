using System;

namespace Shapes.ShapesOfFigure.Circles
{
    /// <summary>
    /// Circle made from film.
    /// </summary>
    [Serializable]
    public class FilmCircle : Circle, IMaterial
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
        public FilmCircle()
        {
        }

        /// <summary>
        /// Create new circle.
        /// </summary>
        /// <param name="radius">Radius.</param>
        public FilmCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Constructor for cutting shapes
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="radius">New radius.</param>
        public FilmCircle(Figure figureBefore, double radius) : base(figureBefore, radius)
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
            return obj is FilmCircle filmCircle && filmCircle.Radius == this.Radius;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = Radius.GetHashCode();
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
            return $"Film circle. Radius: {Radius}.";
        }
    }
}