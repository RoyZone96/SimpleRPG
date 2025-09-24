using System;
using ClassList; // <-- Add this line to access ICharacter
namespace MonsterList;

public class Chimera : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Chimera()
    {
        Name = "Chimera";
        Health = 120;
        Strength = 25;
        Defense = 15;
        Speed = 20;
        Luck = 10;
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

        int damage = (int)(Strength * 1.3) - target.Defense;
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

        int damage = (int)(Strength * 1.1) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Tail Swipe on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            int action = rand.Next(0, 100);
            if (action < 60)
                Attack(target);
            else if (action < 85)
                FireBreath(character);
            else
                TailSwipe(character);
        }
    }
}