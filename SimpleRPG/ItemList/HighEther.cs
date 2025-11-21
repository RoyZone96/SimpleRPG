using System;
using ClassList;

namespace ItemList
{
    public class HighEther : IItem
    {
        public string Name { get; set; } = "High Ether";
        public string Description { get; set; } = "Restores 70 Mana.";
        public int ManaRestoreAmount { get; set; } = 70;

        public void Use(ICharacter character)
        {
            character.Mana += ManaRestoreAmount;
            Console.WriteLine($"{character.Name} used a High Ether and restored {ManaRestoreAmount} Mana. Current Mana: {character.Mana}");
        }
    }
}