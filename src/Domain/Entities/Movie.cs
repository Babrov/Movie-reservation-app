namespace Domain.Entities;

public class Movie : BaseEntity
{
    public Movie(string title, DateTimeOffset duration, string genre, string? description = null)
    {
        Title = title;
        Duration = duration;
        Genre = genre;
        Description = description ?? string.Empty;
    }

    public string Title { get; private set; }
    public string Description { get; set; } = string.Empty;
    public string Genre { get; set; }
    public DateTimeOffset Duration { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
}