using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement
{
    internal class InventoryManager
    {

        internal IList<InventoryItem> inventoryItems { get; set; }   //global variable

        internal InventoryManager ()
        {
            inventoryItems = inventoryInStore;
        }

        IList<InventoryItem> inventoryInStore   // creating temp memory instead of DB
        {
            get
            {
                IList<InventoryItem> inventory = new List<InventoryItem>();

                inventory.Add(
                    new InventoryItem { ProductId = "PD1234", ModelNo="E12234", Description="Inspiron 15 256GB SSD", Name="Inspiron 15 5000", Manufacturer="Dell", Discount=5, Price=500, Quantity=3, UPC="123456789" }                    
                );

                inventory.Add(
                    new InventoryItem { ProductId = "GF1278", ModelNo = "G14534", Description = "Lenovo 15 256GB SSD", Name = "Lenvov 15 5000", Manufacturer = "Lenovo", Discount = 6, Price = 1000, Quantity = 6, UPC = "123745789" }
                    );

                return inventory;
            }
        }

        IList<InventoryItem> GetInventory()
        {
            return inventoryItems;
        }

        internal string AddInventory(InventoryItem item)
        {
            inventoryItems.Add(item);

            return item.ProductId;
        }

        internal string UpdateInventory(InventoryItem item)
        {
            var currentItem = inventoryItems.First(it => it.ProductId == item.ProductId);
            currentItem.Price = item.Price;
            currentItem.Quantity = item.Quantity;
            currentItem.Name = item.Name;
            currentItem.Description = item.Description;
            return item.ProductId;
        }

        internal void DeleteInventory(string productId)
        {

            var item = inventoryItems.First(it => it.ProductId == productId);
            if(item == null)
            {
                throw new Exception("Invalid Product ID");
            }
            inventoryItems.Remove(item);
        }

        internal string UpdateQuantity(string productId, int quantity, bool addquantity)
        {
            var currentItem = inventoryItems.First(it => it.ProductId == productId);
            if (addquantity)
            {
                currentItem.Quantity += quantity;
            }
            else
            {
                if (currentItem.Quantity >= quantity)
                {
                    currentItem.Quantity -= quantity;
                }
                else
                {
                    throw new Exception("Invalid Product Quantity");
                }
            }
            return productId;
        }        
    }
}
