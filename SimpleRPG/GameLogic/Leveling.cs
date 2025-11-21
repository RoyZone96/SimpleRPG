using ClassList;

public class Leveling
{
    public static void LevelUp(ICharacter character)
    {
        character.level++;
        character.MaxHealth += 10;
        character.Health = character.MaxHealth;
        character.MaxMana += 5;
        character.Mana = character.MaxMana;
        character.Strength += 2;
        character.Defense += 2;
        character.Speed += 1;
        character.Luck += 1;

        Console.WriteLine($"{character.Name} has leveled up to level {character.level}!");
        Console.WriteLine($"New stats - Health: {character.Health}, Strength: {character.Strength}, Defense: {character.Defense}, Speed: {character.Speed}, Luck: {character.Luck}");
    }
}