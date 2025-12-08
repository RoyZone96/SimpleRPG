using System;
using ClassList; // <-- Add this line to access ICharacter
using GameLogic;

namespace MonsterList;

public class GiantSpider : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public GiantSpider()
    {
        Name = "Giant Spider";
        Health = 80;
        Mana = 40;
        Strength = 30;
        Defense = 25;
        Speed = 35;
        Luck = 7;
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

    public void WebShot(ICharacter target)
    {
        if (Mana < 20)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Web Shot!");
            Attack(target);
            return;
        }
        Mana -= 20;
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Web Shot!");
            return;
        }

        int damage = (int)(Strength * 1.3) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Web Shot on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        Random stunnRand = new Random();
        if (stunnRand.Next(0, 100) < 30)
        {
            StatusEffects.ApplyStun(target);
            Console.WriteLine($"{target.Name} is stunned by the Web Shot!");
        }
    }

    public void PoisonBite(ICharacter target)
    {
        if (Mana < 15)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Poison Bite!");
            Attack(target);
            return;
        }
        Mana -= 15;
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Poison Bite!");
            return;
        }

        int damage = (int)(Strength * 1.2) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Poison Bite on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        Random poisonRand = new Random();
        if (poisonRand.Next(0, 100) < 50)
        {
            StatusEffects.ApplyPoison(target);
            Console.WriteLine($"{target.Name} is poisoned by the Poison Bite!");
        }
   }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < 70)
                Attack(target);
            else
                WebShot(character);
        }
    }
}