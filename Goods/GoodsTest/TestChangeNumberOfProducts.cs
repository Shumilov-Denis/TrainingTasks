using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Test change number of products.
    /// </summary>
    [TestClass]
    public class TestChangeNumberOfProducts
    {
        /// <summary>
        /// Test change TV number.
        /// </summary>
        [TestMethod]
        public void TestChangeNumberOfTv()
        {
            Tv tv = new Tv(100, 10, 15);

            tv = tv - 10;

            Assert.AreEqual(5, tv.NumberOfUnits);
        }

        /// <summary>
        /// Test change phone number.
        /// </summary>
        [TestMethod]
        public void TestChangeNumberOfPhone()
        {
            Phone phone = new Phone(100, 10, 60);

            phone = phone - 10;

            Assert.AreEqual(50, phone.NumberOfUnits);
        }

        /// <summary>
        /// Test change laptop number.
        /// </summary>
        [TestMethod]
        public void TestChangeNumberOfLaptop()
        {
            Laptop laptop = new Laptop(100, 10, 15);

            laptop = laptop - (-10);

            Assert.AreEqual(25, laptop.NumberOfUnits);
        }
    }
}