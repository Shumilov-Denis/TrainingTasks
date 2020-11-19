using Items;
using Products;
using System.Collections.Generic;

namespace ListActions
{
    /// <summary>
    /// Basic methods for searching products by criteria.
    /// </summary>
    public static class FoundSpecialProducts
    {
        /// <summary>
        /// Search for products equal to the given one in terms of price and calories.
        /// </summary>
        /// <param name="products">Products array.</param>
        /// <param name="productForEqual">Product for comparison.</param>
        /// <returns>List with suitable products.</returns>
        public static List<Product> FindingEqualElements(this Product[] products, Product productForEqual)
        {
            var listWithEqualProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Calories == productForEqual.Calories && product.Price == productForEqual.Price)
                {
                    listWithEqualProducts.Add(product);
                }
            }

            return listWithEqualProducts;
        }

        /// <summary>
        /// Creating a list of products for which the volume of use the specified ingredient is greater than the specified value.
        /// </summary>
        /// <typeparam name="TItem">Item(Flour, Sugar and other).</typeparam>
        /// <param name="products">Products array.</param>
        /// <param name="itemForFound">Item for comparison.</param>
        /// <returns>List with suitable products.</returns>
        public static List<Product> SearchForIngredientsWithSpecificWeight<TItem>(this Product[] products, TItem itemForFound) where TItem : Item
        {
            var listWithProducts = new List<Product>();

            foreach (var product in products)
            {
                foreach (var item in product.Items)
                {
                    if (item is TItem && item.Weight > itemForFound.Weight)
                    {
                        listWithProducts.Add(product);
                    }
                }
            }

            return listWithProducts;
        }

        /// <summary>
        /// Finds the number of products with more ingredients than the specified number.
        /// </summary>
        /// <param name="products">Products array.</param>
        /// <param name="numberOfItem">Number of item.</param>
        /// <returns>List with suitable products.</returns>
        public static List<Product> SearchForProductsWithSpecificNumberOfItems(this Product[] products, int numberOfItem)
        {
            var listWithProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Items.Count >= numberOfItem)
                {
                    listWithProducts.Add(product);
                }
            }

            return listWithProducts;
        }
    }
}
