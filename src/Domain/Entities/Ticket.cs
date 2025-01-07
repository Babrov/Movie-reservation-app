namespace Domain.Entities;

public class Ticket : BaseEntity
{
    public string Code { get; init; }
    public string TicketUrl { get; init; }
    public TicketStatus Status { get; }

    public int ReservationId { get; init; }
}