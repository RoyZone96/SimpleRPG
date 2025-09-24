using System;
using MonsterList;
using ClassList;

namespace SimpleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simple RPG!");

            // Character Creation
            Console.Write("Enter your character's name: ");
            string? playerName = Console.ReadLine();
            Console.Write("Enter your character's class (Warrior, Mage, Cleric, Ranger): ");
            string? characterType = Console.ReadLine();

            if (playerName != null && characterType != null)
            {
                ICharacter player = CharacterCreate.CreateCharacter(characterType, playerName);

                // Monster Progression 
                IMonster monster = Progression.GetMonsterByLevel(player.level);

                // Start Combat
                Combat.StartCombat(player, monster);
                // Continue progression
                while (player.Health > 0)
                {
                    monster = Progression.GetNextMonster(player);
                    if (monster == null)
                    {
                        Console.WriteLine("You have defeated all monsters. The adventure is complete! Congratulations!");
                        break;
                    }
                    Combat.StartCombat(player, monster);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please restart the game.");
            }

            Console.WriteLine("Thank you for playing Simple RPG!");
        }
    }
}
