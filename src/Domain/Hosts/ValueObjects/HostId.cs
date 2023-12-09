namespace Domain.Hosts.ValueObjects;

public record HostId
{
    public Guid Value { get; }
    private HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new(value);
    }
}