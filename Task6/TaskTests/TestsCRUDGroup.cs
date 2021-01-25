using CRUD;
using Databases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using University;

namespace TaskTests
{
    /// <summary>
    /// Test CRUD Group.
    /// </summary>
    [TestClass]
    public class TestsCRUDGroup
    {
        /// <summary>
        /// Connectiion string to database.
        /// </summary>
        static string connectionString = @"Data source=(localdb)\MSSQLLocalDB;Database=Task6;Integrated Security=true;";

        /// <summary>
        /// Database.
        /// </summary>
        Database databases = Database.GetDatabase(connectionString);

        /// <summary>
        /// Factory.
        /// </summary>
        CRUDFactory factory = new CRUDFactory();

        /// <summary>
        /// Test add data in group base.
        /// </summary>
        /// <param name="name">Group name.</param>
        [DataTestMethod]
        [DataRow("IS-11")]
        [DataRow("IS-12")]
        [DataRow("IS-21")]
        [DataRow("IS-22")]
        [DataRow("IS-31")]
        [DataRow("IS-32")]
        [DataRow("IS-41")]
        [DataRow("IS-42")]
        public void TestAddDataInGroupBase(string name)
        {
            Group group = new Group(name);
            int numberOfGroups = factory.GroupFactory().Select().Count;

            factory.GroupFactory().Insert(group);

            Assert.AreEqual(numberOfGroups + 1, factory.GroupFactory().Select().Count);
        }

        /// <summary>
        /// Test update group infoemation
        /// </summary>
        /// <param name="oldName">Old name.</param>
        /// <param name="newName">New name.</param>
        [DataTestMethod]
        [DataRow("IS-11", "IT-11")]
        [DataRow("IS-12", "IT-12")]
        [DataRow("IS-21", "IT-21")]
        [DataRow("IS-22", "IT-22")]
        [DataRow("IS-31", "IT-31")]
        [DataRow("IS-32", "IT-32")]
        [DataRow("IS-41", "IT-41")]
        [DataRow("IS-42", "IT-42")]
        public void TestUpdateDataInGroupBase(string oldName, string newName)
        {
            Group groupNew = new Group(newName);
            Group groupOld = new Group(oldName);

            List<Group> groups = factory.GroupFactory().Select();
            int id = groupOld.GetId(groups);

            factory.GroupFactory().Update(id, groupNew);
        }

        /// <summary>
        /// Test delete data from database.
        /// </summary>
        /// <param name="name">Group name.</param>
        [DataTestMethod]
        [DataRow("IT-11")]
        [DataRow("IT-12")]
        [DataRow("IT-21")]
        [DataRow("IT-22")]
        [DataRow("IT-31")]
        [DataRow("IT-32")]
        [DataRow("IT-41")]
        [DataRow("IT-42")]
        public void TestZDeleteDataInStudentsBase(string name)
        {
            Group group = new Group(name);
            int numberOfGroup = factory.GroupFactory().Select().Count;

            factory.GroupFactory().Delete(group);

            Assert.AreEqual(numberOfGroup - 1, factory.GroupFactory().Select().Count);
        }
    }
}
