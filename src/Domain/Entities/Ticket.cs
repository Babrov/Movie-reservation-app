namespace Domain.Entities;

public class Ticket : BaseEntity
{
    public int ReservationId { get; init; }
    public string Code { get; init; }
    public string TicketUrl { get; init; }
    public string Status { get; private set; }

    public void ChangeStatus()
    {
        Status = "";
    }
}