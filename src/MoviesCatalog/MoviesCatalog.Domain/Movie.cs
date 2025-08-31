using Shared;

namespace MoviesCatalog.Domain;

public class Movie : BaseEntity, IAggregateRoot
{
    public Movie(string title, Genre genre, TimeSpan duration, string? description = null)
    {
        Title = title;
        Genre = genre;
        Duration = duration;
        Description = description ?? string.Empty;
    }

    public string Title { get; init; }
    public string Slug { get; }
    public Genre Genre { get; init; }
    public TimeSpan Duration { get; init; }
    public string Description { get; set; }
    public DateTimeOffset? PublishedAt { get; private set; }

    public void Publish()
    {
        PublishedAt = DateTimeOffset.Now;
    }

    public void Unpublish()
    {
        PublishedAt = null;
    }
}