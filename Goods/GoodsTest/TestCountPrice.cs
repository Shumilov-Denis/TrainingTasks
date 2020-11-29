using Goods;
using Goods.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoodsTest
{
    /// <summary>
    /// Test count price.
    /// </summary>
    [TestClass]
    public class TestCountPrice
    {
        /// <summary>
        /// Test count all price.
        /// </summary>
        [TestMethod]
        public void TestCountAllPrice()
        {
            Tv tvOne = new Tv(100, 10, 10);
            Tv tvTwo = new Tv(90, 10, 2);
            Phone phone = new Phone(50, 50, 3);
            Laptop laptop = new Laptop(200, 10, 4);

            double allPriceTvOne = tvOne.CountPriceAllProduct();
            double allPriceTvTwo = tvTwo.CountPriceAllProduct();
            double allPricePhone = phone.CountPriceAllProduct();
            double allPriceLaptop = laptop.CountPriceAllProduct();

            Assert.AreEqual(1100, allPriceTvOne);
            Assert.AreEqual(200, allPriceTvTwo);
            Assert.AreEqual(300, allPricePhone);
            Assert.AreEqual(840, allPriceLaptop);
        }

        /// <summary>
        /// Test count price per product.
        /// </summary>
        [TestMethod]
        public void TestCountAllPricePerOneProduct()
        {
            Tv tvOne = new Tv(100, 10, 10);
            Tv tvTwo = new Tv(90, 10, 2);
            Phone phone = new Phone(50, 50, 3);
            Laptop laptop = new Laptop(200, 10, 4);

            double allPriceTvOne = tvOne.CountPricePerProduct();
            double allPriceTvTwo = tvTwo.CountPricePerProduct();
            double allPricePhone = phone.CountPricePerProduct();
            double allPriceLaptop = laptop.CountPricePerProduct();

            Assert.AreEqual(110, allPriceTvOne);
            Assert.AreEqual(100, allPriceTvTwo);
            Assert.AreEqual(100, allPricePhone);
            Assert.AreEqual(210, allPriceLaptop);
        }
    }
}