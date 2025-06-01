using Shared;

namespace Venues.Domain;

public class Venue : BaseEntity, IAggregateRoot
{
    private readonly List<Seat> seats = new();

    public Venue(VenueType type)
    {
        Type = type;
    }

    // TODO: Add config and make more specific
    public string Location { get; set; }
    public VenueType Type { get; private set; }
    public IReadOnlyCollection<Seat> Seats => seats.AsReadOnly();

    public void AddSeat(Seat seat)
    {
        if (seats.Any(existing => existing.Row == seat.Row && existing.Number == seat.Number))
            throw new ArgumentException("Seat already exists");

        seats.Add(seat);
    }
}