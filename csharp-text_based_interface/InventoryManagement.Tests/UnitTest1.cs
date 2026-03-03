using NUnit.Framework;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class UnitTest1
    {
        private JSONStorage storage;

        [SetUp]
        public void Setup()
        {
            storage = new JSONStorage();
        }

        [Test]
        public void Storage_ShouldStartEmpty()
        {
            Assert.That(storage.All().Count, Is.EqualTo(0));
        }
    }
}