using System;
using MonsterList; // <-- Add this line to access IMonster
using ClassList;   // <-- Add this line to access ICharacter

public class Combat
{
    public static void ExecuteTurn(ICharacter character, IMonster monster)
    {
        if (character.Speed >= monster.Speed)
        {

            CombatMenu.ShowCombatMenu(character, monster);
            if (monster.Health > 0)
            {
                monster.TakeTurn(character);
            }
        }
        else
        {
            monster.TakeTurn(character);
            if (character.Health > 0)
            {
                CombatMenu.ShowCombatMenu(character, monster);
            }
        }
    }

    public static void ExecuteMonsterTurn(ICharacter character, IMonster monster)
    {
        monster.TakeTurn(character);
    }

    public static bool IsDefeated(ICharacter character)
    {
        return character.Health <= 0;
    }

    public static bool IsDefeated(IMonster monster)
    {
        return monster.Health <= 0;
    }

    public static void DisplayStatus(ICharacter character, IMonster monster)
    {
        Console.WriteLine($"{character.Name} - Health: {character.Health}, Level: {character.level}");
        Console.WriteLine($"{monster.Name} - Health: {monster.Health}");
    }

    public static void StartCombat(ICharacter character, IMonster monster)
    {
        Console.WriteLine($"A wild {monster.Name} appears!");

        while (!IsDefeated(character) && !IsDefeated(monster))
        {
            DisplayStatus(character, monster);
            ExecuteTurn(character, monster);
        }

        if (IsDefeated(monster))
        {
            Console.WriteLine($"{character.Name} has defeated the {monster.Name}!");
            Leveling.LevelUp(character);
        }
        else
        {
            Console.WriteLine($"{character.Name} has been defeated by the {monster.Name}...the adventure ends here.");
        }
    }
}