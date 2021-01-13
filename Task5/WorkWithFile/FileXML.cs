using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BinaryTree;

namespace WorkWithFile
{
    /// <summary>
    /// Work with XML file (read/save).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileXML<T> where T : IComparable<T>
    {
        /// <summary>
        /// Way to file.
        /// </summary>
        public string Way { get; set; }

        /// <summary>
        /// Create new way to file.
        /// </summary>
        /// <param name="way">Way to file.</param>
        public FileXML(string way)
        {
            if (String.IsNullOrWhiteSpace(way))
            {
                throw new ArgumentException("Way to file cannot be null.");
            }

            this.Way = way;
        }

        /// <summary>
        /// Write information in file.
        /// </summary>
        /// <param name="figures">List with figures for writing.</param>
        public void Save(Tree<T> tree)
        {
            using (XmlWriter file = XmlWriter.Create(Way))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(Tree<T>));
                serializerXml.Serialize(file, tree);
            }
        }

        /// <summary>
        /// Read information from file.
        /// </summary>
        /// <returns>List with figure.</returns>
        public Tree<T> Read()
        {
            Tree<T> tree = null;

            using (XmlReader file = XmlReader.Create(Way))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(Tree<T>));
                tree = serializerXml.Deserialize(file) as Tree<T>;
            }

            return tree;
        }


        /// <summary>
        /// Information about way.
        /// </summary>
        /// <returns>Information about way.</returns>
        public override string ToString()
        {
            return $"Way to file: {Way}";
        }
    }
}
