using System;
using ClassList;

namespace ItemList

{
    public class Potion : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HealAmount { get; set; }

        public Potion()
        {
            Name = "Health Potion";
            Description = "Restores 50 health points.";
            HealAmount = 50;
        }

        public void Use(ICharacter character)
        {
            if(character.Health + HealAmount > character.Health)
            {
                Console.WriteLine($"{character.Name} used a {Name}, but health is already full.");
            }
            else
            {
                character.Health += HealAmount;
                Console.WriteLine($"{character.Name} used a {Name} and restored {HealAmount} health points. Current health: {character.Health}");
            }
        }
    }
}