using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskException;
using Shapes;
using System.Collections.Generic;
using Boxes;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;

namespace TestBox
{
    /// <summary>
    /// Checking for exceptions that occur when working with a box.
    /// </summary>
    [TestClass]
    public class TestBoxException
    {
        /// <summary>
        /// Checking for an exception when trying to create a box with two identical shapes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowBoxException))]
        public void TestFindTwoIdenticalShapesWhenCreatingBox()
        {
            List<Figure> figures = new List<Figure>()
            {
                new FilmCircle(1),
                new FilmCircle(2),
                new FilmCircle(3),
                new FilmCircle(4),
                new PaperCircle(1),
                new FilmRectangle(1, 1),
                new FilmTriangle(1),
                new FilmCircle(1),
            };

            Box box = new Box(figures);
        }

        /// <summary>
        /// Checking for an exception when trying to create a box with more than 20 shapes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowBoxException))]
        public void TestOverflowBoxWhenCreateBox()
        {
            List<Figure> figures = new List<Figure>()
            {
                new FilmCircle(1),
                new FilmCircle(2),
                new FilmCircle(3),
                new FilmCircle(4),
                new PaperCircle(1),
                new FilmRectangle(1, 1),
                new FilmTriangle(1),
                new FilmCircle(10),
                new FilmRectangle(2, 2),
                new FilmRectangle(2, 1),
                new FilmRectangle(3, 1),
                new FilmRectangle(1, 5),
                new FilmRectangle(2, 6),
                new FilmTriangle(210),
                new FilmTriangle(2),
                new FilmTriangle(3),
                new FilmTriangle(4),
                new FilmTriangle(5),
                new FilmTriangle(6),
                new FilmTriangle(7),
                new FilmTriangle(8)
            };

            Box box = new Box(figures);
        }

        /// <summary>
        /// Checking for an exception when trying to add a shape to the box with exactly 20 shapes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OverflowBoxException))]
        public void TestOverflowBoxWhenWeTryAddNewFigure()
        {
            List<Figure> figures = new List<Figure>()
            {
                new FilmCircle(1),
                new FilmCircle(2),
                new FilmCircle(3),
                new FilmCircle(4),
                new PaperCircle(1),
                new FilmRectangle(1, 1),
                new FilmTriangle(1),
                new FilmCircle(10),
                new FilmRectangle(2, 2),
                new FilmRectangle(2, 1),
                new FilmRectangle(3, 1),
                new FilmRectangle(1, 5),
                new FilmRectangle(2, 6),
                new FilmTriangle(210),
                new FilmTriangle(2),
                new FilmTriangle(3),
                new FilmTriangle(4),
                new FilmTriangle(5),
                new FilmTriangle(6),
                new FilmTriangle(7)
            };

            Box box = new Box(figures);

            box.AddFigure(new PlasticCircle(4));
        }
    }
}
