namespace Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    public Order(int userId)
    {
        UserId = userId;
    }

    private Order()
    {
    }

    public OrderStatus Status { get; } = OrderStatus.Placed;
    public int UserId { get; init; }

    public Payment? Payment { get; }
    public int? PaymentId { get; init; }
}