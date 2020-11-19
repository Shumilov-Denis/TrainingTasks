using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    /// <summary>
    /// Class for calculating full price and calories.
    /// </summary>
    static class CalculationOfCharacteristics
    {
        /// <summary>
        /// Count full price.
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <param name="unitPrice">Price per gram of product.</param>
        /// <returns>Full price.</returns>
        public static double CountPrice(double weight, double unitPrice)
        {
            return weight * unitPrice;
        }

        /// <summary>
        /// Count full calories. 
        /// </summary>
        /// <param name="weight">Weight of item.</param>
        /// <returns>Full calories.</returns>
        public static double CountCalories(double weight, double unitCalories)
        {
            return weight * unitCalories;
        }
    }
}
