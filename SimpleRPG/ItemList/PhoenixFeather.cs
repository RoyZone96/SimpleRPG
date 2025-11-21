using System;
using ClassList;

namespace ItemList
{
    public class PhoenixFeather : IItem
    {
        public string Name { get; set; } = "Phoenix Feather";
        public string Description { get; set; } = "Revives a fallen character with full health and mana.";

        // Match IItem signature (object) and cast inside
        public void Use(ICharacter target)
        {
            if (target is ICharacter character)
            {
                character.Health = character.MaxHealth;
                character.Mana = character.MaxMana;
                Console.WriteLine($"{character.Name} was revived by a {Name} and is restored to full health and mana!");
            }
            else
            {
                Console.WriteLine("This item can only be used on a character.");
            }
        }
    }
}