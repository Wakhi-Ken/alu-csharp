using NUnit.Framework;
using InventoryLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private StringWriter consoleOutput;
        private StringReader? consoleInput;
        private JSONStorage storage;
        private Type? programType;
        private MethodInfo[]? methods;

        [SetUp]
        public void Setup()
        {
            // Redirect console output
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Get the Program class from InventoryManagerApp namespace using reflection
            programType = Type.GetType("InventoryManagerApp.Program, InventoryManager");
            
            if (programType != null)
            {
                methods = programType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
            }

            // Create a fresh storage instance
            storage = new JSONStorage();
            
            // Clear storage for each test
            var allObjects = storage.All();
            allObjects.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            // Reset console output
            consoleOutput?.Dispose();
            consoleInput?.Dispose();
            
            // Reset console to standard output
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Test]
        public void Test_ClassNames_WithNoObjects_ReturnsEmpty()
        {
            // Arrange
            SimulateUserInput("classnames\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert - Should not crash
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Class Names:"));
        }

        [Test]
        public void Test_ClassNames_WithObjects_ReturnsDistinctClassNames()
        {
            // Arrange
            var user = new User("TestUser");
            var item = new Item("TestItem") 
            { 
                description = "Test Description", 
                price = 10.0f 
            };
            storage.New(user);
            storage.New(item);
            storage.Save();
            
            SimulateUserInput("classnames\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("User"));
            Assert.That(output, Does.Contain("Item"));
        }

        [Test]
        public void Test_All_WithNoObjects_ShowsEmpty()
        {
            // Arrange
            SimulateUserInput("all\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert - Should not throw exception
            Assert.Pass();
        }

        [Test]
        public void Test_All_WithObjects_ShowsAllObjects()
        {
            // Arrange
            var user = new User("TestUser");
            var item = new Item("TestItem") 
            { 
                description = "Description", 
                price = 15.99f 
            };
            storage.New(user);
            storage.New(item);
            storage.Save();
            
            SimulateUserInput("all\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("User." + user.id));
            Assert.That(output, Does.Contain("TestUser"));
            Assert.That(output, Does.Contain("Item." + item.id));
            Assert.That(output, Does.Contain("TestItem"));
        }

        [Test]
        public void Test_All_WithValidClassName_ShowsObjectsOfThatType()
        {
            // Arrange
            var user1 = new User("User1");
            var user2 = new User("User2");
            var item = new Item("Item1") { price = 5.0f };
            storage.New(user1);
            storage.New(user2);
            storage.New(item);
            storage.Save();
            
            SimulateUserInput("all user\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("User." + user1.id));
            Assert.That(output, Does.Contain("User." + user2.id));
            Assert.That(output, Does.Not.Contain("Item." + item.id));
        }

        [Test]
        public void Test_All_WithInvalidClassName_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("all InvalidClass\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert - Check for exact error message format
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("InvalidClass is not a valid object type"));
        }

        [Test]
        public void Test_All_WithLowerCaseClassName_WorksCaseInsensitive()
        {
            // Arrange
            var user = new User("TestUser");
            storage.New(user);
            storage.Save();
            
            SimulateUserInput("all user\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("User." + user.id));
        }

        [Test]
        public void Test_All_WithUpperCaseClassName_WorksCaseInsensitive()
        {
            // Arrange
            var user = new User("TestUser");
            storage.New(user);
            storage.Save();
            
            SimulateUserInput("all USER\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("User." + user.id));
        }

        [Test]
        public void Test_Create_User_AddsNewUser()
        {
            // Arrange
            SimulateUserInput("create user\nJohn\nall\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("user created with id:"));
            Assert.That(output, Does.Contain("John"));
        }

        [Test]
        public void Test_Create_Item_AddsNewItem()
        {
            // Arrange
            SimulateUserInput("create item\nLaptop\nGaming laptop\n1500.50\nall\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("item created with id:"));
            Assert.That(output, Does.Contain("Laptop"));
            Assert.That(output, Does.Contain("Gaming laptop"));
        }

        [Test]
        public void Test_Create_Inventory_AddsNewInventory()
        {
            // Arrange - First create user and item
            var user = new User("TestUser");
            var item = new Item("TestItem") { price = 10.0f };
            storage.New(user);
            storage.New(item);
            storage.Save();
            
            SimulateUserInput($"create inventory\n{user.id}\n{item.id}\n5\nall\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("inventory created with id:"));
        }

        [Test]
        public void Test_Create_WithInvalidClassName_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("create InvalidClass\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("InvalidClass is not a valid object type"));
        }

        [Test]
        public void Test_Show_ValidObject_DisplaysObject()
        {
            // Arrange
            var user = new User("ShowTestUser");
            storage.New(user);
            storage.Save();
            
            SimulateUserInput($"show user {user.id}\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("ShowTestUser"));
        }

        [Test]
        public void Test_Show_InvalidId_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("show user invalid123\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Object invalid123 could not be found"));
        }

        [Test]
        public void Test_Show_InvalidClassName_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("show InvalidClass 123\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("InvalidClass is not a valid object type"));
        }

        [Test]
        public void Test_Update_User_ChangesName()
        {
            // Arrange
            var user = new User("OriginalName");
            storage.New(user);
            storage.Save();
            
            SimulateUserInput($"update user {user.id}\nNewName\nshow user {user.id}\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("NewName"));
            Assert.That(output, Does.Not.Contain("OriginalName"));
        }

        [Test]
        public void Test_Update_Item_ChangesProperties()
        {
            // Arrange
            var item = new Item("OldItem") 
            { 
                description = "Old Description", 
                price = 10.0f 
            };
            storage.New(item);
            storage.Save();
            
            SimulateUserInput($"update item {item.id}\nNewItem\nNew Description\n25.50\nshow item {item.id}\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("NewItem"));
            Assert.That(output, Does.Contain("New Description"));
        }

        [Test]
        public void Test_Update_InvalidId_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("update user invalid123\nnewName\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Object invalid123 could not be found"));
        }

        [Test]
        public void Test_Delete_ValidObject_RemovesObject()
        {
            // Arrange
            var user = new User("ToDelete");
            storage.New(user);
            storage.Save();
            
            SimulateUserInput($"delete user {user.id}\nall\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Object deleted successfully"));
            Assert.That(output, Does.Not.Contain("ToDelete"));
        }

        [Test]
        public void Test_Delete_InvalidId_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("delete user invalid123\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Object invalid123 could not be found"));
        }

        [Test]
        public void Test_Exit_QuitsApplication()
        {
            // Arrange
            SimulateUserInput("exit\n");
            
            // Act
            RunMainMethod();
            
            // Assert - Should exit without error
            Assert.Pass();
        }

        [Test]
        public void Test_InvalidCommand_ShowsErrorMessage()
        {
            // Arrange
            SimulateUserInput("invalidcommand\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert
            string output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Invalid command"));
        }

        [Test]
        public void Test_EmptyInput_ContinuesPrompt()
        {
            // Arrange
            SimulateUserInput("\n\nexit\n");
            
            // Act
            RunMainMethod();
            
            // Assert - Should handle empty input without crashing
            Assert.Pass();
        }

        // Helper method to simulate user input
        private void SimulateUserInput(string input)
        {
            consoleInput = new StringReader(input);
            Console.SetIn(consoleInput);
        }

        // Helper method to run Main method using reflection
        private void RunMainMethod()
        {
            if (programType == null)
            {
                Assert.Ignore("Program class not found. Make sure InventoryManager project is referenced.");
                return;
            }

            var mainMethod = programType.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
            if (mainMethod != null)
            {
                mainMethod.Invoke(null, new object[] { new string[0] });
            }
            else
            {
                Assert.Ignore("Main method not found in Program class.");
            }
        }
    }
}