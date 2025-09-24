using System;
using MonsterList; // <-- Add this line to access IMonster
namespace ClassList;
public class Ranger : ICharacter
{
    public string Name { get; set; }
    public int level { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Ranger(string name)
    {
        Name = name;
        level = 1;
        Health = 80;
        Strength = 25;
        Defense = 15;
        Speed = 20;
        Luck = 20;
    }

    public void Attack(IMonster target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the attack!");
            return;
        }

        int damage = Strength - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void DoubleShot(IMonster target)
    {
        Console.WriteLine($"{Name} uses Double Shot!");
        Attack(target);
        Attack(target);
    }

    public void Evasion()
    {
        int evasionBoost = 10;
        Speed += evasionBoost;
        Console.WriteLine($"{Name} increases speed by {evasionBoost}. New speed is {Speed}.");
    }
}