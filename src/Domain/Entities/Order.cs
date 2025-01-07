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

    public Payment? Payment { get; private set; }
    public int? PaymentId { get; init; }

    public void Cancel()
    {
    }

    public void Confirm()
    {
        if (Status == OrderStatus.Cancelled) throw new ArgumentException("Order is Cancelled");
    }

    public void AddPayment(Payment payment)
    {
        Payment = payment;
    }
}