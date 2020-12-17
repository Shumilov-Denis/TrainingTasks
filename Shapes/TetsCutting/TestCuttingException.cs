using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.ShapesOfFigure;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;
using TaskException;

namespace TestCutting
{
    /// <summary>
    /// Testing cutting exception.
    /// </summary>
    [TestClass]
    public class TestCuttingException
    {
        /// <summary>
        /// Can cut triangle.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CuttingShapesOfDifferentMaterialsException))]
        public void TestExceptionIfWeCantCuttingTriangle()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 10);

            EquilateralTriangle newTriangle = new FilmTriangle(rectangle, 11);
        }

        /// <summary>
        /// Can cut circle.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CuttingShapesOfDifferentMaterialsException))]
        public void TestExceptionIfWeCantCuttingCircle()
        {
            FilmRectangle rectangle = new FilmRectangle(5, 10);

            Circle newTriangle = new FilmCircle(rectangle, 3);
        }

        /// <summary>
        /// Can cut rectangle.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CuttingShapesOfDifferentMaterialsException))]
        public void TestExceptionIfWeCantCuttingRectangle()
        {
            FilmCircle circle = new FilmCircle(2.5);

            Rectangle newTriangle = new FilmRectangle(circle, 4, 5);
        }

        /// <summary>
        /// Can cut film rectangle from paper circle.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CuttingShapesOfDifferentMaterialsException))]
        public void TestExceptionIfWeCantCuttingFilmRectangleFromPaperCircle()
        {
            PaperCircle circle = new PaperCircle(20);

            Rectangle newTriangle = new FilmRectangle(circle, 4, 5);
        }
    }
}