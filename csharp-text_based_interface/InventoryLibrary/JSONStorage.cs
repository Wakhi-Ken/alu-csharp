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
        private string filePath = Path.Combine("InventoryLibrary", "storage", "inventory_manager.json");

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
                IncludeFields = true // include public fields if any
            };

            // Serialize and write
            string jsonString = JsonSerializer.Serialize(objects, options);

            // Ensure directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            File.WriteAllText(filePath, jsonString);
        }

        // Load objects from JSON file
        public void Load()
        {
            if (!File.Exists(filePath))
            {
                objects = new Dictionary<string, BaseClass>();
                return;
            }

            string jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };

            // Deserialize into dictionary of JsonElement first
            var tempDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString, options);

            objects = new Dictionary<string, BaseClass>();

            if (tempDict != null)
            {
                foreach (var kvp in tempDict)
                {
                    // Extract class name from key
                    string className = kvp.Key.Split('.')[0];

                    BaseClass obj = (className switch
                    {
                        "Item" => kvp.Value.Deserialize<Item>(options)!,
                        "User" => kvp.Value.Deserialize<User>(options)!,
                        "Inventory" => kvp.Value.Deserialize<Inventory>(options)!,
                        _ => null
                    })!;

                    if (obj != null)
                        objects[kvp.Key] = obj;
                }
            }
        }
    }
}