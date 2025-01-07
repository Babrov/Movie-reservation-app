namespace Domain.Entities;

public class Schedule : BaseEntity, IAggregateRoot
{
    public Schedule(int hallId)
    {
        HallId = hallId;
    }

    public DateOnly Date { get; set; }
    public int HallId { get; private set; }
}