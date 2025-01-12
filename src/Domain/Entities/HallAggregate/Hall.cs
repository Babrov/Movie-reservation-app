namespace Domain.Entities;

public class Hall : BaseEntity, IAggregateRoot
{
    private readonly List<Seat> seats = new();

    public Hall(HallType type)
    {
        Type = type;
    }

    public HallType Type { get; private set; }
    public IReadOnlyCollection<Seat> Seats => seats.AsReadOnly();

    public void AddSeat(Seat seat)
    {
        if (seats.Any(existing => existing.Row == seat.Row && existing.Number == seat.Number))
            throw new ArgumentException("Seat already exists");

        seats.Add(seat);
    }
}