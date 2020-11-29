using Exceptions;
using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Testing exception in products.
    /// </summary>
    [TestClass]
    public class TestValidationOfValues
    {
        /// <summary>
        /// Test price exception for extra charge.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PriceException))]
        public void TestPriceExceptionForExtraCharge()
        {
            Tv tv = new Tv(-10, 10, 3);
        }

        /// <summary>
        /// Test price exception for purchase price.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PriceException))]
        public void TestPriceExceptionForPurchasePrice()
        {
            Tv tv = new Tv(10, -10, 3);
        }

        /// <summary>
        /// Test number exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NumberException))]
        public void TestPriceExceptionForNumberOfUnits()
        {
            Tv tv = new Tv(10, 10, 0);
        }

        /// <summary>
        /// Test number exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NumberException))]
        public void TestIsUnCorrectDifference()
        {
            Tv tv = new Tv(10, 10, 1);
            int number = 10;
            Tv newTv = tv - number;
        }

        /// <summary>
        /// Test price exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TypeException))]
        public void TestIsCorrectType()
        {
            Tv tv = new Tv(10, 10, 1);
            Phone phone = new Phone(5, 5, 1);
            tv = tv + phone;
        }
    }
}