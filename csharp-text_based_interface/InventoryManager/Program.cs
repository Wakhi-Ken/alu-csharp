using System;
using System.Linq;
using System.Collections.Generic;
using InventoryLibrary;

namespace InventoryManagerApp
{
    internal class Program
    {
        // Single instance of JSONStorage
        private static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            // Load objects
            storage.Load();

            // Show initial prompt
            PrintPrompt();

            // Main loop
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0].ToLower();

                try
                {
                    switch (command)
                    {
                        case "classnames":
                            ShowClassNames();
                            break;
                        case "all":
                            if (parts.Length == 1)
                                ShowAll();
                            else
                                ShowAll(parts[1]);
                            break;
                        case "create":
                            if (parts.Length < 2)
                                Console.WriteLine("Usage: Create [ClassName]");
                            else
                                CreateObject(parts[1]);
                            break;
                        case "show":
                            if (parts.Length < 3)
                                Console.WriteLine("Usage: Show [ClassName] [id]");
                            else
                                ShowObject(parts[1], parts[2]);
                            break;
                        case "update":
                            if (parts.Length < 3)
                                Console.WriteLine("Usage: Update [ClassName] [id]");
                            else
                                UpdateObject(parts[1], parts[2]);
                            break;
                        case "delete":
                            if (parts.Length < 3)
                                Console.WriteLine("Usage: Delete [ClassName] [id]");
                            else
                                DeleteObject(parts[1], parts[2]);
                            break;
                        case "exit":
                            storage.Save();
                            return;
                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                PrintPrompt();
            }
        }

        // Print commands
        private static void PrintPrompt()
        {
            Console.WriteLine("\nInventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ClassNames - show all ClassNames of objects");
            Console.WriteLine("All - show all objects");
            Console.WriteLine("All [ClassName] - show all objects of a ClassName");
            Console.WriteLine("Create [ClassName] - a new object");
            Console.WriteLine("Show [ClassName] [id] - an object");
            Console.WriteLine("Update [ClassName] [id] - an object");
            Console.WriteLine("Delete [ClassName] [id] - an object");
            Console.WriteLine("Exit - quit application\n");
        }

        // Show all class names
        private static void ShowClassNames()
        {
            var classNames = storage.All().Values.Select(v => v.GetType().Name).Distinct();
            Console.WriteLine("Class Names:");
            foreach (var name in classNames)
                Console.WriteLine(name);
        }

        // Show all objects
        private static void ShowAll()
        {
            foreach (var kv in storage.All())
            {
                Console.WriteLine($"{kv.Key} -> {kv.Value}");
            }
        }

        // Show all objects of ClassName
        private static void ShowAll(string className)
        {
            className = className.ToLower();
            var objs = storage.All()
                .Where(kv => kv.Value.GetType().Name.ToLower() == className)
                .ToList();

            if (!objs.Any())
            {
                Console.WriteLine($"{className} is not a valid object type or no objects found.");
                return;
            }

            foreach (var kv in objs)
                Console.WriteLine($"{kv.Key} -> {kv.Value}");
        }

        // Create new object
        private static void CreateObject(string className)
        {
            className = className.ToLower();
            BaseClass obj = className switch
            {
                "user" => new User(Prompt("Enter name: ")),
                "item" => new Item(Prompt("Enter name: ")) 
                            { description = Prompt("Enter description (optional): "),
                              price = float.TryParse(Prompt("Enter price: "), out float p) ? p : 0 },
                "inventory" => 
                    new Inventory(
                        Prompt("Enter user_id: "), 
                        Prompt("Enter item_id: "), 
                        int.TryParse(Prompt("Enter quantity (default 1): "), out int q) ? q : 1),
                _ => null
            };

            if (obj == null)
            {
                Console.WriteLine($"{className} is not a valid object type");
                return;
            }

            storage.New(obj);
            storage.Save();
            Console.WriteLine($"{className} created with id: {obj.id}");
        }

        // Show object by ClassName and id
        private static void ShowObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (!storage.All().TryGetValue(key, out BaseClass obj))
            {
                Console.WriteLine($"Object {id} could not be found");
                return;
            }

            Console.WriteLine(obj);
        }

        // Update object
        private static void UpdateObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (!storage.All().TryGetValue(key, out BaseClass obj))
            {
                Console.WriteLine($"Object {id} could not be found");
                return;
            }

            switch (obj)
            {
                case User user:
                    user.name = Prompt($"Enter new name (current: {user.name}): ");
                    break;
                case Item item:
                    item.name = Prompt($"Enter new name (current: {item.name}): ");
                    item.description = Prompt($"Enter new description (current: {item.description}): ");
                    if (float.TryParse(Prompt($"Enter new price (current: {item.price}): "), out float p))
                        item.price = p;
                    break;
                case Inventory inv:
                    inv.user_id = Prompt($"Enter new user_id (current: {inv.user_id}): ");
                    inv.item_id = Prompt($"Enter new item_id (current: {inv.item_id}): ");
                    if (int.TryParse(Prompt($"Enter new quantity (current: {inv.quantity}): "), out int q))
                        inv.quantity = q;
                    break;
            }

            storage.Save();
            Console.WriteLine("Object updated successfully");
        }

        // Delete object
        private static void DeleteObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (!storage.All().Remove(key))
            {
                Console.WriteLine($"Object {id} could not be found");
                return;
            }

            storage.Save();
            Console.WriteLine("Object deleted successfully");
        }

        // Helper for prompting user
        private static string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine()?.Trim() ?? "";
        }
    }
}