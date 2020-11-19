using Items;
using System.Collections.Generic;

namespace Products
{
    /// <summary>
    /// Product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Name of product.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Full price.
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Calories.
        /// </summary>
        public abstract double Calories { get; }

        /// <summary>
        /// Number of goods.
        /// </summary>
        public abstract int NumberOfGoods { get; }

        /// <summary>
        /// List of items.
        /// </summary>
        public abstract List<Item> Items { get; }
    }
}