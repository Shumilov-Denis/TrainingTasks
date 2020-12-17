using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using Shapes.ShapesOfFigure.Circles;
using Shapes.ShapesOfFigure.Rectangles;
using System.Collections.Generic;
using WorkWithFile.WriteOrReadFile;

namespace WorkWithFileTest
{
    /// <summary>
    /// Test Save/Read in file with StreamWriter/StreamReader.
    /// </summary>
    [TestClass]
    public class TestXmlFile
    {
        /// <summary>
        /// Test write in XML file with use XmlWriter.
        /// </summary>
        [TestMethod]
        public void TestXmlWriter()
        {
            List<Figure> figures = new List<Figure>()
            {
                new PaperCircle(3),
                new FilmCircle(2),
                new PlasticCircle(1),
                new FilmRectangle(10, 10)
            };

            FileWorkWithXml file = new FileWorkWithXml(@"D:\Task3Xml.xml");

            file.Save(figures);
        }

        /// <summary>
        /// Test read list with figure from wile with use XmlWriter. Check type.
        /// </summary>

        [TestMethod]
        public void TestXmlReader()
        {
            FileWorkWithXml file = new FileWorkWithXml(@"D:\Task3Xml.xml");
            List<Figure> figures = file.Read();
            Assert.IsTrue(figures[0] is PaperCircle);
        }

        /// <summary>
        /// Test read list with figures from file which was write with use XmlWriter. Check type.
        /// </summary>
        [TestMethod]
        public void TestReadXmlFileCheckSizeOfFigure()
        {
            FileWorkWithXml file = new FileWorkWithXml(@"D:\Task3.xml");

            List<Figure> newFigures = file.Read();

            Assert.AreEqual(newFigures.Count, 6);
        }
    }
}