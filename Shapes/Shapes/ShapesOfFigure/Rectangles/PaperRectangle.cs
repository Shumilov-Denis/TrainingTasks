using System;

namespace Shapes.ShapesOfFigure.Rectangles
{
    /// <summary>
    /// Rectangle made from paper.
    /// </summary>
    [Serializable]
    public class PaperRectangle : Rectangle, IMaterial
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
        public PaperRectangle()
        {
        }

        /// <summary>
        /// Create new film rectangle.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        public PaperRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="sideFirst">First side.</param>
        /// <param name="sideSecond">Second side.</param>
        public PaperRectangle(Figure figureBefore, double sideFirst, double sideSecond) : base(figureBefore, sideFirst, sideSecond)
        {
        }

        /// <summary>
        /// Get material.
        /// </summary>
        /// <returns>String with material.</returns>
        public string GetMaterial()
        {
            return "Paper";
        }

        /// <summary>
        /// Comparison of two figures.
        /// </summary>
        /// <param name="obj">Comparison object.</param>
        /// <returns>True if two figures are identical.</returns>
        public override bool Equals(object obj)
        {
            return obj is PaperRectangle paperRectangle && ((paperRectangle.SideFirst == this.SideFirst && paperRectangle.SideSecond == this.SideSecond) || (paperRectangle.SideFirst == this.SideSecond && paperRectangle.SideSecond == this.SideFirst));
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
            return $"Paper rectangle. Sides: {SideFirst}, {SideSecond}. Color: {FigureColor}";
        }
    }
}
