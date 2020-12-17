using System;
using Shapes;
using CheckingMaterialsOfFigures;
using Shapes.ShapesOfFigure;
using TaskException;

namespace CutFigure
{
    public static class Cut
    {


        public static void CutShape(this Figure figureBefore, Figure figureAfter)
        {
            if (figureBefore == null || figureAfter == null)
            {
                throw new NullReferenceException();
            }
            else if (IsShapesFromTheSameMaterial(figureBefore, figureAfter))
            {
                CanWeCut(figureBefore, figureAfter);
            }
            else
            {
                throw new CuttingShapesOfDifferentMaterialsException("You cannot cut out a figure consisting of another material from one figure.");
            }
        }

        public static void CanWeCut(Figure figureBefore, Figure figureAfter)
        {
            if (figureBefore is Circle)
            {
                CutFromCircle(figureBefore, figureAfter);
            }
            else if (figureBefore is EquilateralTriangle)
            {
                CutFromTriangle(figureBefore, figureAfter);
            }
            else if (figureBefore is Rectangle)
            {
                CutFromRectangle(figureBefore, figureAfter);
            }
        }

        public static void CutFromRectangle(Figure figureBefore, Figure figureAfter)
        {
            if (figureAfter is EquilateralTriangle && CanCutTriangleFromRectangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as EquilateralTriangle;
            }
            else if (figureAfter is Circle && CanCutCircleFromRectangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Circle;
            }
            else if (figureAfter is Rectangle && CanCutRectangleFromRectangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Rectangle;
            }
        }

        public static void CutFromCircle(Figure figureBefore, Figure figureAfter)
        {
            if (figureAfter is EquilateralTriangle && CanCutTriangleFromCircle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as EquilateralTriangle;
            }
            else if (figureAfter is Circle && CanCutCircleFromCircle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Circle;
            }
            else if (figureAfter is Rectangle && CanCutRectangleFromCircle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Rectangle;
            }
        }

        private static void CutFromTriangle(Figure figureBefore, Figure figureAfter)
        {
            if (figureAfter is EquilateralTriangle && CanCutTriangleFromTriangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as EquilateralTriangle;
            }
            else if (figureAfter is Circle && CanCutCircleFromTriangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Circle;
            }
            else if (figureAfter is Rectangle && CanCutRectangleFromTriangle(figureBefore, figureAfter))
            {
                figureBefore = figureAfter as Rectangle;
            }
        }

        private static bool IsShapesFromTheSameMaterial(Figure figureBefore, Figure figureAfter)
        {
            return (CheckMaterial.IsPaperFigure(figureBefore) && CheckMaterial.IsPaperFigure(figureAfter)) ||
                   (CheckMaterial.IsPlasticFigure(figureBefore) && CheckMaterial.IsPlasticFigure(figureAfter)) ||
                   (CheckMaterial.IsFilmFigure(figureBefore) && CheckMaterial.IsFilmFigure(figureAfter));
        }

        #region Can cut from circle
        private static bool CanCutTriangleFromCircle(Figure figureBefore, Figure figureAfter)
        {
            Circle circle = figureBefore as Circle;
            EquilateralTriangle triangle = figureAfter as EquilateralTriangle;

            return circle.Radius >= (triangle.Side / Math.Pow(3, 0.5));
        }

        private static bool CanCutRectangleFromCircle(Figure figureBefore, Figure figureAfter)
        {
            Circle circle = figureBefore as Circle;
            Rectangle rectangle = figureAfter as Rectangle;

            return Math.Pow((Math.Pow(rectangle.SideFirst, 2) + Math.Pow(rectangle.SideSecond, 2)), 0.5) <= circle.Radius;
        }

        private static bool CanCutCircleFromCircle(Figure figureBefore, Figure figureAfter)
        {
            Circle circleFirst = figureBefore as Circle;
            Circle circleSecond = figureAfter as Circle;

            return circleFirst.Radius >= circleSecond.Radius;
        }
        #endregion

        #region Can cut from triangle

        private static bool CanCutTriangleFromTriangle(Figure figureBefore, Figure figureAfter)
        {
            EquilateralTriangle triangleFirst = figureBefore as EquilateralTriangle;
            EquilateralTriangle triangleSecond = figureAfter as EquilateralTriangle;

            return triangleFirst.Side >= triangleSecond.Side;
        }

        private static bool CanCutCircleFromTriangle(Figure figureBefore, Figure figureAfter)
        {
            EquilateralTriangle triangle = figureBefore as EquilateralTriangle;
            Circle circle = figureAfter as Circle;

            return (triangle.Side / (2 * Math.Pow(3, 0.5))) >= circle.Radius;
        }

        private static bool CanCutRectangleFromTriangle(Figure figureBefore, Figure figureAfter)
        {
            EquilateralTriangle triangle = figureBefore as EquilateralTriangle;
            Rectangle rectangle = figureAfter as Rectangle;

            bool canCut = rectangle.SideFirst <= triangle.Side || rectangle.SideSecond <= triangle.Side;

            return canCut;
        }
        #endregion

        #region Can Cut From Rectangle
        private static bool CanCutCircleFromRectangle(Figure figureBefore, Figure figureAfter)
        {
            Rectangle rectangle = figureBefore as Rectangle;
            Circle circle = figureAfter as Circle;

            return rectangle.SideFirst >= 2 * circle.Radius && rectangle.SideSecond >= 2 * circle.Radius;
        }

        private static bool CanCutTriangleFromRectangle(Figure figureBefore, Figure figureAfter)
        {
            Rectangle rectangle = figureBefore as Rectangle;
            EquilateralTriangle triangle = figureAfter as EquilateralTriangle;

            return rectangle.SideFirst >= triangle.Side && rectangle.SideSecond >= triangle.Side;
        }

        private static bool CanCutRectangleFromRectangle(Figure figureBefore, Figure figureAfter)
        {
            Rectangle firstRectangle = figureBefore as Rectangle;
            Rectangle secondRectangle = figureAfter as Rectangle;

            return (firstRectangle.SideFirst >= secondRectangle.SideFirst && firstRectangle.SideSecond >= secondRectangle.SideSecond) ||
                   (firstRectangle.SideFirst >= secondRectangle.SideSecond && firstRectangle.SideSecond >= secondRectangle.SideFirst);
        }
        #endregion
    }
}