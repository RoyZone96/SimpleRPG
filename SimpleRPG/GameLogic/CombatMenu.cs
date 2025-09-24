using System;
using ClassList;
using MonsterList;
public class CombatMenu
{
    public static void ShowCombatMenu(ICharacter character, IMonster monster)
    {
        Console.WriteLine($"What will {character.Name} do?:");
        Console.WriteLine("1. Attack");

        if (character is Warrior)
        {
            Console.WriteLine("2. Power Strike");
            Console.WriteLine("3. Shield Block");
        }
        else if (character is Mage)
        {
            Console.WriteLine("2. Cast Spell");
            Console.WriteLine("3. Shield Spell");
        }
        else if (character is Cleric)
        {

            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Holy Light");
        }
        else if (character is Ranger)
        {
            Console.WriteLine("2. Double Shot");
            Console.WriteLine("3. Evasion");
        }

        Console.Write("9. Run Away\n");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                character.Attack(monster);
                break;
            case "2":
                if (character is Warrior warrior)
                {
                    warrior.PowerStrike(monster);
                }
                else if (character is Mage mage)
                {
                    mage.CastSpell(monster);
                }
                else if (character is Cleric cleric)
                {
                    cleric.Heal();
                }
                else if (character is Ranger ranger)
                {
                    ranger.DoubleShot(monster);
                }
                break;
            case "3":
                if (character is Warrior warriorBlock)
                {
                    warriorBlock.ShieldBlock();
                }
                else if (character is Mage mageShield)
                {
                    mageShield.ShieldSpell(character);
                }
                else if (character is Cleric clericHoly)
                {
                    clericHoly.HolyLight(monster);
                }
                else if (character is Ranger rangerEvasion)
                {
                    rangerEvasion.Evasion();
                }
                break;
            case "9":
                Console.WriteLine($"{character.Name} ran away from the battle!");
                character.Health = 0; // End combat
                break;
            default:
                Console.WriteLine("Invalid choice, turn skipped.");
                break;
        }
    }
}