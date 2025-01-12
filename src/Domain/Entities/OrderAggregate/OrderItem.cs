namespace Domain.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(int sessionSeatId, decimal price)
    {
        SessionSeatId = sessionSeatId;
        Price = price;
    }

    public decimal Price { get; private set; }
    public int SessionSeatId { get; private set; }
    public int OrderId { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}