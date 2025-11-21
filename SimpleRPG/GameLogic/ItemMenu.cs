using System;
using ClassList;
using ItemList;

namespace GameLogic
{
    public class ItemMenu
    {
        public static void ShowItemMenu(ICharacter character)
        {
            if (character.Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            Console.WriteLine("Inventory:");
            for (int i = 0; i < character.Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.Inventory[i].Name}");
            }
            Console.WriteLine("Select an item number to use it, or 0 to go back:");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice > 0 && choice <= character.Inventory.Count)
                {
                    IItem selectedItem = character.Inventory[choice - 1];
                    selectedItem.Use(character);
                    character.Inventory.RemoveAt(choice - 1);
                }
                else if (choice == 0)
                {
                    // Go back to previous menu
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}