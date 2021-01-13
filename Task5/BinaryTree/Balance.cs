using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    internal static class Balance<T> where T : IComparable<T>
    {
        /// <summary>
        /// Count size branch.
        /// </summary>
        /// <param name="root">Root.</param>
        /// <returns>Size of tree.</returns>
        private static int CountSizeBranch(Node<T> root)
        {
            int height = 0;

            if (root != null)
            {
                height = 1 + Math.Max(CountSizeBranch(root.LeftBranch), CountSizeBranch(root.RightBranch));
            }

            return height;
        }

        /// <summary>
        /// Balance factor.
        /// </summary>
        /// <param name="root">Root for count balance factor.</param>
        /// <returns>Balance factor.</returns>
        private static int BalanceFactor(Node<T> root)
        {
            return CountSizeBranch(root.LeftBranch) - CountSizeBranch(root.RightBranch);
        }

        /// <summary>
        /// Balance node.
        /// </summary>
        /// <param name="root">Root for balance.</param>
        /// <returns>New root.</returns>
        internal static Node<T> BalanceTree(Node<T> root)
        {
            Node<T> newRoot = root;

            if (BalanceFactor(root) == -2)
            {
                if (BalanceFactor(root.RightBranch) > 0)
                {
                    root.RightBranch = RightRotation(root.RightBranch);
                }
                newRoot = LeftRotation(root);
            }
            else if (BalanceFactor(root) == 2)
            {
                if (BalanceFactor(root.LeftBranch) < 0)
                {
                    root.LeftBranch = LeftRotation(root.LeftBranch);
                }
                newRoot = RightRotation(root);
            }

            return newRoot;
        }

        /// <summary>
        /// Left rotaton.
        /// </summary>
        /// <param name="root">Root.</param>
        /// <returns>New root.</returns>
        private static Node<T> LeftRotation(Node<T> root)
        {
            Node<T> newRoot = root.RightBranch;
            root.RightBranch = newRoot.LeftBranch;
            newRoot.LeftBranch = root;
            return newRoot;
        }

        /// <summary>
        /// Left-Right rotation.
        /// </summary>
        /// <param name="root">Root.</param>
        /// <returns>New root.</returns>
        private static Node<T> LeftRightRotation(Node<T> root)
        {
            Node<T> newRoot = LeftRotation(root.RightBranch);
            return RightRotation(newRoot.LeftBranch);
        }

        /// <summary>
        /// Right-Left rotation.
        /// </summary>
        /// <param name="root">Root.</param>
        /// <returns>New root.</returns>
        private static Node<T> RightLeftRotation(Node<T> root)
        {
            Node<T> newRoot = RightRotation(root.LeftBranch);
            return LeftRotation(newRoot.RightBranch);
        }

        /// <summary>
        /// Right rotation.
        /// </summary>
        /// <param name="root">Root.</param>
        /// <returns>New root.</returns>
        private static Node<T> RightRotation(Node<T> root)
        {
            Node<T> newRoot = root.LeftBranch;
            root.LeftBranch = newRoot.RightBranch;
            newRoot.RightBranch = root;
            return newRoot;
        }
    }
}
