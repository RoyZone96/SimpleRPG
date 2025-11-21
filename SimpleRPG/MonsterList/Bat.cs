using System;
using ClassList;

namespace MonsterList
{
    public class Bat : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public Bat()
        {
            Name = "Bat";
            Health = 30;
            Mana = 20;
            Strength = 10;
            Defense = 5;
            Speed = 25;
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

        public void SonicScreech(ICharacter target)
        {
            if (Mana < 5)
            {
                Console.WriteLine($"{Name} does not have enough Mana to use Sonic Screech!");
                Attack(target);
                return;
            }
            Mana -= 5;
            Random rand = new Random();
            if (rand.Next(0, 100) < target.Luck)
            {
                Console.WriteLine($"{target.Name} evaded the Sonic Screech!");
                return;
            }

            int damage = (int)(Strength * 1.2) - target.Defense;
            damage = damage < 0 ? 0 : damage;
            target.Health -= damage;

            Console.WriteLine($"{Name} uses Sonic Screech on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
        }

        public void TakeTurn(object target)
        {
            if (target is ICharacter character)
            {
                Random rand = new Random();
                if (rand.Next(0, 100) < 70)
                    Attack(target);
                else
                    SonicScreech(character);
            }

        }
    }
}