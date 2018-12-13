using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class InventoryItem
    {
       public string ProductId { get; set; }
        public string ModelNo { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UPC { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }

    }
}
