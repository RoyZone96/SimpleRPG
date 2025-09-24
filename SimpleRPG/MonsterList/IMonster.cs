using System;
using ClassList;

namespace MonsterList
{
    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        int Strength { get; set; }
        int Defense { get; set; }
        int Speed { get; set; }
        int Luck { get; set; }

        void Attack(object target); // Temporarily using object to avoid circular dependency
        void TakeTurn(object target); // New method to decide action each turn
    }
}