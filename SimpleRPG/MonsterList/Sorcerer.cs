using System;
using ClassList; // <-- Add this line to access ICharacter  

namespace MonsterList;

public class Sorcerer : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Sorcerer()
    {
        Name = "Sorcerer";
        Health = 140;
        Strength = 30;
        Defense = 8;
        Speed = 15;
        Luck = 12;
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

    public void Fireball(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Fireball!");
            return;
        }

        int damage = (int)(Strength * 1.3) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} casts Fireball on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void IceSpike(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Ice Spike!");
            return;
        }

        int damage = (int)(Strength * 1.2) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} casts Ice Spike on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void LightningBolt(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Lightning Bolt!");
            return;
        }

        int damage = (int)(Strength * 1.4) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} casts Lightning Bolt on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            int action = rand.Next(0, 100);
            if (action < 50)
                Attack(target);
            else if (action < 75)
                Fireball(character);
            else if (action < 90)
                IceSpike(character);
            else
                LightningBolt(character);
        }
    }
}