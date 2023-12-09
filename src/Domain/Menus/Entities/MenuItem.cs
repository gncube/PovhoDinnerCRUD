using Domain.Menus.ValueObjects;

namespace Domain.Menus.Entities;

public sealed class MenuItem
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
    //: base(menuItemId)
    // TODO: Add base class
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description) => new(MenuItemId.CreateUnique(), name, description);
}