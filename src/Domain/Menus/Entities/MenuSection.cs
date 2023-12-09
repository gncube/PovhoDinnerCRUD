namespace Domain.Menus.Entities;

public sealed class MenuSection
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items)
    //: base(menuSectionId)
    // TODO: Add base class
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem> items) => new(MenuSectionId.CreateUnique(), name, description, items);
}