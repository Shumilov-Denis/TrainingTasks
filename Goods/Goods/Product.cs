using System.Runtime.Serialization;
using Goods.Products;

namespace Goods
{
    /// <summary>
    /// Product.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Tv))]
    [KnownType(typeof(Phone))]
    [KnownType(typeof(Laptop))]
    public abstract class Product
    {
        /// <summary>
        /// Name of product.
        /// </summary>
        [DataMember]
        public abstract string Name { get; set; }

        /// <summary>
        /// Purchase price.
        /// </summary>
        [DataMember]
        public abstract double PurchasePrice { get; set; }

        /// <summary>
        /// Extra charge.
        /// </summary>
        [DataMember]
        public abstract double ExtraCharge { get; set; }

        /// <summary>
        /// Number of units.
        /// </summary>
        [DataMember]
        public abstract int NumberOfUnits { get; set; }
    }
}