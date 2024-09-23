using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace InventorySystem
{
    public class InventoryManager
    {
        private List<InventoryItem> items;
        private const string filePath = "Inventory.xml";

        //construcctor
        public InventoryManager()
        {
            items = LoadItemsFromFile();
        }

        public void CreateItem(InventoryItem newItem)
        {
            if (items.Exists(i => i.Id == newItem.Id))
            {
                throw new InvalidOperationException("Item with this id already exists");
            }
            items.Add(newItem);
            SaveItemsToFile();
            Console.WriteLine("Item added successfully");
        }

        public void ReadItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in inventory");
                return;
            }
            Console.WriteLine("Items in inventory:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void UpdateItems(int id, String Name, int quantity, double price, double rating)
        {
            var item = items.Find(i => i.Id == id);
            if(item == null)
            {
                throw new KeyNotFoundException("Item with this id does not exist");
            }
            item.Name = Name;
            item.Quantity = quantity;
            item.Price = price;
            item.Rating = rating;

            SaveItemsToFile();
            Console.WriteLine("Item updated successfully");
        }
        public void DeleteItem(int id)
        {
            var item = items.Find(i => i.Id == id);
            
            if(item == null)
            {
                throw new KeyNotFoundException("Item with this id does not exist");
            }
            items.Remove(item);
            SaveItemsToFile();
            Console.WriteLine("Item deleted successfully");
        }

        private List<InventoryItem> LoadItemsFromFile()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<InventoryItem>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<InventoryItem>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<InventoryItem>)serializer.Deserialize(fs);
            }
        }

        private void SaveItemsToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<InventoryItem>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, items);
            }
        }
    }
}
