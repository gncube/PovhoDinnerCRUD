namespace Domain.Dinners.ValueObjects;

public record DinnerId
{
    public Guid Value { get; }
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DinnerId Create(Guid value)
    {
        return new(value);
    }
}