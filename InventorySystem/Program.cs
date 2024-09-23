using System;
using System.Collections.Generic;

namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();
            bool running = true;

            while (running)
            {
                ShowMenu();
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateItem(manager);
                        break;
                    case "2":
                        ReadItems(manager);
                        break;
                    case "3":
                        UpdateItems(manager);
                        break;
                    case "4":
                        DeleteItem(manager);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Create Item");
            Console.WriteLine("2. Read All Items");
            Console.WriteLine("3. Update Item");
            Console.WriteLine("4. Delete Item");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        static void CreateItem(InventoryManager manager)
        {
            try
            {
                Console.Write("Enter item Id:");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter item Name:");
                String name = Console.ReadLine();

                Console.Write("Enter item Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter item Price:");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Enter item Rating(1-5):");
                double rating = double.Parse(Console.ReadLine());

                InventoryItem newItems = new InventoryItem(id, name, quantity, price, rating);
                manager.CreateItem(newItems);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input Format. Please try again.!");
            }   
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReadItems(InventoryManager manager)
        {
            manager.ReadItems();
        }

        static void UpdateItems(InventoryManager manager)
        {
            try
            {
                Console.Write("Enter item Id:");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter item Name:");
                String name = Console.ReadLine();

                Console.Write("Enter item Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter item Price:");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Enter item Rating(1-5):");
                double rating = double.Parse(Console.ReadLine());

                manager.UpdateItems(id, name, quantity, price, rating);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input Format. Please try again.!");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteItem(InventoryManager manager)
        {
            try
            {
                Console.Write("Enter item Id:");
                int id = int.Parse(Console.ReadLine());
                manager.DeleteItem(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input Format. Please try again.!");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
