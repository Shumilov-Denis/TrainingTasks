namespace Items
{
    public abstract class Item
    {
        /// <summary>
        /// Name of item.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Weight of item. 
        /// </summary>
        public abstract double Weight { get; }

        /// <summary>
        /// All price of item.
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// All calories of item.
        /// </summary>
        public abstract double Calories { get; }

        /// <summary>
        /// Count price.
        /// </summary>
        /// <returns>Price.</returns>
        protected abstract double CountPrice(double weight, double unitPrice);

        /// <summary>
        /// Count calories.
        /// </summary>
        /// <returns>Calories.</returns>
        protected abstract double CountCalories(double weight);
    }
}