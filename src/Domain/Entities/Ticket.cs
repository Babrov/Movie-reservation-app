namespace Domain.Entities;

public class Ticket : BaseEntity
{
    public string Code { get; init; }
    public TicketStatus Status { get; }

    public int OrderItemId { get; init; }
}