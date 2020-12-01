using Goods;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace WorkWithFile
{
    /// <summary>
    /// File json.
    /// </summary>
    public class File : IFile
    {
        /// <summary>
        /// Way to file.
        /// </summary>
        public string Way { get; set; }

        /// <summary>
        /// Create new file.
        /// </summary>
        /// <param name="way"></param>
        public File(string way)
        {
            this.Way = way;
        }

        /// <summary>
        /// Read information.
        /// </summary>
        /// <returns>List with products.</returns>
        public List<Product> Read()
        {
            List<Product> products;
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            using (var file = new FileStream(Way, FileMode.OpenOrCreate))
            {
                products = jsonFormatter.ReadObject(file) as List<Product>;
            }

            return products;
        }

        /// <summary>
        /// Save information.
        /// </summary>
        /// <param name="products">List with product for save.</param>
        public void Save(List<Product> products)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            using (var file = new FileStream(Way, FileMode.OpenOrCreate))
            {
                if (file == null)
                {
                    jsonFormatter.WriteObject(file, products);
                }
            }
        }
    }
}
