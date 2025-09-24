using System;
using MonsterList;

namespace ClassList
{
    public class Warrior : ICharacter
    {
        public string Name { get; set; }
        public int level { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Warrior(string name)
        {
            Name = name;
            level = 1;
            Health = 100;
            Strength = 30;
            Defense = 20;
            Speed = 15;
            Luck = 10;
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

        public void PowerStrike(IMonster target)
        {
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
            int blockAmount = (int)(Defense * 1.5);
            Health += blockAmount;
            Console.WriteLine($"{Name} raises a shield, increasing health by {blockAmount}. {Name} now has {Health} health.");
        }
    }
}

