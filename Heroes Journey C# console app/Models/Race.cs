using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Race
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public Race(string name, int health, int strength, int agility)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Agility = agility;
        }
    }
}
