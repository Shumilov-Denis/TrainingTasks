namespace Goods
{
    /// <summary>
    /// Find price.
    /// </summary>
    public static class Act
    {
        /// <summary>
        /// Price calculation for one product.
        /// </summary>
        /// <returns>Price one product.</returns>
        public static double CountPricePerProduct(this Product product)
        {
            return product.ExtraCharge + product.PurchasePrice;
        }

        /// <summary>
        /// Price calculation for all products.
        /// </summary>
        /// <returns>Price all products.</returns>
        public static double CountPriceAllProduct(this Product product)
        {
            return product.NumberOfUnits * CountPricePerProduct(product);
        }
    }
}