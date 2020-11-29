using System;
using System.Runtime.Serialization;

namespace Goods.Products
{
    /// <summary>
    /// Laptop.
    /// </summary>
    [DataContract]
    public class Laptop : Product
    {
        /// <summary>
        /// Name.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Purchase price.
        /// </summary>
        public sealed override double PurchasePrice { get; set; }

        /// <summary>
        /// Extra charge.
        /// </summary>
        public sealed override double ExtraCharge { get; set; }

        /// <summary>
        /// Number of units.
        /// </summary>
        public sealed override int NumberOfUnits { get; set; }

        /// <summary>
        /// Create new Laptop.
        /// </summary>
        /// <param name="extraCharge">Extra charge.</param>
        /// <param name="purchasePrice">Purchase price.</param>
        /// <param name="numberOfUnits">Number of units.</param>
        public Laptop(double extraCharge, double purchasePrice, int numberOfUnits)
        {
            ValidationOfValues.CheckingValue(purchasePrice, extraCharge, numberOfUnits);

            this.Name = "Laptop";
            this.PurchasePrice = purchasePrice;
            this.ExtraCharge = extraCharge;
            this.NumberOfUnits = numberOfUnits;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode();
            hashCode += PurchasePrice.GetHashCode();
            hashCode += ExtraCharge.GetHashCode();
            hashCode += NumberOfUnits.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True if the object is equal.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Laptop);
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        /// <returns>True if the object is equal.</returns>
        private bool Equals(Laptop laptop)
        {
            return this.ExtraCharge == laptop.ExtraCharge && this.PurchasePrice == laptop.PurchasePrice;
        }

        /// <summary>
        /// Addition of two Laptop-type objects.
        /// </summary>
        /// <param name="firstLaptop">First Laptop.</param>
        /// <param name="product">Second Laptop.</param>
        /// <returns>New Laptop.</returns>
        public static Laptop operator +(Laptop firstLaptop, Product product)
        {
            ValidationOfValues.IsCorrectType(firstLaptop.GetType(), product.GetType());
            Laptop secondLaptop = product as Laptop;
            return new Laptop((firstLaptop.ExtraCharge + secondLaptop.ExtraCharge) / 2, (firstLaptop.PurchasePrice + secondLaptop.PurchasePrice) / 2, firstLaptop.NumberOfUnits + secondLaptop.NumberOfUnits);
        }

        /// <summary>
        /// Reducing the number of products.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        /// <param name="number">Number of products.</param>
        /// <returns>new Laptop.</returns>
        public static Laptop operator -(Laptop laptop, int number)
        {
            int newNumberOfProduct = ValidationOfValues.IsUnCorrectDifference(laptop.NumberOfUnits, number);
            return new Laptop(laptop.ExtraCharge, laptop.PurchasePrice, newNumberOfProduct);
        }

        /// <summary>
        /// Casting to type: double.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        public static explicit operator double(Laptop laptop)
        {
            return laptop.CountPriceAllProduct();
        }

        /// <summary>
        /// Casting to type: int.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        public static explicit operator int(Laptop laptop)
        {
            return Convert.ToInt32(laptop.CountPriceAllProduct() * 100);
        }

        /// <summary>
        /// Casting to type: Phone.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        public static explicit operator Phone(Laptop laptop)
        {
            return new Phone(laptop.ExtraCharge, laptop.PurchasePrice, laptop.NumberOfUnits);
        }

        /// <summary>
        /// Casting to type: TV.
        /// </summary>
        /// <param name="laptop">Laptop.</param>
        public static explicit operator Tv(Laptop laptop)
        {
            return new Tv(laptop.ExtraCharge, laptop.PurchasePrice, laptop.NumberOfUnits);
        }

        /// <summary>
        /// Output information.
        /// </summary>
        /// <returns>String with information.</returns>
        public override string ToString()
        {
            return $"{Name} - Number: {NumberOfUnits} - Purchase price: {PurchasePrice} - Extra charge: {ExtraCharge}.";
        }
    }
}
