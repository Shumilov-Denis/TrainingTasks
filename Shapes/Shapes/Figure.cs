using Colors;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;
using System;
using System.Xml.Serialization;

namespace Shapes
{
    /// <summary>
    /// Figure.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(PaperCircle)), XmlInclude(typeof(FilmCircle)), XmlInclude(typeof(PlasticCircle))]
    [XmlInclude(typeof(PaperRectangle)), XmlInclude(typeof(FilmRectangle)), XmlInclude(typeof(PlasticRectangle))]
    [XmlInclude(typeof(PaperTriangle)), XmlInclude(typeof(FilmTriangle)), XmlInclude(typeof(PlasticTriangle))]
    public abstract class Figure
    {
        /// <summary>
        /// Figure area.
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Figure perimeter.
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Is the figure painted.
        /// </summary>
        public abstract bool HasBeenPainting { get; set; }

        /// <summary>
        /// Figure color.
        /// </summary>
        public abstract Color FigureColor { get; set; }

        /// <summary>
        /// Color assigned when the shape was created
        /// </summary>

        protected const Color FirstColor = Color.NoneColor;
    }
}