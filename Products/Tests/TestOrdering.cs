using System;
using System.Collections.Generic;
using Items;
using Items.List_of_items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;
using Products.List_of_products;
using ListActions;

namespace Tests
{
    [TestClass]
    public class TestOrdering
    {
        /// <summary>
        /// Testing the price sorting method.
        /// </summary>
        [TestMethod]
        public void TestOrderingByPrice()
        {
            Product[] products = new Product[]
            {
                new Bread(1, new List<Item>(){ new Flour(100,2), new Egg(10,2), new Yeast(1,5), new Sugar(5,2), new Salt(1, 1)}),
                new Baton(1, new List<Item>(){new Flour(300, 3), new Egg(200,3), new Sugar(10, 3), new Salt(10,4)}),
                new Bread(2, new List<Item>(){new Flour(50,4), new Water(10, 1)}),
                new Bun(10, new List<Item>(){new Flour(500,3), new Water(40,1), new Egg(100,1), new Yeast(4,4)}), 
            };

            Product[] newProducts = Ordering.OrderingByPrice(products);

            Assert.AreEqual(newProducts[0], products[3]);
            Assert.AreEqual(newProducts[1], products[1]);
            Assert.AreEqual(newProducts[2], products[0]);
            Assert.AreEqual(newProducts[3], products[2]);
        }


        /// <summary>
        /// Calorie sorting method testing.
        /// </summary>
        [TestMethod]
        public void TestOrderingByCalories()
        {
            Product[] products = new Product[]
            {
                new Bread(1, new List<Item>(){ new Flour(100,2), new Egg(10,2), new Yeast(1,5), new Sugar(5,2), new Salt(1, 1)}),
                new Baton(1, new List<Item>(){new Flour(300, 3), new Egg(200,3), new Sugar(10, 3), new Salt(10,4)}),
                new Bread(2, new List<Item>(){new Flour(50,4), new Water(10, 1)}),
                new Bun(10, new List<Item>(){new Flour(500,3), new Water(40,1), new Egg(100,1), new Yeast(4,4)}),
            };

            Product[] newProducts = Ordering.OrderingByCalories(products);

            Assert.AreEqual(newProducts[0], products[3]);
            Assert.AreEqual(newProducts[1], products[1]);
            Assert.AreEqual(newProducts[2], products[0]);
            Assert.AreEqual(newProducts[3], products[2]);
        }
    }
}
