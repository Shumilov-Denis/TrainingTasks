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
    }
}