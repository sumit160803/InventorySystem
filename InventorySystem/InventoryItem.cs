using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        //empty constructor
        public InventoryItem() { }
        //explicit constructor
        public InventoryItem(int id, string name, int quantity, double price, double rating)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Rating = rating;
        }
        public override string ToString() { 
            return $"Id: {Id}, Name: {Name}, Quantity: {Quantity}, Price: {Price}, Rating: {Rating}";
        }

    }
}
