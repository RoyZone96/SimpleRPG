using ClassList; // <-- Add this line to access ICharacter
using ClassList; // <-- Add this line to access ICharacter


namespace MonsterList;

public class EvilKnight : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

    public EvilKnight()
    {
        Name = "Evil Knight";
        Health = 100;
        Strength = 20;
        Defense = 15;
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

    public void DarkSlash(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Dark Slash!");
            return;
        }

        int damage = (int)(Strength * 1.3) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Dark Slash on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void ShieldBash(ICharacter target)
    {
        Random rand = new Random();
        if (rand.Next(0, 100) < target.Luck)
        {
            Console.WriteLine($"{target.Name} evaded the Shield Bash!");
            return;
        }

        int damage = (int)(Strength * 1.1) - target.Defense;
        damage = damage < 0 ? 0 : damage;
        target.Health -= damage;

        Console.WriteLine($"{Name} uses Shield Bash on {target.Name} for {damage} damage. {target.Name} has {target.Health} health left.");
    }

    public void TakeTurn(object target)
    {
        if (target is ICharacter character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) < 70)
                Attack(target);
            else if (rand.Next(0, 2) == 0)
                DarkSlash(character);
            else
                ShieldBash(character);
        }
    }
}