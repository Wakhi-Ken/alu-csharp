using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        // Required property
        public string name { get; set; }

        // Optional properties
        public string? description { get; set; }
        private float _price;
        public float price 
        { 
            get => _price; 
            set => _price = (float)Math.Round(value, 2); // limit to 2 decimals
        }

        public List<string> tags { get; set; } = new List<string>();

        // Constructor
        public Item(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            this.name = name;
        }
    }
}