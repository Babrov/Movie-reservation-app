using Domain.ValueObjects;

namespace Domain.Entities;

public class Session : BaseEntity
{
    public Session(int movieId, int hallId, ShowTime showTime)
    {
        MovieId = movieId;
        HallId = hallId;
        ShowTime = showTime;
    }

    public ShowTime ShowTime { get; private set; }
    public int MovieId { get; private set; }
    public int HallId { get; private set; }
}