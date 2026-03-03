using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private JSONStorage storage;

        [SetUp]
        public void Setup()
        {
            storage = new JSONStorage();
        }

        [Test]
        public void CanCreateUser_Item_Inventory()
        {
            User user = new User("Alice");
            Item item = new Item("Laptop") { price = 1200.50f, description = "Gaming laptop" };
            Inventory inv = new Inventory(user.id, item.id, 2);

            Assert.AreEqual("Alice", user.name);
            Assert.AreEqual("Laptop", item.name);
            Assert.AreEqual(1200.50f, item.price);
            Assert.AreEqual("Gaming laptop", item.description);
            Assert.AreEqual(2, inv.quantity);
            Assert.AreEqual(user.id, inv.user_id);
            Assert.AreEqual(item.id, inv.item_id);
        }

        [Test]
        public void JSONStorage_CanAdd_Save_LoadObjects()
        {
            storage = new JSONStorage();

            User user = new User("Bob");
            Item item = new Item("Phone") { price = 599.99f };
            Inventory inv = new Inventory(user.id, item.id);

            storage.New(user);
            storage.New(item);
            storage.New(inv);
            storage.Save();

            var newStorage = new JSONStorage();
            newStorage.Load();
            var allObjects = newStorage.All();

            Assert.IsTrue(allObjects.ContainsKey($"User.{user.id}"));
            Assert.IsTrue(allObjects.ContainsKey($"Item.{item.id}"));
            Assert.IsTrue(allObjects.ContainsKey($"Inventory.{inv.id}"));

            var loadedUser = allObjects[$"User.{user.id}"] as User;
            Assert.IsNotNull(loadedUser);
            Assert.AreEqual("Bob", loadedUser!.name);

            var loadedItem = allObjects[$"Item.{item.id}"] as Item;
            Assert.IsNotNull(loadedItem);
            Assert.AreEqual("Phone", loadedItem!.name);

            var loadedInv = allObjects[$"Inventory.{inv.id}"] as Inventory;
            Assert.IsNotNull(loadedInv);
            Assert.AreEqual(user.id, loadedInv!.user_id);
            Assert.AreEqual(item.id, loadedInv.item_id);
        }

        [Test]
        public void Inventory_CannotHaveNegativeQuantity()
        {
            User user = new User("TestUser");
            Item item = new Item("TestItem");

            Inventory inv = new Inventory(user.id, item.id, -5);
            Assert.GreaterOrEqual(inv.quantity, 0);

            inv.quantity = -10;
            Assert.AreEqual(0, inv.quantity);
        }

        [Test]
        public void Item_PriceRoundedToTwoDecimals()
        {
            Item item = new Item("RoundedItem") { price = 123.4567f };
            Assert.AreEqual(123.46f, item.price);
        }

        [Test]
        public void RequiredProperties_ThrowExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentException>(() => new User(""));
            Assert.Throws<ArgumentException>(() => new Item("   "));

            User u = new User("U");
            Item i = new Item("I");
            Assert.Throws<ArgumentException>(() => new Inventory("", i.id));
            Assert.Throws<ArgumentException>(() => new Inventory(u.id, ""));
        }
    }
}