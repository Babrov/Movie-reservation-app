using Shared;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public Payment(PaymentMethod method, decimal amount)
    {
        Method = method;
        Amount = amount;
    }

    private Payment()
    {
    }

    public PaymentMethod Method { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; set; }

    public int OrderId { get; }
}