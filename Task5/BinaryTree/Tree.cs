using System;
using System.Collections.Generic;
using System.Text;
using Students;

namespace BinaryTree
{
    /// <summary>
    /// Binary tree.
    /// </summary>
    /// <typeparam name="T">Type for comparable.</typeparam>
    [Serializable]
    public class Tree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Root.
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Number of node.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Add new node in tree.
        /// </summary>
        /// <param name="data"></param>
        public void Add(Student<T> data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Root = Balance<T>.BalanceTree(Root);
            Count++;
        }
    }
}
