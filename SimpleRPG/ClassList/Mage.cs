using System;
using MonsterList;
using ItemList;

namespace ClassList
{
    public class Mage : ICharacter
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

        public Mage(string name)
        {
            Name = name;
            level = 1;
            MaxHealth = 80;
            Health = MaxHealth;
            MaxMana = 120;
            Mana = MaxMana;
            CurrentStatus = "Normal";
            Strength = 10;
            Defense = 10;
            Speed = 20;
            Luck = 15;
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
            Mana += 5;  

            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        }

        public void CastSpell(IMonster target)
        {
            if (Mana < 10)
            {
                Console.WriteLine($"{Name} does not have enough Mana to cast a spell.");
                return;
            }
            Mana -= 10;
            Random rand = new Random();
            if (rand.Next(0, 100) < target.Luck)
            {
                Console.WriteLine($"{target.Name} evaded the spell!");
                return;
            }

            int spellDamage = (int)(Strength * 1.5) - target.Defense;
            spellDamage = spellDamage < 0 ? 0 : spellDamage;
            target.Health -= spellDamage;

            Console.WriteLine($"{Name} casts a spell on {target.Name} for {spellDamage} damage. {target.Name} has {target.Health} health left.");
        }

        public void ShieldSpell(ICharacter target)
        {
            if (Mana < 30)
            {
                Console.WriteLine($"{Name} does not have enough Mana to cast Shield Spell.");
                return;
            }
            Mana -= 30;
            int shieldAmount = (int)(Defense * 1.5);
            Health += shieldAmount;
            Console.WriteLine($"{Name} raises a magical shield, increasing health by {shieldAmount}. {Name} now has {Health} health.");
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
}