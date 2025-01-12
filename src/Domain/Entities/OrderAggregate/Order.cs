namespace Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    private readonly List<OrderItem> items = new();

    public Order(int userId, IList<OrderItem> items)
    {
        UserId = userId;
        foreach (OrderItem item in items) AddItem(item);
    }

    private Order()
    {
    }

    public IReadOnlyCollection<OrderItem> Items => items.AsReadOnly();

    public OrderStatus Status { get; } = OrderStatus.Placed;
    public int UserId { get; init; }

    public int? PaymentId { get; init; }
    public Payment? Payment { get; }

    public void AddItem(OrderItem item)
    {
        items.Add(item);
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (OrderItem item in items) total += item.Price;
        return total;
    }
}