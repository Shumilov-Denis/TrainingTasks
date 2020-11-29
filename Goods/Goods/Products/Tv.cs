using System;
using System.Runtime.Serialization;

namespace Goods.Products
{
    /// <summary>
    /// TV.
    /// </summary>
    [DataContract]
    public class Tv : Product
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
        /// Create new TV.
        /// </summary>
        /// <param name="extraCharge">Extra charge.</param>
        /// <param name="purchasePrice">Purchase price.</param>
        /// <param name="numberOfUnits">Number of units.</param>
        public Tv(double extraCharge, double purchasePrice, int numberOfUnits)
        {
            ValidationOfValues.CheckingValue(purchasePrice, extraCharge, numberOfUnits);

            this.Name = "TV";
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
            return Equals(obj as Tv);
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="tv">TV.</param>
        /// <returns>True if the object is equal.</returns>
        private bool Equals(Tv tv)
        {
            return this.ExtraCharge == tv.ExtraCharge && this.PurchasePrice == tv.PurchasePrice;
        }

        /// <summary>
        /// Addition of two TV-type objects.
        /// </summary>
        /// <param name="firstTv">First TV.</param>
        /// <param name="product">Second TV.</param>
        /// <returns>New TV.</returns>
        public static Tv operator +(Tv firstTv, Product product)
        {
            ValidationOfValues.IsCorrectType(firstTv.GetType(), product.GetType());
            Tv secondTv = product as Tv;
            return new Tv((firstTv.ExtraCharge + secondTv.ExtraCharge) / 2, (firstTv.PurchasePrice + secondTv.PurchasePrice) / 2, firstTv.NumberOfUnits + secondTv.NumberOfUnits);
        }

        /// <summary>
        /// Reducing the number of products.
        /// </summary>
        /// <param name="tv">TV.</param>
        /// <param name="number">Number of products.</param>
        /// <returns>new TV.</returns>
        public static Tv operator -(Tv tv, int number)
        {
            int newNumberOfProduct = ValidationOfValues.IsUnCorrectDifference(tv.NumberOfUnits, number);
            return new Tv(tv.ExtraCharge, tv.PurchasePrice, newNumberOfProduct);
        }

        /// <summary>
        /// Casting to type: double.
        /// </summary>
        /// <param name="tv">TV.</param>
        public static explicit operator double(Tv tv)
        {
            return tv.CountPriceAllProduct();
        }

        /// <summary>
        /// Casting to type: int.
        /// </summary>
        /// <param name="tv">TV.</param>
        public static explicit operator int(Tv tv)
        {
            return Convert.ToInt32(tv.CountPriceAllProduct() * 100);
        }

        /// <summary>
        /// Casting to type: Laptop.
        /// </summary>
        /// <param name="tv">TV.</param>
        public static explicit operator Laptop(Tv tv)
        {
            return new Laptop(tv.ExtraCharge, tv.PurchasePrice, tv.NumberOfUnits);
        }

        /// <summary>
        /// Casting to type: Phone.
        /// </summary>
        /// <param name="tv">TV.</param>
        public static explicit operator Phone(Tv tv)
        {
            return new Phone(tv.ExtraCharge, tv.PurchasePrice, tv.NumberOfUnits);
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