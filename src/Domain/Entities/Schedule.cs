namespace Domain.Entities;

//TODO: Not sure if needed rn
// Could be useful for managing sessions
public class Schedule : BaseEntity, IAggregateRoot
{
    public Schedule(int hallId)
    {
        HallId = hallId;
    }

    public DateOnly Date { get; set; }
    public int HallId { get; private set; }
}