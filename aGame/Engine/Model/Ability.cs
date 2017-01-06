using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
    public class Ability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }

        public Ability(string name, string description, int maxDamage, int minDamage, int id)
        {
            ID = id;
            Name = name;
            Description = description;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
    }
}
