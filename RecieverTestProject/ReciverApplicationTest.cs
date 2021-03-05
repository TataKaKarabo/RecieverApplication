using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecieverApplication;

namespace RecieverTestProject
{
    [TestClass]
    public class ReciverApplicationTest
    {
        [TestMethod]
        public void SenderMessageReturnTrue()
        {
            var factory = new FactoryConfig();
            bool results = factory.RecieveMessage();
            Assert.IsTrue(results, "Message Recieved Succeffuly.");
        }
        [TestMethod]
        public void SenderMessageReturnFalse()
        {
            var factory = new FactoryConfig();
            bool results = factory.RecieveMessage();
            Assert.IsFalse(results, "Message Recieved Cannot be empty.");
        }

    }
}
