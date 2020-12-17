﻿using System;

namespace Shapes.ShapesOfFigure.Triangles
{
    /// <summary>
    /// Triangle made from plastic.
    /// </summary>
    [Serializable]
    public class PlasticTriangle : EquilateralTriangle, IMaterial
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
        public PlasticTriangle()
        {
        }

        /// <summary>
        /// Create new triangle.
        /// </summary>
        /// <param name="side">Side.</param>
        public PlasticTriangle(double side) : base(side)
        {
            this.HasBeenPainting = false;
            this.FigureColor = FirstColor;
        }

        /// <summary>
        /// Constructor for cutting shapes.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="side">New side of triangle</param>
        public PlasticTriangle(Figure figureBefore, double side) : base(figureBefore, side)
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
            return obj is PlasticTriangle plasticTriangle && plasticTriangle.Side == this.Side;
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
            return $"Plastic triangle. Side: {Side}. Color: {FigureColor}";
        }
    }
}