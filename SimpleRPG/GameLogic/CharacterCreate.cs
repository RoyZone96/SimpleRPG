using System;
using ClassList;

public class CharacterCreate
{
    public static ICharacter CreateCharacter(string characterType, string name)
    {
        Console.WriteLine($"Creating character of type: {characterType} with name: {name}");
        switch (characterType.ToLower())
        {
            case "warrior":
                return new Warrior(name);
            case "mage":
                return new Mage(name);
            case "cleric":
                return new Cleric(name);
            case "ranger":
                return new Ranger(name);
            default:
                throw new ArgumentException("This class does not exist. Please choose Warrior, Mage, Cleric, or Ranger.");
        }
    }
}