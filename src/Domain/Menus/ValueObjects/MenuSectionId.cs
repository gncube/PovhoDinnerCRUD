namespace Domain.Menus.Entities;

public record MenuSectionId
{
    public Guid Value { get; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new(value);
    }
}