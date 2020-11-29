using System;
using System.Runtime.Serialization;

namespace Goods.Products
{
    /// <summary>
    /// Phone.
    /// </summary>
    [DataContract]
    public class Phone : Product
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
        /// Create new Phone.
        /// </summary>
        /// <param name="extraCharge">Extra charge.</param>
        /// <param name="purchasePrice">Purchase price.</param>
        /// <param name="numberOfUnits">Number of units.</param>
        public Phone(double extraCharge, double purchasePrice, int numberOfUnits)
        {
            ValidationOfValues.CheckingValue(purchasePrice, extraCharge, numberOfUnits);

            this.Name = "Phone";
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
            return Equals(obj as Phone);
        }

        /// <summary>
        /// Comparison of objects.
        /// </summary>
        /// <param name="phone">Phone.</param>
        /// <returns>True if the object is equal.</returns>
        private bool Equals(Phone phone)
        {
            return this.ExtraCharge == phone.ExtraCharge && this.PurchasePrice == phone.PurchasePrice;
        }

        /// <summary>
        /// Addition of two Phone-type objects.
        /// </summary>
        /// <param name="firstPhone">First Phone.</param>
        /// <param name="product">Second Phone.</param>
        /// <returns>New Phone.</returns>
        public static Phone operator +(Phone firstPhone, Product product)
        {
            ValidationOfValues.IsCorrectType(firstPhone.GetType(), product.GetType());
            Phone secondPhone = product as Phone;
            return new Phone((firstPhone.ExtraCharge + secondPhone.ExtraCharge) / 2, (firstPhone.PurchasePrice + secondPhone.PurchasePrice) / 2, firstPhone.NumberOfUnits + secondPhone.NumberOfUnits);
        }

        /// <summary>
        /// Reducing the number of products.
        /// </summary>
        /// <param name="phone">Phone.</param>
        /// <param name="number">Number of products.</param>
        /// <returns>new Phone.</returns>
        public static Phone operator -(Phone phone, int number)
        {
            int newNumberOfProduct = ValidationOfValues.IsUnCorrectDifference(phone.NumberOfUnits, number);
            return new Phone(phone.ExtraCharge, phone.PurchasePrice, newNumberOfProduct);

        }

        /// <summary>
        /// Casting to type: double.
        /// </summary>
        /// <param name="phone">Phone.</param>
        public static explicit operator double(Phone phone)
        {
            return phone.CountPriceAllProduct();
        }

        /// <summary>
        /// Casting to type: int.
        /// </summary>
        /// <param name="phone">Phone.</param>
        public static explicit operator int(Phone phone)
        {
            return Convert.ToInt32(phone.CountPriceAllProduct() * 100);
        }

        /// <summary>
        /// Casting to type: Laptop.
        /// </summary>
        /// <param name="phone">Phone.</param>
        public static explicit operator Laptop(Phone phone)
        {
            return new Laptop(phone.ExtraCharge, phone.PurchasePrice, phone.NumberOfUnits);
        }

        /// <summary>
        /// Casting to type: TV.
        /// </summary>
        /// <param name="phone">Phone.</param>
        public static explicit operator Tv(Phone phone)
        {
            return new Tv(phone.ExtraCharge, phone.PurchasePrice, phone.NumberOfUnits);
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
