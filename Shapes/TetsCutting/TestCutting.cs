using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.ShapesOfFigure;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;

namespace TestCutting
{
    /// <summary>
    /// Testing cutting.
    /// </summary>
    [TestClass]
    public class TestCutting
    {
        /// <summary>
        /// Test cutting film circle from film figure.
        /// </summary>
        [TestMethod]
        public void CuttingFilmCircleFromFilmFigure()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 20);
            FilmTriangle triangle = new FilmTriangle(30);
            FilmCircle circle = new FilmCircle(3.4);

            Circle newCircleCutFromRectangle = new FilmCircle(rectangle, 3);
            Circle newCircleCutFromTriangle = new FilmCircle(triangle, 4);
            Circle newCircleCutFromCircle = new FilmCircle(circle, 1);

            Assert.AreEqual(typeof(FilmCircle), newCircleCutFromTriangle.GetType());
            Assert.AreEqual(typeof(FilmCircle), newCircleCutFromRectangle.GetType());
            Assert.AreEqual(typeof(FilmCircle), newCircleCutFromCircle.GetType());

            Assert.AreEqual(1, newCircleCutFromCircle.Radius);
            Assert.AreEqual(4, newCircleCutFromTriangle.Radius);
            Assert.AreEqual(3, newCircleCutFromRectangle.Radius);
        }


        /// <summary>
        /// Test cutting paper circle from paper figure.
        /// </summary>
        [TestMethod]
        public void CuttingPaperCircleFromPaperFigure()
        {
            PaperRectangle rectangle = new PaperRectangle(10, 20);
            PaperTriangle triangle = new PaperTriangle(30);
            PaperCircle circle = new PaperCircle(3.4);

            Circle newCircleCutFromRectangle = new PaperCircle(rectangle, 1);
            Circle newCircleCutFromTriangle = new PaperCircle(triangle, 2);
            Circle newCircleCutFromCircle = new PaperCircle(circle, 2);

            Assert.AreEqual(typeof(PaperCircle), newCircleCutFromTriangle.GetType());
            Assert.AreEqual(typeof(PaperCircle), newCircleCutFromRectangle.GetType());
            Assert.AreEqual(typeof(PaperCircle), newCircleCutFromCircle.GetType());

            Assert.AreEqual(2, newCircleCutFromCircle.Radius);
            Assert.AreEqual(2, newCircleCutFromTriangle.Radius);
            Assert.AreEqual(1, newCircleCutFromRectangle.Radius);
        }

        /// <summary>
        /// Test cutting film triangle from film rectangle.
        /// </summary>
        [TestMethod]
        public void CuttingFilmTriangleFromFilmRectangle()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 10);

            EquilateralTriangle newTriangle = new FilmTriangle(rectangle, 6);

            Assert.AreEqual(typeof(FilmTriangle), newTriangle.GetType());
            Assert.AreEqual(18, newTriangle.Perimeter);
        }

        /// <summary>
        /// Test cutting plastic circle from plastic triangle.
        /// </summary>
        [TestMethod]
        public void CuttingPlasticCircleFromPlasticTriangle()
        {
            PlasticRectangle rectangle = new PlasticRectangle(10, 10);

            Circle newCircle = new PlasticCircle(rectangle, 4);

            Assert.AreEqual(typeof(PlasticCircle), newCircle.GetType());
        }
    }
}