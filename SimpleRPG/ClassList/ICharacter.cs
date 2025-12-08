namespace ClassList
{
    using MonsterList;
    using ItemList;

    public interface ICharacter
    {
        string Name { get; set; }
        int level { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Mana { get; set; }
        int MaxMana { get; set; }
        string CurrentStatus { get; set; }
        int Strength { get; set; }
        int Defense { get; set; }
        int Speed { get; set; }
        int Luck { get; set; }

        void Attack(IMonster target);
        //inventory system
        List<IItem> Inventory { get; }
        void InventoryAdd(IItem item);
        void InventoryRemove(IItem item);   
        bool UseItem(IItem item, ICharacter target);
    }
}