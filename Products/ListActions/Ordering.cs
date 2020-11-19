using Products;

namespace ListActions
{
    /// <summary>
    /// Basic operations on the product array.
    /// </summary>
    public static class Ordering
    {
        /// <summary>
        /// Array copy method.
        /// </summary>
        /// <param name="products">Products array.</param>
        /// <returns>The new copied array.</returns>
        private static Product[] CopyArray(Product[] products)
        {
            Product[] productsForSort = null;

            if (products.Length > 0)
            {
                productsForSort = new Product[products.Length];
                products.CopyTo(productsForSort, 0);
            }

            return productsForSort;
        }

        /// <summary>
        /// Permutation of two array elements.
        /// </summary>
        /// <param name="productsForArray">Products array.</param>
        /// <param name="indexOne">Index first element.</param>
        /// <param name="indexTwo">Index second element.</param>
        private static void SwipeProduct(Product[] productsForArray, int indexOne, int indexTwo)
        {
            Product temp = productsForArray[indexTwo];
            productsForArray[indexTwo] = productsForArray[indexOne];
            productsForArray[indexOne] = temp;
        }

        /// <summary>
        /// Sorting by product price.
        /// </summary>
        /// <param name="products">Products array.</param>
        /// <returns>The new sorted array.</returns>
        public static Product[] OrderingByPrice(Product[] products)
        {
            Product[] productsForArray = CopyArray(products);

            if (productsForArray != null)
            {
                Product maxProduct = productsForArray[0];

                for (int indexOne = 0; indexOne < productsForArray.Length; indexOne++)
                {
                    for (int indexTwo = indexOne; indexTwo < productsForArray.Length; indexTwo++)
                    {
                        if (productsForArray[indexOne].Price < productsForArray[indexTwo].Price)
                        {
                            SwipeProduct(productsForArray, indexOne, indexTwo);
                        }
                    }
                }
            }

            return productsForArray;
        }

        /// <summary>
        /// Sorting by product calories.
        /// </summary>
        /// <param name="products">Products array.</param>
        /// <returns>The new sorted array.</returns>
        public static Product[] OrderingByCalories(Product[] products)
        {
            Product[] productsForArray = CopyArray(products);

            if (productsForArray != null)
            {
                Product maxProduct = productsForArray[0];

                for (int indexOne = 0; indexOne < productsForArray.Length; indexOne++)
                {
                    for (int indexTwo = indexOne; indexTwo < productsForArray.Length; indexTwo++)
                    {
                        if (productsForArray[indexOne].Calories < productsForArray[indexTwo].Calories)
                        {
                            SwipeProduct(productsForArray, indexOne, indexTwo);
                        }
                    }
                }
            }

            return productsForArray;
        }
    }
}
