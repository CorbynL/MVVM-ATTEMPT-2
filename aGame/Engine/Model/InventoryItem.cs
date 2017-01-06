using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
   public class InventoryItem : Item
    {
        public int Quantity { get; set; }
        public Item Details { get; set; }

        public InventoryItem( Item details = null, int quantity = 0):
            base(details.Name, details.Description, details.ID)            
        {
            Quantity = quantity;
            Details = details;
        }
        public InventoryItem()
        {

        }
    }
}
