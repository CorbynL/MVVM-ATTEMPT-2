using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
   public class LootItem : Item
    {
        public int Quantity { get; set; }
        public int DropRate { get; set; }

        public LootItem(string name = "", string description = "", int quantity = 0, int dropRate = 0, int id = 0):
            base(name, description, id)
        {
            Quantity = quantity;
            DropRate = dropRate;
        }
        public LootItem()
        {

        }
    }
}
