namespace Domain.Entities;

public class SessionSeat : BaseEntity, IAggregateRoot
{
    public SessionSeat(int sessionId, int seatId)
    {
        SessionId = sessionId;
        SeatId = seatId;
    }

    private SessionSeat()
    {
    }

    public int SessionId { get; private set; }
    public int SeatId { get; private set; }
}