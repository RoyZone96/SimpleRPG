using System;
using ClassList; // <-- Add this line to access ICharacter

namespace MonsterList;

public class GreatDragon : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public GreatDragon()
    {
        Name = "Great Dragon";
        Health = 300;
        Strength = 50;
        Defense = 30;
        Speed = 20;
        Luck = 15;
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

    public void FireBreath(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Fire Breath!");
            return;
        }

        int damage = (int)(Strength * 1.5) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Fire Breath on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TailSwipe(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Tail Swipe!");
            return;
        }

        int damage = (int)(Strength * 1.2) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Tail Swipe on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < 60)
                Attack(target);
            else if (rand.Next(0, 100) < 80)
                FireBreath(character);
            else
                TailSwipe(character);
        }

    }
}