namespace Domain.Entities;

public class Hall : BaseEntity, IAggregateRoot
{
    public Hall(HallType type)
    {
        Type = type;
    }

    public HallType Type { get; private set; }
}