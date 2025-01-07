namespace Domain.Entities;

public class Seat : BaseEntity
{
    public Seat(int hallId, Row row, int number, SeatCategory category)
    {
        HallId = hallId;
        Row = row;
        Number = number;
        Category = category;
    }

    private Seat()
    {
    }

    public Row Row { get; private set; }
    public int Number { get; private set; }
    public SeatCategory Category { get; private set; }

    public int HallId { get; private set; }
}