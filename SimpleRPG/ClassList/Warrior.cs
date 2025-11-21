using System;
using MonsterList;
using ItemList;
namespace ClassList
{
    public class Warrior : ICharacter
    {
        public string Name { get; set; }
        public int level { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Warrior(string name)
        {
            Name = name;
            level = 1;
            MaxHealth = 100;
            Health = MaxHealth;
            MaxMana = 50;
            Mana = MaxMana;
            Strength = 30;
            Defense = 20;
            Speed = 15;
            Luck = 10;
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

        public void PowerStrike(IMonster target)
        {
            if (Mana < 20)
            {
                Console.WriteLine($"{Name} does not have enough Mana to use Power Strike.");
                return;
            }
            Mana -= 20;
            Random rand = new Random();
            if (rand.Next(0, 100) < target.Luck)
            {
                Console.WriteLine($"{target.Name} evaded the Power Strike!");
                return;
            }

            int damage = (int)(Strength * 1.5) - target.Defense;
            damage = damage < 0 ? 0 : damage;
            target.Health -= damage;

            Console.WriteLine($"{Name} uses Power Strike on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        }

        public void ShieldBlock()
        {
            if (Mana < 10)
            {
                Console.WriteLine($"{Name} does not have enough Mana to use Shield Block.");
                return;
            }
            Mana -= 10;
            int blockAmount = (int)(Defense * 1.5);
            Health += blockAmount;
            Console.WriteLine($"{Name} raises a shield, increasing health by {blockAmount}. {Name} now has {Health} health.");
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

