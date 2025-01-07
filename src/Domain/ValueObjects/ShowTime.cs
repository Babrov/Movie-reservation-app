namespace Domain.ValueObjects;

public class ShowTime : ValueObject
{
    public DateOnly Date { get; set; }
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return StartsAt;
        yield return EndsAt;
    }
}