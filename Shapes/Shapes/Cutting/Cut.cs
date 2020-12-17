using Shapes.ShapesOfFigure;
using System;

namespace Shapes.Cutting
{
    /// <summary>
    /// A class for cutting some shapes from others.
    /// </summary>
    internal static class Cut
    {
        /// <summary>
        /// Cutting rectangle from some thing figure.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="sideFirst">New side of rectangle.</param>
        /// <param name="sideSecond">New side of rectangle.</param> 
        /// <returns>Return true if can to cutting rectangle from this figure.</returns>
        public static bool CutRectangle(Figure figureBefore, double sideFirst, double sideSecond)
        {
            bool canCut = false;

            if (figureBefore is EquilateralTriangle && CanCutRectangleFromTriangle(figureBefore as EquilateralTriangle, sideFirst, sideSecond))
            {
                canCut = true;
            }
            else if (figureBefore is Circle && CanCutRectangleFromCircle(figureBefore as Circle, sideFirst, sideSecond))
            {
                canCut = true;
            }
            else if (figureBefore is Rectangle && CanCutRectangleFromRectangle(figureBefore as Rectangle, sideFirst, sideSecond))
            {
                canCut = true;
            }

            return canCut;
        }

        /// <summary>
        /// Cutting circle from some thing figure.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="radius">New radius of circle.</param>
        /// <returns>Return true if can to cutting circle from this figure.</returns>
        public static bool CutCircle(Figure figureBefore, double radius)
        {
            bool canCut = false;

            if (figureBefore is EquilateralTriangle && CanCutCircleFromTriangle(figureBefore as EquilateralTriangle, radius))
            {
                canCut = true;
            }
            else if (figureBefore is Circle && CanCutCircleFromCircle(figureBefore as Circle, radius))
            {
                canCut = true;
            }
            else if (figureBefore is Rectangle && CanCutCircleFromRectangle(figureBefore as Rectangle, radius))
            {
                canCut = true;
            }

            return canCut;
        }

        /// <summary>
        /// Cutting triangle from some thing figure.
        /// </summary>
        /// <param name="figureBefore">Figure before.</param>
        /// <param name="side">Side of new triangle.</param>
        /// <returns>Return true if can to cutting triangle from this figure.</returns>
        public static bool CutTriangle(Figure figureBefore, double side)
        {
            bool canCut = false;

            if (figureBefore is EquilateralTriangle && CanCutTriangleFromTriangle(figureBefore as EquilateralTriangle, side))
            {
                canCut = true;
            }
            else if (figureBefore is Circle && CanCutTriangleFromCircle(figureBefore as Circle, side))
            {
                canCut = true;
            }
            else if (figureBefore is Rectangle && CanCutTriangleFromRectangle(figureBefore as Rectangle, side))
            {
                canCut = true;
            }

            return canCut;
        }

        #region Can cut from circle

        /// <summary>
        /// Checks can we cut triangle from this circle.
        /// </summary>
        /// <param name="figureBefore">Circle before.</param>
        /// <param name="side">New triangle</param>
        /// <returns>True if we can cut triangle from circle.</returns>
        private static bool CanCutTriangleFromCircle(Circle figureBefore, double side)
        {
            return figureBefore.Radius > (side / Math.Pow(3, 0.5));
        }

        /// <summary>
        /// Checks can we cut rectangle from this circle.
        /// </summary>
        /// <param name="figureBefore">Circle before.</param>
        /// <param name="sideFirst">New side of rectangle.</param>
        /// <param name="sideSecond">New side of rectangle.</param> 
        /// <returns>True if we can cut rectangle from circle.</returns>
        private static bool CanCutRectangleFromCircle(Circle figureBefore, double sideFirst, double sideSecond)
        {
            return Math.Pow((Math.Pow(sideFirst, 2) + Math.Pow(sideSecond, 2)), 0.5) < figureBefore.Radius;
        }

        /// <summary>
        /// Checks can we cut circle from this circle.
        /// </summary>
        /// <param name="figureBefore">Circle before.</param>
        /// <param name="radius">New radius.</param>
        /// <returns>True if we can cut circle from this circle.</returns>
        private static bool CanCutCircleFromCircle(Circle figureBefore, double radius)
        {
            return figureBefore.Radius > radius;
        }
        #endregion

        #region Can cut from triangle

        /// <summary>
        /// Checks can we cut triangle from this triangle.
        /// </summary>
        /// <param name="figureBefore">Triangle before.</param>
        /// <param name="side">New triangle.</param>
        /// <returns>True if we can cut triangle from this triangle.</returns>
        private static bool CanCutTriangleFromTriangle(EquilateralTriangle figureBefore, double side)
        {
            return figureBefore.Side > side;
        }

        /// <summary>
        /// Checks can we cut circle from this triangle.
        /// </summary>
        /// <param name="figureBefore">Triangle before.</param>
        /// <param name="radius">New radius.</param> 
        /// <returns>True if we can cut circle from this triangle.</returns>
        private static bool CanCutCircleFromTriangle(EquilateralTriangle figureBefore, double radius)
        {
            return (figureBefore.Side / (2 * Math.Pow(3, 0.5))) >= radius;
        }

        /// <summary>
        /// Checks can we cut rectangle from this triangle.
        /// </summary>
        /// <param name="figureBefore">Triangle before.</param>
        /// <param name="sideFirst">New side of rectangle.</param>
        /// <param name="sideSecond">New side of rectangle.</param> 
        /// <returns>True if we can cut rectangle from this triangle.</returns>
        private static bool CanCutRectangleFromTriangle(EquilateralTriangle figureBefore, double sideFirst, double sideSecond)
        {
            double sinusRatio = Math.Sin(30) / Math.Sin(60);
            double maxSizeOfRecrangle = figureBefore.Side / (sinusRatio + 1) * Math.Sin(30);

            return maxSizeOfRecrangle < sideFirst && maxSizeOfRecrangle < sideSecond;
        }
        #endregion

        #region Can Cut From Rectangle

        /// <summary>
        /// Checks can we cut circle from this rectangle.
        /// </summary>
        /// <param name="figureBefore">Rectangle before.</param>
        /// <param name="radius">New radius.</param>
        /// <returns>True if we can cut circle from rectangle.</returns>
        private static bool CanCutCircleFromRectangle(Rectangle figureBefore, double radius)
        {
            return figureBefore.SideFirst >= 2 * radius && figureBefore.SideSecond >= 2 * radius;
        }

        /// <summary>
        /// Checks can we cut triangle from this rectangle.
        /// </summary>
        /// <param name="figureBefore">Rectangle before.</param>
        /// <param name="side">New triangle.</param>
        /// <returns>True if we can cut triangle from rectangle.</returns>
        private static bool CanCutTriangleFromRectangle(Rectangle figureBefore, double side)
        {
            return figureBefore.SideFirst >= side && figureBefore.SideSecond >= side;
        }

        /// <summary>
        /// Checks can we cut rectangle from this rectangle.
        /// </summary>
        /// <param name="figureBefore">Rectangle before.</param>
        /// <param name="sideFirst">New side of rectangle.</param>
        /// <param name="sideSecond">New side of rectangle.</param> 
        /// <returns>True if we can cut rectangle from this rectangle.</returns>
        private static bool CanCutRectangleFromRectangle(Rectangle figureBefore, double sideFirst, double sideSecond)
        {
            return (figureBefore.SideFirst >= sideFirst && figureBefore.SideSecond >= sideSecond) ||
                   (figureBefore.SideFirst >= sideSecond && figureBefore.SideSecond >= sideFirst);
        }
        #endregion
    }
}