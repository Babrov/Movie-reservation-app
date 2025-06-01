using MoviesCatalog.Domain;
using Shared;

namespace Reservations.Domain;

public class Reservation : BaseEntity, IAggregateRoot
{
    private readonly List<ReservedSeat> seats = new();

    public Reservation(Guid userId, IList<ReservedSeat> items)
    {
        UserId = userId;
        foreach (ReservedSeat item in items) AddSeat(item);
    }

    private Reservation()
    {
    }

    public IReadOnlyCollection<ReservedSeat> Seats => seats.AsReadOnly();

    public Status Status { get; } = Status.Placed;
    public Guid UserId { get; init; }

    public Guid? PaymentId { get; init; }

    public void AddSeat(ReservedSeat item)
    {
        seats.Add(item);
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (ReservedSeat item in seats) total += item.Price;
        return total;
    }
}