using Shared;

public abstract class ReservedSeat : BaseEntity
{
    public ReservedSeat(int sessionSeatId, decimal price)
    {
        SessionSeatId = sessionSeatId;
        Price = price;
    }

    public decimal Price { get; private set; }
    public int SessionSeatId { get; private set; }
    public int OrderId { get; init; }
}