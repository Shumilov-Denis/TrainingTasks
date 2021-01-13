using System;
using Students;

namespace BinaryTree
{
    /// <summary>
    /// Node.
    /// </summary>
    /// <typeparam name="T">Type for comparable.</typeparam>
    public class Node<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Data about student.
        /// </summary>
        public Student<T> Data { get; set; }

        /// <summary>
        /// Left branch of tree.
        /// </summary>
        public Node<T> LeftBranch { get; set; }

        /// <summary>
        /// Right branch of tree.
        /// </summary>
        public Node<T> RightBranch { get; set; }

        /// <summary>
        /// Constructor for serialithation.
        /// </summary>
        private Node()
        {
        }

        /// <summary>
        /// Create new node.
        /// </summary>
        /// <param name="data">Data about student.</param>
        public Node(Student<T> data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Create new node.
        /// </summary>
        /// <param name="data">Data about student.</param>
        /// <param name="leftBranch">Left branch.</param>
        /// <param name="rightBranch">Right branch.</param>
        public Node(Student<T> data, Node<T> leftBranch, Node<T> rightBranch)
        {
            this.Data = data;
            this.LeftBranch = leftBranch;
            this.RightBranch = rightBranch;
        }

        /// <summary>
        /// Add new student in tree.
        /// </summary>
        /// <param name="data">Data about student.</param>
        internal void Add(Student<T> data)
        {
            var node = new Node<T>(data);

            if (data.TestResults.CompareTo(Data.TestResults) == -1)
            {
                if (LeftBranch == null)
                {
                    LeftBranch = node;
                }
                else
                {
                    LeftBranch.Add(data);
                }
            }
            else
            {
                if (RightBranch == null)
                {
                    RightBranch = node;
                }
                else
                {
                    RightBranch.Add(data);
                }
            }
        }
    }
}