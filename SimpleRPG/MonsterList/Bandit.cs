using System;
using ClassList;
namespace MonsterList
{
    public class Bandit : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Bandit()
        {
            Name = "Bandit";
            Health = 70;
            Mana = 30;
            Strength = 20;
            Defense = 5;
            Speed = 50;
            Luck = 15;
        }

        public void Attack(object target)
        {
            if (target is ICharacter character)
            {
                int damage = Strength - character.Defense;
                damage = damage < 0 ? 0 : damage;
                character.Health -= damage;
                Console.WriteLine($"{Name} attacks {character.Name} for {damage} damage!");
            }
        }

        public void Backstab(ICharacter target)
        {
            if (Mana < 10)
            {
                Console.WriteLine($"{Name} does not have enough Mana to use Backstab!");
                Attack(target);
                return;
            }
            Mana -= 10;
            Random rand = new Random();
            if (rand.Next(0, 100) < target.Luck)
            {
                Console.WriteLine($"{target.Name} evaded the Backstab!");
                return;
            }

            int damage = (Strength * 2) - target.Defense;
            damage = damage < 0 ? 0 : damage;
            target.Health -= damage;

            Console.WriteLine($"{Name} uses Backstab on {target.Name} for {damage} damage! {target.Name} has {target.Health} health left.");
        }
        public void TakeTurn(object target)
        {
            Attack(target);
        }
    }
}
    