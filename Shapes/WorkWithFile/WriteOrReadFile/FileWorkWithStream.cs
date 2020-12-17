using Shapes;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WorkWithFile.WriteOrReadFile
{
    public class FileWorkWithStream : File, IFile
    {
        /// <summary>
        /// Create new way to file.
        /// </summary>
        /// <param name="way">Way to file.</param>
        public FileWorkWithStream(string way) : base(way)
        {
        }

        /// <summary>
        /// Write information in file.
        /// </summary>
        /// <param name="figures">List with figures for writing.</param>
        public void Save(List<Figure> figures)
        {
            using (StreamWriter file = new StreamWriter(Way, false))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(List<Figure>));
                serializerXml.Serialize(file, figures);
            }
        }

        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <returns>List with figure.</returns>
        public List<Figure> Read()
        {
            List<Figure> figures = null;

            using (StreamReader file = new StreamReader(Way))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(List<Figure>));
                figures = serializerXml.Deserialize(file) as List<Figure>;
            }

            return figures;
        }
    }
}