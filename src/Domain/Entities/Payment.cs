namespace Domain.Entities;

public class Payment : BaseEntity
{
    public Payment(int orderId, string method, decimal amount)
    {
        OrderId = orderId;
        Method = method;
        Amount = amount;
    }

    private Payment()
    {
    }

    public string Method { get; private set; }
    public decimal Amount { get; private set; }

    public int OrderId { get; private set; }
}