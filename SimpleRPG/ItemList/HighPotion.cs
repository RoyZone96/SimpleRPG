using System;
using ClassList;

namespace ItemList
{
    public class HighPotion : IItem
    {
        public string Name { get; set; } = "High Potion";
        public string Description { get; set; } = "Restores 70 Health.";
        public int HealthRestoreAmount { get; set; } = 70;

        public void Use(ICharacter character)
        {
            character.Health += HealthRestoreAmount;
            Console.WriteLine($"{character.Name} used a High Potion and restored {HealthRestoreAmount} Health. Current Health: {character.Health}");
        }
    }
}