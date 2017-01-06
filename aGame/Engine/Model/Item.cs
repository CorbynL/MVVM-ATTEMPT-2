using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
   public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name = "", string description = "", int id = 1)
        {
            Name = name;
            Description = description;
            ID = id;
        }
    }
}
