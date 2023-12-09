namespace Domain.MenuReview.ValueObjects;

public record MenuReviewId
{
    public Guid Value { get; }
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        return new(value);
    }
}