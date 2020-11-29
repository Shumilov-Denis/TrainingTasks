using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Test override method.
    /// </summary>
    [TestClass]
    public class TestOverrideMethod
    {
        /// <summary>
        /// Test TV method equals.
        /// </summary>
        [TestMethod]
        public void TestTvMethodEquals()
        {
            Tv tvOne = new Tv(100, 100, 10);
            Tv tvTwo = new Tv(200, 50, 4);
            Tv tvThree = new Tv(100, 100, 3);

            Assert.IsFalse(tvOne.Equals(tvTwo));
            Assert.IsTrue(tvOne.Equals(tvThree));
        }

        /// <summary>
        /// Test TV method ToString.
        /// </summary>
        [TestMethod]
        public void TestTvMethodToString()
        {
            Tv tvOne = new Tv(100, 100, 10);
            Tv tvTwo = new Tv(200, 50, 4);
            Tv tvThree = new Tv(500, 100, 1);

            Assert.AreEqual("TV - Number: 10 - Purchase price: 100 - Extra charge: 100.", tvOne.ToString());
            Assert.AreEqual("TV - Number: 4 - Purchase price: 50 - Extra charge: 200.", tvTwo.ToString());
            Assert.AreEqual("TV - Number: 1 - Purchase price: 100 - Extra charge: 500.", tvThree.ToString());
        }

        /// <summary>
        /// Test Phone method equals.
        /// </summary>
        [TestMethod]
        public void TestPhoneMethodEquals()
        {
            Phone phoneOne = new Phone(100, 100, 10);
            Phone phoneTwo = new Phone(200, 50, 4);
            Phone phoneThree = new Phone(100, 100, 3);

            Assert.IsFalse(phoneOne.Equals(phoneTwo));
            Assert.IsTrue(phoneOne.Equals(phoneThree));
        }

        /// <summary>
        /// Test Phone method ToString.
        /// </summary>
        [TestMethod]
        public void TestPhoneMethodToString()
        {
            Phone phoneOne = new Phone(100, 100, 10);
            Phone phoneTwo = new Phone(200, 50, 4);
            Phone phoneThree = new Phone(500, 100, 3);

            Assert.AreEqual("Phone - Number: 10 - Purchase price: 100 - Extra charge: 100.", phoneOne.ToString());
            Assert.AreEqual("Phone - Number: 4 - Purchase price: 50 - Extra charge: 200.", phoneTwo.ToString());
            Assert.AreEqual("Phone - Number: 3 - Purchase price: 100 - Extra charge: 500.", phoneThree.ToString());
        }

        /// <summary>
        /// Test Laptop method equals.
        /// </summary>
        [TestMethod]
        public void TestLaptopMethodEquals()
        {
            Laptop laptopOne = new Laptop(100, 100, 10);
            Laptop laptopTwo = new Laptop(200, 50, 4);
            Laptop laptopThree = new Laptop(100, 100, 3);

            Assert.IsFalse(laptopOne.Equals(laptopTwo));
            Assert.IsTrue(laptopOne.Equals(laptopThree));
        }

        /// <summary>
        /// Test Laptop method ToString.
        /// </summary>
        [TestMethod]
        public void TestLaptopMethodToString()
        {
            Laptop laptopOne = new Laptop(100, 100, 10);
            Laptop laptopTwo = new Laptop(200, 50, 4);
            Laptop laptopThree = new Laptop(500, 100, 3);

            Assert.AreEqual("Laptop - Number: 10 - Purchase price: 100 - Extra charge: 100.", laptopOne.ToString());
            Assert.AreEqual("Laptop - Number: 4 - Purchase price: 50 - Extra charge: 200.", laptopTwo.ToString());
            Assert.AreEqual("Laptop - Number: 3 - Purchase price: 100 - Extra charge: 500.", laptopThree.ToString());
        }
    }
}