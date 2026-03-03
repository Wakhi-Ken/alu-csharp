using NUnit.Framework;
using InventoryLibrary;
using System.Linq;

namespace InventoryManagement.Test
{
    public class JSONStorageTests
    {
        private JSONStorage storage;

        [SetUp]
        public void Setup()
        {
            storage = new JSONStorage();
        }

        [Test]
        public void New_User_ShouldBeAddedToStorage()
        {
            // Arrange
            var user = new User("John");

            // Act
            storage.New(user);
            var allObjects = storage.All();

            // Assert
            Assert.That(allObjects.Count, Is.EqualTo(1));
            Assert.That(allObjects.Values.First(), Is.EqualTo(user));
        }
    }
}