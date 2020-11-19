﻿using Items;
using Items.List_of_items;
using Products;
using Products.List_of_products;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadingFromFile
{
    /// <summary>
    /// Read file.
    /// </summary>
    public class Read
    {
        /// <summary>
        /// Way to text file.
        /// </summary>
        public string Way { get; set; }

        /// <summary>
        /// Create new way to text file.
        /// </summary>
        /// <param name="way"></param>
        public Read(string way)
        {
            if (String.IsNullOrWhiteSpace(way))
            {
                throw new ArgumentException("Way to file cannot be empty.");
            }

            this.Way = way;
        }

        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <returns></returns>
        private List<string> ReadInformationFromFile()
        {
            var information = new List<string>();

            using (StreamReader file = new StreamReader(Way, System.Text.Encoding.Default))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    information.Add(line);
                }
            }

            return information;
        }

        /// <summary>
        /// Create list with products.
        /// </summary>
        /// <returns>List of products.</returns>
        public List<Product> CreateList()
        {
            var information = ReadInformationFromFile();
            var listOfProduct = new List<Product>();

            for (int index = 0; index < information.Count; index++)
            {
                string[] productData = information[index].Split(new char[] { ' ' });
                if (IsProduct(productData[0]))
                {
                    var listOfItems = CreateListOfItems(ref index, information);
                    if (listOfItems != null)
                    {
                        listOfProduct.Add(CreateProduct(productData, listOfItems));
                    }
                }
            }

            return listOfProduct;
        }

        /// <summary>
        /// Create product.
        /// </summary>
        /// <param name="productData">Product data(Name and number).</param>
        /// <param name="items">List of items.</param>
        /// <returns>New product or null.</returns>
        private Product CreateProduct(string[] productData, List<Item> items)
        {
            Product product = null;

            switch (productData[0])
            {
                case "Bread":
                    Bread bread = new Bread(Convert.ToInt32(productData[1]), items);
                    product = bread; break;
                case "Baton":
                    Baton baton = new Baton(Convert.ToInt32(productData[1]), items);
                    product = baton; break;
                case "Bun":
                    Bun bun = new Bun(Convert.ToInt32(productData[1]), items);
                    product = bun; break;
            }

            return product;
        }


        /// <summary>
        /// Create list with items.
        /// </summary>
        /// <param name="lineNumberInFile">Number of checking line.</param>
        /// <param name="information">Information from file.</param>
        /// <returns>List of items.</returns>
        private List<Item> CreateListOfItems(ref int lineNumberInFile, List<string> information)
        {
            var listOfItems = new List<Item>();
            var isProduct = false;

            for (int indexTwo = lineNumberInFile + 1; indexTwo < information.Count && !isProduct; indexTwo++)
            {
                string[] itemData = information[indexTwo].Split(new char[] { ' ' });
                if (IsItem(itemData[0]) && CheckingItemData(itemData))
                {
                    listOfItems.Add(CreateItem(itemData));
                    lineNumberInFile++;
                }
                else
                {
                    isProduct = true;
                }
            }

            return listOfItems;
        }

        /// <summary>
        /// Checking the elements of item for correctness.
        /// </summary>
        /// <param name="itemData">Item data.</param>
        /// <returns>True - if data is correctness.</returns>
        private bool CheckingItemData(string[] itemData)
        {
            return Double.TryParse(itemData[1], out double weight) && Double.TryParse(itemData[2], out double price);
        }

        /// <summary>
        /// Create new item.
        /// </summary>
        /// <param name="itemData">Item data.</param>
        /// <returns>New item or null.</returns>
        private Item CreateItem(string[] itemData)
        {
            Item item = null;

            switch (itemData[0])
            {
                case "\tButter":
                    var butter = new Butter(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = butter; break;
                case "\tEgg":
                    var egg = new Egg(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = egg; break;
                case "\tFlour":
                    var flour = new Flour(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = flour; break;
                case "\tSalt":
                    var salt = new Salt(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = salt; break;
                case "\tSugar":
                    var sugar = new Sugar(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = sugar; break;
                case "\tWater":
                    var water = new Water(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = water; break;
                case "\tYeast":
                    var yeast = new Yeast(Convert.ToDouble(itemData[1]), Convert.ToDouble(itemData[2]));
                    item = yeast; break;
            }

            return item;
        }

        /// <summary>
        /// Checking if it is a product.
        /// </summary>
        /// <param name="type">String for checking.</param>
        /// <returns>True - if it is a product.</returns>
        private bool IsProduct(string type)
        {
            return type == "Bread" || type == "Baton" || type == "Bun";
        }

        /// <summary>
        /// Checking if it is a item.
        /// </summary>
        /// <param name="type">String for checking.</param>
        /// <returns>True - if it is a item.</returns>
        private bool IsItem(string type)
        {
            return type == "\tButter" || type == "\tEgg" || type == "\tFlour" || type == "\tSalt" || type == "\tSugar" || type == "\tWater" || type == "\tYeast";
        }
    }
}
