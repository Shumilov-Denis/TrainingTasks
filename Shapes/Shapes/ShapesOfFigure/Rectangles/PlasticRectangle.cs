using System;

namespace Shapes.ShapesOfFigure.Rectangles
{
    /// <summary>
    /// Rectangle made from plastic.
    /// </summary>
    [Serializable]
    public class PlasticRectangle : Rectangle, IMaterial
    {
        /// <summary>
        /// Rectangle can be painting.
        /// </summary>
        public bool CanPainting()
        {
            return true;
        }

        /// <summary>
        /// Empty constructor required for serialization.
        /// </summary>
        public PlasticRectangle()
        {
        }

        /// <summary>
        /// Create new film rectangle.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        public PlasticRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="sideFirst">First side.</param>
        /// <param name="sideSecond">Second side.</param>
        public PlasticRectangle(Figure figureBefore, double sideFirst, double sideSecond) : base(figureBefore, sideFirst, sideSecond)
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
            return obj is PlasticRectangle plasticRectangle && ((plasticRectangle.SideFirst == this.SideFirst && plasticRectangle.SideSecond == this.SideSecond) || (plasticRectangle.SideFirst == this.SideSecond && plasticRectangle.SideSecond == this.SideFirst));
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = SideFirst.GetHashCode();
            hashCode += SideSecond.GetHashCode();
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
            return $"Plastic rectangle. Sides: {SideFirst}, {SideSecond}. Color: {FigureColor}";
        }
    }
}
