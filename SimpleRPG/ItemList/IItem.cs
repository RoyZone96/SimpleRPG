using ClassList;
namespace ItemList
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }

        void Use(ICharacter character);
    }
}