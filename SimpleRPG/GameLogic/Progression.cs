using System;
using System.Collections.Generic;
using MonsterList; // <-- Add this line to access IMonster
using ClassList;   // <-- Add this line to access ICharacter

public class Progression
{
    public static readonly List<Func<IMonster>> MonsterOrder = new List<Func<IMonster>>
    {
        () => new Bat(),
        () => new Goblin(),
        () => new Skeleton(),
        () => new Bandit(),
        () => new GiantSpider(),
        () => new Sorcerer(),
        () => new MetalGolem(),
        () => new Chimera(),
        () => new EvilKnight(),
        () => new GreatDragon()
    };

    public static IMonster GetMonsterByLevel(int level)
    {
        if (level < 1 || level > MonsterOrder.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid level for monster selection");
        }
        return MonsterOrder[level - 1]();
    }

    public static IMonster GetNextMonster(ICharacter character)
    {
        int nextLevel = character.level;
        if (!HasMoreMonsters(nextLevel))
            return null; // No more monsters, adventure complete
        return GetMonsterByLevel(nextLevel);
    }

    public static bool IsFinalMonster(IMonster monster)
    {
        return monster is GreatDragon;
    }

    public static bool HasMoreMonsters(int level)
    {
        return level <= MonsterOrder.Count;
    }

    public static IMonster GetFinalMonster()
    {
        return new GreatDragon();
    }

    public static void DisplayMonsterInfo(IMonster monster)
    {
        Console.WriteLine($"A wild {monster.Name} appears!");
        Console.WriteLine($"Health: {monster.Health}");
        Console.WriteLine($"Strength: {monster.Strength}");
        Console.WriteLine($"Defense: {monster.Defense}");
        Console.WriteLine($"Speed: {monster.Speed}");
        Console.WriteLine($"Luck: {monster.Luck}");
    }

    public static void DisplayNextMonsterInfo(ICharacter character)
    {
        if (HasMoreMonsters(character.level))
        {
            IMonster nextMonster = GetNextMonster(character);
            DisplayMonsterInfo(nextMonster);
        }
        else
        {
            Console.WriteLine("You have defeated the Great Dragon. The adventure is complete! Congratulations!");
        }
    }

}