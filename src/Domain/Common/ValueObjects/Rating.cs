namespace Domain.Common.ValueObjects;

public record Rating
{
    public double Value { get; init; }

    private Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateNew(double value)
    {
        return new(value);
    }
}