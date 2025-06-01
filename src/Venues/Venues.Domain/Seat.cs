using Shared;

namespace Venues.Domain;

public class Seat : BaseEntity
{
    public Seat(int hallId, Row row, int number, SeatType type)
    {
        HallId = hallId;
        Row = row;
        Number = number;
        Type = type;
    }

    private Seat()
    {
    }

    public Row Row { get; private set; }
    public int Number { get; private set; }
    public SeatType Type { get; private set; }

    public int HallId { get; private set; }
}