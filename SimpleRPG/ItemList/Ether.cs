using System;
using ClassList;

namespace ItemList
{
    public class Ether : IItem
    {
        public string Name { get; set; } = "Ether";
        public string Description { get; set; } = "Restores 30 Mana.";
        public int ManaRestoreAmount { get; set; } = 30;

        public void Use(ICharacter character)
        {
            character.Mana += ManaRestoreAmount;
            Console.WriteLine($"{character.Name} used an Ether and restored {ManaRestoreAmount} Mana. Current Mana: {character.Mana}");
        }
    }
}