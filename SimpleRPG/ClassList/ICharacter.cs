namespace ClassList
{
    using MonsterList;

    public interface ICharacter
    {
        string Name { get; set; }
        int level { get; set; }
        int Health { get; set; }
        int Strength { get; set; }
        int Defense { get; set; }
        int Speed { get; set; }
        int Luck { get; set; }

        void Attack(IMonster target);
    }
}