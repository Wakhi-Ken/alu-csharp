using System;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        // Required properties
        public string user_id { get; set; }
        public string item_id { get; set; }

        private int _quantity = 1;
        public int quantity 
        { 
            get => _quantity; 
            set => _quantity = value < 0 ? 0 : value; // cannot be less than 0
        }

        // Constructor
        public Inventory(string userId, string itemId, int quantity = 1)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("user_id is required");

            if (string.IsNullOrWhiteSpace(itemId))
                throw new ArgumentException("item_id is required");

            user_id = userId;
            item_id = itemId;
            this.quantity = quantity;
        }
    }
}