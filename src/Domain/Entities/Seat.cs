namespace Domain.Entities;

public class Seat : BaseEntity
{
    public Seat(int hallId, string row, int number, string category)
    {
        HallId = hallId;
        Row = row;
        Number = number;
        Category = category;
    }

    private Seat()
    {
    }

    public int HallId { get; private set; }
    public string Row { get; private set; }
    public int Number { get; private set; }
    public string Category { get; private set; }
}