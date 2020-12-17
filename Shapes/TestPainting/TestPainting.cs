using Colors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintingFigures;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;
using TaskException;

namespace TestPainting
{
    /// <summary>
    /// Test painting film, paper and plastic figure.
    /// </summary>
    [TestClass]
    public class TestPainting
    {
        /// <summary>
        /// Test painting paper circle.
        /// </summary>
        [TestMethod]
        public void TestPaintPaperCircle()
        {
            PaperCircle circle = new PaperCircle(10);

            circle.PaintingFigure(Color.Orange);

            Assert.AreEqual(Color.Orange, circle.FigureColor);
        }

        /// <summary>
        /// Test painting paper circle twice.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CannotPaintingException))]
        public void TestPaintPaperCircleTwice()
        {
            PaperCircle circle = new PaperCircle(10);

            circle.PaintingFigure(Color.Orange);
            circle.PaintingFigure(Color.Blue);

            Assert.AreEqual(Color.Orange, circle.FigureColor);
        }

        /// <summary>
        /// Test painting plastic triangle.
        /// </summary>
        [TestMethod]
        public void TestPaintPlasticTriangle()
        {
            PlasticTriangle triangle = new PlasticTriangle(10);

            triangle.PaintingFigure(Color.Blue);

            Assert.AreEqual(Color.Blue, triangle.FigureColor);
        }

        /// <summary>
        /// Test painting plastic triangle twice.
        /// </summary>
        [TestMethod]
        public void TestPaintPlasticTriangleTwice()
        {
            PlasticTriangle triangle = new PlasticTriangle(10);

            triangle.PaintingFigure(Color.Blue);
            triangle.PaintingFigure(Color.Red);

            Assert.AreEqual(Color.Red, triangle.FigureColor);
        }

        /// <summary>
        /// Test painting film rectangle.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CannotPaintingException))]
        public void TestPaintFilmRectangle()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 10);

            rectangle.PaintingFigure(Color.Orange);

            Assert.AreEqual(Color.Orange, rectangle.FigureColor);
        }
    }
}
