namespace Domain.Entities;

public class Reservation : BaseEntity
{
    public Reservation(int sessionSeatId)
    {
        SessionSeatId = sessionSeatId;
    }

    public DateTimeOffset ExpiresAt { get; set; }

    public int SessionSeatId { get; set; }
    public int OrderId { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}