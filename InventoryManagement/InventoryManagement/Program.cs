using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Best Buy!!!");

            //Display Inventory
            InventoryManager inventoryManager = new InventoryManager();
            var items = inventoryManager.inventoryItems;
            bool exist = false;      
            while(!exist)
            {
                string selectedProductId = string.Empty;
                IList<string> productsForDisplay = inventoryManager.inventoryItems.Select(it => string.Format("{0} ({1}) {2}", it.ProductId, it.Description, it.Quantity)).ToList(); ;
                InventoryItem currentItem = null;
                int choice = ReadUserChoice();
                switch (choice)
                {
                    case 1:
                        var item = ReadNewInventory();
                        inventoryManager.AddInventory(item);
                        Console.WriteLine("New item has been added to inventory");
                        break;
                    case 2:
                        selectedProductId = ReadProductFromUser(productsForDisplay);
                        currentItem = ReadInputForUpdateInventory(selectedProductId);
                        inventoryManager.UpdateInventory(currentItem);
                        Console.WriteLine("Item has been updated to inventory");
                        break;
                    case 3:
                        selectedProductId = ReadProductFromUser(productsForDisplay);
                        try
                        {
                            inventoryManager.DeleteInventory(selectedProductId);
                            Console.WriteLine("Product has been deleet from the inventory");
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered invalid product id");
                        }
                        break;
                    case 4:
                        DisplayInventory(inventoryManager.inventoryItems);
                        break;
                    case 5:
                        selectedProductId = ReadProductFromUser(productsForDisplay);
                        int quantity = ReadQuantityInput();

                        inventoryManager.UpdateQuantity(selectedProductId, quantity, true);
                        Console.WriteLine("Item has been updated to inventory");
                        break;
                    case 6:                        
                        selectedProductId = ReadProductFromUser(productsForDisplay);
                        
                        try
                        {
                            int quantity1 = ReadQuantityInput();
                            inventoryManager.UpdateQuantity(selectedProductId, quantity1, false);
                            Console.WriteLine("Item has been updated to inventory");
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (e.Message == "Invalid Product Quantity")
                            {                                
                                Console.WriteLine("You have entered invalid quantity");
                            }
                            else
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    case 7:
                        exist = true;
                        break;
                }
            }

            Console.WriteLine("Good Bye!!!");
            
            Console.ReadKey();


        }


        static void DisplayInventory(IList<InventoryItem> items)
        {
            //print inventory
            /*for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("Product ID: {0}\nName: {1}\nModel: {2}\nUPC: {3}\n",
                    items[i].ProductId,
                    items[i].Name,
                    items[i].ModelNo,
                    items[i].UPC);
            }*/

            foreach (var item in items)
            {
                Console.WriteLine("Product ID: {0}\nName: {1}\nModel: {2}\nUPC: {3}\n",
                    item.ProductId,
                    item.Name,
                    item.ModelNo,
                    item.UPC);
            }
        }

        static int ReadUserChoice()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your choice between 1.Add Inventory, 2.Update Inventory, 3.Delete Inventory, 4.Display Inventory, 5.Add Item Quantiy, 6.Delete Item Quantiy, 7.Quit");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        static InventoryItem ReadNewInventory()
        {
            Console.WriteLine("Enter Inventory Item Details to add");
            InventoryItem inventoryItem = new InventoryItem();
            Console.Write("Product ID:");
            inventoryItem.ProductId = Console.ReadLine();
            Console.Write("Model No:");
            inventoryItem.ModelNo = Console.ReadLine();
            Console.Write("Manufacturer:");
            inventoryItem.Manufacturer = Console.ReadLine();
            Console.Write("Product Name:");
            inventoryItem.Name = Console.ReadLine();
            Console.Write("Product Description:");
            inventoryItem.Description = Console.ReadLine();
            Console.Write("UPC No:");
            inventoryItem.UPC = Console.ReadLine();
            Console.Write("Price:");
            inventoryItem.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Discount:");
            inventoryItem.Discount = decimal.Parse(Console.ReadLine());
            Console.Write("Quantity:");
            inventoryItem.Quantity = Convert.ToInt32(Console.ReadLine());

            return inventoryItem;
        }

        static string ReadProductFromUser(IList<string> inventory)
        {
            Console.WriteLine("Inventory:");
            foreach (string item in inventory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter the product id from the above list");
            string productId = Console.ReadLine();

            return productId;
        }
        static InventoryItem ReadInputForUpdateInventory(string productId)
        {
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.ProductId = productId;
            Console.Write("Product Name:");
            inventoryItem.Name = Console.ReadLine();
            Console.Write("Product Description:");
            inventoryItem.Description = Console.ReadLine();
            Console.Write("Price:");
            inventoryItem.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Discount:");
            inventoryItem.Discount = decimal.Parse(Console.ReadLine());
            Console.Write("Quantity:");
            inventoryItem.Quantity = Convert.ToInt32(Console.ReadLine());

            return inventoryItem;
        }

        static int ReadQuantityInput()
        {            
            Console.WriteLine("Enter the Quantity for the product");
            int quantity = Convert.ToInt32(Console.ReadLine());
            return quantity;
        }
    }
}
