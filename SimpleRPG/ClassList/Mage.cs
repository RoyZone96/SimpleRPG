using System;
using MonsterList;

namespace ClassList
{
    public class Mage : ICharacter
    {
        public string Name { get; set; }
        public int level { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Mage(string name)
        {
            Name = name;
            level = 1;
            Health = 80;
            Strength = 40;
            Defense = 10;
            Speed = 20;
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

        public void CastSpell(IMonster target)
        {
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
            int shieldAmount = (int)(Defense * 1.5);
            Health += shieldAmount;
            Console.WriteLine($"{Name} raises a magical shield, increasing health by {shieldAmount}. {Name} now has {Health} health.");
        }
    }
}