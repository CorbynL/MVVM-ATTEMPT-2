using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
    class HealingPotion : Item
    {
        
        public int AmountToHeal { get; set; }

        public HealingPotion(string name ="", string description ="", int amountToHeal = 0, int id = 0) :
            base(name, description, id)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
