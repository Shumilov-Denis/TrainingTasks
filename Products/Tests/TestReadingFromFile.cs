using Items.List_of_items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.List_of_products;
using ReadingFromFile;

namespace Tests
{
    [TestClass]
    public class TestReadingFromFile
    {
        /// <summary>
        /// Check: the correct number of products will be read from the file.
        /// </summary>
        [TestMethod]
        public void TestNumberOfProductsInFile()
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();

            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Checking whether the products read from the file are of the correct type.
        /// </summary>
        [TestMethod]
        public void TestTypeAfterReadingFile()
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();

            Assert.IsTrue(list[0] is Bread);
            Assert.IsTrue(list[1] is Baton);
            Assert.IsFalse(list[2] is Baton);
            Assert.IsTrue(list[2] is Bun);
        }

        /// <summary>
        /// Checking whether the correct number of ingredients will be read from the file.
        /// </summary>
        [TestMethod]
        public void TestNumberOfItemInFile()
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();

            Assert.AreEqual(5, list[0].Items.Count);
            Assert.AreEqual(6, list[1].Items.Count);
            Assert.AreEqual(3, list[2].Items.Count);
        }

        /// <summary>
        /// Checking for compliance with the type of ingredients that read from the file.
        /// </summary>
        [TestMethod]
        public void TestItems()
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();

            Assert.IsTrue(list[0].Items[0] is Flour);
            Assert.IsTrue(list[0].Items[1] is Water);
            Assert.IsTrue(list[0].Items[2] is Butter);
            Assert.IsTrue(list[0].Items[3] is Sugar);
            Assert.IsTrue(list[0].Items[4] is Salt);
        }

        /// <summary>
        /// Checking the reading of the product number.
        /// </summary>
        [TestMethod]
        public void TestReadingNumberOfProducts()
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();

            Assert.AreEqual(20, list[0].NumberOfGoods);
            Assert.AreEqual(100, list[1].NumberOfGoods);
            Assert.AreEqual(100, list[2].NumberOfGoods);
        }
    }
}
