namespace Shapes
{
    /// <summary>
    /// Material of products.
    /// </summary>
    public interface IMaterial
    {
        /// <summary>
        /// Can material painting.
        /// </summary>
        bool CanPainting();

        /// <summary>
        /// Get material of figure.
        /// </summary>
        /// <returns></returns>
        string GetMaterial();
    }
}