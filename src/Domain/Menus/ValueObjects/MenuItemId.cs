namespace Domain.Menus.ValueObjects;

public record MenuItemId
{
    public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new(value);
    }
}