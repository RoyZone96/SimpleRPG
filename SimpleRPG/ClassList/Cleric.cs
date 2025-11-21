using System;
using MonsterList; // <-- Add this line to access IMonster
using ItemList; 
namespace ClassList;

public class Cleric : ICharacter
{

    public string Name { get; set; }
    public int level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public List<IItem> Inventory { get; } = new List<IItem>();
    public Cleric(string name)
    {
        Name = name;
        level = 1;
        MaxHealth = 90;
        Health = MaxHealth;
        MaxMana = 100;
        Mana = MaxMana;
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
        if (Mana < 15)
        {
            Console.WriteLine($"{Name} does not have enough Mana to heal.");
            return;
        }
        Mana -= 15;
        int healAmount = (int)(Strength * 1.5);
        Health += healAmount;
        Console.WriteLine($"{Name} heals for {healAmount}. {Name} now has {Health} health.");
    }

    public void HolyLight(IMonster target)
    {
        if (Mana < 30)
        {
            Console.WriteLine($"{Name} does not have enough Mana to use Holy Light.");
            return;
        }
        Mana -= 30;
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