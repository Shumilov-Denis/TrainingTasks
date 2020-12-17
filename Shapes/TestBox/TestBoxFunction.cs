using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskException;
using Shapes;
using System.Collections.Generic;
using Boxes;
using Colors;
using PaintingFigures;
using Shapes.ShapesOfFigure;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;

namespace TestBox
{
    /// <summary>
    /// Testing class box. checking basic functions. One test, one method to test.
    /// </summary>
    [TestClass]
    public class TestBoxFunction
    {
        /// <summary>
        /// Checking the writing of the reading in the file of paper figures. To save the record, use StreamReader and StreamWriter.
        /// </summary>
        [TestMethod]
        public void TestSaveInFileStreamWriterAndStreamReader()
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
                new FilmTriangle(7)
            };

            Box box = new Box(figures);
            box.SaveFigureInFileWithStear(@"D:\TestBoxXmlStream.xml", SelectionOfShapes.Paper);

            Box newBox = new Box();
            newBox.ReadFromFileWithStream(@"D:\TestBoxXmlStream.xml");

            Assert.AreEqual(1, newBox.Length);
        }

        /// <summary>
        /// Checking the writing of the reading in the file of paper figures. To save the record, use XmlReader and XmlWriter.
        /// </summary>
        [TestMethod]
        public void TestSaveInFileXmlWriterAndXmlReader()
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
                new FilmTriangle(7)
            };

            Box box = new Box(figures);
            box.SaveFigureInFileWithXml(@"D:\TestBoxXml.xml", SelectionOfShapes.Paper);

            Box newBox = new Box();
            newBox.ReadFromFileWithXml(@"D:\TestBoxXml.xml");

            Assert.AreEqual(1, newBox.Length);
        }

        /// <summary>
        /// Testing adding a new shape to the box.
        /// </summary>
        [TestMethod]
        public void TestAddFigureInBox()
        {
            Box newBox = new Box();

            newBox.AddFigure(new FilmCircle(10));

            Assert.AreEqual(1, newBox.Length);

            newBox.AddFigure(new PaperRectangle(10,10));

            Assert.AreEqual(2, newBox.Length);
        }

        /// <summary>
        /// Checking the view of the figure by number.
        /// </summary>
        [TestMethod]
        public void TestViewFigureByNumber()
        {
            Box box = new Box();
            box.ReadFromFileWithStream(@"D:\TestBoxXml.xml");
            string information = box.ViewFigureByNumber(1);

            Assert.AreEqual(box.Figures[0].ToString(), information);
        }

        /// <summary>
        /// Checking figure extraction by number.
        /// </summary>
        [TestMethod]
        public void TestExtractByNumber()
        {
            Box box = new Box();
            box.ReadFromFileWithStream(@"D:\TestBoxXmlStream.xml");
            Figure figure = box.ExtractByNumber(1);

            Assert.AreEqual(0, box.Length);
            Assert.IsTrue(figure.Equals(new PaperCircle(1)));
        }

        /// <summary>
        /// Checking the replacement of a shape by number.
        /// </summary>
        [TestMethod]
        public void TestReplacementByNumber()
        {
            Box box = new Box();
            box.ReadFromFileWithStream(@"D:\TestBoxXmlStream.xml");
            box.ReplacementByNumber(new PaperRectangle(10,10), 1);

            Assert.IsTrue(box.Figures[0].Equals(new PaperRectangle(10,10)));
        }

        /// <summary>
        /// Checking to find an equivalent shape by instance.
        /// </summary>
        [TestMethod]
        public void TestFindingShape()
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
                new FilmTriangle(7)
            };

            Box box = new Box(figures);

            FilmTriangle triangleForSearch = new FilmTriangle(1);
            string information = box.FindingShape(triangleForSearch);

            Assert.AreEqual(triangleForSearch.ToString(), information);
        }

        /// <summary>
        /// Checking the calculation of the total area.
        /// </summary>
        [TestMethod]
        public void TestCountArea()
        {
            List<Figure> figures = new List<Figure>()
            {
                new FilmRectangle(10, 10),
                new PaperRectangle(1, 2),
                new PlasticRectangle(3, 4)
            };

            Box box = new Box(figures);

            double area = box.SumArea;

            Assert.AreEqual(114, area);
        }

        /// <summary>
        /// Checking the calculation of the total perimeter.
        /// </summary>
        [TestMethod]
        public void TestCountPerimeter()
        {
            List<Figure> figures = new List<Figure>()
            {
                new FilmRectangle(10, 10),
                new PaperRectangle(1, 2),
                new PlasticRectangle(3, 4)
            };

            Box box = new Box(figures);

            double area = box.SumPerimeter;

            Assert.AreEqual(60, area);
        }

        /// <summary>
        /// Checking the extraction of all circles from the figure.
        /// </summary>
        [TestMethod]
        public void TestGetAllCircles()
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
                new FilmTriangle(7)
            };

            Box box = new Box(figures);

            List<Circle> circles = box.GetAllCircles();

            Assert.AreEqual(6, circles.Count);
            Assert.AreEqual(3, box.Length);
        }

        /// <summary>
        /// Checking the extraction of all film figures.
        /// </summary>
        [TestMethod]
        public void TestGetAllFilmFigures()
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
                new FilmTriangle(7)
            };

            Box box = new Box(figures);

            List<Figure> filmFigures = box.GetAllFilmFigures();

            Assert.AreEqual(8,filmFigures.Count);
            Assert.AreEqual(1, box.Length);
        }

        /// <summary>
        /// Removal check of all plastic figures that have not been painted.
        /// </summary>
        [TestMethod]
        public void TestGetAllPlasticFiguresHasNotBeenPainting()
        {
            Box box = new Box();

            PlasticCircle circle = new PlasticCircle(1);
            PlasticTriangle triangle = new PlasticTriangle(3);
            PlasticRectangle rectangle = new PlasticRectangle(10,10);

            circle.PaintingFigure(Color.Orange);
            rectangle.PaintingFigure(Color.Red);

            box.AddFigure(circle);
            box.AddFigure(triangle);
            box.AddFigure(rectangle);

            List<Figure> figures = box.GetAllPlasticFiguresHasNotBeenPainting();

            Assert.AreEqual(1,figures.Count);
            Assert.AreEqual(2, box.Length);
        }
    }
}
