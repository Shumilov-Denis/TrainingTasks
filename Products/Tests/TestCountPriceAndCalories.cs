using System;
using System.Collections.Generic;
using Items;
using Items.List_of_items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.List_of_products;

namespace Tests
{
    [TestClass]
    public class TestCountPriceAndCalories
    {
        /// <summary>
        /// Test count price and calories.
        /// </summary>
        [TestMethod]
        public void TestCountPriceAndCaloriesBread()
        {
            Bread bread = new Bread(1, new List<Item>(){ new Flour(500, 1), new Water(50, 0.4)});

            Assert.AreEqual(521, bread.Price);
            Assert.AreEqual(1670, bread.Calories);
        }

        /// <summary>
        /// Test count price and calories.
        /// </summary>
        [TestMethod]
        public void TestCountPriceAndCaloriesBaton()
        {
            Baton baton = new Baton(1, new List<Item>() { new Flour(500, 1), new Water(50, 0.4), new Egg(50, 2) });

            Assert.AreEqual(621.1, baton.Price);
            Assert.AreEqual(1741, baton.Calories);
        }

        /// <summary>
        /// Test count price and calories.
        /// </summary>
        [TestMethod]
        public void TestCountPriceAndCaloriesBun()
        {
            Bun bun = new Bun(1, new List<Item>() { new Flour(500, 1), new Water(50, 0.4), new Egg(50, 2), new Sugar(10, 3), new Salt(1, 1) });

            Assert.AreEqual(652.1, bun.Price);
            Assert.AreEqual(1780.8, bun.Calories);
        }
    }
}
