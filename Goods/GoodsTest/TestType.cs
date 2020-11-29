using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Test type.
    /// </summary>
    [TestClass]
    public class TestType
    {
        /// <summary>
        /// Test convert to int TV.
        /// </summary>
        [TestMethod]
        public void TestConvertToIntTv()
        {
            var tv = new Tv(10.5, 43.1, 2);

            int price = (int)tv;

            Assert.AreEqual(10720, price);
        }

        /// <summary>
        /// Test convert to double TV.
        /// </summary>
        [TestMethod]
        public void TestConvertToDoubleTv()
        {
            Tv tv = new Tv(10.5, 43.1, 2);

            double price = (double)tv;

            Assert.AreEqual(107.2, price);
        }

        /// <summary>
        /// Test convert to int Phone.
        /// </summary>
        [TestMethod]
        public void TestConvertToIntPhone()
        {
            Phone phone = new Phone(5.5, 1.1, 3);

            int price = (int)phone;

            Assert.AreEqual(1980, price);
        }

        /// <summary>
        /// Test convert to double Phone.
        /// </summary>
        [TestMethod]
        public void TestConvertToDoublePhone()
        {
            Phone phone = new Phone(5, 1.1, 2);

            double price = (double)phone;

            Assert.AreEqual(12.2, price);
        }

        /// <summary>
        /// Test convert to int Laptop.
        /// </summary>
        [TestMethod]
        public void TestConvertToIntLaptop()
        {
            Laptop laptop = new Laptop(100, 20.5, 4);

            int price = (int)laptop;

            Assert.AreEqual(48200, price);
        }

        /// <summary>
        /// Test convert to double Laptop.
        /// </summary>
        [TestMethod]
        public void TestConvertToDoubleLaptop()
        {
            Laptop laptop = new Laptop(100, 20.5, 4);

            double price = (double)laptop;

            Assert.AreEqual(482.0, price);
        }
    }
}