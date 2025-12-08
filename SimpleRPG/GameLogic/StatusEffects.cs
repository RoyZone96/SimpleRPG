using System;
using System.Collections.Generic;
using ClassList;


namespace GameLogic
{
    public static class StatusEffects
    {
        public static void ApplyPoison(ICharacter character)
        {
            if (character.CurrentStatus != "Poisoned")
            {
                character.CurrentStatus = "Poisoned";
                Console.WriteLine($"{character.Name} has been poisoned!");
            }
        }

        public static void ApplyBurn(ICharacter character)
        {
            if (character.CurrentStatus != "Burned")
            {
                character.CurrentStatus = "Burned";
                Console.WriteLine($"{character.Name} has been burned!");
            }
        }

        public static void ApplyStun(ICharacter character)
        {
            if (character.CurrentStatus != "Stunned")
            {
                character.CurrentStatus = "Stunned";
                Console.WriteLine($"{character.Name} has been stunned!");
            }
        }

        public static void ApplyParalyze(ICharacter character)
        {
            if (character.CurrentStatus != "Paralyzed")
            {
                character.CurrentStatus = "Paralyzed";
                Console.WriteLine($"{character.Name} has been paralyzed!");
            }
        }

        public static void ApplyFrozen(ICharacter character)
        {
            if (character.CurrentStatus != "Frozen")
            {
                character.CurrentStatus = "Frozen";
                Console.WriteLine($"{character.Name} has been frozen!");
            }
        }

        public static void ApplyCursed(ICharacter character)
        {
            if (character.CurrentStatus != "Cursed")
            {
                character.CurrentStatus = "Cursed";
                Console.WriteLine($"{character.Name} has been cursed!");
            }
        }

        public static void ClearStatus(ICharacter character)
        {
            character.CurrentStatus = "Normal";
            Console.WriteLine($"{character.Name} is no longer affected by any status effects.");
        }

        public static bool ProcessStatusEffects(ICharacter character)
        {
            switch (character.CurrentStatus)
            {
                case "Poisoned":
                    int poisonDamage = character.MaxHealth / 10;
                    character.Health -= poisonDamage;
                    Console.WriteLine($"{character.Name} takes {poisonDamage} poison damage. Health is now {character.Health}.");
                    return character.Health > 0;
                case "Burned":
                    int burnDamage = character.MaxHealth / 15;
                    int weakenedStrength = character.Strength / 2;
                    character.Health -= burnDamage;
                    Console.WriteLine($"{character.Name} takes {burnDamage} burn damage. Health is now {character.Health}.");
                    return character.Health > 0;
                case "Stunned":
                    Console.WriteLine($"{character.Name} is stunned and cannot move this turn.");
                    StatusEffects.ClearStatus(character);
                    return false;
                case "Paralyzed":
                    Random rand = new Random();
                    if (rand.Next(0, 100) < 50)
                    {
                        Console.WriteLine($"{character.Name} is paralyzed and cannot move this turn.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"{character.Name} overcomes the paralysis and can act this turn.");
                        return true;
                    }

                case "Frozen":
                    Console.WriteLine($"{character.Name} is frozen and cannot move this turn.");
                    StatusEffects.ClearStatus(character);
                    return false;
                case "Cursed":
                    int curseDamage = character.MaxHealth / 20;
                    character.Health -= curseDamage;
                    Console.WriteLine($"{character.Name} takes {curseDamage} curse damage. Health is now {character.Health}.");
                    return character.Health > 0;
                default:
                    return true;
            }
        }
    }


}