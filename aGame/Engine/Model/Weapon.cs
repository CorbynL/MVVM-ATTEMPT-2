using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
  public  class Weapon : Item
    {
        public string ItemClass { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }

        public Weapon(string name = "", string description = "", string itemClass = "", int maxDamage = 0, int minDamage = 0, int id = 0):
            base(name, description, id)
        {
            ItemClass = itemClass;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
        public Weapon()
        {

        }
    }
}
