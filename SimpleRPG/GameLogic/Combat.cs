using System;
using MonsterList; // <-- Add this line to access IMonster
using ClassList;   // <-- Add this line to access ICharacter
using ItemList;
using GameLogic;

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
            IItem reward = RandomItemGet.GetRandomItem();
            character.Inventory.Add(reward);
            Console.WriteLine($"{character.Name} received a {reward.Name}!");
        }
        else
        {
            Console.WriteLine($"{character.Name} has been defeated by the {monster.Name}...the adventure ends here.");
        }
    }

    public static bool TryAutoRevive(ICharacter character){
        if (character.Health <= 0)
        {
            if (character.Mana >= 20)
            {
                character.Mana -= 20;
                character.Health = character.MaxHealth / 2;
                Console.WriteLine($"{character.Name} used Auto-Revive! Health restored to {character.Health}. Mana left: {character.Mana}");
                return true;
            }
            else
            {
                Console.WriteLine($"{character.Name} does not have enough Mana to Auto-Revive.");
                return false;
            }
        }
        return false;
    }

    private static void ResolvePostMonsterTurn(ICharacter character, IMonster monster)
    {
        if (IsDefeated(character))
        {
            if (!TryAutoRevive(character))
            {
                Console.WriteLine($"{character.Name} has been defeated by the {monster.Name}...the adventure ends here.");
            }
        }
    }
}