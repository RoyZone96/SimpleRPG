using System;
using ClassList;
using GameLogic;

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
            Health = 60;
            Mana = 40;
            Strength = 18;
            Defense = 10;
            Speed = 20;
            Luck = 14;
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
            Random stunRand = new Random();
            if (stunRand.Next(0, 100) < 40)
            {
                StatusEffects.ApplyStun(target);
                Console.WriteLine($"{target.Name} is stunned by the Sonic Screech!");
            }

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