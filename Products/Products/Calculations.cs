using Items;
using System.Collections.Generic;

namespace Products
{
    /// <summary>
    /// Calculation price and calories.
    /// </summary>
    internal static class Calculations
    {
        /// <summary>
        /// Count full price.
        /// </summary>
        /// <returns>Full price.</returns>
        public static double CountPrice(List<Item> items, double extraCharge)
        {
            double fullPrice = 0;

            foreach (var item in items)
            {
                fullPrice += item.Price;
            }

            return fullPrice + extraCharge;
        }

        /// <summary>
        /// Count calories.
        /// </summary>
        /// <returns>Calories.</returns>
        public static double CountCalories(List<Item> items)
        {
            double calories = 0;

            foreach (var item in items)
            {
                calories += item.Calories;
            }

            return calories;
        }
    }
}
