namespace Domain.Entities;

public class Session : BaseEntity, IAggregateRoot
{
    public Session(int movieId, DateOnly date, DateTime startsAt, DateTime endsAt)
    {
        MovieId = movieId;
        Date = date;
        StartsAt = startsAt;
        EndsAt = endsAt;
    }

    public DateOnly Date { get; private set; }
    public DateTime StartsAt { get; private set; }
    public DateTime EndsAt { get; private set; }
    public decimal Price { get; set; }

    public int MovieId { get; private set; }
    public int HallId { get; }
}