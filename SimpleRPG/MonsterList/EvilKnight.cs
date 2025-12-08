using GameLogic;
using System;
using ClassList; // <-- Add this line to access ICharacter
    

namespace MonsterList;

public class EvilKnight : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public EvilKnight()
    {
        Name = "Evil Knight";
        Health = 100;
        Mana = 75;
        Strength = 50;
        Defense = 55;
        Speed = 10;
        Luck = 5;
    }

    public void Attack(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < character.Luck)
            {
                Console.WriteLine($"{character.Name} evaded the attack!");
                return;
            }

            int damage = Strength - character.Defense;
            damage = damage < 0 ? 0 : damage;
            character.Health -= damage;

            Console.WriteLine($"{Name} attacks {character.Name} for {damage} damage. {character.Name} has {character.Health} health left.");
        }
    }

    public void DarkSlash(ICharacter target)
    {
        if (Mana < 20)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Dark Slash!");
            return;
        }
        Mana -= 20;
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Dark Slash!");
            return;
        }

        int damage = (int)(Strength * 1.3) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Dark Slash on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    
        Random curseRand = new Random();
        if (curseRand.Next(0, 100) < 75) 
        {
            StatusEffects.ApplyCursed(target);
            Console.WriteLine($"{target.Name} is cursed by the Dark Slash!");
        }
    }

    public void ShieldBash(ICharacter target)
    {
        if (Mana < 15)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Shield Bash!");
            return;
        }
        Mana -= 15; 
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Shield Bash!");
            return;
        }

        int damage = (int)(Strength * 1.1) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Shield Bash on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < 70)
                Attack(target);
            else if (rand.Next(0, 2) == 0)
                DarkSlash(character);
            else
                ShieldBash(character);
        }
    }
}