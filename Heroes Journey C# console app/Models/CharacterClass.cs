using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CharacterClass
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Agility { get; set; }

        public CharacterClass(string name, int health, int agility)
        {
            Name = name;
            Health = health;
            Agility = agility;
        }
    }
}
