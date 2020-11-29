using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Product folding test
    /// </summary>
    [TestClass]
    public class TestSumProducts
    {
        /// <summary>
        /// TV sum test
        /// </summary>
        [TestMethod]
        public void TestSumTv()
        {
            Tv tvFirst = new Tv(100, 10, 2);
            Tv tvSecond = new Tv(200, 20, 1);

            tvFirst = tvFirst + tvSecond;

            Assert.AreEqual(150, tvFirst.ExtraCharge);
            Assert.AreEqual(15, tvFirst.PurchasePrice);
            Assert.AreEqual(3, tvFirst.NumberOfUnits);
        }

        /// <summary>
        /// Phone sum test
        /// </summary>
        [TestMethod]
        public void TestSumPhone()
        {
            Phone phoneFirst = new Phone(50, 10, 3);
            Phone phoneSecond = new Phone(150, 20, 6);

            phoneFirst = phoneFirst + phoneSecond;

            Assert.AreEqual(100, phoneFirst.ExtraCharge);
            Assert.AreEqual(15, phoneFirst.PurchasePrice);
            Assert.AreEqual(9, phoneFirst.NumberOfUnits);
        }

        /// <summary>
        /// Laptop sum test
        /// </summary>
        [TestMethod]
        public void TestSumLaptop()
        {
            Laptop laptopFirst = new Laptop(300, 50, 5);
            Laptop laptopSecond = new Laptop(300, 60, 5);

            laptopFirst = laptopFirst + laptopSecond;

            Assert.AreEqual(300, laptopFirst.ExtraCharge);
            Assert.AreEqual(55, laptopFirst.PurchasePrice);
            Assert.AreEqual(10, laptopFirst.NumberOfUnits);
        }
    }
}