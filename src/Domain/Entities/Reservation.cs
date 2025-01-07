namespace Domain.Entities;

public class Reservation : BaseEntity, IAggregateRoot
{
    public Reservation(int orderId, int sessionId, int seatId)
    {
    }

    public DateTimeOffset ExpiresAt { get; set; }

    public int SessionId { get; set; }
    public int OrderId { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}