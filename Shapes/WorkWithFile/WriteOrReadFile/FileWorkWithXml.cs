using Shapes;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WorkWithFile.WriteOrReadFile
{
    public class FileWorkWithXml : File, IFile
    {
        /// <summary>
        /// Create new way to file.
        /// </summary>
        /// <param name="way"></param>
        public FileWorkWithXml(string way) : base(way)
        {
        }

        /// <summary>
        /// Save list with figures in file.
        /// </summary>
        /// <param name="figures">List with figures.</param>
        public void Save(List<Figure> figures)
        {
            using (XmlWriter write = XmlWriter.Create(Way))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(List<Figure>));
                serializerXml.Serialize(write, figures);
            }
        }

        /// <summary>
        /// Read information about figure from file.
        /// </summary>
        /// <returns></returns>
        public List<Figure> Read()
        {
            List<Figure> figures = null;

            using (XmlReader file = XmlReader.Create(Way))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(List<Figure>));
                figures = serializerXml.Deserialize(file) as List<Figure>;
            }

            return figures;
        }
    }
}