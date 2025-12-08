using System;
using MonsterList; // <-- Add this line to access IMonster
using ItemList;
namespace ClassList;

public class Ranger : ICharacter
{
    public string Name { get; set; }
    public int level { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public string CurrentStatus { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public Ranger(string name)
    {
        Name = name;
        level = 1;
        MaxHealth = 80;
        Health = MaxHealth;
        MaxMana = 80;
        Mana = MaxMana;
        CurrentStatus = "Normal";
        Strength = 25;
        Defense = 15;
        Speed = 20;
        Luck = 20;
    }
public List<IItem> Inventory { get; } = new List<IItem>();  
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
        Mana -= 15;
        Console.WriteLine($"{Name} uses Double Shot!");
        Attack(target);
        Attack(target);
    }

    public void Evasion()
    {
        Mana -= 30;
        int evasionBoost = 10;
        Speed += evasionBoost;
        Console.WriteLine($"{Name} increases speed by {evasionBoost}. New speed is {Speed}.");
    }

      public void InventoryAdd(IItem item)
    {
        Inventory.Add(item);
    }

    public void InventoryRemove(IItem item)
    {
        Inventory.Remove(item);
    }

    public bool UseItem(IItem item, ICharacter target)
    {
        if (Inventory.Contains(item))
        {
            item.Use(target);
            Inventory.Remove(item);
            return true;
        }
        else
        {
            Console.WriteLine($"{Name} does not have a {item.Name} in the inventory.");
            return false;
        }
    }
}