﻿namespace Items.List_of_items
{
    /// <summary>
    /// Salt.
    /// </summary>
    public class Salt : Item
    {
        /// <summary>
        /// Name of product.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Weight of salt.
        /// </summary>
        public override double Weight { get; }

        /// <summary>
        /// Price of salt.
        /// </summary>
        public override double Price { get; }

        /// <summary>
        /// Calories of salt.
        /// </summary>
        public override double Calories { get; }

        /// <summary>
        /// Unit calories of the salt.
        /// </summary>
        private const double UnitCalories = 0;

        /// <summary>
        /// Create new item: salt.
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <param name="unitPrice">Price per gram of product.</param>
        public Salt(double weight, double unitPrice)
        {
            this.Name = "Salt";
            this.Weight = weight;
            this.Price = CalculationOfCharacteristics.CountPrice(weight, unitPrice);
            this.Calories = CalculationOfCharacteristics.CountCalories(weight, UnitCalories);
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode();
            hashCode += Weight.GetHashCode();
            hashCode += Price.GetHashCode();
            hashCode += Calories.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True - if the weight of flours are equal.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <returns>True - if the weight of flours are equal.</returns>
        private bool Equals(Item item)
        {
            return this.Name == item.Name && this.Weight == item.Weight && this.Price == item.Price && this.Calories == item.Calories;
        }

        /// <summary>
        /// Information about salt.
        /// </summary>
        /// <returns>Information about salt.</returns>
        public override string ToString()
        {
            return $"Name: {Name}. Weight: {Weight}. Calories: {Calories}. Price: {Price}.";
        }
    }
}