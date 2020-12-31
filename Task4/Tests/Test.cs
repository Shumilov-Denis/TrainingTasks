using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servers;
using TaskException;

namespace Tests
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Test sending message on server.
        /// </summary>
        [TestMethod]
        public void TestListWithMessage1()
        {
            Server server = new Server("127.0.0.1", 40000);
            Thread serverThread = new Thread(server.Listen);
            serverThread.IsBackground = true;
            serverThread.Start();

            Client client = new Client("127.0.0.1", 40000, "Den");
            client.TrySendMessage("Hello");
            Thread.Sleep(200);
            client.TrySendMessage("How are you?");
            Thread.Sleep(200);

            Assert.AreEqual(2, server.ListWithMessages.Count);
            Assert.AreEqual("Den: Hello", server.ListWithMessages[0]);
            Assert.AreEqual("Den: How are you?", server.ListWithMessages[1]);
        }

        /// <summary>
        /// Test transliteration message.
        /// </summary>
        [TestMethod]
        public void TestTransliterationMessage()
        {
            Server server = new Server("127.0.0.1", 40001);
            Thread serverThread = new Thread(server.Listen);
            serverThread.IsBackground = true;
            serverThread.Start();

            Client client = new Client("127.0.0.1", 40001, "Ден");
            client.TrySendMessage("Привет, как дела? Всё хорошо?");
            Thread.Sleep(200);

            Assert.AreEqual("Den: Privet, kak dela? Vsyo horosho?", server.ListWithMessages[0]);
        }

        /// <summary>
        /// Test IP exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotValidIpException))]
        public void TestIpException()
        {
            Server server = new Server("12343.124.524.2", 5);
        }

        /// <summary>
        /// Test Port exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotValidNumberOfPortException))]
        public void TestPortException()
        {
            Server server = new Server("127.0.0.1", -5);
        }
    }
}