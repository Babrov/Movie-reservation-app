namespace Domain.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public Movie(string title, Genre genre, TimeSpan duration, string? description = null)
    {
        Title = title;
        Genre = genre;
        Duration = duration;
        Description = description ?? string.Empty;
    }

    public string Title { get; private set; }
    public Genre Genre { get; set; }
    public TimeSpan Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? PublishedAt { get; set; }
}