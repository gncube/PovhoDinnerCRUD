namespace Domain.Menus.ValueObjects;

public record MenuId
{
    public Guid Value { get; }
    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new(value);
    }
}