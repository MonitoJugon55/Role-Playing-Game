using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(int id, string name, string namePlural, int minDmg, int maxDmg) : base(id, name, namePlural) 
        {
            MinDamage = minDmg;
            MaxDamage = maxDmg;
        }
    }
}
