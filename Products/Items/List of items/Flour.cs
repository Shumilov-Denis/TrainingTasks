namespace Items.List_of_items
{
    /// <summary>
    /// Flour.
    /// </summary>
    public class Flour : Item
    {
        /// <summary>
        /// Name of item.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Weight of Flour.
        /// </summary>
        public override double Weight { get; }

        /// <summary>
        /// Price of Flour.
        /// </summary>
        public override double Price { get; }

        /// <summary>
        /// Calories of Flour.
        /// </summary>
        public override double Calories { get; }

        /// <summary>
        /// Calorie content of flour per gram.
        /// </summary>
        private const double UnitCalories = 3.34;

        /// <summary>
        /// Create new item: Flour.
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <param name="unitPrice">Price per gram of product.</param>
        public Flour(double weight, double unitPrice)
        {
            this.Name = "Flour";
            this.Weight = weight;
            this.Calories = CountCalories(weight);
            this.Price = CountPrice(weight, unitPrice);

        }


        /// <summary>
        /// Count full price of item.
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <param name="unitPrice">Price per gram of product.</param>
        /// <returns>Full price.</returns>
        protected sealed override double CountPrice(double weight, double unitPrice)
        {
            return weight * unitPrice;
        }

        /// <summary>
        /// Count full calories.
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <returns>Full calories.</returns>
        protected sealed override double CountCalories(double weight)
        {
            return (int)(weight * UnitCalories);
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
        /// Information about Flour.
        /// </summary>
        /// <returns>Information about Flour.</returns>
        public override string ToString()
        {
            return $"Name: {Name}. Weight: {Weight}. Calories: {Calories}. Price: {Price}.";
        }
    }
}