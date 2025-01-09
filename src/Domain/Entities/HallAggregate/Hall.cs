namespace Domain.Entities;

public class Hall : BaseEntity, IAggregateRoot
{
    public HallType Type { get; set; }
}