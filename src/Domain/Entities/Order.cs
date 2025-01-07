namespace Domain.Entities;

public class Order : BaseEntity
{
    public Order(int userId)
    {
        UserId = userId;
    }

    private Order()
    {
    }

    public string Status { get; private set; }
    public int UserId { get; init; }

    public Payment? Payment { get; }
    public int? PaymentId { get; init; }

    public void ChangeStatus()
    {
        Status = "";
    }
}