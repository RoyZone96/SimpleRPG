using System;
using ClassList; // <-- Add this line to access ICharacter
using GameLogic;
namespace MonsterList;


public class Chimera : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Chimera()
    {
        Name = "Chimera";
        Health = 120;
        Mana = 80;
        Strength = 59;
        Defense = 45;
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
        if (Mana < 20)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Fire Breath!");
            Attack(target);
            return;
        }
        Mana -= 20;
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
    
        Random burnRand = new Random();
        if (burnRand.Next(0, 100) < 40) 
        {
            StatusEffects.ApplyBurn(target);
            Console.WriteLine($"{target.Name} is burned by the Fire Breath!");
        }           
    }

    public void TailSwipe(ICharacter target)
    {
        
        if (Mana < 15)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Tail Swipe!");
            Attack(target);
            return;
        }
        Mana -= 15;
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