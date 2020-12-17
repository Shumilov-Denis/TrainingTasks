using System;

namespace Shapes.ShapesOfFigure.Circles
{
    /// <summary>
    /// Circle made from plastic.
    /// </summary>
    [Serializable]
    public class PlasticCircle : Circle, IMaterial
    {
        /// <summary>
        /// Circle can be painting.
        /// </summary>
        public bool CanPainting()
        {
            return true;
        }

        /// <summary>
        /// Empty constructor required for serialization.
        /// </summary>
        public PlasticCircle()
        {
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="radius">New radius.</param>
        public PlasticCircle(Figure figureBefore, double radius) : base(figureBefore, radius)
        {
        }

        /// <summary>
        /// Create new circle.
        /// </summary>
        /// <param name="radius">Radius.</param>
        public PlasticCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Get material.
        /// </summary>
        /// <returns>String with material.</returns>
        public string GetMaterial()
        {
            return "Plastic";
        }

        /// <summary>
        /// Comparison of two figures.
        /// </summary>
        /// <param name="obj">Comparison object.</param>
        /// <returns>True if two figures are identical.</returns>
        public override bool Equals(object obj)
        {
            return obj is PlasticCircle plasticCircle && plasticCircle.Radius == this.Radius;
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
            return $"Plastic circle. Radius: {Radius}. Color: {FigureColor}.";
        }
    }
}