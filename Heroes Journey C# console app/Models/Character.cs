using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class Character
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public int Health { get; set; }
        public int Agility { get; set; }

        public Character(string name, Race race, CharacterClass characterClass)
        {
            Name = name;
            Race = race;
            CharacterClass = characterClass;
            Health = Race.Health + CharacterClass.Health;
            Agility = Race.Agility + CharacterClass.Agility;
        }
        public string CharacterInfo()
        {
            return $"\n{Name} ({Race.Name}) the {CharacterClass.Name,5}";
        }
        public string Stats()
        {
            return $"{Race.Health + CharacterClass.Health} HP, {Race.Strength,3} STR, {Race.Agility + CharacterClass.Agility,3} AGI";
        }
    }
}
