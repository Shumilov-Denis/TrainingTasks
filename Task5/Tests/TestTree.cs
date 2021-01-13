using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students;
using BinaryTree;
using System;
using WorkWithFile;

namespace Tests
{
    /// <summary>
    /// Test tree.
    /// </summary>
    [TestClass]
    public class TestTree
    {
        /// <summary>
        /// Test add new node in tree.
        /// </summary>
        [TestMethod]
        public void TestAddToTree()
        {
            Student<int> student1 = new Student<int>("A", "A", DateTime.Now, 10);
            Student<int> student2 = new Student<int>("B", "q", DateTime.Now, 11);
            Student<int> student3 = new Student<int>("C", "w", DateTime.Now, 9);
            Student<int> student4 = new Student<int>("V", "e", DateTime.Now, 7);

            Tree<int> tree = new Tree<int>();
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);

            Assert.AreEqual(4, tree.Count);
            Assert.AreEqual(student1, tree.Root.Data);
            Assert.AreEqual(student2, tree.Root.RightBranch.Data);
            Assert.AreEqual(student3, tree.Root.LeftBranch.Data);
            Assert.AreEqual(student4, tree.Root.LeftBranch.LeftBranch.Data);
        }

        /// <summary>
        /// Test balance tree.
        /// </summary>
        [TestMethod]
        public void TestBalanceTree()
        {
            Student<int> student1 = new Student<int>("A", "A", DateTime.Now, 10);
            Student<int> student2 = new Student<int>("B", "q", DateTime.Now, 9);
            Student<int> student3 = new Student<int>("C", "w", DateTime.Now, 8);
            Student<int> student4 = new Student<int>("V", "e", DateTime.Now, 7);
            Student<int> student5 = new Student<int>("V", "e", DateTime.Now, 6);

            Tree<int> tree = new Tree<int>();
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            tree.Add(student5);

            Assert.AreEqual(student1, tree.Root.RightBranch.RightBranch.Data);
            Assert.AreEqual(student2, tree.Root.RightBranch.Data);
            Assert.AreEqual(student3, tree.Root.Data);
            Assert.AreEqual(student4, tree.Root.LeftBranch.Data);
            Assert.AreEqual(student5, tree.Root.LeftBranch.LeftBranch.Data);
        }

        /// <summary>
        /// Test save tree in Xml file.
        /// </summary>
        [TestMethod]
        public void TestSaveTreeInXmlFile()
        {
            Student<int> student1 = new Student<int>("A", "A", DateTime.Now, 10);
            Student<int> student2 = new Student<int>("B", "q", DateTime.Now, 9);
            Student<int> student3 = new Student<int>("C", "w", DateTime.Now, 8);
            Student<int> student4 = new Student<int>("V", "e", DateTime.Now, 7);

            Tree<int> tree = new Tree<int>();
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);

            FileXML<int> file = new FileXML<int>(@"D:\test.xml");

            file.Save(tree);
        }

        /// <summary>
        /// Test read from file.
        /// </summary>
        [TestMethod]
        public void TestReadFromFile()
        {
            FileXML<int> file = new FileXML<int>(@"D:\test.xml");
            Tree<int> tree = file.Read();

            Assert.AreEqual(4, tree.Count);
            Assert.AreEqual(9, tree.Root.Data.TestResults);
            Assert.AreEqual(10, tree.Root.RightBranch.Data.TestResults);
            Assert.AreEqual(8, tree.Root.LeftBranch.Data.TestResults);
            Assert.AreEqual(7, tree.Root.LeftBranch.LeftBranch.Data.TestResults);
        }
    }
}
