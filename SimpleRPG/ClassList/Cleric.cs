using System;
using MonsterList; // <-- Add this line to access IMonster

namespace ClassList;
public class Cleric : ICharacter
{

    public string Name { get; set; }
    public int level { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Cleric(string name)
    {
        Name = name;
        level = 1;
        Health = 90;
        Strength = 20;
        Defense = 25;
        Speed = 15;
        Luck = 15;
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

    public void Heal()
    {
        int healAmount = (int)(Strength * 1.5);
        Health += healAmount;
        Console.WriteLine($"{Name} heals for {healAmount}. {Name} now has {Health} health.");
    }

    public void HolyLight(IMonster target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Holy Light!");
            return;
        }

        int holyDamage = (int)(Strength * 1.2) - target.Defense;
        holyDamage = holyDamage < 0 ? 0 : holyDamage;
        target.Health -= holyDamage;

        Console.WriteLine($"{Name} uses Holy Light on {target.Name} for {holyDamage} damage. {target.Name} has {target.Health} health left.");
    }

}