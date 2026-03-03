using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        // Dictionary to store objects
        private Dictionary<string, BaseClass> objects = new Dictionary<string, BaseClass>();

        // File path for JSON storage
        private readonly string filePath = Path.Combine("InventoryLibrary", "storage", "inventory_manager.json");

        // Return all objects
        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }

        // Add a new object
        public void New(BaseClass obj)
        {
            string key = $"{obj.GetType().Name}.{obj.id}";
            objects[key] = obj;
        }

        // Save objects to JSON file
        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            // Ensure directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            string jsonString = JsonSerializer.Serialize(objects, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Load objects from JSON file
        public void Load()
        {
            // If file does not exist, create empty file and empty dictionary
            if (!File.Exists(filePath))
            {
                objects = new Dictionary<string, BaseClass>();
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                File.WriteAllText(filePath, "{}");
                return;
            }

            string jsonString = File.ReadAllText(filePath);

            // If file is empty, treat as empty dictionary
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                objects = new Dictionary<string, BaseClass>();
                return;
            }

            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };

            // Deserialize into dictionary of JsonElement
            var tempDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString, options);

            objects = new Dictionary<string, BaseClass>();

            if (tempDict != null)
            {
                foreach (var kvp in tempDict)
                {
                    string className = kvp.Key.Split('.')[0];

                    BaseClass obj = className switch
                    {
                        "Item" => kvp.Value.Deserialize<Item>(options) ?? throw new Exception("Failed to deserialize Item"),
                        "User" => kvp.Value.Deserialize<User>(options) ?? throw new Exception("Failed to deserialize User"),
                        "Inventory" => kvp.Value.Deserialize<Inventory>(options) ?? throw new Exception("Failed to deserialize Inventory"),
                        _ => null!
                    };

                    if (obj != null)
                        objects[kvp.Key] = obj;
                }
            }
        }
    }
}