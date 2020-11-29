using Goods;
using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FileTest
{
    [TestClass]
    public class TestFile
    {
        /// <summary>
        /// Test save in file.
        /// </summary>
        [TestMethod]
        public void TestSaveInFile()
        {
            List<Product> products = new List<Product>()
            {
                new Tv(100,100,2),
                new Phone(50,30,2),
                new Laptop(1000,100,2)
            };

            WorkWithFile.File file = new WorkWithFile.File(@"D:\Goods.json");

            file.Save(products);
        }

        /// <summary>
        /// Test read from file.
        /// </summary>
        [TestMethod]
        public void TestReadFromFile()
        {
            WorkWithFile.File file = new WorkWithFile.File(@"D:\Goods.json");

            List<Product> newProducts = file.Read();

            Assert.AreEqual(3, newProducts.Count);
            Assert.IsTrue(newProducts[0].Equals(new Tv(100, 100, 2)));
            Assert.IsTrue(newProducts[1].Equals(new Phone(50, 30, 2)));
            Assert.IsTrue(newProducts[2].Equals(new Laptop(1000, 100, 2)));
        }
    }
}