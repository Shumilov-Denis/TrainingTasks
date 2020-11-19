using Items;
using System;
using System.Collections.Generic;

namespace Products.List_of_products
{
    /// <summary>
    /// Baton.
    /// </summary>
    public class Baton : Product
    {
        /// <summary>
        /// Name.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Full price.
        /// </summary>
        public override double Price { get; }

        /// <summary>
        /// Calories.
        /// </summary>
        public override double Calories { get; }

        /// <summary>
        /// Number of goods.
        /// </summary>
        public override int NumberOfGoods { get; }

        /// <summary>
        /// List of items.
        /// </summary>
        public override List<Item> Items { get; }

        /// <summary>
        /// Extra charge.
        /// </summary>
        private const double ExtraCharge = 1.1;

        /// <summary>
        /// Create new product: baton.
        /// </summary>
        /// <param name="numberOfProducts">Number of products.</param>
        /// <param name="items">List of items.</param>
        public Baton(int numberOfProducts, List<Item> items)
        {
            if (numberOfProducts < 1)
            {
                throw new ArgumentException("Number of products cannot be less then 1.");
            }

            if (items == null)
            {
                throw new ArgumentException("List of items cannot be empty.");
            }

            this.Name = "Baton";
            this.Items = items;
            this.NumberOfGoods = numberOfProducts;
            this.Price = Calculations.CountPrice(Items, ExtraCharge);
            this.Calories = Calculations.CountCalories(Items);
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode();

            hashCode += NumberOfGoods.GetHashCode();
            hashCode += Price.GetHashCode();
            hashCode += Calories.GetHashCode();

            foreach (var item in Items)
            {
                hashCode += item.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True - if the weight of flours are equal.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>True - if the weight of flours are equal.</returns>
        private bool Equals(Product product)
        {
            return this.Name == product.Name && this.Items == product.Items && this.Price == product.Price;
        }

        /// <summary>
        /// Information about bread.
        /// </summary>
        /// <returns>Information about bread/</returns>
        public override string ToString()
        {
            return $"Baton. Price per one: {Price}. Calories per one: {Calories}. Number of products: {NumberOfGoods}.";
        }
    }
}
