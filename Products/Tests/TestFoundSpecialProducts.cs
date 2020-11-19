using System;
using System.Collections.Generic;
using System.Configuration;
using Items;
using Items.List_of_items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;
using Products.List_of_products;
using ListActions;

namespace Tests
{
    [TestClass]
    public class TestFoundSpecialProducts
    {
        /// <summary>
        /// Checking the search for identical products by price and calorie content.
        /// </summary>
        [TestMethod]
        public void TestFindingEqualElements()
        {
            Product[] products = new Product[]
            {
                new Bread(1, new List<Item>(){ new Flour(100,2), new Egg(10,2), new Yeast(1,5), new Sugar(5,2), new Salt(1, 1)}),
                new Baton(1, new List<Item>(){new Flour(300, 3), new Egg(200,3), new Sugar(10, 3), new Salt(10,4)}),
                new Bread(2, new List<Item>(){new Flour(50,4), new Water(10, 1)}),
                new Bun(10, new List<Item>(){new Flour(500,3), new Water(40,1), new Egg(100,1), new Yeast(4,4)}),
            };

            Product product = new Baton(1, new List<Item>() { new Flour(300, 3), new Egg(200, 3), new Sugar(10, 3), new Salt(10, 4) });

            var productList = products.FindingEqualElements(product);

            Assert.AreEqual(products[1], productList[0]);
        }

        /// <summary>
        /// Checking the search for products that use a specific ingredient with a specific mass.
        /// </summary>
        [TestMethod]
        public void TestSearchForIngredientsWithSpecificWeight()
        {
            Product[] products = new Product[]
            {
                new Bread(1, new List<Item>(){ new Flour(100,2), new Egg(10,2), new Yeast(1,5), new Sugar(5,2), new Salt(1, 1)}),
                new Baton(1, new List<Item>(){new Flour(300, 3), new Egg(200,3), new Sugar(10, 3), new Salt(10,4)}),
                new Bread(2, new List<Item>(){new Flour(50,4), new Water(10, 1)}),
                new Bun(10, new List<Item>(){new Flour(500,3), new Water(40,1), new Egg(100,1), new Yeast(4,4)}),
            };

            Flour flour = new Flour(200, 1);

            var productList = products.SearchForIngredientsWithSpecificWeight<Flour>(flour);

            Assert.AreEqual(2, productList.Count);
            Assert.AreEqual(products[1], productList[0]);
            Assert.AreEqual(products[3], productList[1]);
        }

        /// <summary>
        /// Checking the search for products greater than the specified number of products.
        /// </summary>
        [TestMethod]
        public void TestSearchForProductsWithSpecificNumberOfItems()
        {
            Product[] products = new Product[]
            {
                new Bread(1, new List<Item>(){ new Flour(100,2), new Egg(10,2), new Yeast(1,5), new Sugar(5,2), new Salt(1, 1)}),
                new Baton(1, new List<Item>(){new Flour(300, 3), new Egg(200,3), new Sugar(10, 3), new Salt(10,4)}),
                new Bread(2, new List<Item>(){new Flour(50,4), new Water(10, 1)}),
                new Bun(10, new List<Item>(){new Flour(500,3), new Water(40,1), new Egg(100,1), new Yeast(4,4)}),
            };

            var productList = products.SearchForProductsWithSpecificNumberOfItems(3);

            Assert.AreEqual(3, productList.Count);
            Assert.AreEqual(products[0], productList[0]);
            Assert.AreEqual(products[1], productList[1]);
            Assert.AreEqual(products[3], productList[2]);
        }
    }
}
