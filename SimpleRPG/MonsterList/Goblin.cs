using System;
using ClassList;

namespace MonsterList
{
    public class Goblin : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Goblin()
        {
            Name = "Goblin";
            Health = 50;
            Strength = 15;
            Defense = 10;
            Speed = 10;
            Luck = 5;
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

        public void SneakAttack(ICharacter target)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < target.Luck)
            {
                Console.WriteLine($"{target.Name} evaded the Sneak Attack!");
                return;
            }

            int damage = (int)(Strength * 1.5) - target.Defense;
            damage = damage < 0 ? 0 : damage;
            target.Health -= damage;

            Console.WriteLine($"{Name} uses Sneak Attack on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        }


        public void TakeTurn(object target)
        {
            if (target is ICharacter character)
            {
                Random rand = new Random();
                if (rand.Next(0, 100) < 70)
                    Attack(target);
                else
                    SneakAttack(character);
            }
        }
    }
}