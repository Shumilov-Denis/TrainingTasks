using Exceptions;
using System;

namespace Goods
{
    /// <summary>
    /// Validation of values
    /// </summary>
    internal static class ValidationOfValues
    {
        /// <summary>
        /// Checking the values required to create an object.
        /// </summary>
        /// <param name="purchasePrice">Purchase price.</param>
        /// <param name="extraCharge">Extra charges.</param>
        /// <param name="numberOfUnits">Number of units.</param>
        public static void CheckingValue(double purchasePrice, double extraCharge, int numberOfUnits)
        {
            if (purchasePrice <= 0)
            {
                throw new PriceException("Price cannot be less then zero", purchasePrice);
            }

            if (extraCharge <= 0)
            {
                throw new PriceException("Price cannot be less then zero", extraCharge);
            }

            if (numberOfUnits <= 0)
            {
                throw new NumberException("Number of units cannot be less then null.", numberOfUnits);
            }
        }

        /// <summary>
        /// Validation of the value.
        /// </summary>
        /// <param name="numberOfProduct">Number of products.</param>
        /// <param name="value">A value derived from the number of products.</param>
        /// <returns>New number of products.</returns>
        public static int IsUnCorrectDifference(int numberOfProduct, int value)
        {
            int newNumberOfProduct = numberOfProduct - value;

            if (newNumberOfProduct <= 0)
            {
                throw new NumberException("Number of units cannot be less then null.", newNumberOfProduct);
            }

            return newNumberOfProduct;
        }

        /// <summary>
        /// Checking type.
        /// </summary>
        /// <param name="mainType">Main type.</param>
        /// <param name="secondType">Second type.</param>
        public static void IsCorrectType(Type mainType, Type secondType)
        {
            if (mainType != secondType)
            {
                throw new TypeException("Objects cannot be stacked.", secondType);
            }
        }
    }
}