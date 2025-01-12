namespace Domain.Entities;

public class PricingRule : BaseEntity, IAggregateRoot
{
    public PricingRule(SeatType seatType, decimal price)
    {
        SeatType = seatType;
        Price = price;
    }

    public SeatType SeatType { get; private set; }
    public decimal Price { get; private set; }

    // TODO: Later
    // public HallType HallType { get; set; }
}