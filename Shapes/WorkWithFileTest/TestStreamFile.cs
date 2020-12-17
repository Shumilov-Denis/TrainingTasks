using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using Shapes.ShapesOfFigure.Triangles;
using System.Collections.Generic;
using WorkWithFile.WriteOrReadFile;

namespace WorkWithFileTest
{
    /// <summary>
    /// Test Save/Read in file with StreamWriter/StreamReader.
    /// </summary>
    [TestClass]
    public class TestStreamFile
    {
        /// <summary>
        /// Test save list with figures in file test.
        /// </summary>
        [TestMethod]
        public void TestSaveInXmlFile()
        {
            List<Figure> figures = new List<Figure>()
            {
                new PaperCircle(10),
                new FilmCircle(2),
                new PlasticCircle(1),
                new FilmRectangle(10, 5),
                new PaperTriangle(4),
                new PaperRectangle(10, 10)
            };

            FileWorkWithStream file = new FileWorkWithStream(@"D:\Task3.xml");

            file.Save(figures);
        }

        /// <summary>
        /// Test read list with figures from file. Check type.
        /// </summary>
        [TestMethod]
        public void TestReadXmlFileCheckType()
        {
            FileWorkWithStream file = new FileWorkWithStream(@"D:\Task3.xml");

            List<Figure> figures = file.Read();

            Assert.IsTrue(figures[0] is PaperCircle);
            Assert.IsTrue(figures[1] is FilmCircle);
            Assert.IsTrue(figures[2] is PlasticCircle);
            Assert.IsTrue(figures[3] is FilmRectangle);
            Assert.IsTrue(figures[4] is PaperTriangle);
            Assert.IsTrue(figures[5] is PaperRectangle);
        }

        /// <summary>
        /// Test read list with figures from file which was write with use XmlWriter. Check type.
        /// </summary>
        [TestMethod]
        public void TestReadXmlFileCheckSizeOfFigure()
        {
            FileWorkWithStream file = new FileWorkWithStream(@"D:\Task3Xml.xml");

            List<Figure> newFigures = file.Read();

            Assert.AreEqual(newFigures.Count, 4);
        }
    }
}